namespace StaticSerializer.Core.Extensions
{
    public static class SerializerExtensions
    {
        public static string Serialize<T>(this T instance) where T : class 
        {
            return Serializer.Serialize(instance);
        }

        public static T Deserialize<T>(this string serializedObject)
        {
            return Serializer.Desezialize<T>(serializedObject);
        }
    }
}
