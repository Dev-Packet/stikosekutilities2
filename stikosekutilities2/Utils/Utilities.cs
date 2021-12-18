using stikosekutilities2.Cheats;
using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Reflection;

namespace stikosekutilities2.Utils
{
    public static class Utilities
    {
        /// <summary>
        /// Formats the version of the executing Assembly.
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="pretty"></param>
        /// <returns></returns>
        public static string FormatAssemblyVersion(bool pretty = false)
        {
            return FormatAssemblyVersion(Assembly.GetExecutingAssembly(), pretty);
        }

        /// <summary>
        /// Formats the version of an Assembly.
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="pretty"></param>
        /// <returns></returns>
        public static string FormatAssemblyVersion(Assembly assembly, bool pretty = false)
        {
            if (assembly == null)
            {
                assembly = Assembly.GetExecutingAssembly();
            }

            string version = assembly.GetName().Version.ToString();
            for (int i = 0; i < 100; i++)
            {
                if (version.EndsWith(".0"))
                    version = version.Trim().Substring(0, version.Length - 2);
                else
                    break;
            }

            // Readd a single ".0" to make it look nicer
            if (pretty && !version.Contains("."))
            {
                version += ".0";
            }

            return version;
        }

        public static bool IsCheat(this Type type)
        {
            return
                // Has CheatAttribute
                type.GetCustomAttributes(typeof(CheatAttribute), false).Length != 0 &&
                // Is inherited from BaseCheat
                typeof(BaseCheat).IsAssignableFrom(type);
        }

        /// <summary>
        /// Downloads a File from an URL
        /// </summary>
        /// <param name="fileName">File Location</param>
        /// <param name="url">Download URL</param>
        public static void DownloadFile(string fileName, string url)
        {
            using var client = new WebClient();
            client.DownloadFile(url, fileName);
        }

        /// <summary>
        /// Downloads Newtonsoft Json.
        /// </summary>
        public static void DownloadJsonLibrary()
        {
            // Paths
            string path = GetAssemblyLocation();
            string dllLoadPath = Path.Combine(path, "Newtonsoft.Json.dll");


            if (!File.Exists(dllLoadPath))
            {
                // Temp Paths
                string tempPath = Path.Combine(Path.GetTempPath(), "CrabGame Cheat " + Guid.NewGuid().ToString());
                string zipPath = Path.Combine(tempPath, "Unzipped");

                string zip = Path.Combine(tempPath, "Json.zip");

                // Create zipPath
                Directory.CreateDirectory(zipPath);

                // Download Newtonsoft.Json.
                DownloadFile(zip,
                    "https://github.com/JamesNK/Newtonsoft.Json/releases/download/13.0.1/Json130r1.zip");

                // Extract the zip.
                ZipFile.ExtractToDirectory(zip, zipPath);

                string dllFile = Path.Combine(zipPath, "Bin", "net45", "Newtonsoft.Json.dll");

                // Copy Newtonsoft.Json to plugins folder, to not download it every start.
                File.Copy(dllFile, dllLoadPath);

                // Load Newtonsoft.Json
                Assembly.LoadFrom(dllLoadPath);
            }
        }

        public static string GetAssemblyLocation()
        {
            return GetAssemblyLocation(Assembly.GetExecutingAssembly());
        }

        public static string GetAssemblyLocation(Assembly assembly)
        {
            return Path.GetDirectoryName(assembly.Location);
        }

    }
}
