using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;

using System.Windows.Markup;

namespace test {
public class Tests {
    
    private static string migrationFolderPath = "" ;
    private static string wpfPath = "" ;
    private static string angularPath = "" ;


    public static void testestst (string[] args) {
        string pwd;
        // Récupération du working directory : pwd
        pwd = Directory.GetCurrentDirectory();
        migrationFolderPath = Path.Combine(pwd, "WpfToAngular") ;
        wpfPath = Path.Combine(migrationFolderPath, "WPF") ;

        // cd migrationFolderPath && pwd
        Directory.SetCurrentDirectory(@migrationFolderPath);
        pwd = Directory.GetCurrentDirectory();
        Console.WriteLine("pwd : {0}", pwd);

        Console.WriteLine("migrationFolderPath : {0}", migrationFolderPath);
        Console.WriteLine("wpfPath : {0}", wpfPath);
        Console.WriteLine("angularPath : {0}", angularPath);


        List<string> xamlFiles = getFilesByExtension(@wpfPath, "xaml") ;
        Console.WriteLine(xamlFiles.Count);
        foreach (string file in xamlFiles) {
            Console.WriteLine(file) ;
        }       

        return ;
/*
        string path = @"martin/martin/App.xaml";

        string text = System.IO.File.ReadAllText(path);
        System.Console.WriteLine("Contents of WriteText.txt = \n{0}", text);

        var parsedXaml = XamlReader.Parse(text);

        Console.WriteLine(parsedXaml) ;
*/
    }

    public static List<string> getFilesByExtension(string path, string extension) {
        List<string> ret = new List<string>();
        var dir = new DirectoryInfo(path);
        foreach (FileInfo file in dir.GetFiles()){
            string[] splitName = file.Name.Split(".");
            if (splitName[splitName.Length-1] == extension) {
                ret.Add(Path.Combine(path, file.Name));
                //Console.WriteLine(Path.Combine(path, file.Name)) ;
            }
        }
        DirectoryInfo[] dirs = dir.GetDirectories();
        foreach (DirectoryInfo subDir in dirs){
            ret.AddRange(getFilesByExtension(Path.Combine(path, subDir.Name), extension));
        }   
        return ret;
    }

}
}