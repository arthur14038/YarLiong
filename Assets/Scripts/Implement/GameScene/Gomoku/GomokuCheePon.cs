using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YarLiong.Model
{
    public class GomokuCheePon : CheePon
    {
        List<GomokuNode> mAllGomokuNodes;

        public GomokuCheePon(int width, int height) : base(width, height)
        {
            mAllGomokuNodes = new List<GomokuNode>();
            for (int i = 0; i < height; ++i)
                for (int j = 0; j < width; ++j)
                    mAllGomokuNodes.Add(new GomokuNode(j, i, width, height));

            Width = width;
            Height = height;
        }

        public override INode[] AllNodes => mAllGomokuNodes.ToArray();
    }
}