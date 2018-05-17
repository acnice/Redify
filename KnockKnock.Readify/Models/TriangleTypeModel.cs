namespace KnockKnock.Readify.Models
{
    public class TriangleTypeModel
    {
        public enum TriangleType
        {
            Error,
            Equilateral,
            Scalene,
            Isosceles
        }

        public TriangleType DetermineTringle(int a, int b, int c)
        {
            if(!IsTriangle(a,b,c))
                return TriangleType.Error;

            if (a == b && a == c)
            { 
                //All side lengths are equal
                return TriangleType.Equilateral;
            }
            else if(a == b || a == c || b == c)
            {
                //Only two side lengths are equal
                return TriangleType.Isosceles;
            }
            else
            {
                //a != b && a != c && b != c
                return TriangleType.Scalene;
            }
        }

        /// <summary>
        /// Determine whether given sides form a triangle
        /// </summary>
        internal bool IsTriangle(int a, int b, int c)
        {
            //All side lengths should be greater than 0
            if (a <= 0 || b <= 0 || c <= 0)
            {
                return false;
            }
            
            //Sum of any two side lengths should be grater than the remaining side's length.
            if ((a + b) <= c || (a + c) <= b || (b + c) <= a)
            {
                return false;
            }

            return true;
        }

    }
}