using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsAndFunctions
{
    public class ShoppingCart
    {
        public int NumPairOfSocks { get; set; }
        public decimal Total { get; set; }

        public void AdSocksToCart(int NumOfPairs)
        {
            NumPairOfSocks += NumOfPairs;
            Debug.WriteLine($"Added {NumOfPairs} pairs of socks to the cart. Total: {NumPairOfSocks} pairs (${NumPairOfSocks * PricePerPair})");
            
        }

        private const float PricePerPair = 10f;

        [Description("Computes the price of socks, returning a value in dollars.")]
        public float GetPrice([Description("The number of pairs of socks to calculate the price for")] int Count)
        {
            
            Debug.WriteLine($"Calculating price for {Count} pairs of socks. Total:${Count * PricePerPair}");
            return Count * PricePerPair;
        }
 
        public ShoppingCart()
        {
           
        }
    }
}
