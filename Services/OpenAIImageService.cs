using Microsoft.Extensions.Hosting;
using OpenAI.GPT3.Interfaces;
using OpenAI.GPT3.Managers;
using OpenAI.GPT3.ObjectModels.RequestModels;
using OpenAI.GPT3.ObjectModels.ResponseModels.ImageResponseModel;
using OpenAI.GPT3.ObjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAI_API.Services
{
    public class OpenAIImageService : BackgroundService
    {
        readonly IOpenAIService _ıOpenAIService;

        public OpenAIImageService(IOpenAIService ıOpenAIService)
        {
            _ıOpenAIService = ıOpenAIService;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            while (true)
            {
                Console.Write("::");
                ImageCreateResponse result = await _ıOpenAIService.Image.CreateImage(new ImageCreateRequest()
                {
                    Prompt = Console.ReadLine(),
                    N = 2,
                    Size = StaticValues.ImageStatics.Size.Size256,
                    ResponseFormat = StaticValues.ImageStatics.ResponseFormat.Url,
                    User = "test"
                });


                Console.WriteLine(string.Join("\n", result.Results.Select(r => r.Url)));
            }
        }
    }
    }

