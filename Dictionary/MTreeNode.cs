using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using SafeControl.Base;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Windows.Forms;

namespace SafeControl.Dictionary
{
    /// <summary>
    /// Thư viện thao tác với TreeNode
    /// CreateBy: truongnm 05.02.2020
    /// </summary>
    [Serializable]
    public class MTreeNode : TreeNode
    {
        /// <summary>
        /// Hàm lấy nút cha
        /// CreateBy: truongnm 05.02.2020
        /// </summary>
        public TreeNode MGetParent(TreeNode oTreeNode)
        {
            return oTreeNode.Parent;
        }
        /// <summary>
        /// Hàm lấy FirstNode
        /// CreateBy: truongnm 05.02.2020
        /// </summary>
        public TreeNode MGetFirstNode(TreeNode oTreeNode)
        {
            return oTreeNode.FirstNode;
        }
        /// <summary>
        /// Hàm lấy các nút con
        /// CreateBy: truongnm 05.02.2020
        /// </summary>
        public TreeNodeCollection MGetSon(TreeNode oTreeNode)
        {
            return oTreeNode.Nodes;
        }
        /// <summary>
        /// Hàm về nút gốc
        /// CreateBy: truongnm 05.02.2020
        /// </summary>
        public void MToRoot(ref TreeNode oTreeNode)
        {
            if (!TreeNode.Equals(MGetParent(oTreeNode), null))
            {
                oTreeNode = MGetParent(oTreeNode);
                MToRoot(ref oTreeNode);
            }
        }
        /// <summary>
        /// Hàm duyệt cây theo thứ tự trước
        /// CreateBy: truongnm 05.02.2020
        /// </summary>
        public void MToPreorderWithResultNodeText(TreeNode oTreeNode, ref string sResultNodeText)
        {
            if (!TreeNode.Equals(oTreeNode, null))
                foreach (TreeNode item in MGetSon(oTreeNode))
                    if (!TreeNode.Equals(item, null))
                    {
                        sResultNodeText += string.Format("{0}+", item.Text);
                        MToPreorderWithResultNodeText(item, ref sResultNodeText);
                    }
        }
        /// <summary>
        /// Hàm tìm kiếm cây có giá trị NodeText = "string"
        /// CreateBy: truongnm 05.02.2020
        /// </summary>
        public void MSearchTreeByNodeTextWithPreorder(
            ref TreeNode oTreeNodeResult
            ,TreeNode oTreeNode
            , string sNodeText = ""
            )
        {
            if (oTreeNode != null)
            {
                foreach (TreeNode item in MGetSon(oTreeNode))
                {
                    if (item != null)
                    {
                        if (sNodeText != item.Text)
                            MSearchTreeByNodeTextWithPreorder(ref oTreeNodeResult, item, sNodeText);
                        else
                            oTreeNodeResult = item;
                    }
                }
            }
        }
        /// <summary>
        /// Hàm tìm kiếm cây có giá trị NodeTag = "string"
        /// CreateBy: truongnm 05.02.2020
        /// </summary>
        public void MSearchTreeByNodeTagWithPreorder(
            ref TreeNode oTreeNodeResult
            , TreeNode oTreeNode
            , string sNodeTag = ""
            )
        {
            if (oTreeNode != null)
            {
                foreach (TreeNode item in MGetSon(oTreeNode))
                {
                    if (item != null)
                    {
                        if (sNodeTag != item.Tag.ToString())
                            MSearchTreeByNodeTagWithPreorder(ref oTreeNodeResult, item, sNodeTag);
                        else
                            oTreeNodeResult = item;
                    }
                }
            }
        }
    }
}
