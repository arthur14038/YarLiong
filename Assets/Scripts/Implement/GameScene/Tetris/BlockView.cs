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
        [SerializeField]
        Text m_Text = null;

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

        public void SetBlockColor(BlockPattern.Pattern patternType)
        {
            switch (patternType)
            {
                case BlockPattern.Pattern.None:
                    m_BlockImg.color = mNoneColor;
                    break;
                case BlockPattern.Pattern.S:
                    m_BlockImg.color = mPatternColor_S;
                    break;
                case BlockPattern.Pattern.Z:
                    m_BlockImg.color = mPatternColor_Z;
                    break;
                case BlockPattern.Pattern.L:
                    m_BlockImg.color = mPatternColor_L;
                    break;
                case BlockPattern.Pattern.J:
                    m_BlockImg.color = mPatternColor_J;
                    break;
                case BlockPattern.Pattern.T:
                    m_BlockImg.color = mPatternColor_T;
                    break;
                case BlockPattern.Pattern.O:
                    m_BlockImg.color = mPatternColor_O;
                    break;
                case BlockPattern.Pattern.I:
                    m_BlockImg.color = mPatternColor_I;
                    break;
            }
        }

        public void SetText(string text)
        {
            m_Text.text = text;
        }
    }
}