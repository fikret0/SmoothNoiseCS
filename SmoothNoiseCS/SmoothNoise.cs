using System;
using System.Collections.Generic;
using System.Text;

namespace SmoothNoiseCS
{
    public class SmoothNoise
    {
        private static Random random = new Random();

        public static float GenerateNoise(float min, float max, float maxupchange, float maxdownchange)
        {
            float average = (min + max) / 2;

            float curRandom = NextFloat(min, max);

            bool validated = ValidateFloat(curRandom, average, maxupchange, maxdownchange);

            while (!validated)
            {
                curRandom = NextFloat(min, max);

                validated = ValidateFloat(curRandom, average, maxupchange, maxdownchange);
            }

            return curRandom;
        }

        private static float NextFloat(float min, float max)
        {
            return (float)(min + (random.NextDouble() * (max - min)));
        }

        private static bool ValidateFloat(float curRandom, float average, float maxupchange, float maxdownchange)
        {
            if (curRandom > average)
            {
                if (average + maxupchange >= curRandom)
                {
                    return true;
                }
            }
            else
            {
                if (average - maxdownchange <= curRandom)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
