using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iris.Models;
using Facebook;
using System.Windows.Forms;
using System.Drawing;
using Iris.Views;

namespace Iris.Presenters
{
    public class NewsFeedPresenter : Presenter<Views.IPresenterHost>
    {
        public StoryListBox NewsListBox { get; set; }

        public NewsFeedPresenter(Views.IPresenterHost view)
            : base(view)
        {
            this.Model = new NewsFeed();
            NewsListBox = new StoryListBox();
            GenerateListBox();
        }

        public Facebook.JsonArray NewsItems
        {
            get
            {
                return ((NewsFeed)Model).NewsItems;
            }
        }

        private void GenerateListBox()
        {
            NewsListBox.Dock = DockStyle.Fill;
            NewsListBox.SelectionMode = SelectionMode.One;
            NewsListBox.Name = "newsListBox";
            foreach (JsonObject item in NewsItems)
            {
                Story viewItem = new Story(item);
                NewsListBox.Items.Add(viewItem);
            }
        }

    }
}