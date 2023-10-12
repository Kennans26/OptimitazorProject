using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter a directory path:");
        string directoryPath = Console.ReadLine();

        if (Directory.Exists(directoryPath))
        {
            CleanEmptyFolders(directoryPath);

            CreateCategoryFolders(directoryPath);

            OrganizeFiles(directoryPath);

            CleanEmptyFolders(directoryPath);

            Console.WriteLine("Directory optimization complete.");
        }
        else
        {
            Console.WriteLine("Directory not found.");
        }
    }

    static void CleanEmptyFolders(string directoryPath)
    {
        string[] subdirectories = Directory.GetDirectories(directoryPath);
        foreach (string subdirectory in subdirectories)
        {
            if (Directory.GetFiles(subdirectory).Length == 0 && Directory.GetDirectories(subdirectory).Length == 0)
            {
                Directory.Delete(subdirectory);
            }
        }
    }

    static void CreateCategoryFolders(string directoryPath)
    {
        List<string> categories = new List<string>
        {
            "Audio", "Compressed", "Disc and media", "Data and database", "E-mail",
            "Executable", "Font", "Image", "Internet-related", "Presentation", "Programming",
            "Spreadsheet", "System related", "Video file", "Word processor and text"
        };

        foreach (string category in categories)
        {
            Directory.CreateDirectory(Path.Combine(directoryPath, category));
        }
    }

    static void OrganizeFiles(string directoryPath)
    {
        string[] files = Directory.GetFiles(directoryPath);
        foreach (string file in files)
        {
            string extension = Path.GetExtension(file)?.ToLower();

            if (extension != null)
            {
                string category = GetCategory(extension);

                if (!string.IsNullOrEmpty(category))
                {
                    string destinationPath = Path.Combine(directoryPath, category, Path.GetFileName(file));
                    File.Move(file, destinationPath);
                }
            }
        }
    }

    static string GetCategory(string extension)
    {
        switch (extension)
        {
            case ".aif":
            case ".cda":
            case ".mid":
            case ".midi":
            case ".mp3":
            case ".mpa":
            case ".ogg":
            case ".wav":
            case ".wma":
            case ".wpl":
                return "Audio";

            case ".7z":
            case ".arj":
            case ".deb":
            case ".pkg":
            case ".rar":
            case ".rpm":
            case ".tar.gz":
            case ".z":
            case ".zip":
                return "Compressed";

            case ".bin":
            case ".dmg":
            case ".iso":
            case ".toast":
            case ".vcd":
                return "Disc and media";

            case ".csv":
            case ".dat":
            case ".db":
            case ".dbf":
            case ".log":
            case ".mdb":
            case ".sav":
            case ".sql":
            case ".tar":
            case ".xml":
                return "Data and database";

            case ".email":
            case ".eml":
            case ".emlx":
            case ".msg":
            case ".oft":
            case ".ost":
            case ".pst":
            case ".vcf":
                return "E-mail";

            case ".apk":
            case ".bat":
            //case ".bin":
            case ".cgi":
            case ".pl":
            case ".com":
            case ".exe":
            case ".gadget":
            case ".jar":
            //case ".msi":
            //case ".py":
            case ".wsf":
                return "Executable";

            case ".fnt":
            case ".fon":
            case ".otf":
            case ".ttf":
                return "Font";

            case ".ai":
            case ".bmp":
            case ".gif":
            case ".ico":
            case ".jpeg":
            case ".jpg":
            case ".png":
            case ".ps":
            case ".psd":
            case ".svg":
            case ".tif":
            case ".tiff":
            case ".webp":
                return "Image";

            case ".asp":
            case ".aspx":
            case ".cer":
            case ".cfm":
            case ".css":
            case ".htm":
            case ".html":
            case ".js":
            case ".jsp":
            case ".part":
            //case ".php":
            //case ".py":
            case ".rss":
            case ".xhtml":
                return "Internet-related";

            case ".key":
            case ".odp":
            case ".pps":
            case ".ppt":
            case ".pptx":
                return "Presentation";

            case ".c":
            //case ".cgi":
            //case ".pl":
            case ".class":
            case ".cpp":
            case ".cs":
            case ".h":
            case ".java":
            case ".php":
            case ".py":
            case ".sh":
            case ".swift":
            case ".vb":
                return "Programming";

            case ".ods":
            case ".xls":
            case ".xlsm":
            case ".xlsx":
                return "Spreadsheet";

            case ".bak":
            case ".cab":
            case ".cfg":
            case ".cpl":
            case ".cur":
            case ".dll":
            case ".dmp":
            case ".drv":
            case ".icns":
            //case ".ico":
            case ".ini":
            case ".lnk":
            case ".msi":
            case ".sys":
            case ".tmp":
                return "System related";

            case ".3g2":
            case ".3gp":
            case ".avi":
            case ".flv":
            case ".h264":
            case ".m4v":
            case ".mkv":
            case ".mov":
            case ".mp4":
            case ".mpg":
            case ".mpeg":
            case ".rm":
            case ".swf":
            case ".vob":
            case ".webm":
            case ".wmv":
                return "Video file";

            case ".doc":
            case ".docx":
            case ".odt":
            case ".pdf":
            case ".rtf":
            case ".tex":
            case ".txt":
            case ".wpd":
                return "Word processor and text";

            default:
                return null; // Default category for unhandled extensions
        }
    }
}