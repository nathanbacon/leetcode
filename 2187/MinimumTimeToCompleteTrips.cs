namespace MinimumTimeToCompleteTrips;

public class Solution
{
  int[] _times;
  int _totalTrips;
  public long MinimumTime(int[] time, int totalTrips)
  {
    _times = time;
    _totalTrips = totalTrips;
    long maxTime = int.MinValue;
    foreach (int t in time)
    {
      maxTime = Math.Max(maxTime, (long)t);
    }

    long lowerBound = 1;
    long upperBound = totalTrips * maxTime;
    return Search(lowerBound, upperBound);
  }

  private bool Test(long time) => _times.Sum(t => time / t) >= _totalTrips;

  private long Search(long lo, long hi)
  {
    if (lo > hi) return -1;

    long mid = (lo + hi) / 2;

    if (Test(mid))
    {
      long result = Search(lo, mid - 1);
      return result == -1 ? mid : result;
    }
    else
    {
      return Search(mid + 1, hi);
    }
  }
}
