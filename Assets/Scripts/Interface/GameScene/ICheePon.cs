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

        void ClearCheePon();
    }
}