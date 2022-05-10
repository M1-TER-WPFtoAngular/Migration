using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Windows.Markup;
using System.Text.RegularExpressions;


namespace MigrationTool {
    public class AngularComponent {
        private string path;
        public string getPath() { return path;}

        private string name;
        public string getName() { return name;}


        public AngularComponent(string path, string name) {
            this.path = path;
            this.name = name;
        }

        public List<string> getHTML() {
            return Utils.getFilesByExtension(getPath(), ".html") ;
        }

        public List<string> getTypescript() {
            List<string> ret = new List<string>() ;
            List<string> list = Utils.getFilesByExtension(getPath(), ".ts") ;
            foreach(string s in list) {
                if (! s.EndsWith(".spec.ts")) {
                    ret.Add(s) ;
                }
            }
            
            return ret;
        }
    }



    public class AngularEditor {

        private string projectRoot ;
        private List<AngularComponent> components = new List<AngularComponent>();

        public AngularEditor(string project) {
            projectRoot = project;

            var dir = new DirectoryInfo(Path.Combine(project, "src", "app"));
            DirectoryInfo[] dirs = dir.GetDirectories();
            foreach (DirectoryInfo subDir in dirs){
                string dirPath = Path.Combine(Path.Combine(project, "src", "app"), subDir.Name);
                components.Add(new AngularComponent(dirPath, subDir.Name)) ;
            }
        }

        // Revoir les regex c'est pas générique
        public void updateRoutes(List<Route> routes) {
            string routingModule = Path.Combine(projectRoot, "src", "app", "app-routing.module.ts") ;

            string newRoutesString = "[" ;
            foreach(Route r in routes) {
                //   {path: "", component: MainWindowComponent},
                newRoutesString = newRoutesString + "{path: \"" + r.getUrl() + "\", component: " + r.getComponent() + "}," ;
            }
            newRoutesString = newRoutesString + "]" ;


            string readText = File.ReadAllText(routingModule);      
            File.WriteAllText(routingModule, 
                readText.Replace("const routes: Routes = [];",
                    "const routes: Routes = "+ newRoutesString +";"
            )) ;
        }

        public AngularComponent selectComponent(string componentName) {
            AngularComponent selectedComponent = null;
            foreach (AngularComponent comp in components) {
                if (comp.getName() == componentName) {
                    selectedComponent = comp ;
                }
            }
           if (selectedComponent == null)
                throw new NullReferenceException("Cannot found the component : " + componentName);
            return selectedComponent;
        }
    }
}