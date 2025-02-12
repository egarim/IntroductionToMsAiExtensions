using Microsoft.Extensions.AI;
using OpenAI;

namespace ChatCompletions
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

            ChatCompletion Result = await CurrentClient.CompleteAsync(Prompt);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Result.Message);
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();

            Console.WriteLine(new string('*', 100));
            Console.WriteLine("Now we will use the ChatOptions to limit the number of tokens in the output");
            var ChatOptions = new ChatOptions()
            {

                MaxOutputTokens = 20,
            };
            //Print prompt again "Describe what is C# in 100 words";
            Console.WriteLine(Prompt);

            Result = await CurrentClient.CompleteAsync(Prompt, ChatOptions);

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(Result.Message);
            Console.ReadKey();

            Console.ForegroundColor = ConsoleColor.Green;


          

        }
        private static IChatClient GetChatClientOpenAiImp(string ApiKey, string ModelId)
        {
            OpenAIClient openAIClient = new OpenAIClient(ApiKey);

            return new OpenAIChatClient(openAIClient, ModelId)
                .AsBuilder()
                .Build();
        }
   
    }
}
