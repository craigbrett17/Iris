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
        private FacebookClient client;
        
        public Loginform()
        {
            InitializeComponent();
            client = new FacebookClient();
        }

        private void Loginform_Load(object sender, EventArgs e)
        {
            webBrowser.Navigate(GenerateAuthenticationUrl());
        }

        private void webBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            FacebookOAuthResult result;
            if (client.TryParseOAuthCallbackUrl(e.Url, out result))
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
                "publish_stream", "read_stream"
            };
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "client_id", _appId },
                { "redirect_uri", "https://www.facebook.com/connect/login_success.html" },
                { "display", "popup" },
                { "response_type", "token" }
            };
            if (_extendedPermissions.Length > 0)
            {
                StringBuilder scopeString = new StringBuilder();
                for (int index = 0; index < _extendedPermissions.Length; index++)
                {
                    if (index != 0)
                    {
                        scopeString.Append(",");
                    }
                    scopeString.Append(_extendedPermissions[index]);
                }
                parameters.Add("scope", scopeString.ToString());
            }
            return client.GetLoginUrl(parameters);
        }

    }
}