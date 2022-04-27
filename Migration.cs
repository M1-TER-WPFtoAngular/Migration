using System;
using System.IO;
using System.Diagnostics;


class Migration {

    private static string err_usage = "Usage: ./runC#.sh Migration.cs <Project To Migrate" ;



    public static void Main (string[] args) {
        Console.WriteLine ("=-=-=-=-=-=  WPF -> Angular  =-=-=-=-=-=");
        // Console.WriteLine("Args : " + string.Join(",", args));
        // Console.WriteLine("Args.Length : " + args.Length);

        if (args.Length < 1) {
            Console.WriteLine(err_usage) ;
            return ;
        }

        // Récupération du working directory
        string pwd = Directory.GetCurrentDirectory();
        Console.WriteLine("pwd : {0}", pwd);

        // Projet à migrer
        string projectToMigrate = args[0];
        Console.WriteLine("projectToMigrate : {0}", projectToMigrate);


        // Création du répertoire de migration
        string migrationFolder = Path.Combine(pwd, "Migration") ;
        if (Directory.Exists(migrationFolder)) {
            Directory.Delete(migrationFolder, true) ;
        }
        Directory.CreateDirectory(migrationFolder);
        Console.WriteLine("mkdir : {0}", migrationFolder);


        // Copie du projet a migrer dans le fichier de migration
        Console.WriteLine("cp : {0} {1}", Path.Combine(pwd,projectToMigrate), Path.Combine(pwd, "Migration", "WPF"));

        CopyDirectory(Path.Combine(pwd,projectToMigrate), Path.Combine(pwd, "Migration", "WPF"));
        Console.WriteLine("cp : {0} {1}", Path.Combine(pwd,projectToMigrate), Path.Combine(pwd, "Migration", "WPF"));



    }


    public static void executeShellCmd(String cmd, String args) {
        ProcessStartInfo startInfo = new ProcessStartInfo() { FileName = cmd, Arguments = args}; 
        Process proc = new Process() { StartInfo = startInfo, };
        proc.Start();
    }


    static void CopyDirectory(string sourceDir, string destinationDir){
        var dir = new DirectoryInfo(sourceDir);
        if (!dir.Exists)
            throw new DirectoryNotFoundException($"Source directory not found: {dir.FullName}");

        DirectoryInfo[] dirs = dir.GetDirectories();

        foreach (FileInfo file in dir.GetFiles()){
            string targetFilePath = Path.Combine(destinationDir, file.Name);
            file.CopyTo(targetFilePath);
        }
        foreach (DirectoryInfo subDir in dirs){
            string newDestinationDir = Path.Combine(destinationDir, subDir.Name);
            CopyDirectory(subDir.FullName, newDestinationDir);
        }   
    }
}

