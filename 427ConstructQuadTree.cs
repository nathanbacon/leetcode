/*
// Definition for a QuadTree node.
public class Node {
    public bool val;
    public bool isLeaf;
    public Node topLeft;
    public Node topRight;
    public Node bottomLeft;
    public Node bottomRight;

    public Node() {
        val = false;
        isLeaf = false;
        topLeft = null;
        topRight = null;
        bottomLeft = null;
        bottomRight = null;
    }
    
    public Node(bool _val, bool _isLeaf) {
        val = _val;
        isLeaf = _isLeaf;
        topLeft = null;
        topRight = null;
        bottomLeft = null;
        bottomRight = null;
    }
    
    public Node(bool _val,bool _isLeaf,Node _topLeft,Node _topRight,Node _bottomLeft,Node _bottomRight) {
        val = _val;
        isLeaf = _isLeaf;
        topLeft = _topLeft;
        topRight = _topRight;
        bottomLeft = _bottomLeft;
        bottomRight = _bottomRight;
    }
}
*/

namespace ConstructQuadTree
{
  public class Node
  {
    public bool val;
    public bool isLeaf;
    public Node topLeft;
    public Node topRight;
    public Node bottomLeft;
    public Node bottomRight;

    public Node()
    {
      val = false;
      isLeaf = false;
      topLeft = null;
      topRight = null;
      bottomLeft = null;
      bottomRight = null;
    }

    public Node(bool _val, bool _isLeaf)
    {
      val = _val;
      isLeaf = _isLeaf;
      topLeft = null;
      topRight = null;
      bottomLeft = null;
      bottomRight = null;
    }

    public Node(bool _val, bool _isLeaf, Node _topLeft, Node _topRight, Node _bottomLeft, Node _bottomRight)
    {
      val = _val;
      isLeaf = _isLeaf;
      topLeft = _topLeft;
      topRight = _topRight;
      bottomLeft = _bottomLeft;
      bottomRight = _bottomRight;
    }
  }

  public class Solution
  {
    private int[][] grid;
    public Node Construct(int[][] grid)
    {
      if (grid.Length == 1)
      {
        return new Node(grid[0][0] == 1, true);
      }
      this.grid = grid;
      return Build(0, 0, grid.Length);
    }

    private Node Build(int row, int col, int size)
    {
      Node node;
      if (size == 2)
      {
        bool topLeft = grid[row][col] == 1;
        bool topRight = grid[row][col + 1] == 1;
        bool bottomLeft = grid[row + 1][col] == 1;
        bool bottomRight = grid[row + 1][col + 1] == 1;
        Node topLeftNode = new Node(topLeft, true);
        Node topRightNode = new Node(topRight, true);
        Node bottomLeftNode = new Node(bottomLeft, true);
        Node bottomRightNode = new Node(bottomRight, true);
        node = new Node(false, false, topLeftNode, topRightNode, bottomLeftNode, bottomRightNode);
      }
      else
      {
        int newSize = size / 2;
        Node topLeftNode = Build(row, col, newSize);
        Node topRightNode = Build(row, col + newSize, newSize);
        Node bottomLeftNode = Build(row + newSize, col, newSize);
        Node bottomRightNode = Build(row + newSize, col + newSize, newSize);
        node = new Node(false, false, topLeftNode, topRightNode, bottomLeftNode, bottomRightNode);
      }

      if (
          node.topLeft.isLeaf
          && node.topRight.isLeaf
          && node.bottomLeft.isLeaf
          && node.bottomRight.isLeaf
      )
      {
        if (
            node.topLeft.val == node.topRight.val
            && node.topRight.val == node.bottomLeft.val
            && node.bottomLeft.val == node.bottomRight.val
        )
        {
          node = new Node(node.topLeft.val, true);
        }
      }

      return node;
    }
  }
}
