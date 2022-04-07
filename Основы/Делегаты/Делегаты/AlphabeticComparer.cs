using System;
namespace Делегаты
{
    public class AlphabeticComparer 
    {
        public bool Descending { get; set; }

        public int Compare(string x, string y)
        {
            return x.CompareTo(y) * (Descending ? -1 : 1);
        }
    }
}
