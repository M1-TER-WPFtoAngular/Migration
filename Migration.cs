using System;
using System.Diagnostics;

class Migration {

    public static void Main (string[] args) {
        Console.WriteLine ("=-=-=-=-=-=  WPF -> Angular  =-=-=-=-=-=");
        // Console.WriteLine("Args : " + string.Join(",", args));



        String projectToMigrate = args[0] ;
        Console.WriteLine("Project : " + projectToMigrate);

        executeShellCmd("ls", "-l -a") ;


    }

    public static void executeShellCmd(String cmd, String args) {
        ProcessStartInfo startInfo = new ProcessStartInfo() { FileName = cmd, Arguments = args}; 
        Process proc = new Process() { StartInfo = startInfo, };
        proc.Start();
    }
}

