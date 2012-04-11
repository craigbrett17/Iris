using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Facebook;

namespace Iris.Models
{
    /// <summary>
    /// Retrieves the user's friends
    /// </summary>
    public class Friends : IPresentable
    {
        public Dictionary<string, string> Connections { get; set; }
        private FacebookClient _client = Facade.Client;

        public Friends()
        {
            Connections = new Dictionary<string, string>();
            System.Diagnostics.Debug.WriteLine("Retrieving friends...");
            JsonObject friendsCall = _client.Get("/me/friends/") as JsonObject;
            // Maybe there's a neater way of doing this. 
            foreach (var item in friendsCall["data"] as JsonArray)
            {
                Connections.Add((string)(((JsonObject)item)["id"]),
                    (string)(((JsonObject)item)["name"]));
            }
        }

    }
}