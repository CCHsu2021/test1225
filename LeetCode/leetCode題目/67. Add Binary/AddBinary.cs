using System;

namespace Plus_One
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = "1111";
            string b = "1111";
            Console.WriteLine(AddBinary(a,b));
        }
        public static string AddBinary(string a, string b)
        {
            int c = Math.Abs(a.Length - b.Length);
            if (a.Length >= b.Length)
            {
                string[] addarr = new string[a.Length];
                string d = a.Substring(c);
                int index = 0;
                for (; index < c; index++)
                {
                    addarr[index] = a[index].ToString();
                }
                for (; index < addarr.Length; index++)
                {
                    addarr[index] = (d[index - c] - '0' + b[index - c] - '0').ToString();
                }
                for (int i = addarr.Length - 1; i > 0; i--)
                {
                    if (addarr[i].Equals("2") || addarr[i].Equals("3"))
                    {
                        addarr[i] = (int.Parse(addarr[i]) % 2).ToString();
                        addarr[i - 1] = (int.Parse(addarr[i - 1]) + 1).ToString();
                    }
                }
                if (addarr[0].Equals("2") || addarr[0].Equals("3"))
                {
                    string[] ans = new string[addarr.Length + 1];
                    ans[0] = "1";
                    addarr[0] = (int.Parse(addarr[0]) % 2).ToString();
                    Array.Copy(addarr, 0, ans, 1, addarr.Length);
                    string answer = ArrayToString(ans);
                    return answer;
                }
                if (addarr != null)
                {
                    string answer = ArrayToString(addarr);
                    return answer;
                }
            }
            else
            {
                string[] addarr = new string[b.Length];
                string d = b.Substring(c);
                int index = 0;
                for (; index < c; index++)
                {
                    addarr[index] = b[index].ToString();
                }
                for (; index < addarr.Length; index++)
                {
                    addarr[index] = (d[index - c] - '0' + a[index - c] - '0').ToString();
                }
                for (int i = addarr.Length - 1; i > 0; i--)
                {
                    if (addarr[i].Equals("2") || addarr[i].Equals("3"))
                    {
                        addarr[i] = (int.Parse(addarr[i]) % 2).ToString();
                        addarr[i - 1] = (int.Parse(addarr[i - 1]) + 1).ToString();
                    }
                }
                if (addarr[0].Equals("2") || addarr[0].Equals("3"))
                {
                    string[] ans = new string[addarr.Length + 1];
                    ans[0] = "1";
                    addarr[0] = (int.Parse(addarr[0]) % 2).ToString();
                    Array.Copy(addarr, 0, ans, 1, addarr.Length);
                    string answer = ArrayToString(ans);
                    return answer;
                }
                if (addarr != null)
                {
                    string answer = ArrayToString(addarr);
                    return answer;
                }
            }

            return "1234";
        }

        private static string ArrayToString(string[] ans)
        {
            string answer = "";
            for (int i = 0; i < ans.Length; i++)
            {
                answer += ans[i];
            }

            return answer;
        }
    }
}
