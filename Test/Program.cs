using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Web.Mvc;
using Test.Models;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal money = 999.261646m;
            decimal cw = Math.Round(money, 4);
            Console.WriteLine(cw.ToString());
            //var xx = GetData();
            //foreach (var item in xx)
            //{
            //    Console.WriteLine("****************************************");
            //    Console.WriteLine("// ID : {0}",item.id);
            //    Console.WriteLine("// ROOM : {0}",item.room);
            //    Console.WriteLine("// DATA({1}) : {0}", item.data, item.data.Split(",").Length);
            //    Console.WriteLine("// NAME : {0}", item.name);
            //    Console.WriteLine("// % : {0}", item.percent);
            //    Console.WriteLine("// DEALER : {0}", item.dealer);
            //    Console.WriteLine("// IMG : {0}", item.img);
            //    Console.WriteLine("// CARD : {0}", item.card);

            //    //Console.WriteLine("DATA : {0}", item.data.Split(",").Length);

            //    //sb = sb.Append(item.data+" ");
            //    string[] ll = item.data.Split(",");
            //    int count = 0;

            //    for (int i = 0; i < ll.Length; i++)
            //    {

            //        if (ll[i] == "p")
            //        {
            //            count = 0;
            //        }
            //        else
            //        {
            //            count++;
            //        }
            //        if (count == 4)
            //        {
            //            Console.WriteLine("RUN!!");
            //            //System.Diagnostics.Process.Start("C:\\Program Files (x86)\\Google\\Chrome\\Application\\chrome.exe");
            //            break;
            //        }
            //        else
            //        {
            //            Console.Write(".");
            //        }

            //    }
            //    Console.WriteLine();

            //}


            //Console.Write("Enter Number");
            //string text = Console.ReadLine();
            //do
            //{
            //    if (OverCheck(text))
            //    {
            //        Console.WriteLine("\nOK");
            //    }
            //    else
            //    {
            //        Console.WriteLine("\nNOT OK!");
            //    }
            //    text = Console.ReadLine();
            //} while (text != "stop");
            //EqualVsOpEquals();
            //string x = "CID:1234567890121,Result:Pass:[CID IsExist],Result:Pass:[checkbox=True],Result:Fail:[Username is Exist],Result:Pass:[testuserx],Result:Pass[checkbox=True],user:[testuserx],Result:Pass:[testuserx],Result:Register:[Done]";
            //var xx = x.Length;
            //Console.WriteLine(xx);
            //Console.ReadLine();
            //foreach (char c in text)
            //{
            //    int unicode = c;
            //    Console.WriteLine(unicode < 128 ? "ASCII: {0}" : "Non-ASCII: {0}", unicode);
            //}

        }
        [HttpGet]
        public static Ans[] GetData()
        {
            using (var client = new HttpClient())
            {
                //Ans[] ansx = new Ans();
                client.BaseAddress = new Uri("https://newsa.zean.app/");
                var response = client.GetAsync(client.BaseAddress).Result;
                if (response.IsSuccessStatusCode)
                {
                    var responseString = response.Content.ReadAsStringAsync().Result;
                    Ans[] item = JsonConvert.DeserializeObject<Ans[]>(responseString);
                    return item;
                }
                else
                {
                    return null;
                }
            }
        }
        private static void EqualVsOpEquals()
        {
            String nameA = "Chatri Ngambenchawong";
            String nameB = "Chatri Ngambenchawong";
            char[] values = { 'C', 'h', 'a', 't', 'r', 'i', ' ', 'N', 'g', 'a', 'm', 'b', 'e', 'n', 'c', 'h', 'a', 'w', 'o', 'n', 'g' };
            String nameC = new String(values);
            //=================================================
            //Test 1
            bool resultEqualsMethodAB = nameA.Equals(nameB);
            //Result = True
            //=================================================
            //=================================================
            //Test 2
            bool resultEqualsOperatorAB = nameA == nameB;
            //Result = True
            //=================================================
            //=================================================
            //Test 3
            bool resultEqualsMethodAC = nameA.Equals(nameC);
            //Result = True
            //=================================================
            //=================================================
            //Test 4
            bool resultEqualsOperatorAC = nameA == nameC;
            //Result = False
            //=================================================
        }

        static bool hasOrderedCharacters(string x)
        {
            var num = 4;
            var count = 0;
            var dir = 1;
            var last = 0;
            for (int i = 0; i < x.Length; i++)
            {
                //1 2 3 5 6 7 8 0
                //49 50 51 53 54 55 56
                var current = Convert.ToInt32(x[i]);

                if (count == 1 && current == last - 1)
                {
                    count++;
                    dir = -1;
                    if (count >= num)
                    {
                        Console.Write(current + "\t");
                        return false;
                    }
                }
                else if (current == last + dir)
                {
                    count++;
                    if (count >= num)
                    {
                        Console.Write(current + "\t");
                        return false;
                    }
                }
                else
                {
                    count = 1;
                    dir = 1;
                }
                Console.Write(current + "\t");
                last = current;
            }

            return true;
        }
        static bool OverCheck(string stringInput)
        {
            int forword = 0;
            int backword = 0;
            int fouthword = 0;
            int max = 3;
            int befor = 0;

            for (int i = 0; i < stringInput.Length; i++)
            {
                int now = Convert.ToInt32(stringInput[i]);

                if (now == befor + 1)//forword
                {
                    forword++;
                    if (forword >= max)
                    {
                        return false;
                    }
                    backword = 0;
                    fouthword = 0;
                }
                else if (now == befor - 1)//backword
                {
                    backword++;
                    if (backword >= max)
                    {
                        return false;
                    }
                    forword = 0;
                    fouthword = 0;
                }
                else if (now == befor)//fouthword
                {
                    fouthword++;
                    if (fouthword >= max)
                    {
                        return false;
                    }
                    forword = 0;
                    backword = 0;
                }
                else
                {
                    forword = 0;
                    backword = 0;
                    fouthword = 0;
                }
                befor = now;

                Console.Write(now + "\t");

            }
            return true;
        }
        static bool TipleCheck(string stringInput)
        {
            int count = 1;
            int max = 4;
            int next = 0;
            for (int i = 0; i < stringInput.Length; i++)
            {
                int now = Convert.ToInt32(stringInput[i]);
                Console.Write(now + "\t");
                if (now == next)
                {
                    count++;
                    if (count >= max)
                    {
                        Console.WriteLine("XXXX NOT OK");
                        return false;
                    }
                }
                next = now;
            }
            Console.WriteLine();
            return true;
        }
        static bool BackwordCheck(string stringInput)
        {
            int count = 1;
            int max = 4;
            int next = 0;

            for (int i = 0; i < stringInput.Length; i++)
            {
                int current = Convert.ToInt32(stringInput[i]);
                Console.Write(current + "\t");
                if (current == next - 1)
                {
                    count++;
                    if (count >= max)
                    {
                        Console.WriteLine("<<<< NOT OK");
                        return false;
                    }
                }
                next = current;
            }
            return true;
        }
        static bool ForwordCheck(string stringInput)
        {
            int count = 0;
            int max = 4;
            int next = 0;
            for (int i = 0; i < stringInput.Length; i++)
            {
                int current = Convert.ToInt32(stringInput[i]);
                Console.Write(current + "\t");
                if (current == next + 1)
                {
                    count++;
                    if (count >= max)
                    {
                        Console.WriteLine(">>> NOT OK");
                        return false;
                    }
                }
                else
                {
                    count = 1;
                }
                next = current;
            }
            Console.WriteLine();
            return true;
        }
        static string SplitName(string fullname)
        {
            var x = SplitName("hell 0 g 1 6  6").Split(" ");

            string name;
            string lastname = "-";
            var splitName = fullname.Split(' ');
            StringBuilder sb = new StringBuilder();
            name = splitName[0];
            if (splitName.Length >= 2)
            {
                for (int i = 1; i < splitName.Length; i++)
                {
                    sb.Append(splitName[i]);
                }
                lastname = sb.ToString();
            }
            name = x[0];
            lastname = x[1];
            Console.WriteLine(name + " " + lastname);
            Console.ReadLine();

            return name + " " + lastname;
        }
    }
}
