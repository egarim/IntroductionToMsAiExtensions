using Microsoft.Extensions.AI;

namespace ChatClientAbstractions
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            var client=GetChatClient("", "");
          
        }
        private static IChatClient GetChatClient(string endpoint, string modelId)
        {

            return new OllamaChatClient(endpoint, modelId: modelId)
                .AsBuilder()
                .UseFunctionInvocation()
                .Build();
        }
    }
}
