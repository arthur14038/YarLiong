using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YarLiong.Model
{
    public interface ICheePon
    {
        int Width { get; }
        int Height { get; }
        INode[,] AllNodes { get; }

        INode[] GetRowNodes(int y);

        INode[] GetColumnNodes(int x);

        INode[] GetLeftObliqueNodes(int x, int y);

        INode[] GetRightObliqueNodes(int x, int y);

        INode GetCertainNode(int x, int y);
    }
}