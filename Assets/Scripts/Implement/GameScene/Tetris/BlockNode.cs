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

        public enum BlockPattern
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

        BlockType mBlockType = BlockType.None;
        BlockPattern mBlockPattern = BlockPattern.None;

        public BlockType Type { get { return mBlockType; } }
        public BlockPattern Pattern { get { return mBlockPattern; } }

        public BlockNode(int x, int y) : base(x, y)
        {
            mBlockType = BlockType.None;
            mBlockPattern = BlockPattern.None;
        }

        public void SetBlockType(BlockType blockType)
        {
            mBlockType = blockType;
        }

        public void SetBlockPattern(BlockPattern blockPattern)
        {
            mBlockPattern = blockPattern;
        }
    }
}