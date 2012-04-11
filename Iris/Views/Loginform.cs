using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Facebook;

namespace Iris
{
    /// <summary>
    /// A form that retrieves the access token from Facebook
    /// </summary>
    public partial class Loginform : Form
    {
        public Loginform()
        {
            InitializeComponent();
        }

        private void Loginform_Load(object sender, EventArgs e)
        {
            webBrowser.Navigate(GenerateAuthenticationUrl());
        }

        private void webBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            FacebookOAuthResult result;
            if (FacebookOAuthResult.TryParse(e.Url, out result))
            {
                this.Result = result;
                this.DialogResult = result.IsSuccess ? DialogResult.OK : DialogResult.No;
            }
            else
            {
                this.Result = null;
            }
        }

        public FacebookOAuthResult Result { get; private set; }

        private Uri GenerateAuthenticationUrl()
        {
            string _appId = "323667051013078";
            string[] _extendedPermissions = new[]
            {
                "user_birthday", "user_events", "user_groups", "user_likes", "user_notes", "user_photos", "user_questions", "user_relationships", "user_status", "user_videos", 

                "publish_stream", "offline_access", "read_stream"
            };
            var oauth = new FacebookOAuthClient { AppId = _appId };
            var parameters = new Dictionary<string, object>
            {
                        { "response_type", "token" },
                        { "display", "popup" }
            };
            if (_extendedPermissions != null && _extendedPermissions.Length > 0)
            {
                var scope = new StringBuilder();
                scope.Append(string.Join(",", _extendedPermissions));
                parameters["scope"] = scope.ToString();
            }
            return oauth.GetLoginUrl(parameters);
        }

    }
}