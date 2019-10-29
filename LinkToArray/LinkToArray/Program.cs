using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkToArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**** Fun with LINQ to objects ****\n");

            //define an array of strings
            string[] currentVideoGames = { "Morrowwind", "Uncharted 2",
                "Fallout 3", "Dexter", "System Shock 2"};

            //desired query: Games that have a space in the title

            #region First let's try it the old fashion way 
            QueryOverStringsLongHand(currentVideoGames);
            foreach(string s in result)
            {
                Console.WriteLine("Item: {0}", s);
            }
            Console.WriteLine();
            #endregion


            #region Lets try the same thing using LINQ
            QueryOverStringsLongHand(currentVideoGames);

            #endregion



        }

        #region Old fashion way
        static void QueryOverStringsLongHand(string[] s)
        {
            string[] resultWtihSpaces = new string[s.Length];

            //find the results
            for(int i=0; i < s.Length; i++)
            {
                if (s[i].Contains(" "))
                    resultWtihSpaces[i] = s[i];
            }

            //sort results
            Array.Sort(resultWtihSpaces);

            //print results
            Console.WriteLine("Imeediate results from longhand versions.");
            foreach(string s1 in resultWtihSpaces)
            {
                if (s1 != null)
                    Console.WriteLine("Item: {0}", s1);
            }
            Console.WriteLine();

            //generate a return array
            //figure out size
            int count = 0;
            foreach (string s2 in resultWtihSpaces)
            {
                if (s2 != null) count++;
            }

            //create output array
            string[] outputArray = new string[count];

            //populate output array
            count = 0;
            foreach (string s1 in resultWtihSpaces)
            {
                if (s1 != null)
                {
                    outputArray[count] = s1;
                    count++;
                }
            }
            Console.WriteLine();

        }
        #endregion


        #region
        static void QueryOverStrings(string[] inputArray)
        {
            //build query
            //Ienummerable<string> subset = from ....
            // var subset from game in inputArray
            //          where game.Contains(" ")
            //        orderby game
            //
            //select game;

            //print results
            ReflectOverQueryResults(subset, "Query Expression");

            //prints results
            Console.WriteLine("Immediate results using LINQ query");
            foreach(var s in subset)
            {
                Console.WriteLine("Item: {0}", s);
            }
            Console.WriteLine();

            //demonstrate reuse of query
            inputArray[0] = "some string";
            Console.WriteLine("Immediate results using LINQ query after change to data");
            foreach (var s in subset)
            {
                Console.WriteLine("Item: {0}", s);
            }
            Console.WriteLine();

            //demonstrate returning results - imeediate execution
            List<string> outputList = (from game in inputArray
                                       where game.Contains("")
                                       orderby game
                                       select game).ToList<string>();

        }

        static void ReflectOverQueryResults(object resultSet, string queryType)
        {
            Console.WriteLine("**** query type: {0}", queryType);
            Console.WriteLine("resultSet is of type: {0}", resultSet.GetType().Name);
            Console.WriteLine("resultSet location: {0}", resultSet.GetType().Assembly.GetName().Name);
        }
        #endregion
    }
}
