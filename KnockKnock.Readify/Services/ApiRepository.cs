using KnockKnock.Readify.Models;
using System.Threading.Tasks;

namespace KnockKnock.Readify.Services
{
    public class ApiRepository : IAPIRepository
    {
        /// <summary>
        /// Calculate the fibonacci number at the given position
        /// </summary>
        public async Task<long> CalculateFibonacciNumber(int position)
        {
            FibonacciModel model = new FibonacciModel();
            return await Task.FromResult(model.GenerateFibonacciNumber(position));
        }

        /// <summary>
        /// Determine triangle type by side lengths
        /// </summary>
        public async Task<string> DetermineTriangleType(int a, int b, int c)
        {
            TriangleTypeModel model = new TriangleTypeModel();
            return await Task.FromResult(model.DetermineTringle(a, b, c).ToString());
        }

        /// <summary>
        /// Reverse order of the given word
        /// </summary>
        public async Task<string> ReverseWords(string word)
        {
            ReverseWordsModel model = new ReverseWordsModel();
            return await Task.FromResult(model.Reverse(word));
        }
    }
}