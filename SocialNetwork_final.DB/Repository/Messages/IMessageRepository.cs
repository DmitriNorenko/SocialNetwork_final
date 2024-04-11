using SocialNetwork_final.DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork_final.DB.Repository.Messages
{
    public interface IMessageRepository
    {
        List<Message> GetMessages(User sender,User recipient);
        void Create(Message message);
    }
}
