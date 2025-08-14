#include <iostream>
#include <list>
#include <string>
#include <map>
using namespace std;

struct Edge
{
    int destination;
};
class Graph
{
private:
    map<int, list<Edge>> adjacencyList;
    bool isValidVertex(int vertex) const
    {
        return adjacencyList.count(vertex) > 0;
    }

public:
    void addVertex(int vertex)
    {
        if (!isValidVertex(vertex))
        {
            adjacencyList[vertex];
        }
    }
    void addEdge(int source, int destination, bool isDirected = false)
    {
        addVertex(source);
        addVertex(destination);
        adjacencyList[source].push_back({destination});
        if (!isDirected)
        {
            adjacencyList[destination].push_back({source});
        }
    }
    void displayGraph() const
    {
        for (const auto &[vertex, edges] : adjacencyList)
        {
            cout << " Vertex " << vertex << " -> ";
            if (edges.empty())
            {
                cout << " No connection" << endl;
            }
            else
            {
                for (const auto &edge : edges)
                {
                    cout << edge.destination << " ";
                }
                cout << endl;
            }
        }
    }
};

int main()
{
    Graph g;
    g.addEdge(0, 1);
    g.addEdge(0, 2);
    g.addEdge(1, 2);

    cout << "\nUndirected graph:" << endl;
    g.displayGraph();
    cout << endl;

    Graph digraph;
    digraph.addEdge(0, 1, true);
    digraph.addEdge(1, 2, true);
    digraph.addEdge(2, 0, true);

    cout << "\nDirected graph:" << endl;
    digraph.displayGraph();

    return 0;
}