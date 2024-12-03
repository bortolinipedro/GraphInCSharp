@echo off

csc -out:graph.exe Program.cs View\MainView.cs Application\GraphApplication.cs Controller\GraphController.cs Domain\Models\Edge.cs Domain\Models\Graph.cs Domain\Models\Vertex.cs Domain\Representations\AdjacencyList.cs Domain\Representations\AdjacencyMatrix.cs Domain\GraphDomain.cs

if exist graph.exe (
    echo Compilation successful.
    graph.exe
) else (
    echo Compilation failed.
)
pause