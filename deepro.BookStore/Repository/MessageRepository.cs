using deepro.BookStore.Models;
using Microsoft.Extensions.Options;

namespace deepro.BookStore.Repository
{
    public class MessageRepository : IMessageRepository
    {
        private readonly IOptionsMonitor<NewBookAlertConfig> _newBookAlertConfigration;
        public MessageRepository(IOptionsMonitor<NewBookAlertConfig> newBookAlertConfigration)
        {
            _newBookAlertConfigration = newBookAlertConfigration;
            
        }
        public string GetName()
        {
            return _newBookAlertConfigration.CurrentValue.BookName;
        }
    }
}
