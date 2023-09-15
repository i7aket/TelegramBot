using Telegram.Bot.Types.Payments;
using Telegram.Bot.Types;
using TelegramBot.Interface;

public interface IUpdateHandler
{
    Task<IUpdateHandlerResult> BotOnMessageReceived(Message message);
    Task<IUpdateHandlerResult> BotOnCallbackQueryReceived(CallbackQuery callbackQuery);
    Task<IUpdateHandlerResult> BotOnInlineQueryReceived(InlineQuery inlineQuery);
    Task<IUpdateHandlerResult> BotOnChosenInlineResultReceived(ChosenInlineResult chosenInlineResult);
    Task<IUpdateHandlerResult> BotOnMessageEdited(Message editedMessage);
    Task<IUpdateHandlerResult> BotOnChannelPostReceived(Message channelPost);
    Task<IUpdateHandlerResult> BotOnEditedChannelPostReceived(Message editedChannelPost);
    Task<IUpdateHandlerResult> BotOnShippingQueryReceived(ShippingQuery shippingQuery);
    Task<IUpdateHandlerResult> BotOnPreCheckoutQueryReceived(PreCheckoutQuery preCheckoutQuery);
    Task<IUpdateHandlerResult> BotOnPollReceived(Poll poll);
    Task<IUpdateHandlerResult> BotOnPollAnswerReceived(PollAnswer pollAnswer);
}