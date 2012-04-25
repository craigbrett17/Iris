using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iris.Models;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.ComponentModel;
using Facebook;
using System.Drawing;

namespace Iris.Presenters
{
    /// <summary>
    /// Handles displaying of all the user's friends
    /// </summary>
    public class FriendsPresenter : Presenter<Views.IPresenterHost>
    {
        private ImageList _friendsImages;
        private ContextMenuStrip _friendsMenu;
        private BackgroundWorker pictureWorker;
        public delegate void PictureLoadedHandler(object sender, PictureLoadedEventArgs e);
        /// <summary>
        /// An event triggered when a new picture is finished loading
        /// </summary>
        public event PictureLoadedHandler PictureLoaded;
        /// <summary>
        /// A listview containing all the user's friends
        /// </summary>
        public ListView FriendsListView { get; set; }

        public FriendsPresenter(Views.IPresenterHost view)
            : base(view)
        {
            Model = new Friends();
            _friendsImages = new ImageList();
            FriendsListView = new ListView();
            _friendsMenu = new ContextMenuStrip();
            pictureWorker = new BackgroundWorker();
            pictureWorker.DoWork += pictureWorker_DoWork;
            pictureWorker.RunWorkerCompleted += pictureWorker_RunWorkerComplete;
            GenerateListView();
        }

        /// <summary>
        /// The ordered dictionary of the user's friends
        /// </summary>
        public Dictionary<string, string> Connections
        {
            get
            {
                var OrderedConnections = ((Friends)Model).Connections.OrderBy(f => f.Value).ToDictionary(f => f.Key, f => f.Value);
                return OrderedConnections;
            }
        }

        private void GenerateListView()
        {
            FriendsListView.View = System.Windows.Forms.View.Tile;
            FriendsListView.Dock = DockStyle.Fill;
            FriendsListView.FullRowSelect = true;
            FriendsListView.MultiSelect = false;
            FriendsListView.Name = "friendsListView";
            _friendsImages.ImageSize = new Size(50, 50);
            FriendsListView.LargeImageList = _friendsImages;
            _friendsMenu.RenderMode = ToolStripRenderMode.System;
            var friendViewMenuItem = new ToolStripMenuItem("&View Profile");
            friendViewMenuItem.Name = "friendViewMenuItem";
            _friendsMenu.Items.Add(friendViewMenuItem);
            var friendMessageMenuItem = new ToolStripMenuItem("Send &Message");
            friendMessageMenuItem.Name = "friendMessageMenuItem";
            _friendsMenu.Items.Add(friendMessageMenuItem);
            var friendPostMenuItem = new ToolStripMenuItem("&Post On Wall");
            friendPostMenuItem.Name = "friendPostMenuItem";
            _friendsMenu.Items.Add(friendPostMenuItem);
            var friendPokeMenuItem = new ToolStripMenuItem("Pok&e");
            friendPokeMenuItem.Name = "friendPokeMenuItem";
            _friendsMenu.Items.Add(friendPokeMenuItem);
            FriendsListView.ContextMenuStrip = _friendsMenu;
            ScreenReader.SayStringAsync("Loading friends list...", false);
            foreach (var connection in Connections)
            {
                ListViewItem viewItem = new ListViewItem();
                viewItem.Text = connection.Value;
                viewItem.ImageKey = connection.Key;
                FriendsListView.Items.Add(viewItem);
            }
            pictureWorker.RunWorkerAsync();
        }

        // TODO: This sort of thing should be moved to the model
        private void pictureWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            foreach (string uid in Connections.Keys)
            {
                string query = String.Format("SELECT pic_square FROM user WHERE uid={0};", uid);
                var result = Facade.Client.Get("fql", new { q = query }) as JsonObject;
                JsonArray data = result["data"] as JsonArray;
                string imageUrl = ((JsonObject)data[0])[0] as string;
                Image img = DownloadImage(imageUrl);
                if (img != null)
                {
                    _friendsImages.Images.Add(uid, img);
                    PictureLoaded(this, new PictureLoadedEventArgs(uid, img));
                }
            }
        }

        private void pictureWorker_RunWorkerComplete(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        // taken from a blog online http://www.digitalcoding.com/Code-Snippets/C-Sharp/C-Code-Snippet-Download-Image-from-URL.html
        private Image DownloadImage(string url)
        {
            Stream stream;
            WebResponse response;
            Image temp = null;
            try
            {
                HttpWebRequest request = HttpWebRequest.Create(url) as HttpWebRequest;
                request.AllowWriteStreamBuffering = true;
                response = request.GetResponse();
                stream = response.GetResponseStream();
                temp = Image.FromStream(stream);
                stream.Flush();
                stream.Close();
                response.Close();
            }
            catch (Exception ex)
            {

            }
            return temp;
        }

    }

    // This is a friends specific enough thing to be put here. For now.
    // TODO: Put this somewhere appropriate
    public class PictureLoadedEventArgs : EventArgs
    {
        public Image Image { get; set; }
        public string Key { get; set; }

        public PictureLoadedEventArgs(string key, Image img)
        {
            this.Key = key;
            this.Image = img;
        }

    }
}