using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Demo
{
    public class Finder
    {
        public string[] findNames(string input)
        {
            string pattern = @"(\w+:)(?<=:)[ ]*(\S*(?:[ ]+\S+)*)";
            RegexOptions options = RegexOptions.Multiline;
            string[] str = new string[10];
            int j = 0;
            foreach (Match m in Regex.Matches(input, pattern, options))
            {
                str[j] = m.Value+"\n";
                j++;
            }
            return str;
        }
    }
}