using Microsoft.Extensions.AI;
using OpenAI;

namespace ChatClientAbstractions
{
    internal class Program
    {
        static IChatClient CurrentClient;
        static string OpenAiModelId = "gpt-4o";
        static string OllamaModelId = " phi3";
        static async Task Main(string[] args)
        {

            CurrentClient = GetChatClientOpenAiImp(Environment.GetEnvironmentVariable("OpenAiTestKey"), OpenAiModelId);


            //Tools: A list of tools that can be used to enhance the chat experience
            //MaxTokens: The maximum number of tokens to generate
            //Temperature: This parameter (typically between 0 and 1) controls the randomness in the model's output
            //TopP: What is the top p value
            //FrequencyPenalty: What is the frequency penalty
            //PresencePenalty: What is the presence penalty
            //Stop: What is the stop value

            var ChatOptions = new ChatOptions()
            {

                MaxOutputTokens = 10,
            };


            var Prompt = "Describe what is C#";
            Console.WriteLine(Prompt);

            var Result = await CurrentClient.CompleteAsync(Prompt, ChatOptions);

            //image content

            //ChatMessage Message = new ChatMessage(ChatRole.User, "Describe what is in the picture in 500 or less characters");

            //Message.Contents.Add(new ImageContent(CurrentDetail.Image.MediaData, "image/jpg"));
            //var Client = ChatClientHelper.GetChatClient();
            //var Result = await Client.CompleteAsync(new List<ChatMessage>() { Message });


            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Result.Message);
            Console.ReadKey();

        }
        private static IChatClient GetChatClientOpenAiImp(string ApiKey, string ModelId)
        {
            OpenAIClient openAIClient = new OpenAIClient(ApiKey);

            return new OpenAIChatClient(openAIClient, ModelId)
                .AsBuilder()
                .UseFunctionInvocation()
                .Build();
        }
   
    }
}
