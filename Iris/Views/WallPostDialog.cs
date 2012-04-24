using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Iris.Presenters;

namespace Iris.Views
{
    public partial class WallPostDialog : Form, IPresenterHost
    {
        Presenter<IPresenterHost> _presenter;
        
        public string Id { get; set; }
        public string RecipientName { get; set; }

        public WallPostDialog(string uid, string name)
        {
            InitializeComponent();
            this.Id = uid;
            this.RecipientName = name;
            this.Text += RecipientName; // update the title bar
            NewWallPostPresenter newPresenter = new NewWallPostPresenter(this, this.Id);
            _presenter = newPresenter;
            postBox.DataBindings.Add("Text", newPresenter, "Message");
        }

        private void locationButton_Click(object sender, EventArgs e)
        {

        }

        private void friendsButton_Click(object sender, EventArgs e)
        {

        }

        private void audienceButton_Click(object sender, EventArgs e)
        {

        }

        private void postButton_Click(object sender, EventArgs e)
        {
            try
            {
                ((NewWallPostPresenter)_presenter).PostToWall();
                this.Close();
            }
            catch (Facebook.FacebookApiException ex)
            {
                MessageBox.Show(ex.Message, "Error in request", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Iris Unhandled exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}