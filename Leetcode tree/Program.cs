class Leetcode
{
    public IList<int> InorderTraversal(TreeNode root) 
    {
        var result = new List<int>();
        Inorder(root, result);
        return result;
    }
    
    void Inorder(TreeNode node, List<int> result) 
    {
        if (node == null) 
        {
            return;
        }
        Inorder(node.left, result);
        result.Add(node.val);
        Inorder(node.right, result);
    }
}
public class TreeNode {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
          this.val = val;
          this.left = left;
          this.right = right;
      }
  }
  public class Solution {
    public int RangeSumBST(TreeNode root, int low, int high) {
        return DFS(root, low, high);
    }

    private int DFS(TreeNode node, int low, int high) {
        if (node == null) {
            return 0;
        }

        int sum = 0;
        if (node.val >= low && node.val <= high) {
            sum += node.val;
        }

        if (node.val > low) {
            sum += DFS(node.left, low, high);
        }

        if (node.val < high) {
            sum += DFS(node.right, low, high);
        }

        return sum;
    }
}


