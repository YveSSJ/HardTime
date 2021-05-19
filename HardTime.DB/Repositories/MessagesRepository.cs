using HardTime.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace HardTime.DB
{
    public class MessagesRepository : IMessagesRepository
    {
        private readonly AppDbContext _dbContext;
        private DbSet<MessageEntity> Messages { get; set; }

        public MessagesRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            Messages = dbContext.Messages;
        }

        public IEnumerable<MessageEntity> GetAll()
        {
            return Messages;
        }
        public bool Add(MessageEntity message)
        {
            Messages.Add(message);
            return _dbContext.SaveChanges() > 0;
        }
        public bool Delete(MessageEntity message)
        {
            Messages.Remove(message);
            return _dbContext.SaveChanges() > 0;

        }
    }
}
