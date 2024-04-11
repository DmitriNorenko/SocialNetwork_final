using SocialNetwork_final.DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork_final.DB.Repository.Messages
{
    public class MessageRepository : IMessageRepository
    {
        private SocialNetworkContext _context;
        public MessageRepository(SocialNetworkContext context)
        {
            _context = context;
        }

        public void Create(Message message)
        {
            _context.Messages.Add(message);
            _context.SaveChanges();
        }

        public List<Message> GetMessages(User sender, User recipient)
        {
            var from = _context.Messages.AsEnumerable().Where(
                x => x.SenderId == sender.Id && x.RecipientId == recipient.Id).ToList();
            var to = _context.Messages.AsEnumerable().Where(
                x => x.SenderId == recipient.Id && x.RecipientId == sender.Id).ToList();

            var itog = new List<Message>();
            itog.AddRange(from);
            itog.AddRange(to);
            itog.OrderBy(x => x.Id);
            return itog;
        }
    }
}
