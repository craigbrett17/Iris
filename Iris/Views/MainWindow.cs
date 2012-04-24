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
                contentPanel.Controls.Add(newsFeedPresenter.NewsListBox);
                contentPanel.Controls[0].Focus();
                MessageBox.Show("The box contains " + newsFeedPresenter.NewsListBox.Items.Count + " items.");
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
                // TODO: Tidy this up a little.
                friendsPresenter.FriendsListView.ContextMenuStrip.Items[2].Click += friendPostMenuItem_Click;
                friendsPresenter.FriendsListView.ContextMenuStrip.Items[3].Click += friendPokeMenuItem_Click;
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

        public void UpdateFriendsListPictures(object sender, PictureLoadedEventArgs e)
        {
            ListView list = contentPanel.Controls.Find("friendsListView", false)[0] as ListView;
            if (list != null)
            {
                list.LargeImageList.Images.Add(e.Key, e.Image);
            }
        }

        public void friendPostMenuItem_Click(object sender, EventArgs e)
        {
            if (contentPanel.Controls[0] is ListView && ((ListView)contentPanel.Controls[0]).SelectedItems.Count == 1)
            {
                string uid = ((ListView)contentPanel.Controls[0]).SelectedItems[0].ImageKey;
                string name = ((ListView)contentPanel.Controls[0]).SelectedItems[0].Text;
                WallPostDialog dialog = new WallPostDialog(uid, name);
                dialog.ShowDialog();
            }
        }

        public void friendPokeMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (contentPanel.Controls[0] is ListView && ((ListView)contentPanel.Controls[0]).SelectedItems.Count == 1)
                {
                    string uid = ((ListView)contentPanel.Controls[0]).SelectedItems[0].ImageKey;
                    string name = ((ListView)contentPanel.Controls[0]).SelectedItems[0].Text;
                    _presenter.PokeFriend(uid, name);
                    UpdateStatusBar("You have poked " + name);
                }
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

        public void UpdateStatusBar(string message)
        {
            statusBar.Items.Clear();
            ToolStripStatusLabel label = new ToolStripStatusLabel(message);
            statusBar.Items.Add(label);
            ScreenReader.sayString(label.Text, false);
        }

    }
}