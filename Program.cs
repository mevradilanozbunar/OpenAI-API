

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OpenAI.GPT3.Extensions;
using OpenAI_API.Services;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddOpenAIService(settings => settings.ApiKey = "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");
        services.AddHostedService<openAiCompletionService>();
        //services.AddHostedService<OpenAIImageService>();
    })
    .Build();

host.Run();

