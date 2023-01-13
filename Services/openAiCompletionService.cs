using Microsoft.Extensions.Hosting;
using OpenAI.GPT3.Interfaces;
using OpenAI.GPT3.Managers;
using OpenAI.GPT3.ObjectModels.RequestModels;
using OpenAI.GPT3.ObjectModels.ResponseModels;
using OpenAI.GPT3.ObjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAI_API.Services
{
    public class openAiCompletionService : BackgroundService
    {
        readonly IOpenAIService _ıOpenAIService;

        public openAiCompletionService(IOpenAIService ıOpenAIService)
        {
            _ıOpenAIService = ıOpenAIService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (true)
            {
                Console.Write("Soru sorun:");
                CompletionCreateResponse result = await _ıOpenAIService.Completions.CreateCompletion(new CompletionCreateRequest()
                {
                    Prompt = Console.ReadLine(),
                    MaxTokens = 500
                }, Models.TextDavinciV3);

                Console.WriteLine(result.Choices[0].Text);
            }
        
    }
    }
}
