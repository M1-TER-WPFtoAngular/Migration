if mcs -out:../Migration.exe Main.cs Utils.cs Migration.cs AngularEditor.cs; then
    echo "mcs -out:Migration.exe Main.cs SetupMigration.cs" ;
    echo " " ;
else
    echo "Erreurs de compilation.";
fi

