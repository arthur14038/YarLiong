using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YarLiong.Model
{
    [Flags]
    public enum GomokuNodeFlags
    {
        None = 0,
        Up = 1,
        Down = 2,
        Right = 4,
        Left = 8,
        All = Up | Down | Right | Left,
    }

    public enum GomokuNodeState
    {
        Empty,
        Black,
        White,
    }

    public class GomokuNode : Node
    {
        public GomokuNodeFlags ThisNodeFlags;
        public GomokuNodeState CurrentGomokuNodeState;

        public GomokuNode(int x, int y, int width, int height) : base(x, y)
        {
            ThisNodeFlags = GomokuNodeFlags.None;
            if(x != 0)
                ThisNodeFlags |= GomokuNodeFlags.Left;
            if (x != width-1)
                ThisNodeFlags |= GomokuNodeFlags.Right;
            if(y != 0)
                ThisNodeFlags |= GomokuNodeFlags.Up;
            if (y != height - 1)
                ThisNodeFlags |= GomokuNodeFlags.Down;

            CurrentGomokuNodeState = GomokuNodeState.Empty;
        }
    }
}
