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
    public partial class NewStatusDialog : Form, IPresenterHost
    {
        Presenter<IPresenterHost> _presenter;

        public NewStatusDialog()
        {
            InitializeComponent();
            NewStatusPresenter newPresenter = new NewStatusPresenter(this);
            _presenter = newPresenter;
            statusBox.DataBindings.Add("Text", newPresenter, "Message");
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
            ((NewStatusPresenter)_presenter).PostStatus();
            System.Threading.Thread.Sleep(3000);
            this.Close();
        }

    }
}