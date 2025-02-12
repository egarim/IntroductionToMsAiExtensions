using Microsoft.Extensions.AI;
using OpenAI;

namespace StructureOutput
{
    internal class Program
    {
        static IChatClient CurrentClient;
        static string OpenAiModelId = "gpt-4o";
        static async Task Main(string[] args)
        {
            CurrentClient = GetChatClientOpenAiImp(Environment.GetEnvironmentVariable("OpenAiTestKey"), OpenAiModelId);
            var Message = new ChatMessage(ChatRole.User, "Analyze this images to count the number of black cats, white cats, other animals and objects that are NOT animals");

            //read the bytes of the image Cats.jpg
            byte[] catsBytes = File.ReadAllBytes("Cats.jpg");

            //read the bytes of the image Puppies.jpg
            byte[] PuppiesBytes = File.ReadAllBytes("Puppies.jpg");

            //read the bytes of the image Robots.jpg
            byte[] RobotsBytes = File.ReadAllBytes("Robots.jpg");


            Message.Contents.Add(new ImageContent(catsBytes, "image/jpg"));
            Message.Contents.Add(new ImageContent(PuppiesBytes, "image/jpg"));
            Message.Contents.Add(new ImageContent(RobotsBytes, "image/jpg"));

            ChatCompletion<CatCollectionDescription> Answer = await CurrentClient.CompleteAsync<CatCollectionDescription>(new List<ChatMessage>() { Message });

            Console.WriteLine($"Number of black cats: {Answer.Result.NumberOfBlackCats}");
            Console.WriteLine($"Number of white cats: {Answer.Result.NumberOfWhiteCats}");
            Console.WriteLine($"Number of other animals: {Answer.Result.NumberOfOtherAnimals}");
            Console.WriteLine($"Number of other objects that are NOT animals: {Answer.Result.NumberOfNotAnimals}");

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
