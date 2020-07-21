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

        public BlockNode(int x, int y) : base(x, y)
        {
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
    }
}