using System.Text;

namespace MetaQuotes.IPSearch.Services.Extensions
{
    public static class StreamReaderExtensions
    {
        public static sbyte[] ReadSBytes(this BinaryReader reader, int number)
        {
            sbyte[] sbyteData = new sbyte[number];
            for (int i = 0; i < number; i++)
            {
                sbyteData[i] = reader.ReadSByte();
            }

            return sbyteData;
        }

        public static string ToString(this SByte[] sbyteData) {
            var number = sbyteData.Length;
          
            //Convert sbyte[] to byte[]
            byte[] byteData = Array.ConvertAll(sbyteData, (a) => (byte)a);
            System.IO.Stream stream = new System.IO.MemoryStream(byteData);

            //you got the actual string here
            string stringFromByteData = UTF8Encoding.UTF8.GetString(byteData);
            return stringFromByteData;
        }
    }
}
