using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Mod05Lab01
{
    class Program
    {
        static void Main(string[] args)
        {
            string personStr = File.ReadAllText("people.json");
            List<Person> PersonList = new List<Person>();
            try
            {
                PersonList = JsonConvert.DeserializeObject<List<Person>>(personStr);
                Console.WriteLine("--------------------------------------------------------------------------------------------------");
                Console.WriteLine("First Name     | Last Name      | Mobile #       | Email");
                Console.WriteLine("--------------------------------------------------------------------------------------------------");
                foreach (var p in PersonList)
                {
                    Console.WriteLine(String.Format("{0,-14} | {1,-14} | {2,-10} | {3,-10}", p.FirstName, p.LastName, p.Mobile, p.Email));
                }
                Console.WriteLine("--------------------------------------------------------------------------------------------------");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
