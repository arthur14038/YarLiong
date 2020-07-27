using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YarLiong.Model
{
    public enum SnakeNodeState
    {
        Empty,
        Body,
        Apple,
    }

    public class SnakeNode : Node
    {
        public SnakeNode(int x, int y) : base(x, y)
        {

        }
    }
}