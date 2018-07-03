using System;

namespace DACSistemas.Central_de_Cursos.BackEnd.Utils
{
    public static class TrimString
    {
        public static string LimpaString(this String str)
        {
            if (string.IsNullOrEmpty(str))
                return null;

            return str.Trim();
        }
    }
}