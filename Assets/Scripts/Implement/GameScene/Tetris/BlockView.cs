using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YarLiong.Model;

namespace YarLiong.View
{
    public class BlockView : MonoBehaviour
    {
        [SerializeField]
        Image m_BlockImg = null;

        Color mNoneColor = Color.gray;
        Color mFallingColor = Color.yellow;
        Color mStuckColor = Color.blue;

        public void SetBlockColor(BlockNode.BlockType blockType)
        {
            switch (blockType)
            {
                case BlockNode.BlockType.None:
                    m_BlockImg.color = mNoneColor;
                    break;
                case BlockNode.BlockType.Falling:
                    m_BlockImg.color = mFallingColor;
                    break;
                case BlockNode.BlockType.Stuck:
                    m_BlockImg.color = mStuckColor;
                    break;
            }
        }
    }
}