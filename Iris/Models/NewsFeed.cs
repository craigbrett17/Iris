using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Facebook;

namespace Iris.Models
{
    /// <summary>
    /// Handles logic for retrieving the current user's news feed
    /// </summary>
    public class NewsFeed : IPresentable
    {
        /// <summary>
        /// The list of news stories in the news feed
        /// </summary>
        public JsonArray NewsItems { get; set; }
        private FacebookClient _client = Facade.Client;

        public NewsFeed()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            DateTime subtractedTime = DateTime.Now.AddHours(-2);
            var sinceTime = DateTimeConvertor.ToIso8601FormattedDateTime(subtractedTime);
            parameters.Add("since", sinceTime);
            JsonObject feedRetrieved = _client.Get("/me/home", parameters) as JsonObject;
            NewsItems = feedRetrieved["data"] as JsonArray;
        }
    }
}