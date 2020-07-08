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

        public void SetSize(IGrid grid)
        {
            for (int i = 0; i < grid.Width; i++)
            {
                for (int j = 0; j < grid.Height; j++)
                {
                    var block = GetBlock();
                    block.SetBlockColor(BlockNode.BlockType.None);
                    block.gameObject.SetActive(true);
                }
            }
        }

        BlockView GetBlock()
        {
            return Instantiate(m_BlockView, m_GridLayoutGroup.transform);
        }
    }
}