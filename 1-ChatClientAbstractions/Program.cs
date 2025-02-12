using Microsoft.Extensions.AI;
using OpenAI;

namespace ChatClientAbstractions
{
    internal class Program
    {
        static IChatClient CurrentClient;
        static string OpenAiModelId = "gpt-4o";
        static string OllamaModelId = " phi3:latest";
        static async Task Main(string[] args)
        {

            //CurrentClient = GetChatClientOpenAiImp(Environment.GetEnvironmentVariable("OpenAiTestKey"), OpenAiModelId);
            CurrentClient=GetChatClientGetOllamaImp("http://127.0.0.1:11434/", OllamaModelId);


            var Prompt = "Describe what is c# in 20 words";
            Console.WriteLine(Prompt);
            
            var Result=  await CurrentClient.CompleteAsync(Prompt);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Result.Message);
            Console.ReadKey();

        }
        private static IChatClient GetChatClientOpenAiImp(string ApiKey,string ModelId)
        {
            OpenAIClient openAIClient =new OpenAIClient(ApiKey);

            return new OpenAIChatClient(openAIClient, ModelId)
                .AsBuilder()
                .Build();
        }
        private static IChatClient GetChatClientGetOllamaImp(string endpoint, string modelId)
        {

            return new OllamaChatClient(endpoint, modelId: modelId)
                .AsBuilder()
                .Build();
        }
    }
}
