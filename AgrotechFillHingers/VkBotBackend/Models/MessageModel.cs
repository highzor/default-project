using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgrotechFillHingers.VkBotBackend.Models
{
    [Serializable]
    public class MessageModel
    {
        public string type { get; set; }
        [JsonProperty("object")]
        public ObjectClass Object { get; set; }
        public int group_id { get; set; }
        public string event_id { get; set; }
    }

    public class ObjectClass
    {
        public Message message { get; set; }
        public Client_Info client_info { get; set; }
    }

    public class Message
    {
        public int date { get; set; }
        public int from_id { get; set; }
        public int id { get; set; }
        [JsonProperty("out")]
        public int Out { get; set; }
        public int peer_id { get; set; }
        public string text { get; set; }
        public object[] attachments { get; set; }
        public int conversation_message_id { get; set; }
        public object[] fwd_messages { get; set; }
        public bool important { get; set; }
        public bool is_hidden { get; set; }
        public int random_id { get; set; }
    }

    public class Client_Info
    {
        public string[] button_actions { get; set; }
        public bool keyboard { get; set; }
        public bool inline_keyboard { get; set; }
        public bool carousel { get; set; }
        public int lang_id { get; set; }
    }
}
