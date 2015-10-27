using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Net_module1_2_1_lab.Model
{
    public struct Book
    {
        public string Name;
        public string Author;
        public string PublishingHouse;
        public int PageCount;
        public int Year;
        public override string ToString()
        {
            var sb= new StringBuilder();
            sb.AppendLine("---------------------------------------------------------");
            sb.AppendLine(String.Format("Name - {0}", Name));
            sb.AppendLine(String.Format("Author - {0}", Author));
            sb.AppendLine(String.Format("Publishing House - {0}", PublishingHouse));
            sb.AppendLine(String.Format("Year - {0}", Year));
            sb.AppendLine(String.Format("PageCount - {0}", PageCount));
            sb.AppendLine("---------------------------------------------------------");

            return sb.ToString();

        }
    }
}
