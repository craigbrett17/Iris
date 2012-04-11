using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iris.Models;

namespace Iris.Presenters
{
    public class NewStatusPresenter : Presenter<Views.IPresenterHost>
    {
        public string Message { get; set; }
        
        public NewStatusPresenter(Views.IPresenterHost viewIn)
            : base(viewIn)
        {
            Model = new Post();
        }

        public void PostStatus()
        {
            ((Post)Model).Message = this.Message;
            bool result = ((Post)Model).MakePost();
            if (result == true)
            {
                ScreenReader.sayString("Update successful", false);
            }
            else
            {
                ScreenReader.sayString("Update failed", false);
            }
        }

    }
}