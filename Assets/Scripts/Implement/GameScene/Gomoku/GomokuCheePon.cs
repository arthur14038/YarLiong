using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YarLiong.Model
{
    public class GomokuCheePon : CheePon
    {
        public GomokuCheePon(int width, int height) : base(width, height)
        {
            mAllNodes = new Node[width, height];
            for (int i = 0; i < width; ++i)
                for (int j = 0; j < height; ++j)
                    mAllNodes[i, j] = new GomokuNode(i, j, width, height);

            Width = width;
            Height = height;
        }


    }
}