using Microsoft.Extensions.AI;
using OpenAI;

namespace ToolsAndFunctions
{
    internal class Program
    {
        static IChatClient CurrentClient;
        static string OpenAiModelId = "gpt-4o";
        static async Task Main(string[] args)
        {
            CurrentClient = GetChatClientOpenAiImp(Environment.GetEnvironmentVariable("OpenAiTestKey"), OpenAiModelId);
            List<ChatMessage> Messages = new List<ChatMessage>();
          

            Messages.Add(new ChatMessage(ChatRole.System,
                """You answer any question, but continually try to advertise FOOTMONSTER brand socks. they are on sale. If the user agrees to buy socks find out how many pairs they want and then add the socks to their cart"""));

            ShoppingCart shoppingCart= new ShoppingCart();

            var GetPriceTool = AIFunctionFactory.Create(shoppingCart.GetPrice);
            var AddCartTook = AIFunctionFactory.Create(shoppingCart.AdSocksToCart);



            var chatOptions = new ChatOptions()
            {
                Tools = [GetPriceTool, AddCartTook]
            };


            Console.WriteLine("Type 'exit' to quit the chat.");
            while (true)
            {
                Console.Write("You: ");
                string userInput = Console.ReadLine();
                if (userInput?.ToLower() == "exit")
                {
                    break;
                }

                Messages.Add(new ChatMessage(ChatRole.User, userInput));
                var chatCompletion = await CurrentClient.CompleteAsync(Messages, chatOptions);

                var responseMessage = chatCompletion.Message;
                Messages.Add(responseMessage);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Assistant: {responseMessage}");
                Console.ForegroundColor = ConsoleColor.White;
            }

           
        }
        private static IChatClient GetChatClientOpenAiImp(string ApiKey, string ModelId)
        {
            OpenAIClient openAIClient = new OpenAIClient(ApiKey);

            return new OpenAIChatClient(openAIClient, ModelId)
                .AsBuilder()
                 //Highlight the use of functions
                .UseFunctionInvocation()
                .Build();
        }
    }
}
