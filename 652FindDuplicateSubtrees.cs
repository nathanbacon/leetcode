using System.Text;

namespace FindDuplicateSubtrees
{
  // Definition for a binary tree node.
  public class TreeNode
  {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
      this.val = val;
      this.left = left;
      this.right = right;
    }
  }

  public class Solution
  {
    HashSet<string> s = new();
    List<TreeNode> output = new();
    HashSet<string> added = new();

    public IList<TreeNode> FindDuplicateSubtrees(TreeNode root)
    {
      Search(root);
      return output;
    }

    StringBuilder Search(TreeNode node)
    {
      if (node == null) return new StringBuilder();

      StringBuilder lsb = Search(node.left);
      StringBuilder rsb = Search(node.right);
      if (s.Contains(lsb.ToString()))
      {
        if (!added.Contains(lsb.ToString()))
        {
          output.Add(node.left);
          added.Add(lsb.ToString());
        }
      }
      else if (lsb.Length > 0)
      {
        s.Add(lsb.ToString());
      }

      if (s.Contains(rsb.ToString()))
      {
        if (!added.Contains(rsb.ToString()))
        {
          output.Add(node.right);
          added.Add(rsb.ToString());
        }
      }
      else if (rsb.Length > 0)
      {
        s.Add(rsb.ToString());
      }

      StringBuilder msb = new();
      msb.Append(node.val);

      msb.Append("L");
      msb.Append(lsb.Length > 0 ? lsb : new StringBuilder("()"));
      msb.Append("R");
      msb.Append(rsb.Length > 0 ? rsb : new StringBuilder("()"));
      return msb;
    }
  }

}
