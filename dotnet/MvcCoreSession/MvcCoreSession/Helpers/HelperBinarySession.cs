using Newtonsoft.Json.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Text;

namespace MvcCoreSession.Helpers
{
    public class HelperBinarySession
    {
        public static byte[]? ObjectToByte(object obj)
        {
            if (obj == null)
                return null;
            BinaryFormatter bf = new();
            using (MemoryStream ms = new())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        public static object ByteToObject(byte[] data)
        {
            BinaryFormatter bf = new();
            using (MemoryStream ms = new())
            {
                ms.Write(data, 0, data.Length);
                ms.Seek(0, SeekOrigin.Begin);
                Object objeto = (Object)bf.Deserialize(ms);
                return objeto;
            }
        }
    }
}
