namespace RottingOranges;

public class Solution
{
  static int ROTTEN = 2;
  static int FRESH = 1;
  public int OrangesRotting(int[][] grid)
  {
    Queue<(int, int)> q = new();
    int freshCt = 0;
    for (int i = 0; i < grid.Length; i++)
    {
      for (int j = 0; j < grid[0].Length; j++)
      {
        int cell = grid[i][j];
        if (cell == ROTTEN)
        {
          q.Enqueue((i, j));
        }
        else if (cell == FRESH)
        {
          freshCt += 1;
        }
      }
    }

    q.Enqueue((-1, -1));
    if (freshCt == 0) return 0;

    int time = 0;
    while (q.Count > 0)
    {
      (int r, int c) = q.Dequeue();
      if (r == -1)
      {
        if (q.Count > 0)
        {
          time += 1;
          q.Enqueue((-1, -1));
        }
        continue;
      }

      List<(int, int)> directions = new() { (1, 0), (-1, 0), (0, 1), (0, -1) };
      foreach ((int v, int h) in directions)
      {
        (int nr, int nc) = (r + v, c + h);
        if (nr < 0 || nr >= grid.Length) continue;
        if (nc < 0 || nc >= grid[0].Length) continue;

        int cell = grid[nr][nc];
        if (cell == FRESH)
        {
          freshCt -= 1;
          q.Enqueue((nr, nc));
          grid[nr][nc] = ROTTEN;
        }
      }
    }

    return freshCt > 0 ? -1 : time;
  }
}
