using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023
{
    internal class FetchData
    {
        /// <summary>
        /// Reads input, chops it up into lines.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<string> ReadList(string path, bool trim = true)
        {
            string line;
            var sr = new StreamReader(path)
                ?? throw new FileNotFoundException();

            do
            {
                line = sr.ReadLine();

                if (line != null && line != string.Empty) 
                {
                    yield return (trim) ? line.Trim() : line; 
                }
            } while (line != null);

            sr.Close();
        }
    }
}
