using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerReader.Classes
{
    public static class Conditioner
    {
        public static string ToEmail(this string email) {
            return email.ToLower();
        }
        public static string ToName(this string name)
        {
            return name[0].ToString().ToUpper() + name.Substring(1).ToLower();
        }
        public static string ToStreetAddress(this string address)
        {
            StringBuilder sb = new StringBuilder();
            var adds = address.TrimStart().Split(' ');
            for(int i=0;i<adds.Length;i++)
            {
                var wrd = adds[i];
                sb.AppendFormat("{0}{1} ", wrd[0].ToString().ToUpper(), wrd.Substring(2).ToLower());
            }
            return sb.ToString();
        }

        public static string ToCity(this string city)
        {
            return city.ToName();
        }

        public static string ToState(this string state)
        {
            return state.ToUpper();
        }
    }
}
