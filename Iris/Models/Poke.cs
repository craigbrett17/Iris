using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Facebook;

namespace Iris.Models
{
    /// <summary>
    /// A tiny object that handles a poke on its constructor
    /// </summary>
    public class Poke
    {
        private FacebookClient _client = Facade.Client;
        public string Id { get; set; }

        public Poke(string idIn)
        {
            this.Id = idIn;
            _client.Post(String.Format("{0}/pokes", this.Id), null);
        }

    }
}