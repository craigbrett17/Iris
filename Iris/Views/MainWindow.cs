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
                NewsFeedPresenter newsFeedPresenter = new NewsFeedPresenter(this);
                _presenter = newsFeedPresenter;
                contentPanel.Controls.Clear();
                contentPanel.Controls.Add(newsFeedPresenter.NewsListView);
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

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void newsFeedMenuItem_Click(object sender, EventArgs e)
        {
            DisplayNewsFeed();
        }

    }
}