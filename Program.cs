

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OpenAI.GPT3.Extensions;
using OpenAI_API.Services;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddOpenAIService(settings => settings.ApiKey = "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");
        //services.AddHostedService<openAiCompletionService>();
        services.AddHostedService<OpenAIImageService>();
    })
    .Build();

host.Run();

