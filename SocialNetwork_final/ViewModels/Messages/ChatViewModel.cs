﻿using SocialNetwork_final.DB.Model;

namespace SocialNetwork_final.ViewModels.Messages
{
    public class ChatViewModel
    {
        public User You {  get; set; }
        public User ToWhom { get; set; }
        public List<Message> History { get; set; }
        public MessageViewModel NewMessage { get; set; }
        public ChatViewModel() 
        {
         NewMessage = new MessageViewModel();
        }

    }
}
