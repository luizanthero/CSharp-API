using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp_API.Classes;

namespace CSharp_API
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length != 0)
                {
                    string name = args[0];

                    if (name != "" || name != " ")
                    {
                        Connection.Api(name).Wait();
                    }
                    else
                    {
                        Console.WriteLine("No records found!");
                    }
                }
                else
                {
                    Console.Write("Enter an anime: ");
                    string name = Console.ReadLine();

                    if (name != "" || name != " ")
                    {
                        Connection.Api(name).Wait();
                    }
                    else
                    {
                        Console.WriteLine("No records found!");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
