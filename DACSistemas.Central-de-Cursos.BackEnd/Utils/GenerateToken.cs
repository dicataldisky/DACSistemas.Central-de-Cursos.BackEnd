using System;
using System.Linq;

namespace DACSistemas.Central_de_Cursos.BackEnd.Utils
{
    public class GenerateToken
    {
        public static string GetNewToken()
        {
            byte[] time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
            byte[] key = Guid.NewGuid().ToByteArray();
            string token = Convert.ToBase64String(time.Concat(key).ToArray());

            token = token.Replace("/", "").Replace("+", "").Replace(",", "").Replace(@"\", "");
            return token;
        }
    }
}