using System;

namespace D_AND_D
{
    public class Random_kosc
    {
        private static readonly Random random = new();
        private static readonly object syncLock = new();

        public static int RandomNumber(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                return random.Next(min, max);
            }
        }
    }
}
