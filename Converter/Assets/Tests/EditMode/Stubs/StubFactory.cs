using Converter;

namespace Tests.EditMode.Stubs
{
    public static class StubFactory
    {
        public static T[] Create<T>(int count) where T : class, new()
        {
            var result = new T[count];

            for (var i = 0; i < count; i++)
            {
                result[i] = new T();
            }

            return result;
        }
    }
}