﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Code4Ro.CoViz19.Models.ParsedPdfModels;

namespace Code4Ro.CoViz19.Parser.Parsers
{
    public class PdfParser
    {
        internal static int ParseNumberInfected(string pdfContents)
        {
            const string pattern = @"(\d+) cazuri diagnosticate covid";

            var result = ExtractNumberByPattern(pattern, pdfContents);

            return result ?? -1;
        }

        private static int? ExtractNumberByPattern(string pattern, string text)
        {
            var regex = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
            var match = regex.Matches(text);
            if (match.Count > 0)
            {
                return int.Parse(match[0].Groups[1].Value);
            }
            return null;
        }

        internal static int ParseNumberCured(string pdfContents)
        {
            throw new NotImplementedException();
        }

        internal static int ParseNumberDeceased(string pdfContents)
        {
            throw new NotImplementedException();
        }

        internal static Dictionary<AgeRange, int> ParseDistributionByAge(string pdfContents)
        {
            throw new NotImplementedException();
        }

        internal static int ParseAverageAge(string pdfContents)
        {
            throw new NotImplementedException();
        }
    }
}
