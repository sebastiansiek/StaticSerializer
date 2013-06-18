using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace StaticSerializer.Core
{
    public static class Serializer
    {
        public static string Serialize<T>(T instance)
        {
            var xmlSerializer = new XmlSerializer(typeof (T));

            string result;

            using (var stream = new MemoryStream())
            {
                xmlSerializer.Serialize(stream, instance);
                result = Encoding.UTF8.GetString(stream.ToArray());
            }

            return result;
        }

        public static T Desezialize<T>(string serializedObject)
        {
            var xmlSerializer = new XmlSerializer(typeof(T));

            T result;

            using (TextReader reader = new StringReader(serializedObject))
            {
                result = (T)xmlSerializer.Deserialize(reader);
            }

            return result;
        }
    }
}
