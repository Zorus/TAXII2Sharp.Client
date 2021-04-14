using System;
using System.Collections.Generic;
using TAXII2Sharp.Client.V20;

namespace TAXII2Sharp.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a Server endpoint of MITRE's ATT&CK TAXII server
            // NOTE: This is using the V20 version of the TAXII Implementation 
            Server endpoint = new Server("https://cti-taxii.mitre.org/taxii/");

            // Get all APIRoots from the endpoint's Discovery endpoint
            List<APIRoot> APIRoots = endpoint.GetAPIRoots();

            
            Console.WriteLine("TAXII Server: {0}", endpoint.BasePath);
            Console.WriteLine("APIRoot Elements: {0}", APIRoots.Count);

            // Iterate over the APIRoots
            foreach (APIRoot root in APIRoots)
            {
                Console.WriteLine("APIRoot Base Path: {0}", root.BasePath);
                Console.WriteLine("APIRoot Count: {0}", root.Collections.Count);

                Console.WriteLine("APIRoot Collections:");

                // Iterate over the Collections
                foreach (Collection collection in root.Collections)
                {
                    Console.WriteLine("\t[*] Collection Title: {0}", collection.Resource.Title);
                    Console.WriteLine("\t[*] Collection: {0}", collection.Resource.Id);

                    // Get the Objects from the Collection
                    var Objects = collection.GetObjects();

                    Console.WriteLine("\t\t[+] Objects in Collection: {0}", Objects.Objects.Length);

                    // Using the first STIXObject of the Objects property of the Bundle, display some of the properties of that object
                    var Object = collection.GetObject(Objects.Objects[0].Id).Objects[0];
                    Console.WriteLine("\t\t[+] First Object ID: {0}", Object.Id);

                    Console.WriteLine("\t\t\t[-] STIXObject ID: {0}", Object.Id);
                    Console.WriteLine("\t\t\t[-] STIXObject Type: {0}", Object.Type);
                    Console.WriteLine("\t\t\t[-] STIXObject Created Timestamp: {0}", Object.Created);
                    Console.WriteLine("\t\t\t[-] STIXObject Modified Timestamp: {0}", Object.Modified);
                    if (Object.Labels != null)
                    {
                        foreach (String label in Object.Labels)
                        {
                            Console.WriteLine("\t\t\t[-] STIXObject Label: {0}", label);
                        }
                    }


                }
            }
        }
    }
}
