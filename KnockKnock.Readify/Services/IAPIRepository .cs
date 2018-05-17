using System.Threading.Tasks;

namespace KnockKnock.Readify.Services
{
    public interface IAPIRepository
    {
        Task<long> CalculateFibonacciNumber(int position);
        Task<string> ReverseWords(string word);
        Task<string> DetermineTriangleType(int a, int b, int c);
    }
}