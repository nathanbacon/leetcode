namespace PaintHouse;

public class Solution
{
  public int MinCost(int[][] costs)
  {
    int colors = costs[0].Length;
    for (int i = 1; i < costs.Length; i++)
    {
      int[] prev = costs[i - 1];
      costs[i][0] += Math.Min(prev[1], prev[2]);
      costs[i][1] += Math.Min(prev[0], prev[2]);
      costs[i][2] += Math.Min(prev[0], prev[1]);
    }

    return costs[costs.Length - 1].Min();
  }
}
