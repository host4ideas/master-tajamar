using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoClases.Helpers
{
    public class HelperImages
    {
        static public async Task<byte[]> GetBytesFromFile(string path)
        {
            // Calling the ReadAllBytes() function
            byte[] bytes = await File.ReadAllBytesAsync(path);
            return bytes;
        }
    }
}
