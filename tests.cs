using System;
using System.IO;
using System.Diagnostics;

using System.Windows.Markup;

class Tests {
    public static void Main (string[] args) {
        string path = @"martin/martin/App.xaml";

        string text = System.IO.File.ReadAllText(path);
        System.Console.WriteLine("Contents of WriteText.txt = \n{0}", text);

        var parsedXaml = XamlReader.Parse(text);

        Console.WriteLine(parsedXaml) ;
    }

}