using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YarLiong.Model
{
    public interface ISnakeGround
    {
        int Width { get; }
        int Height { get; }
        INode[,] AllNodes { get; }

        void Reset();
    }
}