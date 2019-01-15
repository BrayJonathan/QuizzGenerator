using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzGenerator.Domain.ExtensionMethods
{
    public static class ListExtensions
    {
        private static Random rdn = new Random();

        public static void Shuffle<T>(this IList<T> list)
        {
            List<T> rdmliste = list.ToList();
            list.Clear();
            for (int i = 0; i < rdmliste.Count; i++)
            {
                var random = new Random();
                int index = random.Next(rdmliste.Count);
                list.Add(rdmliste[index]);
                rdmliste.RemoveAt(index);
            }
        }
    }
}
