namespace YarLiong.Model
{
    public enum GameType
    {
        Gomoku,
        Tetris,
        Snake
    }

    public interface IMainGameModel
    {
        string GetLoadingTips();

        GameType CurrentGameType { get; set; }
}
}