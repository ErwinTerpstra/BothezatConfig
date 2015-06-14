using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BothezatConfig
{
    public static class Util
    {
        public const int MIN_PWM = 1000, MAX_PWM = 2000;

        public static int ClampPWM(int input)
        {
            return Math.Min(Math.Max(input, MIN_PWM), MAX_PWM);
        }

    }
}
