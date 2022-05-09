using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;


using System.Windows.Markup;

/*
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
*/
namespace test2 {
class Migration {

        // Messages d'erreurs
    private static string err_usage = "Usage: ./runC#.sh Migration.cs <Project To Migrate" ;


        // Path utiles pour le script
    private static string migrationFolderPath = "" ;
    private static string wpfPath = "" ;
    private static string angularPath = "" ;


    public static void Main (string[] args) {
        string pwd;
        Console.WriteLine ("\n                    =-=-=-=-=-=  WPF -> Angular  =-=-=-=-=-=");
        // Console.WriteLine("Args : " + string.Join(",", args));
        // Console.WriteLine("Args.Length : " + args.Length);

        if (args.Length < 1) {
            Console.WriteLine(err_usage) ;
            return ;
        }

// ##############################################################################################################
// ##############################################################################################################
// ##############################################################################################################


        Console.WriteLine("\n\n") ;
        Console.WriteLine("                     ^ ^");                                               
        Console.WriteLine("                    (O,O)    ");                                            
        Console.WriteLine("                    (   ) Première étape: Préparation à la migration    "); 
        Console.WriteLine("                    -\"-\"------------------------------------------------------  ");


        // Récupération du working directory : pwd
        pwd = Directory.GetCurrentDirectory();
        Console.WriteLine("pwd : {0}", pwd);

        // Projet à migrer
        string projectToMigrate = args[0];
        Console.WriteLine("projectToMigrate : {0}", projectToMigrate);

        // Création du répertoire de migration : mkdir
        migrationFolderPath = Path.Combine(pwd, "WpfToAngular") ;
        wpfPath = Path.Combine(migrationFolderPath, "WPF") ;

        if (Directory.Exists(migrationFolderPath)) {
            Directory.Delete(migrationFolderPath, true) ;
        }
        Directory.CreateDirectory(migrationFolderPath);
        Directory.CreateDirectory(wpfPath);
        Console.WriteLine("mkdir : {0}", migrationFolderPath);

        // Copie du projet a migrer dans le fichier de migration : cp
        CopyDirectory(@Path.Combine(pwd,projectToMigrate), @wpfPath);
        Console.WriteLine("cp : {0} {1}", Path.Combine(pwd,projectToMigrate), wpfPath);


        // cd migrationFolderPath && pwd
        Directory.SetCurrentDirectory(@migrationFolderPath);
        pwd = Directory.GetCurrentDirectory();
        Console.WriteLine("pwd : {0}", pwd);


// ##############################################################################################################
// ##############################################################################################################
// ##############################################################################################################


        Console.WriteLine("\n\n") ;
        Console.WriteLine("                     ^ ^    ");                                                  
        Console.WriteLine("                    (O,O)      ");                                               
        Console.WriteLine("                    (   ) Deuxième étape: Initialisation du projet Angular    ");
        Console.WriteLine("                    -\"-\"------------------------------------------------------  ");

            // Clone du dépot git "Template"
        Console.WriteLine("git clone https://github.com/M1-TER-WPFtoAngular/AngularTemplate.git");
        Console.WriteLine(executeShellCmd("git", "clone https://github.com/M1-TER-WPFtoAngular/AngularTemplate.git"));

            // Création du projet Angular
        Console.WriteLine("ng new "+projectToMigrate+ " --routing --defaults");
        Console.WriteLine(executeShellCmd("ng", "new "+projectToMigrate+ " --routing --defaults"));
        angularPath = Path.Combine(migrationFolderPath, projectToMigrate) ;

            // Copie de index.html et de app-component.html
        File.Copy(@"AngularTemplate/src/index.html", @projectToMigrate+"/src/index.html", true);  
        Console.WriteLine("cp AngularTemplate/src/index.html "+projectToMigrate+"/src/index.html") ;

        File.Copy(@"AngularTemplate/src/app/app.component.html", @projectToMigrate+"/src/app/app.component.html", true);  
        Console.WriteLine("cp AngularTemplate/src/app/app.component.html "+projectToMigrate+"/src/app/app.component.html") ;

            // Suppression du projet "template", il ne nous sert plus
        if (Directory.Exists(@"AngularTemplate")) {
            Directory.Delete(@"AngularTemplate", true) ;
        }
        Console.WriteLine("rm -rf AngularTemplate") ;


// ##############################################################################################################
// ##############################################################################################################
// ##############################################################################################################


        Console.WriteLine("\n\n") ;
        Console.WriteLine("                     ^ ^");                                               
        Console.WriteLine("                    (O,O)    ");                                            
        Console.WriteLine("                    (   ) Troisième étape: Migration du projet WPF    "); 
        Console.WriteLine("                    -\"-\"------------------------------------------------------  ");


        pwd = Directory.GetCurrentDirectory();
        Console.WriteLine("pwd : {0}", pwd);

        Console.WriteLine("migrationFolderPath : {0}", migrationFolderPath);
        Console.WriteLine("wpfPath : {0}", wpfPath);
        Console.WriteLine("angularPath : {0}", angularPath);


//                             ##########################################################
//                             ##########################################################
//                             ##########################################################
        Console.WriteLine("\n\n") ;
        Console.WriteLine("                         ^ ^");                                               
        Console.WriteLine("                        (O,O)    ");                                            
        Console.WriteLine("                        (   ) 3.1 : Transformation des fichiers XAML vers des fichiers HTML"); 
        Console.WriteLine("                        -\"-\"------------------------------------------------------  ");


            // cd WPF && pwd
        Directory.SetCurrentDirectory(@wpfPath);
        pwd = Directory.GetCurrentDirectory();
        Console.WriteLine("pwd : {0}", pwd);

            // Récupération de tout les fichiers xaml
        List<string> xamlFiles = getFilesByExtension(@wpfPath, "xaml") ;
        foreach (string file in xamlFiles) {
            string[] filezefjzeof = file.Split("/");
            string fileNameExt = filezefjzeof[filezefjzeof.Length-1];
            string fileName = file.Split(".")[0];

            Console.WriteLine("Dealing with : " + fileName + " (" + fileNameExt + ")");

                // cd angularpath && pwd
            Directory.SetCurrentDirectory(@angularPath);
            pwd = Directory.GetCurrentDirectory();
            Console.WriteLine("pwd : {0}", pwd);

                // Création du composant Angular
            Console.WriteLine("ng generate component "+fileName);
            Console.WriteLine(executeShellCmd("ng", "generate component "+fileName));


                // Gérer les routes
                // Ast
                // Traduction du HTML
                // Positionnement
                // Logique métier



                // cd WPF && pwd
            Directory.SetCurrentDirectory(@wpfPath);
            pwd = Directory.GetCurrentDirectory();
            Console.WriteLine("pwd : {0}", pwd);
        }
        

//                             ##########################################################
//                             ##########################################################
//                             ##########################################################
        Console.WriteLine("\n\n") ;
        Console.WriteLine("                         ^ ^");                                               
        Console.WriteLine("                        (O,O)    ");                                            
        Console.WriteLine("                        (   ) 3.2 : Positionnement et style des éléments HTML"); 
        Console.WriteLine("                        -\"-\"------------------------------------------------------  ");





//                             ##########################################################
//                             ##########################################################
//                             ##########################################################
        Console.WriteLine("\n\n") ;
        Console.WriteLine("                         ^ ^");                                               
        Console.WriteLine("                        (O,O)    ");                                            
        Console.WriteLine("                        (   ) 3.3 : Transformation des fichiers C# vers des fichiers TYPESCRIPT"); 
        Console.WriteLine("                        -\"-\"------------------------------------------------------  ");

    }


    /*
    public static CompilationUnitSyntax getAstFromCS(String programme) {
        SyntaxTree tree = CSharpSyntaxTree.ParseText(programme);
        CompilationUnitSyntax root = tree.GetCompilationUnitRoot();

        return root;
    }*/

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

    static void CopyDirectory(string sourceDir, string destinationDir){
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

