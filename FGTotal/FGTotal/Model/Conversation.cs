﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FGTotal.Model
{
    public class Conversation : INotifyPropertyChanged
    {
        public string Id { get; set; }
        public string Subject { get; set; }
        public string usuario { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string Body { get; set; }
        public string Category { get; set; }
        public bool IsAccepted { get; set; }
        public string UserProfilePicture { get; set; }
        public string client { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
    public static class Conversations
    {
        public static List<Conversation> All = new List<Conversation>
        {
            new Conversation{Subject="Declined - Caleb",Body="text of the printing and typesetting industry. Lorem Ipsum has been the industry",Category="Beautiful & Elegant Mansion",IsAccepted=false, UserProfilePicture="https://randomuser.me/api/portraits/women/44.jpg"},
            new Conversation{Subject="Accepted - Jessie",Body="classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock",Category="Modern Beach House",IsAccepted=true, UserProfilePicture="https://randomuser.me/api/portraits/men/43.jpg"},
            new Conversation{Subject="Expired - Duane",Body="Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium",Category="Beautiful & Elegant Mansion",IsAccepted=false, UserProfilePicture="https://randomuser.me/api/portraits/men/29.jpg"},
            new Conversation{Subject="Expired - Anthony",Body=" aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt.",Category="Beautiful & Elegant Mansion",IsAccepted=false, UserProfilePicture="https://randomuser.me/api/portraits/women/70.jpg"},
            new Conversation{Subject="Expired - Anthony",Body=" aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt.",Category="Beautiful & Elegant Mansion",IsAccepted=false, UserProfilePicture="https://randomuser.me/api/portraits/women/70.jpg"}
        };
    }
}