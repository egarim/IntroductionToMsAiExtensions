using Microsoft.Extensions.AI;
using OpenAI;
using System.Diagnostics;
using System.Numerics.Tensors;
using System.Text;

namespace EmbeddingsTensorsAndSearch
{
    internal class Program
    {
        static IChatClient CurrentClient;
        static string OpenAiModelId = "gpt-4o";
        static async Task Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;



            IEmbeddingGenerator<string, Embedding<float>> embeddingGenerator = new OllamaEmbeddingGenerator(new Uri("http://127.0.0.1:11434"), modelId: "all-minilm:latest");


      

            var text = "Artificial Intelligence (AI) refers to the development of computer systems capable of performing tasks " +
                "that typically require human intelligence. " +
                "These tasks include reasoning, learning, problem-solving, perception, and language understanding.";

            Console.WriteLine($"Original Text:{text}");

            Embedding<float> result = await embeddingGenerator.GenerateEmbeddingAsync(text);


            var VectorData= result.Vector.Span.ToArray();
            foreach (float item in VectorData)
            {
                Console.Write(item+" ");
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"vector length:{result.Vector.Length}");

            Console.ReadKey();



            //zip
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;

            var strings = new List<string>();
           

            var TacosAlPastor = "Tacos al pastor are thin slices of pork marinated with spices and pineapple or orange juice." +
                " The meat is stacked on a vertical spit," +
                " cooked, and then thinly cut. It is served in corn tortillas with pineapple," +
                " green salsa, and lime wedges";

            var MachineLearning = "Machine learning is a subset of artificial intelligence that focuses on the development of algorithms and statistical models that computer systems use to perform specific tasks without explicit instructions. " +
                "These tasks include pattern recognition, data analysis, and decision-making.";

            strings.Add(text);
            strings.Add(TacosAlPastor);
            strings.Add(MachineLearning);

            (string Value, Embedding<float> Embedding)[] ZipEmbeddings = await embeddingGenerator.GenerateAndZipAsync(strings);




            var parameterValue = "What is A.I";
            
            Embedding<float> InputEmbedding = await embeddingGenerator.GenerateEmbeddingAsync(parameterValue);



            var Closest = from candidate in ZipEmbeddings
                          let similarity = TensorPrimitives.CosineSimilarity(candidate.Embedding.Vector.Span, InputEmbedding.Vector.Span)
                          orderby similarity descending
                          select new { Text = candidate.Value, Similarity = similarity};


            
            foreach (var item in Closest)
            {
                Console.WriteLine($"Similarity:{item.Similarity} Text:{item.Text}");
                Console.WriteLine();
            }
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
