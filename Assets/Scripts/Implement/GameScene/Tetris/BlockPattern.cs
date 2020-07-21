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

        private List<Node[]> mPatternModel;
        public List<Node[]> PatternModel { get { return mPatternModel; } }

        public int CurrentModelIndex = 0;

        public BlockPattern()
        {
            mPatternType = (BlockPattern.Pattern)Random.Range(1, 8);
            mPatternType = BlockPattern.Pattern.I;
            mPatternModel = GetModel(mPatternType);
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

        public void SetPatternType(Pattern pattern)
        {
            for (int i = 0; i < mBlockNodes.Length; i++)
            {
                mBlockNodes[i].SetBlockPattern(pattern);
            }
        }

        public List<Node[]> GetModel(Pattern pattern)
        {
            switch (pattern)
            {
                default:
                case Pattern.I:
                    return Pattern_I;
            }
        }

        //public int[,,] Pattern_I = new int[,,]
        //{
        //   { { 0, 1 }, { 1, 1 }, { 2, 1 }, { 3, 1 } },
        //   { { 2, 0 }, { 2, 1 }, { 2, 2 }, { 2, 3 } },
        //   { { 0, 2 }, { 1, 2 }, { 2, 2 }, { 3, 2 } },
        //   { { 1, 0 }, { 1, 1 }, { 1, 2 }, { 1, 3 } },
        //};

        public List<Node[]> Pattern_I = new List<Node[]>()
        {
            new Node[4] { new Node(0, 1), new Node(1, 1) , new Node(2, 1) , new Node(3, 1) },
            new Node[4] { new Node(2, 0), new Node(2, 1) , new Node(2, 2) , new Node(2, 3) },
            new Node[4] { new Node(0, 2), new Node(1, 2) , new Node(2, 2) , new Node(3, 2) },
            new Node[4] { new Node(1, 0), new Node(1, 1) , new Node(1, 2) , new Node(1, 3) },
        };
    }

}