using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgrotechFillHingers.VkBotBackend.Models
{
    //public class MessageModel
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

    //{
    //    [JsonProperty("type")]
    //    public string Type { get; set; }
    //    [JsonProperty("object")]
    //    public ObjectType Object { get; set; }
    //    [JsonProperty("group_id")]
    //    public long GroupId { get; set; }
    //    [JsonProperty("event_id")]
    //    public string EventId { get; set; }

    //    public class ObjectType
    //    {
    //        [JsonProperty("message")]
    //        public Message Message { get; set; }
    //        [JsonProperty("client_info")]
    //        public ClientInfo ClientInfo { get; set; }
    //    }

    //    public class Message
    //    {
    //        [JsonProperty("date")]
    //        public int Date { get; set; }
    //        [JsonProperty("from_id")]
    //        public long FromId { get; set; }
    //        [JsonProperty("id")]
    //        public int Id { get; set; }
    //        [JsonProperty("out")]
    //        public long Out { get; set; }
    //        [JsonProperty("peer_id")]
    //        public long PeerId { get; set; }
    //        [JsonProperty("text")]
    //        public string Text { get; set; }
    //        [JsonProperty("attachments")]
    //        public Attachment[] attachments { get; set; }
    //        [JsonProperty("conversation_message_id")]
    //        public long ConversationMessageId { get; set; }
    //        [JsonProperty("fwd_messages")]
    //        public object[] FwdMessages { get; set; }
    //        [JsonProperty("important")]
    //        public bool Important { get; set; }
    //        [JsonProperty("is_hidden")]
    //        public bool IsHidden { get; set; }
    //        [JsonProperty("random_id")]
    //        public long RandomId { get; set; }
    //    }

    //    public class Attachment
    //    {
    //        [JsonProperty("type")]
    //        public string Type { get; set; }
    //        [JsonProperty("photo")]
    //        public Photo Photo { get; set; }
    //    }

    //    public class Photo
    //    {
    //        [JsonProperty("album_id")]
    //        public long AlbumId { get; set; }
    //        [JsonProperty("date")]
    //        public int Date { get; set; }
    //        [JsonProperty("id")]
    //        public int Id { get; set; }
    //        [JsonProperty("owner_id")]
    //        public long OwnerId { get; set; }
    //        [JsonProperty("has_tags")]
    //        public bool HasTags { get; set; }
    //        [JsonProperty("access_key")]
    //        public string AccessKey { get; set; }
    //        [JsonProperty("post_id")]
    //        public long PostId { get; set; }
    //        [JsonProperty("sizes")]
    //        public Size[] Sizes { get; set; }
    //        [JsonProperty("text")]
    //        public string Text { get; set; }
    //    }

    //    public class Size
    //    {
    //        [JsonProperty("height")]
    //        public int Height { get; set; }
    //        [JsonProperty("url")]
    //        public string Url { get; set; }
    //        [JsonProperty("type")]
    //        public string Type { get; set; }
    //        [JsonProperty("width")]
    //        public int Width { get; set; }
    //    }

    //    public class ClientInfo
    //    {
    //        [JsonProperty("button_actions")]
    //        public string[] ButtonActions { get; set; }
    //        [JsonProperty("keyboard")]
    //        public bool Keyboard { get; set; }
    //        [JsonProperty("inline_keyboard")]
    //        public bool InlineKeyboard { get; set; }
    //        [JsonProperty("carousel")]
    //        public bool Carousel { get; set; }
    //        [JsonProperty("lang_id")]
    //        public long LangId { get; set; }
    //    }

    //}
}
