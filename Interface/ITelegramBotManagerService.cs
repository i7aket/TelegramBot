using Telegram.Bot.Types;

namespace TelegramBot.Interface
{
    public interface ITelegramBotManagerService
    {
        Task Handle(Update update);
    }
}