using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Task1
{
    public static class Utilities
    {
        /// <summary>
        /// Sorts an array in ascending order using bubble sort.
        /// </summary>
        /// <param name="numbers">Numbers to sort.</param>
        public static void Sort(int[] numbers)
        {
            if (numbers == null)
                throw new ArgumentNullException($"Array to sort shouldn't be null");
            for (var i = 0; i < numbers.Length - 1; i++)
                for (var j = 0; j < numbers.Length - i - 1; j++) 
                    if (numbers[j] > numbers[j + 1])
                        (numbers[j], numbers[j + 1]) = (numbers[j + 1], numbers[j]);
        }

        /// <summary>
        /// Searches for the index of a product in an <paramref name="products"/> 
        /// based on a <paramref name="predicate"/>.
        /// </summary>
        /// <param name="products">Products used for searching.</param>
        /// <param name="predicate">Product predicate.</param>
        /// <returns>If match found then returns index of product in <paramref name="products"/>
        /// otherwise -1.</returns>
        public static int IndexOf(Product[] products, Predicate<Product> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException($"Condition Shouldn't be null");
            var t = products.Select((prod, ind) => new { prod, ind })
                .FirstOrDefault(product =>predicate(product.prod));
            return t?.ind ?? -1;
        }
    }
}
