using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iris.Models;
using Facebook;
using System.Windows.Forms;
using System.Drawing;

namespace Iris.Presenters
{
    public class NewsFeedPresenter : Presenter<Views.IPresenterHost>
    {
        public ListView NewsListView { get; set; }

        public NewsFeedPresenter(Views.IPresenterHost view)
            : base(view)
        {
            this.Model = new NewsFeed();
            NewsListView = new ListView();
            GenerateListView();
        }

        public Facebook.JsonArray NewsItems
        {
            get
            {
                return ((NewsFeed)Model).NewsItems;
            }
        }

        private void GenerateListView()
        {
            NewsListView.View = System.Windows.Forms.View.Tile;
            NewsListView.Dock = DockStyle.Fill;
            NewsListView.FullRowSelect = true;
            NewsListView.MultiSelect = false;
            NewsListView.Name = "newsListView";
            foreach (JsonObject item in NewsItems)
            {
                ListViewItem viewItem = new ListViewItem();
                StringBuilder itemText = new StringBuilder();
                DateTime createTime = DateTimeConvertor.FromIso8601FormattedDateTime(item["created_time"].ToString());
                if (item.ContainsKey("story"))
                {
                    itemText.AppendLine(item["story"] as string);
                }
                else
                {
                    itemText.Append(((JsonObject)item["from"])["name"] as string);
                    itemText.Append(" posted");
                    if (item.ContainsKey("type"))
                    {
                        switch (item["type"] as string)
                        {
                            case "link":
                                itemText.Append(" a link");
                                break;
                            case "photos":
                                itemText.Append(" a photo");
                                break;
                            default:
                                break;
                        }
                    }
                    itemText.AppendLine(": ");
                    if (item.ContainsKey("message"))
                    {
                        itemText.AppendLine(item["message"] as string);
                    } 
                }
                itemText.AppendLine(createTime.ToString("HH:mm"));
                viewItem.Text = itemText.ToString();
                NewsListView.Items.Add(viewItem);
            }
        }

    }
}