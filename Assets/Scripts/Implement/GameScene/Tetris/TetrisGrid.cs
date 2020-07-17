namespace YarLiong.Model
{
    public class TetrisGrid : IGrid
    {
        BlockNode[,] mAllNodes;
        public BlockNode[,] AllNodes { get { return mAllNodes; } }

        public TetrisGrid(int width, int height)
        {
            Width = width;
            Height = height;

            mAllNodes = new BlockNode[width, height];

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    mAllNodes[i, j] = new BlockNode(i, j);
                }
            }
        }

        public int Width { get; private set; }

        public int Height { get; private set; }

        public INode[] GetRowNodes(int y)
        {
            Node[] rowNodes = new Node[Width];
            for (int i = 0; i < Width; i++)
            {
                rowNodes[i] = mAllNodes[i, y];
            }
            return rowNodes;
        }

        public BlockNode GetNode(int x, int y)
        {
            if (x >= 0 && y >= 0 && x < mAllNodes.GetLength(0) && y < mAllNodes.GetLength(1))
                return mAllNodes[x, y];

            return null;
        }

        public bool IsInBound(BlockNode blockNode)
        {
            if (blockNode.X >= 0 && blockNode.Y >= 0 && blockNode.X < mAllNodes.GetLength(0) && blockNode.Y < mAllNodes.GetLength(1))
                return true;

            return false;
        }

        /// <summary>
        /// 方塊是否觸底
        /// </summary>
        public bool IsGround(BlockNode[] blockNodes)
        {
            for(int i = 0; i < blockNodes.Length; i++)
            {
                if (blockNodes[i].Y == mAllNodes.GetLength(1) - 1)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 是否被方塊擋住(下一格是否有方塊)
        /// </summary>
        public bool IsBlock(BlockNode[] blockNodes, int direction)
        {
            for (int i = 0; i < blockNodes.Length; i++)
            {
                //取得下一格的方塊
                BlockNode block = null;
                switch (direction)
                {
                    case 0:
                        block = GetNode(blockNodes[i].X, blockNodes[i].Y + 1);
                        break;
                    case 1:
                        block = GetNode(blockNodes[i].X + 1, blockNodes[i].Y);
                        break;
                    case 2:
                        block = GetNode(blockNodes[i].X - 1, blockNodes[i].Y);
                        break;
                }

                if (block != null && block.Type == BlockNode.BlockType.Stuck)
                    return true;
            }
            return false;
        }
    }
}