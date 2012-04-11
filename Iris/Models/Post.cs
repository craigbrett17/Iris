using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Facebook;

namespace Iris.Models
{
    public class Post : IPresentable
    {
        public string Message { get; set; }
        public string RecipientId { get; set; }

        public Post()
        {

        }

        public Post(string idIn)
        {
            this.RecipientId = idIn;
        }

        public bool MakePost()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            if (Message != null)
            {
                parameters.Add("message", Message);
            }
            if (parameters.Count > 0)
            {
                JsonObject result;
                if (RecipientId == null)
                {
                    result = Facade.Client.Post("/me/feed", parameters) as JsonObject;
                }
                else
                {
                    result = Facade.Client.Post(String.Format("/{0}/feed", RecipientId), parameters) as JsonObject;
                }
                string postId = result["id"] as string;
                if (postId != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

    }
}