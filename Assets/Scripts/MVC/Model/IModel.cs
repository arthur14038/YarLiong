namespace YarLiong.Model
{
    public interface IModel
    {
        float ScrollViewValue
        {
            get;
            set;
        }

        string GetLoadingTips();
    }
}