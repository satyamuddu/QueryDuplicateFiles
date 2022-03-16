using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest
{
    class Program
    {
        static void Main(string[] args)
        {
            QueryDuplicateFiles.QueryDuplicateFiles.startFolder = @"C:\git";
            QueryDuplicateFiles.QueryDuplicateFiles.extension = "*";

            foreach (var x in QueryDuplicateFiles.QueryDuplicateFiles.QueryDuplicatesByFileNameAndLength())
            {
                foreach(var y in x)
                {
                    
                    foreach(var z in y.OrderBy(a=>a))
                    {
                        Console.Write(z+",");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
