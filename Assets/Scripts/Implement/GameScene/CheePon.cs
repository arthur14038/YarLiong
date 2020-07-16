using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YarLiong.Model
{
    public class CheePon : ICheePon
    {
        public CheePon(int width, int height)
        {
            mAllNodes = new Node[width, height];
            for (int i = 0; i < width; ++i)
                for (int j = 0; j < height; ++j)
                    mAllNodes[i, j] = new Node(i, j);

            Width = width;
            Height = height;
        }

        Node[,] mAllNodes = null;

        public int Width { get; protected set; }
        public int Height { get; protected set; }
        public virtual INode[] AllNodes => throw new System.NotImplementedException();

        public virtual INode[] GetColumnNodes(int x)
        {
            throw new System.NotImplementedException();
        }

        public virtual INode[] GetLeftObliqueNodes(int x, int y)
        {
            throw new System.NotImplementedException();
        }

        public virtual INode[] GetRightObliqueNodes(int x, int y)
        {
            throw new System.NotImplementedException();
        }

        public virtual INode[] GetRowNodes(int y)
        {
            throw new System.NotImplementedException();
        }
    }
}