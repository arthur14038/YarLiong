namespace YarLiong.Model
{
    public interface IGrid
    {
        int Width { get; }
        int Height { get; }

        INode[] GetRowNodes(int y);
    }
}