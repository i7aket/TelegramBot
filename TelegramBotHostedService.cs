using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Telegram.Bot;
using Telegram.Bot.Requests;
using Telegram.Bot.Types.Enums;
using TelegramBot.Interface;


namespace TelegramBot;

public class TelegramBotHostedService : IHostedService
{
    private readonly ITelegramBotClient _botClient;
    private readonly ITelegramBotManagerService _botManager;
    private CancellationTokenSource _cancellationTokenSource;
    private Task _task;


    public TelegramBotHostedService(ITelegramBotManagerService botManager, ITelegramBotClient botClient)
    {
        _botManager = botManager;
        _botClient = botClient;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _cancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);

        _task = Task.Factory.StartNew(
            async () => await RunBotAsync(_cancellationTokenSource.Token),
            cancellationToken,
            TaskCreationOptions.LongRunning,
            TaskScheduler.Default
        );

        return Task.CompletedTask;
    }


    public Task StopAsync(CancellationToken cancellationToken)
    {
        _cancellationTokenSource.Cancel();
        _cancellationTokenSource.Dispose();
        return Task.CompletedTask;
    }

    private async Task RunBotAsync(CancellationToken cancellationToken)
    {
        int? offset = null;

        while (!cancellationToken.IsCancellationRequested)
        {
            var getUpdatesRequest = new GetUpdatesRequest { Offset = offset };
            var updatesResponse = await _botClient.MakeRequestAsync(getUpdatesRequest, cancellationToken);

            foreach (var update in updatesResponse)
            {
                await _botManager.Handle(update);
                offset = update.Id + 1;
            }

            await Task.Delay(TimeSpan.FromMilliseconds(100), cancellationToken);
        }
    }

}
