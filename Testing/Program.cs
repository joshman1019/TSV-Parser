using TSVParser; 
using System.Data; 

namespace Testing
{
    public static class Program
    {
        public static void Main()
        {
            string somePath = @"C:\Users\c44jhs\Downloads\title.episode.tsv\data.tsv"; 
            var result = Parser.CreateDataTableFromFile(somePath); 
            foreach (var rowName in result.Columns)
            {
                Console.Write(rowName);
                Console.Write('\t');
                Console.WriteLine(); 
            }
            foreach (DataRow item in result.Rows)
            {
                for (int i = 0; i < result.Columns.Count; i++)
                {
                    Console.Write(item[i]);
                    Console.Write('\t'); 
                }
                Console.WriteLine(); 
            }
            Console.ReadLine(); 
        }
    }
}