using Iris.Models;

namespace Iris.Presenters
{
    public class Presenter<T> where T : Views.IPresenterHost
    {
        protected IPresentable Model { get; set; }
        protected T View { get; private set; }

        public Presenter(T viewIn)
        {
            this.View = viewIn;
        }

        #region NonPresenterSpecificMethods

        public void PokeFriend(string id, string name)
        {
            Poke poke = new Poke(id);
        }

        #endregion

    }
}