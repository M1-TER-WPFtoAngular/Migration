using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Windows.Markup;


namespace MigrationTool {
    public class Utils {

        public static void printTitle(string title) {
            Console.WriteLine("\n\n") ;
            Console.WriteLine("                     ^ ^");                                               
            Console.WriteLine("                    (O,O)    ");                                            
            Console.WriteLine("                    (   ) " + title); 
            Console.WriteLine("                    -\"-\"------------------------------------------------------  ");
        }

        public enum LevelOfDebug { none, low, high }

        public static void log(string msg, ConsoleColor color = ConsoleColor.Blue) {
            Console.Write("> ") ;
            Console.ForegroundColor = color;
            Console.WriteLine(msg) ;
            Console.ResetColor();
        }


        public static string executeShellCmd(String cmd, String args) {
            ProcessStartInfo startInfo = new ProcessStartInfo() { 
                FileName = cmd, 
                Arguments = args,
                RedirectStandardOutput = true,
                UseShellExecute = false
            }; 
            var process = Process.Start(startInfo);
            string output = process.StandardOutput.ReadToEnd(); 
            process.WaitForExit();
            
            return output;
        }

        public static void CopyDirectory(string sourceDir, string destinationDir){
            var dir = new DirectoryInfo(sourceDir);
            if (!dir.Exists)
                throw new DirectoryNotFoundException($"Source directory not found: {dir.FullName}");

            foreach (FileInfo file in dir.GetFiles()){
                string targetFilePath = Path.Combine(destinationDir, file.Name);
                file.CopyTo(targetFilePath);
            }
            DirectoryInfo[] dirs = dir.GetDirectories();
            foreach (DirectoryInfo subDir in dirs){
                string newDestinationDir = Path.Combine(destinationDir, subDir.Name);
                if (!Directory.Exists(newDestinationDir)) {
                    Directory.CreateDirectory(newDestinationDir);
                }
                CopyDirectory(subDir.FullName, newDestinationDir);
            }   
        }

        public static List<string> getFilesByExtension(string path, string extension) {
            List<string> ret = new List<string>();
            var dir = new DirectoryInfo(path);
            foreach (FileInfo file in dir.GetFiles()){
                if (file.Name.EndsWith(extension)) {
                    ret.Add(Path.Combine(path, file.Name));
                }
            }
            DirectoryInfo[] dirs = dir.GetDirectories();
            foreach (DirectoryInfo subDir in dirs){
                ret.AddRange(getFilesByExtension(Path.Combine(path, subDir.Name), extension));
            }   
            return ret;
        }
    }





    public class Route {

        private string url;
        private string componentName;


        public Route(string url, string componentName) {
            this.url = url;
            this.componentName = componentName;
        }

        public string getUrl() { return url;}
        public string getComponent() { return componentName;}

        public Route setUrl(string url) { this.url = url; return this;}
        public Route setComponent(string componentName) { this.componentName = componentName;return this;}

    }
    
}