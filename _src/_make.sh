if mcs -out:../Migration.exe Main.cs Utils.cs Migration.cs Route.cs; then
    echo "mcs -out:Migration.exe Main.cs SetupMigration.cs" ;
    echo " " ;
else
    echo "Erreurs de compilation.";
fi

