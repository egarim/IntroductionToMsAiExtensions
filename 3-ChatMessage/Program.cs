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

          
            Console.WriteLine("Prompt in chat list: 'Describe what is C# in 100 words'" + Environment.NewLine);
           
            List<ChatMessage> Prompt = new List<ChatMessage>()
            {
                new ChatMessage(ChatRole.User, "Describe what is C# in 100 words"),
            
            };

            ChatCompletion Result = await CurrentClient.CompleteAsync(Prompt);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Result.Message);
            
            Console.ReadKey();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(new string('*', 100));
            Console.WriteLine("Now we will create a chat history using ChatMessage to give context to the A.I"+Environment.NewLine);

            List<ChatMessage> chatMessages = new List<ChatMessage>()
            {
                new ChatMessage(ChatRole.User, "What is the capital of El Salvador?"),
                new ChatMessage(ChatRole.Assistant, "The capital of El Salvador is San Salvador."),
                new ChatMessage(ChatRole.User, "What is the capital of Dominican Republic?"),
                new ChatMessage(ChatRole.Assistant, "The capital of El Dominican Republic is Santo Domingo.")
            };

            chatMessages.Add(new ChatMessage(ChatRole.User, "Which countries have we mention on this conversation"));

            foreach (ChatMessage chatMessage in chatMessages)
            {
                Console.WriteLine($"{chatMessage.Role}:{chatMessage.ToString()}");
            }



            Result = await CurrentClient.CompleteAsync(chatMessages);

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(Result.Message);
            Console.ReadKey();
          
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(new string('*', 100));
            Console.WriteLine("Messages can have attached content, let's add an image to the message" + Environment.NewLine);
           

            ChatMessage Message = new ChatMessage(ChatRole.User, "Describe what is in the picture in 500 or less characters");
            Console.WriteLine(Message.ToString()+Environment.NewLine);

            ReadOnlyMemory<byte> Image = File.ReadAllBytes("puppy.jpg");
            Message.Contents.Add(new ImageContent(Image, "image/jpg"));

            Result = await CurrentClient.CompleteAsync(new List<ChatMessage>() { Message });
            
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(Result.Message);
            Console.ReadKey();
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
