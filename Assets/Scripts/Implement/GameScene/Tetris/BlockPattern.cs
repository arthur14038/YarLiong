using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YarLiong.Model
{
    public class BlockPattern
    {
        public enum Pattern
        {
            None,
            S,
            Z,
            L,
            J,
            T,
            O,
            I,
        }

        BlockNode[] mBlockNodes = null;
        public BlockNode[] BlockNodes { get { return mBlockNodes; } }

        public int Length { get { return (mBlockNodes == null) ? 0 : mBlockNodes.Length; } }

        Pattern mPatternType = Pattern.None;
        public Pattern PatternType { get { return mPatternType; } }

        //private List<Node[]> mPatternModel;
        //public List<Node[]> PatternModel { get { return mPatternModel; } }

        public int CurrentModelIndex = 0;

        public Vector3 Pivot { get; set; }

        public BlockPattern()
        {
            mPatternType = (BlockPattern.Pattern)Random.Range(1, 8);
            //mPatternType = BlockPattern.Pattern.I;
            //mPatternModel = GetModel(mPatternType);
        }

        //public BlockPattern(BlockNode[] blockNodes, Pattern pattern)
        //{
        //    mBlockNodes = blockNodes;
        //    mPatternType = pattern;
        //}

        public void SetBlockNodes(BlockNode[] blockNodes)
        {
            mBlockNodes = blockNodes;
            SetPatternType(mPatternType);
        }

        public void InitPivot(Pattern pattern)
        {
            switch (pattern)
            {
                case BlockPattern.Pattern.S:
                case BlockPattern.Pattern.Z:
                case BlockPattern.Pattern.L:
                case BlockPattern.Pattern.J:
                case BlockPattern.Pattern.T:
                    Pivot = BlockNodes[2].Point;
                    return;
                case BlockPattern.Pattern.O:
                    Pivot = new Vector3(BlockNodes[0].X + 0.5f, BlockNodes[0].Y + 0.5f, 0f);
                    return;
                case Pattern.I:
                    Pivot = new Vector3(BlockNodes[2].X - 0.5f, BlockNodes[2].Y + 0.5f, 0f);
                    break;
            }
        }

        public void SetPatternType(Pattern pattern)
        {
            for (int i = 0; i < mBlockNodes.Length; i++)
            {
                mBlockNodes[i].SetBlockPattern(pattern);
            }
        }

        //public List<Node[]> GetModel(Pattern pattern)
        //{
        //    switch (pattern)
        //    {
        //        default:
        //        case Pattern.I:
        //            return Pattern_I;
        //    }
        //}

        //public List<Node[]> Pattern_I = new List<Node[]>()
        //{
        //    new Node[4] { new Node(0, 1), new Node(1, 1) , new Node(2, 1) , new Node(3, 1) },
        //    new Node[4] { new Node(2, 0), new Node(2, 1) , new Node(2, 2) , new Node(2, 3) },
        //    new Node[4] { new Node(0, 2), new Node(1, 2) , new Node(2, 2) , new Node(3, 2) },
        //    new Node[4] { new Node(1, 0), new Node(1, 1) , new Node(1, 2) , new Node(1, 3) },
        //};
    }

}