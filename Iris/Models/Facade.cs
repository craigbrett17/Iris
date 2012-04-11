using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Facebook;
using System.Windows.Forms;

namespace Iris.Models
{
    /// <summary>
    /// A static class that handles any of the more complex operations within the Facebook API
    /// </summary>
    public static class Facade
    {
        private static FacebookClient _client;
        /// <summary>
        /// A singleton object representing a Facebook client connection. 
        /// Causes log in for access token if not already existing
        /// </summary>
        public static FacebookClient Client
        {
            get
            {
                return GetClient();
            }
        }

        public static FacebookClient GetClient()
        {
            if (_client == null)
            {
                try
                {
                    Login();
                    return _client;
                }
                catch (Exception ex)
                {
                    throw ex; // just pass this along
                }
            }
            else
            {
                return _client;
            }
        }

        private static void Login()
        {
            Loginform dialog = new Loginform();
            dialog.ShowDialog();
            if (dialog.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                _client = new FacebookClient(dialog.Result.AccessToken);
                dialog.Close();
                System.Threading.Thread.Sleep(500);
                dynamic namecall = Client.Get("/me");
                string name = namecall.name;
                ScreenReader.sayString("Logged into Facebook as " + name + ".", false);
            }
            else
            {
                MessageBox.Show("Unable to log into facebook: \n" + dialog.Result.ErrorReason, "Log in error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}