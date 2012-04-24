using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iris.Models;

namespace Iris.Presenters
{
    public class NewWallPostPresenter : Presenter<Views.IPresenterHost>
    {
        public string Recipient { get; set; }
        public string Message { get; set; }

        public NewWallPostPresenter(Views.IPresenterHost viewIn, string idIn)
            : base(viewIn)
        {
            this.Recipient = idIn;
            Model = new Post(this.Recipient);
        }

        public void PostToWall()
        {
            ((Post)Model).Message = this.Message;
            bool result = ((Post)Model).MakePost();
            if (result == true)
            {
                ScreenReader.sayString("Post successful", false);
            }
            else
            {
                ScreenReader.sayString("Post failed", false);
            }
        }

    }
}