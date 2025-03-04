using Microsoft.Extensions.AI;
using OpenAI;

namespace Pipelines
{
    internal class Program
    {
        static IChatClient CurrentClient;
        static string OpenAiModelId = "gpt-4o";
  
        static async Task Main(string[] args)
        {

            CurrentClient = GetChatClientOpenAiImp(Environment.GetEnvironmentVariable("OpenAiTestKey"), OpenAiModelId);


            var Prompt = "Describe what is C# in 100 words";
            Console.WriteLine(Prompt);

            var Result = await CurrentClient.CompleteAsync(Prompt);


            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Result.Message);
            Console.ReadKey();


            for (int i = 0; i < 10; i++)
            {
                 Result = await CurrentClient.CompleteAsync(Prompt);
                 Console.WriteLine(Result.Message);
            }
        }
        private static IChatClient GetChatClientOpenAiImp(string ApiKey, string ModelId)
        {
            OpenAIClient openAIClient = new OpenAIClient(ApiKey);

            return new OpenAIChatClient(openAIClient, ModelId)
                .AsBuilder()
                .UseFunctionInvocation()
                .UserLanguage("spanish")
                .UseRateLimitThreading(TimeSpan.FromSeconds(5))
                .Build();
        }
     
    }
}
