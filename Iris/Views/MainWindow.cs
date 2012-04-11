using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using Iris.Presenters;
using Facebook;

namespace Iris.Views
{
    public partial class MainWindow : Form, IPresenterHost
    {
        Presenter<IPresenterHost> _presenter;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            DisplayNewsFeed();
        }

        private void DisplayNewsFeed()
        {
            try
            {
                _presenter = new NewsFeedPresenter(this);
                var presenterObject = _presenter as NewsFeedPresenter;
                JsonArray newsObject = presenterObject.NewsItems;
                // TODO: Get presenter's info to display on the form somewhere
                MessageBox.Show(String.Format("Retrieved {0} stories in the past 2 hours. Now if only we knew what to do with them...", newsObject.Count), "News feed retrieved",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (FacebookApiException ex)
            {
                MessageBox.Show(ex.Message, "Error in request", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Iris Unhandled exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void allFriendsMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FriendsPresenter friendsPresenter = new FriendsPresenter(this);
                _presenter = friendsPresenter;
                friendsPresenter.PictureLoaded += UpdateFriendsListPictures;
                contentPanel.Controls.Clear();
                contentPanel.Controls.Add(friendsPresenter.FriendsListView);
                contentPanel.Controls[0].Focus();
            }
            catch (FacebookApiException ex)
            {
                MessageBox.Show(ex.Message, "Error in request", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Iris Unhandled exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateFriendsListPictures(object sender, PictureLoadedEventArgs e)
        {
            ListView list = contentPanel.Controls.Find("friendsListView", false)[0] as ListView;
            if (list != null)
            {
                list.LargeImageList.Images.Add(e.Key, e.Image);
            }
        }

        private void newStatusMenuItem_Click(object sender, EventArgs e)
        {
            NewStatusDialog dialog = new NewStatusDialog();
            dialog.ShowDialog();
        }

    }
}