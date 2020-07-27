using UnityEngine;

namespace YarLiong.Model
{
    public class BlockNode : Node
    {
        public enum BlockType
        {
            None = 0,
            Falling = 1,
            Stuck = 2,
        }

        BlockType mBlockType = BlockType.None;
        BlockPattern.Pattern mPatternType = BlockPattern.Pattern.None;

        public BlockType Type { get { return mBlockType; } }
        public BlockPattern.Pattern PatternType { get { return mPatternType; } }

        Vector3 mPoint = new Vector3();
        public Vector3 Point { get { return mPoint; } }

        public BlockNode(int x, int y) : base(x, y)
        {
            mPoint.Set(x, y, 0);

            mBlockType = BlockType.None;
            mPatternType = BlockPattern.Pattern.None;
        }

        public void SetBlockType(BlockType blockType)
        {
            mBlockType = blockType;
        }

        public void SetBlockPattern(BlockPattern.Pattern blockPattern)
        {
            mPatternType = blockPattern;
        }

        public override string ToString()
        {
            return string.Format("({0},{1})", X, Y);
        }
    }
}