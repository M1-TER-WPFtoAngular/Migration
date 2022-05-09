#!/bin/bash

if [ "$#" -lt 1 ]
then
    echo  "Usage : $0 <file>";
    exit;
fi

if mcs -out:$1.exe $1 ; then
    echo "mono $1.exe ${@:2}" ;
    echo " " ;
    mono $1.exe ${@:2} ;
    echo " ";
else
    echo "Erreurs de compilation.";
fi

exit;

# mcs -out:$1.exe $1 ;
# echo "mono $1.exe ${@:2}" ;
# echo " " ;
# mono $1.exe ${@:2} ;
# echo " ";