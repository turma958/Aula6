﻿namespace Aula6.Utils
{
    public static class Utils
    {
        public static int ToInt(this string input)
            => int.TryParse(input, out var number) ? number : default;
    }
}
