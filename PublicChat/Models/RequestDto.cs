using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PublicChat.Models
{
    public class MessageDto
    {
        public string user { get; set; }
        public string msgText { get; set; }
        public string reciever { get; set; }

    } 
    public class NotificationDto
    {
        public Notification Notify { get; set; }
        public bool IsPrivate { get; set; } = false;
        public string[] Receivers { get; set; }

    }

    public class Notification
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public string SubTitle { get; set; }
        public bool HasVibrate { get; set; }
        public string VibrationPattern { get; set; }
    }
    public class Location
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
    public class Messages
    {
        public int Id { get; set; }
        public bool Seen { get; set; }
        public int From { get; set; }
        public string FromFirstName { get; set; }
        public string FromLastName { get; set; }
        public int To { get; set; }
        public string Message { get; set; }
        public int ReplyToId { get; set; }
        public Messages ReplyTo { get; set; }
        public string SeenDateTime { get; set; }
        public int Category { get; set; }
        public string CategoryTitle { get; set; }
        public string ConversationId { get; set; }
        public string CreateDateTime { get; set; }
        public string Link { get; set; }
    }
    public class SignalRDto
    {
        public Notification Notify { get; set; }
        public Messages Message { get; set; }
        public Location Location { get; set; }
        public Wallet Wallet { get; set; }
        public bool IsPrivate { get; set; } = false;
        public string[] Receivers { get; set; }
        
    }

    public class Wallet
    {
        public int Price { get; set; }
    }
    public class SignalRModel
    {
        public Notification Notify { get; set; }
        public Messages Message { get; set; }
        public Location Location { get; set; }
        public Wallet Wallet { get; set; }

    }
}
