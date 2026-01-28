#:package Handlebars.Net@2.*
#:package Humanizer@3.*
#:package Microsoft.Extensions.FileSystemGlobbing@8.*
#:package Spectre.Console@0.*
#:package Spectre.Console.Cli@0.*
#:package YamlDotNet@16.*

#:property PublishAot=false
#:property PackAsTool=true
#:property PackageId=Microsoft.Learn.Automation.TestTool

using System.Text.RegularExpressions;
using HandlebarsDotNet;
using Humanizer;
using Microsoft.Extensions.FileSystemGlobbing;
using Microsoft.Extensions.FileSystemGlobbing.Abstractions;
using Spectre.Console;
using Spectre.Console.Cli;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

CommandApp<FileSearchCommand> app = new();

return await app.RunAsync(args);

/// <summary>
/// Main command that searches for markdown files, processes them by adding .md extensions to links,
/// and generates index files and hub pages for documentation navigation.
/// </summary>
partial class FileSearchCommand : AsyncCommand<FileSearchSettings>
{
    // Cache for parsed markdown file metadata to avoid redundant file reads
    private static readonly Dictionary<string, MetadataProperties?> _metadataCache = new(StringComparer.OrdinalIgnoreCase);

    // Reusable YAML deserializer instance for parsing YAML front matter in markdown files
    private static readonly IDeserializer _yamlDeserializer = new DeserializerBuilder()
        .WithNamingConvention(CamelCaseNamingConvention.Instance)
        .IgnoreUnmatchedProperties()
        .Build();

    /// <summary>
    /// Executes the main file search and processing workflow.
    /// This includes: searching for files, copying and processing markdown content,
    /// building directory metadata, and generating index files.
    /// </summary>
    /// <param name="context">The command context provided by Spectre.Console.Cli.</param>
    /// <param name="settings">Command-line settings including target path and output path.</param>
    /// <param name="cancellationToken">Cancellation token for async operations.</param>
    /// <returns>Exit code: 0 for success, 1 for errors.</returns>
    public override async Task<int> ExecuteAsync(CommandContext context, FileSearchSettings settings, CancellationToken cancellationToken)
    {
        if (!Directory.Exists(settings.TargetPath))
        {
            AnsiConsole.MarkupLine($"[red]Error: Target path '{settings.TargetPath}' does not exist.[/]");
            return 1;
        }

        DirectoryInfo directoryInfo = new(settings.TargetPath);

        // Search for files
        PatternMatchingResult regularMarkdownResults = SearchFiles(directoryInfo, includes: ["**/*.md"], excludes: ["**/_*.md"]);
        PatternMatchingResult metadataResults = SearchFiles(directoryInfo, includes: ["**/_metadata.*.md"]);

        AnsiConsole.MarkupLine("\n[bold blue]Article Files[/]");
        RenderResultsTable(regularMarkdownResults, settings.TargetPath);

        AnsiConsole.MarkupLine("\n[bold blue]Metadata Files (_metadata.*)[/]");
        RenderResultsTable(metadataResults, settings.TargetPath);

        AnsiConsole.WriteLine();
        RenderBarChart(
            ("Regular Markdown", regularMarkdownResults.Files.Count()),
            ("Metadata Files", metadataResults.Files.Count())
        );

        int totalCount = regularMarkdownResults.Files.Count() + metadataResults.Files.Count();
        AnsiConsole.MarkupLine($"\n[green]Files found![/] Total: [cyan]{totalCount}[/]");

        // Delete and recreate output directory
        if (Directory.Exists(settings.OutputPath))
        {
            AnsiConsole.MarkupLine($"[yellow]Deleting existing output directory...[/]");
            Directory.Delete(settings.OutputPath, recursive: true);
        }
        Directory.CreateDirectory(settings.OutputPath);
        AnsiConsole.MarkupLine($"\n[bold yellow]Processing files...[/]");

        // Copy markdown files and generate index files
        await ProcessFilesAsync(settings.TargetPath, settings.OutputPath, regularMarkdownResults, metadataResults, cancellationToken);

        AnsiConsole.MarkupLine($"\n[green]✓ Processing complete![/] Output: [cyan]{Path.GetFullPath(settings.OutputPath)}[/]");

        return 0;
    }

    /// <summary>
    /// Processes all markdown files by copying them to the output directory,
    /// fixing extensionless links, building directory metadata, and generating index files.
    /// </summary>
    /// <param name="sourcePath">The source directory containing the original markdown files.</param>
    /// <param name="outputPath">The destination directory for processed files.</param>
    /// <param name="markdownFiles">Pattern matching results for regular markdown files.</param>
    /// <param name="metadataFiles">Pattern matching results for _metadata.*.md files.</param>
    /// <param name="cancellationToken">Cancellation token for async operations.</param>
    private static async Task ProcessFilesAsync(
        string sourcePath,
        string outputPath,
        PatternMatchingResult markdownFiles,
        PatternMatchingResult metadataFiles,
        CancellationToken cancellationToken)
    {
        // Process all markdown files in parallel for better performance
        // Track how many files had links modified
        int processedLinks = 0;
        object lockObj = new(); // Lock for thread-safe counter increment

        await Parallel.ForEachAsync(markdownFiles.Files, cancellationToken, async (file, ct) =>
        {
            string sourceFile = Path.Combine(sourcePath, file.Path);
            string destFile = Path.Combine(outputPath, file.Path);
            string destDir = Path.GetDirectoryName(destFile)!;

            // Ensure destination directory exists before writing file
            Directory.CreateDirectory(destDir);

            // Read markdown content, process links to add .md extensions, then write to output
            string content = await File.ReadAllTextAsync(sourceFile, ct);
            string originalContent = content;
            content = ProcessMarkdownLinks(content); // Adds .md to extensionless relative links

            // Track files that had links modified for reporting
            if (content != originalContent)
            {
                lock (lockObj)
                {
                    processedLinks++;
                }
            }

            await File.WriteAllTextAsync(destFile, content, ct);
        });

        AnsiConsole.MarkupLine($"[green]✓[/] Copied {markdownFiles.Files.Count()} markdown files");
        AnsiConsole.MarkupLine($"[green]✓[/] Processed links in {processedLinks} file(s)");

        // Build directory structure with metadata
        Dictionary<string, MetadataProperties> directoryMetadata = BuildDirectoryMetadata(sourcePath, metadataFiles);
        Dictionary<string, List<FileProperties>> directoryContents = BuildDirectoryContents(sourcePath, markdownFiles);

        // Generate index files for each directory
        int indexCount = 0;
        int yamlCount = 0;
        // Normalize source path for consistent comparison across platforms
        string normalizedSourcePath = Path.GetFullPath(sourcePath);
        foreach (string dir in directoryContents.Keys.OrderBy(k => k))
        {
            string relativeDir = Path.GetRelativePath(sourcePath, dir);
            string outputDir = Path.Combine(outputPath, relativeDir);
            Directory.CreateDirectory(outputDir);

            MetadataProperties? metadata = directoryMetadata.GetValueOrDefault(dir);
            List<FileProperties> files = directoryContents[dir];

            // Determine if this is root or a category directory
            // Normalize both paths to ensure consistent comparison on Windows and Linux
            bool isRoot = Path.GetFullPath(dir).Equals(normalizedSourcePath, StringComparison.OrdinalIgnoreCase);

            if (isRoot)
            {
                // Generate YAML hub page for root
                string hubYaml = GenerateHubPage(dir, sourcePath, metadata, directoryMetadata, directoryContents);
                string indexPath = Path.Combine(outputDir, "index.yml");
                await File.WriteAllTextAsync(indexPath, hubYaml, cancellationToken);
                yamlCount++;
            }
            else
            {
                // Generate markdown index for subdirectories
                string indexContent = GenerateIndexFile(dir, sourcePath, metadata, files, directoryMetadata, directoryContents, isRoot);
                string indexPath = Path.Combine(outputDir, "index.md");
                await File.WriteAllTextAsync(indexPath, indexContent, cancellationToken);
            }

            indexCount++;
        }

        AnsiConsole.MarkupLine($"[green]✓[/] Generated {indexCount - yamlCount} markdown index files");
        AnsiConsole.MarkupLine($"[green]✓[/] Generated {yamlCount} YAML hub page");

        // Generate TOC.yml file at the root of the output directory
        string tocYaml = GenerateTocYaml(sourcePath, directoryMetadata, directoryContents);
        string tocPath = Path.Combine(outputPath, "TOC.yml");
        await File.WriteAllTextAsync(tocPath, tocYaml, cancellationToken);
        AnsiConsole.MarkupLine($"[green]✓[/] Generated TOC.yml");
    }

    /// <summary>
    /// Builds a dictionary mapping directories to their metadata properties.
    /// Reads _metadata.*.md files to extract titles and descriptions for each directory.
    /// </summary>
    /// <param name="sourcePath">The root source directory.</param>
    /// <param name="metadataFiles">Pattern matching results containing _metadata.*.md files.</param>
    /// <returns>Dictionary with directory paths as keys and metadata properties as values.</returns>
    private static Dictionary<string, MetadataProperties> BuildDirectoryMetadata(string sourcePath, PatternMatchingResult metadataFiles)
    {
        Dictionary<string, MetadataProperties> result = new(StringComparer.OrdinalIgnoreCase);

        foreach (FilePatternMatch file in metadataFiles.Files)
        {
            string fullPath = Path.GetFullPath(Path.Combine(sourcePath, file.Path));
            string directory = Path.GetDirectoryName(fullPath)!;

            // Metadata files contain plain text descriptions for their parent directory
            string description = File.ReadAllText(fullPath).Trim();

            // Generate a human-readable title from the directory name (e.g., "array-operators" -> "Array Operators")
            string dirName = Path.GetFileName(directory);
            string title = dirName.Humanize(LetterCasing.Title);

            result[directory] = new MetadataProperties { Title = title, Description = description };
        }

        return result;
    }

    /// <summary>
    /// Builds a comprehensive directory structure mapping each directory to its contained markdown files.
    /// Also ensures all parent directories are included in the result, even if empty.
    /// </summary>
    /// <param name="sourcePath">The root source directory.</param>
    /// <param name="markdownFiles">Pattern matching results containing all markdown files.</param>
    /// <returns>Dictionary with directory paths as keys and lists of file properties as values.</returns>
    private static Dictionary<string, List<FileProperties>> BuildDirectoryContents(string sourcePath, PatternMatchingResult markdownFiles)
    {
        // Normalize source path to absolute path for consistent comparisons across platforms
        string normalizedSourcePath = Path.GetFullPath(sourcePath);
        Dictionary<string, List<FileProperties>> result = new(StringComparer.OrdinalIgnoreCase);

        // First pass: Map each file to its parent directory
        foreach (FilePatternMatch file in markdownFiles.Files)
        {
            string fullPath = Path.GetFullPath(Path.Combine(sourcePath, file.Path));
            string directory = Path.GetDirectoryName(fullPath)!;

            if (!result.ContainsKey(directory))
            {
                result[directory] = [];
            }

            FileProperties fileProperties = new()
            {
                Path = fullPath,
                RelativePath = file.Path,
                Name = Path.GetFileNameWithoutExtension(fullPath),
                Directory = directory
            };

            result[directory].Add(fileProperties);
        }

        // Second pass: Ensure all parent directories exist in the result
        // This is important for generating index files at every level
        foreach (string dir in result.Keys.ToList())
        {
            DirectoryInfo current = new(dir);
            while (!string.Equals(current.FullName, normalizedSourcePath, StringComparison.OrdinalIgnoreCase) && current.Parent != null)
            {
                if (!result.ContainsKey(current.Parent.FullName))
                {
                    result[current.Parent.FullName] = [];
                }
                current = current.Parent;
            }

            if (!result.ContainsKey(normalizedSourcePath))
            {
                result[normalizedSourcePath] = [];
            }
        }

        return result;
    }

    /// <summary>
    /// Generates a YAML hub page for the root directory following the YamlMime:Hub format.
    /// Hub pages include highlighted content cards and conceptual content sections with links.
    /// This creates the main landing page for the documentation site.
    /// </summary>
    /// <param name="directory">The directory to generate the hub page for (typically root).</param>
    /// <param name="sourcePath">The root source directory.</param>
    /// <param name="metadata">Optional metadata for this directory.</param>
    /// <param name="allMetadata">All directory metadata for looking up subdirectory info.</param>
    /// <param name="allDirectoryContents">All directory contents for building navigation.</param>
    /// <returns>YAML-formatted hub page content.</returns>
    private static string GenerateHubPage(
        string directory,
        string sourcePath,
        MetadataProperties? metadata,
        Dictionary<string, MetadataProperties> allMetadata,
        Dictionary<string, List<FileProperties>> allDirectoryContents)
    {
        // Build highlighted content section - these appear as large cards at the top
        List<HighlightedContentItem> highlightedItems =
        [
            new() { Title = "Overview", ItemType = "overview", Url = "overview.md" },
            new() { Title = "DocumentDB OSS documentation", ItemType = "get-started", Url = "https://documentdb.io/docs" }
        ];

        // Get top-level directories (commands, operators, etc.) to build navigation structure
        // Normalize paths for consistent dictionary lookups across platforms
        string[] topLevelDirs = [.. Directory.GetDirectories(directory).Select(d => Path.GetFullPath(d)).OrderBy(d => d)];

        // Build conceptual content sections - these are collapsible sections with multiple cards
        List<ConceptualContentSection> conceptualSections = [];
        HashSet<string> noLocTerms = []; // Track terms that should not be localized

        foreach (string topDir in topLevelDirs)
        {
            string topDirName = Path.GetFileName(topDir);
            MetadataProperties? topMetadata = allMetadata.GetValueOrDefault(topDir);
            string sectionTitle = topMetadata?.Title ?? topDirName.Humanize(LetterCasing.Title);
            string sectionSummary = topMetadata?.Description ?? string.Empty;

            // Add type landing page to highlighted content
            string typeIndexPath = Path.GetRelativePath(directory, Path.Combine(topDir, "index.md")).Replace("\\", "/");
            highlightedItems.Add(new HighlightedContentItem { Title = sectionTitle, ItemType = "reference", Url = typeIndexPath });

            // Get subdirectories (categories within commands/operators)
            // Normalize paths for consistent dictionary lookups
            string[] categoryDirs = [.. Directory.GetDirectories(topDir).Select(d => Path.GetFullPath(d)).OrderBy(d => d)];

            List<ConceptualContentItem> sectionItems = [];

            foreach (string categoryDir in categoryDirs)
            {
                string categoryName = Path.GetFileName(categoryDir);
                MetadataProperties? categoryMetadata = allMetadata.GetValueOrDefault(categoryDir);
                string cardTitle = categoryMetadata?.Title ?? categoryName.Humanize(LetterCasing.Title);
                string cardSummary = categoryMetadata?.Description ?? string.Empty;

                // Get files in this category
                List<FileProperties> categoryFiles = allDirectoryContents.GetValueOrDefault(categoryDir) ?? [];

                List<ContentLink> links = [];

                // Add up to 18 file links (hub page limit)
                foreach (FileProperties file in categoryFiles.OrderBy(f => f.Name).Take(12))
                {
                    MetadataProperties? fileMetadata = ParseMarkdownFile(file.Path);
                    string relativePath = Path.GetRelativePath(directory, file.Path).Replace("\\", "/");
                    string linkText = fileMetadata?.Title ?? file.Name.Humanize(LetterCasing.Title);

                    // Add the name/title to no-loc terms
                    noLocTerms.Add(linkText);

                    links.Add(new ContentLink { Text = linkText, ItemType = "reference", Url = relativePath });
                }

                // Add footer link if there are more files
                LightContentLink? footerLinkObj = null;
                if (categoryFiles.Count > 18 || links.Count > 0)
                {
                    string categoryRelativePath = Path.GetRelativePath(directory, categoryDir).Replace("\\", "/");
                    footerLinkObj = new LightContentLink { Text = "See more", Url = $"{categoryRelativePath}/index.md" };
                }

                if (links.Count > 0)
                {
                    sectionItems.Add(new ConceptualContentItem()
                    {
                        Title = cardTitle,
                        Links = links,
                        Summary = string.IsNullOrEmpty(cardSummary) ? null : cardSummary,
                        FooterLink = footerLinkObj
                    });
                }
            }

            if (sectionItems.Count > 0)
            {
                conceptualSections.Add(new ConceptualContentSection()
                {
                    Title = sectionTitle,
                    Items = [.. sectionItems.Take(18)], // Enforce 18 item limit
                    Summary = string.IsNullOrEmpty(sectionSummary) ? null : sectionSummary
                });
            }
        }

        // Build hub page record
        HubPage hubPage = new()
        {
            Title = "Query language for DocumentDB (in Azure) documentation",
            Summary = "Learn about the open-source DocumentDB platform and the MongoDB Query Language (MQL) used by Azure DocumentDB. Build modern MongoDB-compatible applications with familiar MQL syntax.",
            Brand = "sql",
            Metadata = new HubMetadata()
            {
                Title = "Query Language for DocumentDB (in Azure) Documentation",
                Summary = "Learn about the open-source DocumentDB platform and the MongoDB Query Language (MQL) used by Azure DocumentDB. Build modern MongoDB-compatible applications with familiar MQL syntax.",
                MsTopic = "hub-page",
                AiUsage = "ai-generated",
                NoLoc = [.. noLocTerms.OrderBy(t => t)]
            },
            HighlightedContent = new HighlightedContent() { Items = highlightedItems },
            ConceptualContent = conceptualSections.Count > 0 ? new ConceptualContent() { Sections = conceptualSections } : null
        };

        ISerializer serializer = new SerializerBuilder()
            .WithIndentedSequences()
            .WithNamingConvention(CamelCaseNamingConvention.Instance)
            .ConfigureDefaultValuesHandling(DefaultValuesHandling.OmitNull | DefaultValuesHandling.OmitEmptyCollections)
            .Build();

        string yaml = serializer.Serialize(hubPage);

        // Add YamlMime:Hub prefix as required by Microsoft Learn
        return $"### YamlMime:Hub{Environment.NewLine}{yaml}";
    }

    /// <summary>
    /// Generates a markdown index file for a directory, listing all contained files in tables.
    /// The structure varies based on directory level: root and type directories group by subdirectory,
    /// while category directories show a simple flat list.
    /// </summary>
    /// <param name="directory">The directory to generate an index for.</param>
    /// <param name="sourcePath">The root source directory.</param>
    /// <param name="metadata">Optional metadata for this directory.</param>
    /// <param name="files">List of files directly in this directory.</param>
    /// <param name="allMetadata">All directory metadata for looking up subdirectory info.</param>
    /// <param name="allDirectoryContents">All directory contents for building grouped lists.</param>
    /// <param name="isRoot">Whether this is the root directory.</param>
    /// <returns>Markdown-formatted index page content.</returns>
    private static string GenerateIndexFile(
        string directory,
        string sourcePath,
        MetadataProperties? metadata,
        List<FileProperties> files,
        Dictionary<string, MetadataProperties> allMetadata,
        Dictionary<string, List<FileProperties>> allDirectoryContents,
        bool isRoot)
    {
        // Extract directory information and generate human-readable titles
        string dirName = directory == sourcePath ? "Root" : Path.GetFileName(directory);
        string title = metadata?.Title ?? dirName.Humanize(LetterCasing.Title);
        string description = metadata?.Description ?? string.Empty;
        string heading = dirName.Humanize(LetterCasing.Sentence);

        // Extract type and category from path structure (e.g., "commands/array" -> type="commands", category="array")
        string relativePath = Path.GetRelativePath(sourcePath, directory);
        string[] pathParts = relativePath.Split(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
        string? type = pathParts.Length > 0 && pathParts[0] != "." ? pathParts[0] : null;
        string? category = pathParts.Length > 1 ? pathParts[1] : null;

        // For category landing pages, append the type name to provide context
        if (!isRoot && !string.IsNullOrEmpty(type) && !string.IsNullOrEmpty(category))
        {
            string typeSuffix = type.Humanize(LetterCasing.Title);
            title = $"{title} - {typeSuffix}";
            heading = $"{heading} - {type}";
        }

        List<object> sections = [];

        // Root and type-level directories (commands, operators) get grouped sections by subdirectory
        if (isRoot || IsCommandsOrOperatorsDirectory(directory))
        {
            // Group by subdirectories for root and commands/operators folders
            // Normalize paths for consistent dictionary lookups across platforms
            string[] subdirs = Directory.GetDirectories(directory).Select(d => Path.GetFullPath(d)).ToArray();

            foreach (string subdir in subdirs.OrderBy(d => d))
            {
                string subdirName = Path.GetFileName(subdir);
                MetadataProperties? subdirMetadata = allMetadata.GetValueOrDefault(subdir);
                string subdirTitle = subdirMetadata?.Title ?? subdirName.Humanize(LetterCasing.Title);
                string subdirDescription = subdirMetadata?.Description ?? string.Empty;

                // Get all markdown files in this subdirectory for the table
                List<FileProperties> subdirFiles = allDirectoryContents.GetValueOrDefault(subdir) ?? [];

                List<object> fileItems = [.. subdirFiles.OrderBy(f => f.Name).Select(file =>
                {
                    MetadataProperties? fileMetadata = ParseMarkdownFile(file.Path);
                    string relativePath = Path.GetRelativePath(directory, file.Path).Replace("\\", "/");
                    return new
                    {
                        name = fileMetadata?.Title ?? file.Name.Humanize(LetterCasing.Title),
                        link = relativePath,
                        description = fileMetadata?.Description ?? string.Empty
                    };
                }).Cast<object>()];

                if (fileItems.Count != 0)
                {
                    sections.Add(new
                    {
                        title = subdirTitle,
                        description = subdirDescription,
                        files = fileItems
                    });
                }
            }

            // Handle files that are directly in this directory (not in subdirectories)
            List<FileProperties> directFiles = [.. files.Where(f => Path.GetDirectoryName(f.Path) == directory)];
            if (directFiles.Any())
            {
                List<object> fileItems = [.. directFiles.OrderBy(f => f.Name).Select(file =>
                {
                    MetadataProperties? fileMetadata = ParseMarkdownFile(file.Path);
                    string relativePath = Path.GetRelativePath(directory, file.Path).Replace("\\", "/");
                    return new
                    {
                        name = fileMetadata?.Title ?? file.Name.Humanize(LetterCasing.Title),
                        link = relativePath,
                        description = fileMetadata?.Description ?? string.Empty
                    };
                }).Cast<object>()];

                sections.Add(new
                {
                    title = "Other",
                    description = string.Empty,
                    files = fileItems
                });
            }
        }
        else
        {
            // Category directories get a simple flat table of all files
            if (files.Any())
            {
                List<object> fileItems = [.. files.OrderBy(f => f.Name).Select(file =>
                {
                    MetadataProperties? fileMetadata = ParseMarkdownFile(file.Path);
                    string relativePath = Path.GetRelativePath(directory, file.Path).Replace("\\", "/");
                    return new
                    {
                        name = fileMetadata?.Title ?? file.Name.Humanize(LetterCasing.Title),
                        link = relativePath,
                        description = fileMetadata?.Description ?? string.Empty
                    };
                }).Cast<object>()];

                sections.Add(new
                {
                    title = string.Empty,
                    description = string.Empty,
                    files = fileItems
                });
            }
        }

        // Use Handlebars template
        IHandlebars handlebars = Handlebars.Create();
        HandlebarsTemplate<object, object> template = handlebars.Compile(GetIndexTemplate());

        return template(new
        {
            title,
            description,
            heading,
            hasDescription = !string.IsNullOrEmpty(description),
            type,
            category,
            hasType = !string.IsNullOrEmpty(type),
            hasCategory = !string.IsNullOrEmpty(category),
            sections
        });
    }

    /// <summary>
    /// Returns the Handlebars template for generating markdown index files.
    /// Template includes YAML front matter and markdown tables for file listings.
    /// </summary>
    /// <returns>Handlebars template string.</returns>
    private static string GetIndexTemplate()
    {
        return @"---
title: {{title}}{{#if hasDescription}}
description: {{description}}{{/if}}{{#if hasType}}
type: {{type}}{{/if}}{{#if hasCategory}}
category: {{category}}{{/if}}
---

# {{heading}}
{{#if hasDescription}}

{{description}}
{{/if}}
{{#each sections}}
{{#if title}}

## {{title}}
{{#if description}}

{{description}}
{{/if}}
{{/if}}
{{#if files}}

| | Description |
| --- | --- |
{{#each files}}
| [**`{{name}}`**]({{link}}) | {{description}} |
{{/each}}
{{/if}}
{{/each}}";
    }

    /// <summary>
    /// Generates a YAML table of contents for the root directory following the YamlMime:TOC format.
    /// Generates a TOC.yml file following the DocFX format.
    /// The TOC structure mirrors the folder hierarchy with nested items.
    /// </summary>
    /// <param name="sourcePath">The root source directory.</param>
    /// <param name="allMetadata">All directory metadata for looking up titles.</param>
    /// <param name="allDirectoryContents">All directory contents for building the TOC structure.</param>
    /// <returns>YAML-formatted TOC content compatible with DocFX.</returns>
    private static string GenerateTocYaml(
        string sourcePath,
        Dictionary<string, MetadataProperties> allMetadata,
        Dictionary<string, List<FileProperties>> allDirectoryContents)
    {
        string normalizedSourcePath = Path.GetFullPath(sourcePath);

        // Build the root TOC items list
        List<TocItem> rootItems = [];

        // Add required Overview entry as the first item (per Microsoft Learn TOC requirements)
        rootItems.Add(new TocItem
        {
            Name = "Overview",
            DisplayName = "introduction, welcome, start, getting started",
            Href = "overview.md"
        });

        // Add remaining root-level files (excluding overview.md which is already added)
        if (allDirectoryContents.TryGetValue(normalizedSourcePath, out List<FileProperties>? rootFiles))
        {
            foreach (FileProperties file in rootFiles.OrderBy(f => f.Name))
            {
                // Skip overview.md since it's already added as the first entry
                if (file.Name.Equals("overview", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                MetadataProperties? fileMetadata = ParseMarkdownFile(file.Path);
                string relativePath = file.RelativePath.Replace("\\", "/");
                rootItems.Add(new TocItem
                {
                    Name = fileMetadata?.Title ?? file.Name.Humanize(LetterCasing.Title),
                    Href = relativePath
                });
            }
        }

        // Get top-level directories and build nested TOC structure
        // Only include directories that have actual content (files or subdirectories with files)
        string[] topLevelDirs = [.. Directory.GetDirectories(sourcePath).Select(d => Path.GetFullPath(d)).OrderBy(d => d)];

        foreach (string topDir in topLevelDirs)
        {
            // Skip directories that have no content (no files in this dir or any subdirectory)
            if (!HasContentInDirectoryTree(topDir, allDirectoryContents))
            {
                continue;
            }

            TocItem topLevelItem = BuildTocItemForDirectory(topDir, sourcePath, allMetadata, allDirectoryContents);
            rootItems.Add(topLevelItem);
        }

        // Serialize to YAML
        ISerializer serializer = new SerializerBuilder()
            .WithIndentedSequences()
            .WithNamingConvention(CamelCaseNamingConvention.Instance)
            .ConfigureDefaultValuesHandling(DefaultValuesHandling.OmitNull | DefaultValuesHandling.OmitEmptyCollections)
            .Build();

        // Serialize directly as items list with wrapper object
        TocRoot tocRoot = new() { Items = rootItems };
        string yaml = serializer.Serialize(tocRoot);

        // Add YamlMime:TOC prefix as required by Microsoft Learn
        return $"### YamlMime:TOC{Environment.NewLine}{yaml}";
    }

    /// <summary>
    /// Recursively builds a TOC item for a directory, including all nested subdirectories and files.
    /// </summary>
    /// <param name="directory">The directory to build a TOC item for.</param>
    /// <param name="sourcePath">The root source directory.</param>
    /// <param name="allMetadata">All directory metadata for looking up titles.</param>
    /// <param name="allDirectoryContents">All directory contents for building nested items.</param>
    /// <returns>A TocItem representing the directory and its contents.</returns>
    private static TocItem BuildTocItemForDirectory(
        string directory,
        string sourcePath,
        Dictionary<string, MetadataProperties> allMetadata,
        Dictionary<string, List<FileProperties>> allDirectoryContents)
    {
        string dirName = Path.GetFileName(directory);
        MetadataProperties? dirMetadata = allMetadata.GetValueOrDefault(directory);
        string title = dirMetadata?.Title ?? dirName.Humanize(LetterCasing.Title);
        string relativeDir = Path.GetRelativePath(sourcePath, directory).Replace("\\", "/");

        List<TocItem> childItems = [];

        // Only add Overview entry if this directory has files (meaning index.md will be generated)
        bool hasFilesInThisDir = allDirectoryContents.ContainsKey(directory);
        if (hasFilesInThisDir)
        {
            string indexPath = $"{relativeDir}/index.md";
            childItems.Add(new TocItem
            {
                Name = "Overview",
                Href = indexPath
            });
        }

        // Add files directly in this directory
        if (allDirectoryContents.TryGetValue(directory, out List<FileProperties>? dirFiles))
        {
            foreach (FileProperties file in dirFiles.OrderBy(f => f.Name))
            {
                MetadataProperties? fileMetadata = ParseMarkdownFile(file.Path);
                string relativePath = file.RelativePath.Replace("\\", "/");
                childItems.Add(new TocItem
                {
                    Name = fileMetadata?.Title ?? file.Name.Humanize(LetterCasing.Title),
                    Href = relativePath
                });
            }
        }

        // Recursively add subdirectories that have content
        string[] subdirs = Directory.GetDirectories(directory).Select(d => Path.GetFullPath(d)).OrderBy(d => d).ToArray();
        foreach (string subdir in subdirs)
        {
            // Skip subdirectories that have no content
            if (!HasContentInDirectoryTree(subdir, allDirectoryContents))
            {
                continue;
            }

            TocItem subdirItem = BuildTocItemForDirectory(subdir, sourcePath, allMetadata, allDirectoryContents);
            childItems.Add(subdirItem);
        }

        return new TocItem
        {
            Name = title,
            Items = childItems.Count > 0 ? childItems : null
        };
    }

    /// <summary>
    /// Checks if a directory or any of its subdirectories contain actual content files.
    /// Used to filter out empty directories from TOC generation.
    /// </summary>
    /// <param name="directory">The directory to check.</param>
    /// <param name="allDirectoryContents">Dictionary mapping directories to their file contents.</param>
    /// <returns>True if the directory or any subdirectory has files; false otherwise.</returns>
    private static bool HasContentInDirectoryTree(string directory, Dictionary<string, List<FileProperties>> allDirectoryContents)
    {
        // Check if this directory has files
        if (allDirectoryContents.ContainsKey(directory))
        {
            return true;
        }

        // Recursively check subdirectories
        foreach (string subdir in Directory.GetDirectories(directory))
        {
            if (HasContentInDirectoryTree(Path.GetFullPath(subdir), allDirectoryContents))
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Determines if a directory is a "commands" or "operators" type directory.
    /// These directories receive special grouping treatment in index generation.
    /// </summary>
    /// <param name="directory">The directory path to check.</param>
    /// <returns>True if the directory name contains "command" or "operator".</returns>
    private static bool IsCommandsOrOperatorsDirectory(string directory)
    {
        string dirName = Path.GetFileName(directory).ToLowerInvariant();
        return dirName.Contains("command") || dirName.Contains("operator");
    }

    /// <summary>
    /// Parses YAML front matter from a markdown file to extract metadata (title, description).
    /// Results are cached to avoid redundant file reads.
    /// </summary>
    /// <param name="filePath">The full path to the markdown file.</param>
    /// <returns>Metadata properties if found, null if file doesn't exist, or empty metadata if no front matter.</returns>
    private static MetadataProperties? ParseMarkdownFile(string filePath)
    {
        // Check cache first to avoid redundant file I/O
        if (_metadataCache.TryGetValue(filePath, out MetadataProperties? cached))
        {
            return cached;
        }

        if (!File.Exists(filePath))
        {
            _metadataCache[filePath] = null;
            return null;
        }

        string content = File.ReadAllText(filePath);
        Match match = YamlFrontMatterRegex().Match(content); // Match YAML between --- delimiters

        MetadataProperties? result;
        if (match.Success)
        {
            string yaml = match.Groups[1].Value;
            try
            {
                result = _yamlDeserializer.Deserialize<MetadataProperties>(yaml) ?? new MetadataProperties();
            }
            catch
            {
                result = new MetadataProperties();
            }
        }
        else
        {
            result = new MetadataProperties();
        }

        _metadataCache[filePath] = result;
        return result;
    }

    /// <summary>
    /// Searches for files matching glob patterns within a directory.
    /// Supports include and exclude patterns for flexible file filtering.
    /// </summary>
    /// <param name="directoryInfo">The directory to search in.</param>
    /// <param name="includes">Array of glob patterns for files to include (e.g., "**/*.md").</param>
    /// <param name="excludes">Optional array of glob patterns for files to exclude.</param>
    /// <returns>Pattern matching result containing matched files.</returns>
    private static PatternMatchingResult SearchFiles(DirectoryInfo directoryInfo, string[] includes, string[]? excludes = null)
    {
        Matcher matcher = new();
        matcher.AddIncludePatterns(includes);
        if (excludes != null)
        {
            matcher.AddExcludePatterns(excludes);
        }
        return matcher.Execute(new DirectoryInfoWrapper(directoryInfo));
    }

    /// <summary>
    /// Processes markdown content to append .md extensions to extensionless relative links.
    /// Preserves absolute URLs, fragment identifiers (#section), and query strings (?param=value).
    /// Skips links that already have common file extensions.
    /// </summary>
    /// <param name="content">The markdown content to process.</param>
    /// <returns>Processed markdown content with .md extensions added to relative links.</returns>
    private static string ProcessMarkdownLinks(string content)
    {
        return MarkdownLinkRegex().Replace(content, match =>
        {
            string linkText = match.Groups[1].Value;
            string linkUrl = match.Groups[2].Value;

            // Skip absolute URLs - they don't need .md extensions
            if (linkUrl.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ||
                linkUrl.StartsWith("https://", StringComparison.OrdinalIgnoreCase) ||
                linkUrl.StartsWith("mailto:", StringComparison.OrdinalIgnoreCase) ||
                linkUrl.StartsWith("ftp://", StringComparison.OrdinalIgnoreCase))
            {
                return match.Value;
            }

            // Separate the base path from fragment identifiers (#section) and query strings (?param=value)
            // This allows us to add .md before the fragment/query: "page#section" -> "page.md#section"
            int fragmentIndex = linkUrl.IndexOf('#');
            int queryIndex = linkUrl.IndexOf('?');
            int separatorIndex = fragmentIndex >= 0 && queryIndex >= 0
                ? Math.Min(fragmentIndex, queryIndex)
                : Math.Max(fragmentIndex, queryIndex);

            string basePath = separatorIndex >= 0 ? linkUrl[..separatorIndex] : linkUrl;
            string suffix = separatorIndex >= 0 ? linkUrl[separatorIndex..] : string.Empty;

            // Skip links that already have common file extensions or are empty (anchor-only links)
            if (basePath.EndsWith(".md", StringComparison.OrdinalIgnoreCase) ||
                basePath.EndsWith(".yml", StringComparison.OrdinalIgnoreCase) ||
                basePath.EndsWith(".yaml", StringComparison.OrdinalIgnoreCase) ||
                basePath.EndsWith(".html", StringComparison.OrdinalIgnoreCase) ||
                basePath.EndsWith(".htm", StringComparison.OrdinalIgnoreCase) ||
                string.IsNullOrEmpty(basePath))
            {
                return match.Value;
            }

            // Append .md to relative extensionless links, preserving fragments/queries
            return $"[{linkText}]({basePath}.md{suffix})";
        });
    }

    /// <summary>
    /// Renders a formatted table displaying file search results with file paths and sizes.
    /// Includes a total row summarizing the count of files found.
    /// </summary>
    /// <param name="results">Pattern matching results containing found files.</param>
    /// <param name="basePath">Base path for resolving full file paths.</param>
    private static void RenderResultsTable(PatternMatchingResult results, string basePath)
    {
        Table table = new Table()
            .Border(TableBorder.Rounded)
            .BorderColor(Color.Blue)
            .AddColumn(new TableColumn("[yellow]#[/]").RightAligned())
            .AddColumn(new TableColumn("[yellow]File Path[/]").LeftAligned())
            .AddColumn(new TableColumn("[yellow]Size (KB)[/]").RightAligned());

        int count = 0;
        foreach (FilePatternMatch file in results.Files)
        {
            count++;
            string fullPath = Path.Combine(basePath, file.Path);
            FileInfo fileInfo = new(fullPath);
            double sizeKB = fileInfo.Length / 1024.0;

            table.AddRow(
                $"[cyan]{count}[/]",
                $"[white]{file.Path}[/]",
                $"[green]{sizeKB:F2}[/]"
            );
        }

        // Add separator and total row
        if (count > 0)
        {
            table.AddEmptyRow();
            table.AddRow(
                $"[bold yellow]Total:[/]",
                $"[bold yellow]{count} file(s) found[/]",
                $"[bold yellow]-[/]"
            );
        }
        else
        {
            table.AddRow(
                $"[dim]-[/]",
                $"[dim]No files found[/]",
                $"[dim]-[/]"
            );
        }

        AnsiConsole.Write(table);
    }

    /// <summary>
    /// Renders a bar chart showing the distribution of different file types.
    /// Color-codes bars based on file type (green for regular, yellow for metadata).
    /// </summary>
    /// <param name="data">Array of tuples containing labels and counts for each category.</param>
    private static void RenderBarChart(params (string Label, int Count)[] data)
    {
        BarChart chart = new BarChart()
            .Width(60)
            .Label("[bold underline]File Type Distribution[/]")
            .CenterLabel();

        foreach ((string label, int count) in data)
        {
            if (count > 0)
            {
                chart.AddItem(label, count, count switch
                {
                    _ when label.Contains("Regular") => Color.Green,
                    _ when label.Contains("Metadata") => Color.Yellow,
                    _ => Color.Grey
                });
            }
        }

        AnsiConsole.Write(chart);
    }

    /// <summary>
    /// Source-generated regex for matching YAML front matter in markdown files.
    /// Matches content between --- delimiters at the start of a file.
    /// </summary>
    [GeneratedRegex(@"^---\s*\n(.*?)\n---", System.Text.RegularExpressions.RegexOptions.Singleline)]
    private static partial Regex YamlFrontMatterRegex();

    /// <summary>
    /// Source-generated regex for matching markdown link syntax: [text](url).
    /// Used to find and modify links in markdown content.
    /// </summary>
    [GeneratedRegex(@"\[([^\]]+)\]\(([^)]+?)\)", System.Text.RegularExpressions.RegexOptions.Multiline)]
    private static partial Regex MarkdownLinkRegex();
}

/// <summary>
/// Command-line settings for the file search and processing command.
/// </summary>
internal class FileSearchSettings : CommandSettings
{
    /// <summary>
    /// The target directory path containing source markdown files to process.
    /// </summary>
    [CommandArgument(0, "<TARGET_PATH>")]
    public string TargetPath { get; init; } = string.Empty;

    /// <summary>
    /// The output directory path where processed files will be written. Defaults to "out".
    /// </summary>
    [CommandOption("-o|--output <OUTPUT_PATH>")]
    public string OutputPath { get; init; } = "out";
}

/// <summary>
/// Represents a YamlMime:Hub page for the documentation root.
/// Hub pages provide a visual landing page with highlighted content and categorized sections.
/// </summary>
record HubPage
{
    /// <summary>
    /// The main title displayed on the hub page.
    /// </summary>
    public required string Title { get; init; }

    /// <summary>
    /// A brief summary describing the hub page content.
    /// </summary>
    public required string Summary { get; init; }

    /// <summary>
    /// The brand identifier for styling (e.g., "sql", "azure").
    /// </summary>
    public required string Brand { get; init; }

    /// <summary>
    /// Metadata properties for the hub page including SEO and localization settings.
    /// </summary>
    public required HubMetadata Metadata { get; init; }

    /// <summary>
    /// Collection of highlighted content items displayed as prominent cards.
    /// </summary>
    public required HighlightedContent HighlightedContent { get; init; }

    /// <summary>
    /// Optional conceptual content sections with categorized links.
    /// </summary>
    public ConceptualContent? ConceptualContent { get; init; }
}

/// <summary>
/// Metadata properties for a hub page, including SEO and localization settings.
/// </summary>
record HubMetadata
{
    /// <summary>
    /// The metadata title used for SEO purposes.
    /// </summary>
    public required string Title { get; init; }

    /// <summary>
    /// The metadata summary/description used for SEO purposes.
    /// </summary>
    public required string Summary { get; init; }

    /// <summary>
    /// The Microsoft topic type (e.g., "hub-page", "conceptual").
    /// </summary>
    [YamlMember(Alias = "ms.topic")]
    public required string MsTopic { get; init; }

    /// <summary>
    /// Indicates AI usage in content generation (e.g., "ai-generated", "ai-assisted").
    /// </summary>
    [YamlMember(Alias = "ai-usage")]
    public required string AiUsage { get; init; }

    /// <summary>
    /// List of terms that should not be localized/translated.
    /// </summary>
    [YamlMember(Alias = "no-loc")]
    public required List<string> NoLoc { get; init; }
}

/// <summary>
/// Container for highlighted content items displayed prominently on hub pages.
/// </summary>
record HighlightedContent
{
    /// <summary>
    /// Collection of highlighted content items.
    /// </summary>
    public required List<HighlightedContentItem> Items { get; init; }
}

/// <summary>
/// Represents a single highlighted content card on a hub page.
/// </summary>
record HighlightedContentItem
{
    /// <summary>
    /// The display title for the highlighted item.
    /// </summary>
    public required string Title { get; init; }

    /// <summary>
    /// The type of item (e.g., "overview", "get-started", "reference").
    /// </summary>
    public required string ItemType { get; init; }

    /// <summary>
    /// The URL or relative path this item links to.
    /// </summary>
    public required string Url { get; init; }
}

/// <summary>
/// Container for conceptual content sections on a hub page.
/// </summary>
record ConceptualContent
{
    /// <summary>
    /// Collection of conceptual content sections.
    /// </summary>
    public required List<ConceptualContentSection> Sections { get; init; }
}

/// <summary>
/// Represents a section within conceptual content, grouping related items.
/// </summary>
record ConceptualContentSection
{
    /// <summary>
    /// The section title displayed as a heading.
    /// </summary>
    public required string Title { get; init; }

    /// <summary>
    /// Collection of content items within this section.
    /// </summary>
    public required List<ConceptualContentItem> Items { get; init; }

    /// <summary>
    /// Optional summary text describing the section.
    /// </summary>
    public string? Summary { get; init; }
}

/// <summary>
/// Represents a content card within a conceptual content section.
/// </summary>
record ConceptualContentItem
{
    /// <summary>
    /// The card title.
    /// </summary>
    public required string Title { get; init; }

    /// <summary>
    /// Collection of links displayed within this card.
    /// </summary>
    public required List<ContentLink> Links { get; init; }

    /// <summary>
    /// Optional summary text for the card.
    /// </summary>
    public string? Summary { get; init; }

    /// <summary>
    /// Optional footer link (e.g., "See more") at the bottom of the card.
    /// </summary>
    public LightContentLink? FooterLink { get; init; }
}

/// <summary>
/// Represents a simple link with text and URL, used for footer links.
/// </summary>
record LightContentLink
{
    /// <summary>
    /// The display text for the link.
    /// </summary>
    public required string Text { get; init; }

    /// <summary>
    /// The URL or relative path this link points to.
    /// </summary>
    public required string Url { get; init; }
}

/// <summary>
/// Represents a content link with text, type, and URL.
/// </summary>
record ContentLink
{
    /// <summary>
    /// The display text for the link.
    /// </summary>
    public required string Text { get; init; }

    /// <summary>
    /// The type of item (e.g., "reference", "concept", "tutorial").
    /// </summary>
    public required string ItemType { get; init; }

    /// <summary>
    /// The URL or relative path this link points to.
    /// </summary>
    public required string Url { get; init; }
}

/// <summary>
/// Represents metadata properties extracted from markdown file YAML front matter.
/// </summary>
record MetadataProperties
{
    /// <summary>
    /// The title of the document.
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    /// The description/summary of the document.
    /// </summary>
    public string? Description { get; set; }
}

/// <summary>
/// Represents properties of a markdown file in the documentation structure.
/// </summary>
record FileProperties
{
    /// <summary>
    /// The absolute path to the file.
    /// </summary>
    public required string Path { get; init; }

    /// <summary>
    /// The path relative to the source root directory.
    /// </summary>
    public required string RelativePath { get; init; }

    /// <summary>
    /// The file name without extension.
    /// </summary>
    public required string Name { get; init; }

    /// <summary>
    /// The directory containing this file.
    /// </summary>
    public required string Directory { get; init; }
}

/// <summary>
/// Represents a YamlMime:TOC file for the documentation root.
/// Represents the root structure of a TOC.yml file for DocFX-compatible documentation.
/// </summary>
record TocRoot
{
    /// <summary>
    /// The root collection of TOC items.
    /// </summary>
    public required List<TocItem> Items { get; init; }
}

/// <summary>
/// Represents a TOC (Table of Contents) item for DocFX-compatible TOC.yml generation.
/// </summary>
record TocItem
{
    /// <summary>
    /// Display name for the TOC entry. When not specified, the title from the referenced file is used.
    /// </summary>
    public string? Name { get; init; }

    /// <summary>
    /// Alternative display names for search and discoverability (comma-separated keywords).
    /// </summary>
    public string? DisplayName { get; init; }

    /// <summary>
    /// Path to the file or directory this TOC entry links to.
    /// </summary>
    public string? Href { get; init; }

    /// <summary>
    /// Child TOC items nested under this entry.
    /// </summary>
    public List<TocItem>? Items { get; init; }
}