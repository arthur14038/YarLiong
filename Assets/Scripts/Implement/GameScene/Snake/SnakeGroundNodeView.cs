using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YarLiong.Model;
using YarLiong.View;

public class SnakeGroundNodeView : MonoBehaviour, ISnakeGroundNodeView
{
    [SerializeField]
    Image m_ImageBG = null;

    Color mEmptyColor = Color.white;

    public void SetNode(INode node)
    {
        mEmptyColor = (node.X + node.Y) % 2 == 0 ? (Color.white + Color.green) / 2f : (Color.green + Color.black) / 2f;
        m_ImageBG.color = mEmptyColor;
    }

    public void SetNodeState(SnakeNodeState snakeNodeState)
    {
        switch (snakeNodeState)
        {
            case SnakeNodeState.Apple:
                m_ImageBG.color = Color.red;
                break;
            case SnakeNodeState.Body:
                m_ImageBG.color = Color.black;
                break;
            case SnakeNodeState.Empty:
                m_ImageBG.color = mEmptyColor;
                break;
        }
    }
}
