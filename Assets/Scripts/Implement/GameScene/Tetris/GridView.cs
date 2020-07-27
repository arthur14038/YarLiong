using UnityEngine;
using UnityEngine.UI;
using YarLiong.Model;

namespace YarLiong.View
{
    public class GridView : MonoBehaviour, IGridView
    {
        [SerializeField]
        GridLayoutGroup m_GridLayoutGroup = null;

        [SerializeField]
        BlockView m_BlockView = null;

        BlockView[,] mBlockViews;

        private void Start()
        {
            m_GridLayoutGroup.startAxis = GridLayoutGroup.Axis.Vertical;
        }

        public void SetSize(IGrid grid)
        {
            mBlockViews = new BlockView[grid.Width, grid.Height];
            for (int i = 0; i < grid.Width; i++)
            {
                for (int j = 0; j < grid.Height; j++)
                {
                    var block = GetBlock();
                    block.name = string.Format("Block({0},{1})", i, j);
                    block.SetBlockColor(BlockNode.BlockType.None);
                    block.gameObject.SetActive(true);

                    mBlockViews[i, j] = block;
                }
            }
        }

        BlockView GetBlock()
        {
            return Instantiate(m_BlockView, m_GridLayoutGroup.transform);
        }

        public void SetBlockView(BlockNode[] blockNodes)
        {
            for (int i = 0; i < blockNodes.Length; i++)
            {
                var block = blockNodes[i];
                var pattern = block.PatternType;
                var blockView = mBlockViews[block.X, block.Y];
                blockView.SetBlockColor(pattern);
                //for debug
                if (pattern == BlockPattern.Pattern.None)
                    blockView.SetText(string.Empty);
                else
                    blockView.SetText(block.ToString());
                Debug.Log(block.ToString());
            }
        }
    }
}