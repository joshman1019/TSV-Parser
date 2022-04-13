using System.Data;

namespace TSVParser
{
    public static class Parser
    {
        public static DataTable CreateDataTableFromFile(string path)
        {
            DataTable table = new DataTable();
            var reader = new StreamReader(path);
            List<string[]> resultsArray = new List<string[]>();
            string[]? headerRow;
            int columnCount = 0;

            // if the reader is not null, proceed to split lines on tab delimiter
            if (reader is not null)
            {
                while (!reader.EndOfStream)
                {
#pragma warning disable CS8602
                    resultsArray.Add(reader.ReadLine().Split('\t'));
#pragma warning restore CS8602
                }
            }

            // If the results array count is not zero then we determine column count and 
            // assign a header row
            if (resultsArray.Count > 0)
            {
                // Assign a column count
                columnCount = resultsArray[0].Length;

                // Create the header row
                headerRow = resultsArray[0];

                // Remove the header from the results list
                resultsArray.RemoveAt(0);
            }
            // Otherwise, if count is 0 or less, create an empty header row
            else
            {
                headerRow = new string[] { };
            }

            // For each string in the header row, create a data column
            for (int i = 0; i < headerRow.Length; i++)
            {
                // Create the columm and name it
                DataColumn dc = new DataColumn(headerRow[i].ToString());

                // Add teh column to the table
                table.Columns.Add(dc); 
            }

            // Now that headers are in palce, add the data to the table
            foreach (string[] item in resultsArray)
            {
                table.Rows.Add(item); 
            }

            // Finally, return the completed table
            return table; 
        }
    }
}