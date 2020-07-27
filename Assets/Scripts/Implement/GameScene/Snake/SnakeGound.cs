using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YarLiong.Model
{
    public class SnakeGound : ISnakeGround
    {
        public SnakeGound(int width, int height)
        {
            mAllNodes = new SnakeNode[width, height];

            for (int i = 0; i < width; ++i)
                for (int j = 0; j < height; ++j)
                    mAllNodes[i, j] = new SnakeNode(i, j);

            Width = width;
            Height = height;
        }

        public int Width { get; protected set; }
        public int Height { get; protected set; }
        public INode[,] AllNodes => mAllNodes;

        protected SnakeNode[,] mAllNodes = null;

        public void Reset()
        {
            //for (int i = 0; i < Width; ++i)
            //    for (int j = 0; j < Height; ++j)
            //        mAllNodes[i, j].CurrentSnakeNodeState = SnakeNodeState.Empty;
        }
    }
}
