using System.Diagnostics;
using System.Text;

namespace EmbeddingsTensorsAndSearch
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //zip

            //IEmbeddingGenerator<string, Embedding<float>> embeddingGenerator = new OllamaEmbeddingGenerator(new Uri("http://127.0.0.1:11434"), modelId: "all-minilm:latest");

            //var strings = this.View.ObjectSpace.GetObjectsQuery<XpoEmbedding>().Select(x => x.Text).ToList();

            //(string Value, Embedding<float> Embedding)[] ZipEmbeddings = await embeddingGenerator.GenerateAndZipAsync(strings);



            //IEmbeddingGenerator<string, Embedding<float>> embeddingGenerator = new OllamaEmbeddingGenerator(new Uri("http://127.0.0.1:11434"), modelId: "all-minilm:latest");


            //Embedding<float> result = await embeddingGenerator.GenerateEmbeddingAsync(CurrentXpoEmbedding.Text);
            //Debug.WriteLine($"vector lenght:{result.Vector.Length}");

            //CurrentXpoEmbedding.Data = result.Vector.ToArray();

            //var parameterValue = (string)e.ParameterCurrentValue;
            //IEmbeddingGenerator<string, Embedding<float>> embeddingGenerator = new OllamaEmbeddingGenerator(new Uri("http://127.0.0.1:11434"), modelId: "all-minilm:latest");
            //Embedding<float> InputEmbedding = await embeddingGenerator.GenerateEmbeddingAsync(parameterValue);


            //Debug.WriteLine($"vector lenght:{InputEmbedding.Vector.Length}");


            //var Embeddings = this.View.ObjectSpace.GetObjectsQuery<XpoEmbedding>().ToList();

            //IEmbeddingGenerator<string, Embedding<float>> embeddingGenerator = new OllamaEmbeddingGenerator(new Uri("http://127.0.0.1:11434"), modelId: "all-minilm:latest");

            //var strings = this.View.ObjectSpace.GetObjectsQuery<XpoEmbedding>().Select(x => x.Text).ToList();

            //(string Value, Embedding<float> Embedding)[] ZipEmbeddings = await embeddingGenerator.GenerateAndZipAsync(strings);




            //var Closest = from candidate in Embeddings
            //              let similarity = TensorPrimitives.CosineSimilarity(candidate.GetEmbedding().Vector.Span, InputEmbedding.Vector.Span)
            //              orderby similarity descending
            //              select new { Text = candidate.Text, Similarity = similarity, Code = candidate.Code };


            //StringBuilder stringBuilder = new StringBuilder();
            //foreach (var item in Closest)
            //{
            //    stringBuilder.AppendLine($"Code:{item.Code} Text:{item.Text} Similarity:{item.Similarity}");
            //}

        }
    }
}
