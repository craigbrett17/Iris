using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iris.Models;

namespace Iris.Presenters
{
    public class NewsFeedPresenter : Presenter<Views.IPresenterHost>
    {
        public NewsFeedPresenter(Views.IPresenterHost view)
            : base(view)
        {
            this.Model = new NewsFeed();
        }

        public Facebook.JsonArray NewsItems
        {
            get
            {
                return ((NewsFeed)Model).NewsItems;
            }
        }
    }
}