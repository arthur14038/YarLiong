using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YarLiong.Model;

namespace YarLiong.View
{
    public interface ISnakeGroundNodeView : INodeView
    {
        void SetNodeState(SnakeNodeState snakeNodeState);
    }
}