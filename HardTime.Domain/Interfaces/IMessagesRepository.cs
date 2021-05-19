using System.Collections.Generic;

namespace HardTime.Domain
{
    public interface IMessagesRepository
    {
        bool Add(MessageEntity message);
        bool Delete(MessageEntity message);
        IEnumerable<MessageEntity> GetAll();
    }
}