using System;

namespace ZPOS.UI.Helper
{
    public static class GenerateCodeForProduct
    {
        public static string Generate()
        {
            Random _random = new Random();
            var code = "0";

            while (code.Length < 6)
            {
                code += _random.Next(0, 9).ToString();
            }

            return code;
        }
    }
}
