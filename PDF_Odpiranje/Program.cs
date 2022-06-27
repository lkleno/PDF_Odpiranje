using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;

namespace PDF_Odpiranje
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filename = ConfigurationManager.AppSettings["filename"];
            int interval = Convert.ToUInt16(ConfigurationManager.AppSettings["interval"]);
            while (true)
            {
                string[] fileGroup = Directory.GetFiles(filename, "*_R.pdf");
                foreach (var x in fileGroup)
                {
                    var newName = x.Substring(0, x.Length - 6) + ".pdf";
                    System.IO.File.Move(x, newName);
                    System.Diagnostics.Process.Start(newName);
                }
                System.Threading.Thread.Sleep(interval);
            }
        }
    }
}
