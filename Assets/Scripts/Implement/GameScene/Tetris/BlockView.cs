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

        Color mPatternColor_S = Color.red;
        Color mPatternColor_Z = Color.green;
        Color mPatternColor_L = new Color(0.8f, 0.4f, 0f);
        Color mPatternColor_J = new Color(0f, 0f, 0.8f);
        Color mPatternColor_T = new Color(0.6f, 0f, 0.8f);
        Color mPatternColor_O = Color.yellow;
        Color mPatternColor_I = Color.cyan;

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

        public void SetBlockColor(BlockNode.BlockPattern blockPattern)
        {
            switch (blockPattern)
            {
                case BlockNode.BlockPattern.None:
                    m_BlockImg.color = mNoneColor;
                    break;
                case BlockNode.BlockPattern.S:
                    m_BlockImg.color = mPatternColor_S;
                    break;
                case BlockNode.BlockPattern.Z:
                    m_BlockImg.color = mPatternColor_Z;
                    break;
                case BlockNode.BlockPattern.L:
                    m_BlockImg.color = mPatternColor_L;
                    break;
                case BlockNode.BlockPattern.J:
                    m_BlockImg.color = mPatternColor_J;
                    break;
                case BlockNode.BlockPattern.T:
                    m_BlockImg.color = mPatternColor_T;
                    break;
                case BlockNode.BlockPattern.O:
                    m_BlockImg.color = mPatternColor_O;
                    break;
                case BlockNode.BlockPattern.I:
                    m_BlockImg.color = mPatternColor_I;
                    break;
            }
        }
    }
}