@echo off

csc -out:graph.exe main.cs models\edge.cs models\vertex.cs models\graph.cs

if exist graph.exe (
    echo Compilation successful.
    graph.exe
) else (
    echo Compilation failed.
)
pause