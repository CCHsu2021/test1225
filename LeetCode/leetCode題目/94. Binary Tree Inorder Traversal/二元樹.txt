/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
        Stack<TreeNode> stack = new Stack<TreeNode>();
    
    public IList<int> InorderTraversal(TreeNode root) {
        var res = new List<int>();
        
        TraverseLeft(root);
        
        while(stack.Count > 0)
        {
            var node = stack.Pop();
            res.Add(node.val);
            TraverseLeft(node.right);
        }
        
        return res;
    }
    
    private void TraverseLeft(TreeNode node)
    {
        while(node != null)
        {
            stack.Push(node);
            node = node.left;
        }
    }
}