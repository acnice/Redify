using System.Linq;
using System.Text;

namespace KnockKnock.Readify.Models
{
    public class ReverseWordsModel
    {
        private readonly char[] delimeter = new char[] { ' ' };
        public string Reverse(string sentence)
        {
            if (string.IsNullOrWhiteSpace(sentence))
                return string.Empty;

            //Keep space counts
            int preSpaces = sentence.Length - sentence.TrimStart().Length;
            int postSpaces = sentence.Length - sentence.TrimEnd().Length;

            StringBuilder sb = new StringBuilder();
            string[] words = sentence.Trim().Split(delimeter); //Remove spaces and split
            foreach (var word in words)
            {
                sb.Append(new string(word.ToCharArray().Reverse().ToArray()));
                sb.Append(new string(delimeter));
            }
            return  new string(' ', preSpaces) + sb.ToString().Trim() + new string(' ', postSpaces); //Insert back Left Right Spaces
        }
    }
}