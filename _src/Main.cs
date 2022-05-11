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

namespace MigrationTool {
    public class MainClass {

        public static void Main (string[] args) {
            Console.WriteLine ("\n                    =-=-=-=-=-=  WPF -> Angular  =-=-=-=-=-=");

            if (args.Length < 1) {
                Console.WriteLine("Usage: ./runC#.sh Migration.cs <Project To Migrate>") ;
                return ;
            }
    /*
            AngularEditor a = new AngularEditor("WpfToAngular/martin") ;
            List<Route> r = new List<Route>() ;
            r.Add(new Route("/", "Component")) ;
            r.Add(new Route("/", "Component")) ;
            r.Add(new Route("/", "Component")) ;
            r.Add(new Route("/", "Component")) ;

            //a.updateRoutes(r);

            foreach(string s in a.selectComponent("app").getHTML()) {
                Console.WriteLine(s) ;
            } 
            foreach(string s in a.selectComponent("app").getTypescript()) {
                Console.WriteLine(s) ;
            }
            return;
 */


            Migration m = new Migration(Utils.LevelOfDebug.high);
            m.setup(args[0]) ;
            m.initializeAngular() ;
            m.showPaths() ;

            List<Route> routes = m.generateAngularComponent() ;
            foreach (Route route in routes){
                Utils.log(route.getUrl() + " -> " + route.getComponent(), ConsoleColor.Green) ;
            }

            AngularEditor angularEditor = new AngularEditor(m.getAngularPath()) ;
            angularEditor.updateRoutes(routes) ;


           // m.fromXAMLtoHTML() ;



            return;
        }
    }
}