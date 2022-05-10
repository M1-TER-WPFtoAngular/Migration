using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Windows.Markup;


namespace MigrationTool {
    public class Migration {

            // Path utiles pour le script
        private string migrationFolderPath = "" ;
        public string getMigrationFolderPath() { return migrationFolderPath;}
        private string wpfPath = "" ;
        public string getWpfPath() { return wpfPath;}
        private string angularPath = "" ;
        public string getAngularPath() { return angularPath;}


        private string projectToMigrate = "" ;
        public Migration setProjectToMigrate(string project) { projectToMigrate = project ; return this;}

            // Niveau d'affichage dans la console
        private Utils.LevelOfDebug debug = Utils.LevelOfDebug.high;


            // Constructors
        public Migration() {
            this.debug = Utils.LevelOfDebug.none;
        }
        public Migration(Utils.LevelOfDebug levelOfDebug) {
            this.debug = levelOfDebug;
        }

            // Attribut lié à Angular
        private List<Route> routes = new List<Route>();
        public List<Route> getRoutes() { return routes; }
        



            // Methods
        public void setup(string wpfProject) {
            Utils.printTitle("Première étape: Préparation à la migration") ;
            string pwd;

                // Récupération du working directory : pwd
            pwd = Directory.GetCurrentDirectory();
            Utils.log("pwd : " + pwd);


                // Projet à migrer
            projectToMigrate = wpfProject;
            Utils.log("projectToMigrate : " + projectToMigrate);


                // Création du répertoire de migration : mkdir
            migrationFolderPath = Path.Combine(pwd, "WpfToAngular") ;
            wpfPath = Path.Combine(migrationFolderPath, "WPF") ;

            if (Directory.Exists(migrationFolderPath)) {
                Directory.Delete(migrationFolderPath, true) ;
            }
            Directory.CreateDirectory(migrationFolderPath);
            Directory.CreateDirectory(wpfPath);
            Utils.log("mkdir : " + migrationFolderPath);


                // Copie du projet a migrer dans le fichier de migration : cp
            Utils.CopyDirectory(@Path.Combine(pwd,projectToMigrate), @wpfPath);
            Utils.log("cp : "+  Path.Combine(pwd,projectToMigrate) +" "+ wpfPath);


                // cd migrationFolderPath && pwd
            Directory.SetCurrentDirectory(@migrationFolderPath);
            pwd = Directory.GetCurrentDirectory();
            Utils.log("cd " + migrationFolderPath);
            Utils.log("pwd : " + pwd) ;
        }


        public void initializeAngular() {
            Utils.printTitle("Deuxième étape: Initialisation du projet Angular") ;

                // Clone du dépot git "Template"
            Utils.log("git clone https://github.com/M1-TER-WPFtoAngular/AngularTemplate.git");

            if (debug == Utils.LevelOfDebug.high) { Utils.log(Utils.executeShellCmd("git", "clone https://github.com/M1-TER-WPFtoAngular/AngularTemplate.git"), ConsoleColor.Red); }

                // Création du projet Angular
            Utils.log("ng new "+projectToMigrate+ " --routing --defaults");
            if (debug == Utils.LevelOfDebug.high) { Utils.log(Utils.executeShellCmd("ng", "new "+projectToMigrate+ " --routing --defaults"), ConsoleColor.Red); }
            
            angularPath = Path.Combine(migrationFolderPath, projectToMigrate) ;

                // Copie de index.html et de app-component.html
            File.Copy(@"AngularTemplate/src/index.html", @projectToMigrate+"/src/index.html", true);  
            Utils.log("cp AngularTemplate/src/index.html "+projectToMigrate+"/src/index.html") ;

            File.Copy(@"AngularTemplate/src/app/app.component.html", @projectToMigrate+"/src/app/app.component.html", true);  
            Utils.log("cp AngularTemplate/src/app/app.component.html "+projectToMigrate+"/src/app/app.component.html") ;

                // Suppression du projet "template", il ne nous sert plus
            if (Directory.Exists(@"AngularTemplate")) {
                Directory.Delete(@"AngularTemplate", true) ;
            }
            Utils.log("rm -rf AngularTemplate") ;
        }


        public void showPaths() {
            Utils.printTitle("Troisième étape: Migration du projet WPF") ;

            string pwd = Directory.GetCurrentDirectory();
            Utils.log("pwd : " + pwd);
            Utils.log("projectToMigrate : " + projectToMigrate);
            Utils.log("migrationFolderPath : " + migrationFolderPath);
            Utils.log("wpfPath : " + wpfPath);
            Utils.log("angularPath : " + angularPath);
        }


        public List<Route> generateAngularComponent() {
            Utils.printTitle("3.1 : Génération des composant Angular") ;

                // cd WPF && pwd
            Directory.SetCurrentDirectory(@wpfPath);
            string pwd = Directory.GetCurrentDirectory();
            Utils.log("pwd : " + pwd);

                // Récupération de tout les fichiers xaml
            List<string> xamlFiles = Utils.getFilesByExtension(@wpfPath, ".xaml") ;
            foreach (string file in xamlFiles) {
                string[] filenameSplit = file.Split("/");
                string fileNameExt = filenameSplit[filenameSplit.Length-1];
                string fileName = fileNameExt.Split(".")[0];

                if (debug == Utils.LevelOfDebug.high) { Utils.log("Dealing with : " + fileName + " (" + fileNameExt + ")"); }

                    // cd angularpath && pwd
                Directory.SetCurrentDirectory(@angularPath);
                pwd = Directory.GetCurrentDirectory();
                Utils.log("pwd : " + pwd);

                    // Création du composant Angular
                Utils.log("ng generate component "+fileName);
                if (debug == Utils.LevelOfDebug.high) { Utils.log(Utils.executeShellCmd("ng", "generate component "+fileName), ConsoleColor.Red); }

                    // Gérer les routes
                if (fileName == "App") {
                    this.routes.Add(new Route("/", fileName+"Component")) ;
                }else {
                    this.routes.Add(new Route("/"+fileName, fileName+"Component")) ;
                }

                    // cd WPF && pwd
                Directory.SetCurrentDirectory(@wpfPath);
                pwd = Directory.GetCurrentDirectory();
                Utils.log("pwd : " + pwd);
            }

            return this.routes;
        }


        public void fromXAMLtoHTML() {
                // Récupération de tout les fichiers xaml
            List<string> xamlFiles = Utils.getFilesByExtension(@wpfPath, ".xaml") ;
            foreach (string file in xamlFiles) {
                string[] filenameSplit = file.Split("/");
                string fileNameExt = filenameSplit[filenameSplit.Length-1];
                string fileName = fileNameExt.Split(".")[0];
        
                if (debug == Utils.LevelOfDebug.high) { Utils.log("Dealing with : " + fileName + " (" + fileNameExt + ")"); }


                    // Ast
                    // Traduction du HTML
            }
        }
                
                    // Positionnement
                    // Logique métier

    }
}