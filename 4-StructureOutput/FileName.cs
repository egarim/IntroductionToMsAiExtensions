using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StructureOutput
{
    public class CatCollectionDescription
    {
        [JsonPropertyName("numberOfBlackCats")]
        [Description("Number of black cats")]
        public int NumberOfBlackCats { get; set; }
        [JsonPropertyName("numberOfWhiteCats")]
        [Description("Number of white cats")]
        public int NumberOfWhiteCats { get; set; }
        [JsonPropertyName("numberOfOtherAnimals")]
        [Description("Number of other animals that are NOT cats")]
        public int NumberOfOtherAnimals { get; set; }
        [JsonPropertyName("numberOfNotAnimals")]
        [Description("Number of other objects that are not animals")]
        public int NumberOfNotAnimals { get; set; }
        public CatCollectionDescription()
        {

        }
    }
}
