using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.Payments;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramBot.Interface;
using static System.Net.WebRequestMethods;

namespace TelegramBot;

public class TelegramBotManagerService : ITelegramBotManagerService
{
    private readonly ITelegramBotClient _botClient;

    public TelegramBotManagerService(ITelegramBotClient botClient)
    {
        _botClient = botClient;
    }

    public async Task Handle(Update update)
    {
        switch (update.Type)
        {
            case UpdateType.Message:
                await BotOnMessageReceived(update.Message);
                break;

            case UpdateType.CallbackQuery:
                await BotOnCallbackQueryReceived(update.CallbackQuery);
                break;

            case UpdateType.InlineQuery:
                await BotOnInlineQueryReceived(update.InlineQuery);
                break;

            case UpdateType.ChosenInlineResult:
                await BotOnChosenInlineResultReceived(update.ChosenInlineResult);
                break;

            case UpdateType.EditedMessage:
                await BotOnMessageEdited(update.EditedMessage);
                break;

            case UpdateType.ChannelPost:
                await BotOnChannelPostReceived(update.ChannelPost);
                break;

            case UpdateType.EditedChannelPost:
                await BotOnEditedChannelPostReceived(update.EditedChannelPost);
                break;

            case UpdateType.ShippingQuery:
                await BotOnShippingQueryReceived(update.ShippingQuery);
                break;

            case UpdateType.PreCheckoutQuery:
                await BotOnPreCheckoutQueryReceived(update.PreCheckoutQuery);
                break;

            case UpdateType.Poll:
                await BotOnPollReceived(update.Poll);
                break;

            case UpdateType.PollAnswer:
                await BotOnPollAnswerReceived(update.PollAnswer);
                break;

            default:
                Console.WriteLine($"Unknown update type: {update.Type}");
                break;
        }
    }

    private async Task BotOnMessageReceived(Message message)
    {

        if (message.Text != null && message.Text.StartsWith("/start"))
        {
            await _botClient.SendGameAsync(
                chatId: message.Chat.Id,
                gameShortName: "Guess_the_secret_code"
            );
            await _botClient.SendGameAsync(
                chatId: message.Chat.Id,
                gameShortName: "Puzzle_15"
            );
        }
        else
        {
            // Create a keyboard with the /start button
            var keyboard = new ReplyKeyboardMarkup(new[]
            {
                new KeyboardButton("/start")
            })
            {
                ResizeKeyboard = true 
            };
            // Send a message with the keyboard
            await _botClient.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: "Welcome! Press /start to begin.",
                replyMarkup: keyboard
            );
        }

    }

    private async Task BotOnCallbackQueryReceived(CallbackQuery callbackQuery)
    {
        if (callbackQuery.GameShortName == "Guess_the_secret_code")
        {
            await _botClient.AnswerCallbackQueryAsync(
                callbackQueryId: callbackQuery.Id,
                url: "https://i7aket.com/GuessTheNumber/index.html"
            );
        }

        if (callbackQuery.GameShortName == "Puzzle_15")
        {
            await _botClient.AnswerCallbackQueryAsync(
                callbackQueryId: callbackQuery.Id,
                url: "https://i7aket.com/puzzle15/index.html"
            );
        }
    }

    private async Task BotOnInlineQueryReceived(InlineQuery inlineQuery)
    {
        throw new NotImplementedException("BotOnInlineQueryReceived ещё не реализован.");
    }

    private async Task BotOnChosenInlineResultReceived(ChosenInlineResult chosenInlineResult)
    {
        throw new NotImplementedException("BotOnChosenInlineResultReceived ещё не реализован.");
    }

    private async Task BotOnMessageEdited(Message editedMessage)
    {
        throw new NotImplementedException("BotOnMessageEdited ещё не реализован.");
    }

    private async Task BotOnChannelPostReceived(Message channelPost)
    {
        throw new NotImplementedException("BotOnChannelPostReceived ещё не реализован.");
    }

    private async Task BotOnEditedChannelPostReceived(Message editedChannelPost)
    {
        throw new NotImplementedException("BotOnEditedChannelPostReceived ещё не реализован.");
    }

    private async Task BotOnShippingQueryReceived(ShippingQuery shippingQuery)
    {
        throw new NotImplementedException("BotOnShippingQueryReceived ещё не реализован.");
    }

    private async Task BotOnPreCheckoutQueryReceived(PreCheckoutQuery preCheckoutQuery)
    {
        throw new NotImplementedException("BotOnPreCheckoutQueryReceived ещё не реализован.");
    }

    private async Task BotOnPollReceived(Poll poll)
    {
        throw new NotImplementedException("BotOnPollReceived ещё не реализован.");
    }

    private async Task BotOnPollAnswerReceived(PollAnswer pollAnswer)
    {
        throw new NotImplementedException("BotOnPollAnswerReceived ещё не реализован.");
    }

}

