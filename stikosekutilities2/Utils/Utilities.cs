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
