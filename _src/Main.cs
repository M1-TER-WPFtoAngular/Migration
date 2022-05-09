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
                Console.WriteLine("Usage: ./runC#.sh Migration.cs <Project To Migrate") ;
                return ;
            }
    
            Migration m = new Migration(Utils.LevelOfDebug.high);
            m.setup(args[0]) ;
            m.initializeAngular() ;
            m.showPaths() ;

            List<Route> routes = m.generateAngularComponent() ;
            foreach (Route route in routes){
                Utils.log(route.getUrl() + " -> " + route.getComponent(), ConsoleColor.Green) ;
            }


            return;
        }
    }
}