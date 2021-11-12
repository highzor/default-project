using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgrotechFillHingers.VkBotBackend.Models
{
    [Serializable]
    public class MessageModel
    {
        public string Type { get; set; }
        public ObjectType Object { get; set; }
        public int GroupId { get; set; }
        public string EventId { get; set; }

        public class ObjectType
        {
            public Message Message { get; set; }
            public ClientInfo ClientInfo { get; set; }
        }

        public class Message
        {
            public int Date { get; set; }
            public int FromId { get; set; }
            public int Id { get; set; }
            public int Out { get; set; }
            public int PeerId { get; set; }
            public string Text { get; set; }
            public Attachment[] attachments { get; set; }
            public int ConversationMessageId { get; set; }
            public object[] FwdMessages { get; set; }
            public bool Important { get; set; }
            public bool IsHidden { get; set; }
            public int RandomId { get; set; }
        }

        public class Attachment
        {
            public string Type { get; set; }
            public Photo Photo { get; set; }
        }

        public class Photo
        {
            public int AlbumId { get; set; }
            public int Date { get; set; }
            public int Id { get; set; }
            public int OwnerId { get; set; }
            public bool HasTags { get; set; }
            public string AccessKey { get; set; }
            public int PostId { get; set; }
            public Size[] Sizes { get; set; }
            public string Text { get; set; }
        }

        public class Size
        {
            public int Height { get; set; }
            public string Url { get; set; }
            public string Type { get; set; }
            public int Width { get; set; }
        }

        public class ClientInfo
        {
            public string[] ButtonActions { get; set; }
            public bool Keyboard { get; set; }
            public bool InlineKeyboard { get; set; }
            public bool Carousel { get; set; }
            public int LangId { get; set; }
        }

    }
}
