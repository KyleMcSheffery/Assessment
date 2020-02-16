using System;
using System.Linq;

namespace Assessment
{
    class Question1
    {
        static void Main(string[] args)
        {
            /*NOTE: I found the question ambiguous about whether I needed to work with only the LOC segments or to remove the LOC segment and work with the remaining segments. In a work situation I would seek clarification.
             * If I was supposed to remove the LOC segments and work with the remaining segments, replace line 30 with the following:
             * segments = segments.Where(s => !s.StartsWith("LOC + ")).ToArray();
             */

            string edifactText = @"UNA:+.? '
UNB + UNOC:3 + 2021000969 + 4441963198 + 180525:1225 + 3VAL2MJV6EH9IX + KMSV7HMD + CUSDECU - IE++1++1'
UNH + EDIFACT + CUSDEC:D: 96B: UN: 145050'
BGM + ZEM:::EX + 09SEE7JPUV5HC06IC6 + Z'
LOC + 17 + IT044100'
LOC + 18 + SOL'
LOC + 35 + SE'
LOC + 36 + TZ'
LOC + 116 + SE003033'
DTM + 9:20090527:102'
DTM + 268:20090626:102'
DTM + 182:20090527:102'";

            //Split the EDIFACT into lines then filter to find LOC segments
            string[] segments = edifactText.Split('\n');
            segments = segments.Where(s => s.StartsWith("LOC + ")).ToArray();
            string[] result = new String[segments.Count() * 2];

            for (int i=0; i<segments.Length; i++)
            {
                //Trim the segments of segment tags, carriage returns and the ' character
                segments[i] = segments[i].TrimEnd('\r', '\'');

                //Split into segments using the + delimiter
                string[] elements = segments[i].Split('+').ToArray();

                //Populate the result array with the second and third elements.
                if (elements.Length > 1) result[i * 2] = elements[1];
                if (elements.Length > 2) result[i * 2 + 1] = elements[2];
            }

            //Check the results
            foreach (string element in result)
            {
                Console.WriteLine(element);
            }
        }
    }
}
