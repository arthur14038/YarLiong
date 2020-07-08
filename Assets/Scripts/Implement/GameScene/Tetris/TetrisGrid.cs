namespace YarLiong.Model
{
    public class TetrisGrid : IGrid
    {
        BlockNode[,] mAllNodes;

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
            for(int i = 0; i < Width; i++)
            {
                rowNodes[i] = mAllNodes[i, y];
            }
            return rowNodes;
        }
    }
}