
namespace Iris.Presenters
{
    public class Presenter<T> where T : Views.IPresenterHost
    {
        protected Models.IPresentable Model { get; set; }
        protected T View { get; private set; }

        public Presenter(T viewIn)
        {
            this.View = viewIn;
        }
    }
}