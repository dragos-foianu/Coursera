using System;

namespace AlgorithmsI.Courses
{
    public class KnuthShuffle
    {
        private static Random rnd;

        static KnuthShuffle()
        {
            rnd = new Random();
        }

        public static void Shuffle(ref IComparable[] a)
        {
            int N = a.Length;

            for (int i = 0; i < N; i++)
            {
                /* Random between 0 and i (inclusive) */
                int r = rnd.Next(i + 1);

                /* Swap */
                IComparable tmp = a[i];
                a[i] = a[r];
                a[r] = tmp;
            }
        }
    }
}
