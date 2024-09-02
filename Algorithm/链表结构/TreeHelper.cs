using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.链表结构
{
    public class TreeHelper
    {
        /// <summary>
        /// 使用递归方法建树
        /// </summary>
        public static List<TreeNode> BulidTreeByRecursive(List<TreeNode> treeNodes, List<TreeNode> resps, string pID)
        {
            resps = new List<TreeNode>();
            List<TreeNode> tempList = treeNodes.Where(c => c.ParentId == pID).ToList();

            for (int i = 0; i < tempList.Count; i++)
            {
                TreeNode node = new TreeNode();
                node.Id = tempList[i].Id;
                node.ParentId = tempList[i].ParentId;
                node.Name = tempList[i].Name;
                node.Children = BulidTreeByRecursive(treeNodes, resps, node.Id);
                resps.Add(node);
            }

            return resps;
        }

        /// <summary>
        /// 双层循环
        /// </summary>
        /// <param name="treeNodes"></param>
        /// <returns></returns>
        public static List<TreeNode> BulidTree(List<TreeNode> treeNodes)
        {
            try
            {
                List<TreeNode> trees = new List<TreeNode>();

                foreach (var treeNode in treeNodes)
                {
                    if ("0" == (treeNode.ParentId))
                    {
                        trees.Add(treeNode);
                    }

                    foreach (var it in treeNodes)
                    {
                        if (it.ParentId == treeNode.Id)
                        {
                            treeNode.Children.Add(it);
                        }
                    }
                }
                return trees;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
