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

        public BlockNode(int x, int y) : base(x, y)
        {
            mBlockType = BlockType.None;
        }

        public void SetBlockType(BlockType blockType)
        {
            mBlockType = blockType;
        }
    }
}