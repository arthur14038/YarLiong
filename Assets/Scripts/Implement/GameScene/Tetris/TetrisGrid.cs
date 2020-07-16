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
    }
}