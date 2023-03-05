namespace AllPathsFromSourceLeadToDestination;

public class Solution
{
  Dictionary<int, List<int>> _graph = new();
  int _destination;
  HashSet<int> _dp = new();
  HashSet<int> _visited = new();

  public bool LeadsToDestination(int n, int[][] edges, int source, int destination)
  {
    foreach (int[] edge in edges)
    {
      if (!_graph.ContainsKey(edge[0]))
        _graph[edge[0]] = new List<int>();
      _graph[edge[0]].Add(edge[1]);
    }

    _destination = destination;
    _dp.Add(destination);

    if (_graph.ContainsKey(_destination)) return false;

    return DFS(source);
  }

  private bool DFS(int source)
  {
    if (_visited.Contains(source)) return false;
    if (_dp.Contains(source)) return true;
    _visited.Add(source);
    if (!_graph.ContainsKey(source)) return false;
    List<int> nodes = _graph[source];
    if (_graph.ContainsKey(source)) nodes = _graph[source];
    foreach (int node in nodes)
    {
      if (!DFS(node))
      {
        return false;
      }

      _dp.Add(source);
    }

    _visited.Remove(source);
    return true;
  }
}
