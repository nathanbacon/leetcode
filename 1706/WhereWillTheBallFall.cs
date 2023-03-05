namespace WhereWillTheBallFall;

public class Solution
{
  public int[] FindBall(int[][] grid)
  {
    int[] origin = new int[grid[0].Length];
    for (int i = 0; i < origin.Length; i++)
      origin[i] = i;

    foreach (int[] row in grid)
    {
      int[] next = new int[origin.Length];
      for (int i = 0; i < origin.Length; i++)
        next[i] = -1;

      for (int i = 0; i < row.Length; i++)
      {
        if (row[i] == 1)
        {
          if (i + 1 == row.Length) continue;
          if (row[i + 1] == -1) continue;

          next[i + 1] = origin[i];
        }
        else
        {
          if (i == 0) continue;
          if (row[i - 1] == 1) continue;
          next[i - 1] = origin[i];
        }
      }

      origin = next;
    }

    int[] output = new int[origin.Length];

    for (int i = 0; i < output.Length; i++)
    {
      output[i] = -1;
    }

    for (int i = 0; i < origin.Length; i++)
    {
      if (origin[i] == -1) continue;

      output[origin[i]] = i;
    }

    return output;
  }
}
