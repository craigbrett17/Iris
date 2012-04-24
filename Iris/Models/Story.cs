using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Facebook;

namespace Iris.Models
{
    public class Story : IPresentable
    {
        public string StoryId { get; set; }
        public string FromId { get; set; }
        public string FromName { get; set; }
        public string StoryProperty { get; set; }
        public string Type { get; set; }
        public string Message { get; set; }
        public string PictureUrl { get; set; }
        public string Link { get; set; }
        public string LinkName { get; set; }
        public string LinkCaption { get; set; }
        public string LinkDescription { get; set; }
        public int LikeCount { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }

        public Story()
        {

        }

        public Story(JsonObject jsonIn)
        {
            this.StoryId = GetJsonValueIfExists(jsonIn, "id") as string;
            this.FromId = GetJsonValueIfExists((JsonObject)GetJsonValueIfExists(jsonIn, "from"), "id") as string;
            this.FromName = GetJsonValueIfExists((JsonObject)GetJsonValueIfExists(jsonIn, "from"), "name") as string;
            this.StoryProperty = GetJsonValueIfExists(jsonIn, "story") as string;
            this.Type = GetJsonValueIfExists(jsonIn, "type") as string;
            this.Message = GetJsonValueIfExists(jsonIn, "message") as string;
            this.PictureUrl = GetJsonValueIfExists(jsonIn, "picture") as string;
            this.Link = GetJsonValueIfExists(jsonIn, "link") as string;
            this.LinkName = GetJsonValueIfExists(jsonIn, "name") as string;
            this.LinkCaption = GetJsonValueIfExists(jsonIn, "caption") as string;
            this.LinkDescription = GetJsonValueIfExists(jsonIn, "description") as string;
            JsonObject likes = GetJsonValueIfExists(jsonIn, "likes") as JsonObject;
            if (likes != null)
            {
                this.LikeCount = Convert.ToInt32(GetJsonValueIfExists(likes, "count"));
            }
            string timeString = GetJsonValueIfExists(jsonIn, "created_time") as string;
            if (timeString != null)
            {
                this.CreateTime = DateTime.Parse(timeString);
            }
            timeString = GetJsonValueIfExists(jsonIn, "update_time") as string;
            if (timeString != null)
            {
                this.UpdateTime = DateTime.Parse(timeString);
            }
        }

        private object GetJsonValueIfExists(JsonObject jsonIn, string desiredKey)
        {
            if (jsonIn.ContainsKey(desiredKey))
            {
                return jsonIn[desiredKey];
            }
            return null;
        }

        public override string ToString()
        {
            StringBuilder returnString = new StringBuilder();
            if (StoryProperty != null)
            {
                returnString.Append(StoryProperty);
            }
            else
            {
                returnString.Append(FromName);
                returnString.Append(" posted");
                if (Type != null)
                {
                    switch (this.Type)
                    {
                        case "link":
                            returnString.Append(" a link");
                            break;
                        case "photos":
                            returnString.Append(" a photo");
                            break;
                        default:
                            break;
                    }
                }
                returnString.Append(": ");
                returnString.Append(Message);
                if (Message != null && !Message.EndsWith(".") && !Message.EndsWith("!") && !Message.EndsWith("?"))
                {
                    returnString.Append(". ");
                }
                returnString.Append(LinkName);
                returnString.Append(" ");
                returnString.Append(CreateTime.ToString("HH:mm") ?? ".");
                if (this.LikeCount > 0)
                {
                    returnString.Append(" ");
                    returnString.Append(LikeCount);
                    returnString.Append(" likes"); 
                }
            }
            return returnString.ToString();
        }

    }
}