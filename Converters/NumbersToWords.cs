using System.Text;

namespace Re_useable_Classes.Converters
{
    public static class NumbersToWords
    {
        public static string NumberToText
            (
            int number,
            bool isUk)
        {
            if (number == 0)
            {
                return "Zero";
            }
            string and = isUk
                             ? "and "
                             : ""; // deals with UK or US numbering
            if (number == -2147483648)
            {
                return "Minus Two Billion One Hundred " + and +
                       "Forty Seven Million Four Hundred " + and + "Eighty Three Thousand " +
                       "Six Hundred " + and + "Forty Eight";
            }
            var num = new int[4];
            int first = 0;
            var sb = new StringBuilder();
            if (number < 0)
            {
                sb.Append("Minus ");
                number = -number;
            }
            string[] words0 =
            {
                "",
                "One ",
                "Two ",
                "Three ",
                "Four ",
                "Five ",
                "Six ",
                "Seven ",
                "Eight ",
                "Nine "
            };
            string[] words1 =
            {
                "Ten ",
                "Eleven ",
                "Twelve ",
                "Thirteen ",
                "Fourteen ",
                "Fifteen ",
                "Sixteen ",
                "Seventeen ",
                "Eighteen ",
                "Nineteen "
            };
            string[] words2 =
            {
                "Twenty ",
                "Thirty ",
                "Forty ",
                "Fifty ",
                "Sixty ",
                "Seventy ",
                "Eighty ",
                "Ninety "
            };
            string[] words3 =
            {
                "Thousand ",
                "Million ",
                "Billion "
            };
            num[0] = number%1000; // units
            num[1] = number/1000;
            num[2] = number/1000000;
            num[1] = num[1] - 1000*num[2]; // thousands
            num[3] = number/1000000000; // billions
            num[2] = num[2] - 1000*num[3]; // millions
            for (int i = 3;
                 i > 0;
                 i--)
            {
                if (num[i] == 0)
                {
                    continue;
                }
                first = i;
                break;
            }
            for (int i = first;
                 i >= 0;
                 i--)
            {
                if (num[i] == 0)
                {
                    continue;
                }
                int u = num[i]%10;
                int t = num[i]/10;
                int h = num[i]/100;
                t = t - 10*h; // tens
                if (h > 0)
                {
                    sb.Append(words0[h] + "Hundred ");
                }
                if (u > 0 || t > 0)
                {
                    if (h > 0 || i < first)
                    {
                        sb.Append(and);
                    }
                    if (t == 0)
                    {
                        sb.Append(words0[u]);
                    }
                    else if (t == 1)
                    {
                        sb.Append(words1[u]);
                    }
                    else
                    {
                        sb.Append(words2[t - 2] + words0[u]);
                    }
                }
                if (i != 0)
                {
                    sb.Append(words3[i - 1]);
                }
            }
            return sb.ToString()
                     .TrimEnd();
        }
    }
}
