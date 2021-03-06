namespace Rookie.Ecom.Contracts.Constants
{
    public static class ValidationRules
    {
        public static class CommonRules
        {
            public const int MinLenghCharactersForText = 0;
            public const int MaxLenghCharactersForText = 255;
        }

        public static class CategoryRules
        {
            public const int MinLenghCharactersForName = 0;
            public const int MaxLenghCharactersForName = 50;

            public const int MinLenghCharactersForDesc = 0;
            public const int MaxLenghCharactersForDesc = 100;
        }

        public static class BrandRules
        {
            public const int MinLenghCharactersForName = 0;
            public const int MaxLenghCharactersForName = 50;

            public const int MinLenghCharactersForDecription = 0;
            public const int MaxLenghCharactersForDecription = 500; 
        }
    }
}
