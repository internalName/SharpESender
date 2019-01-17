using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text.RegularExpressions;
using System.Xml;

namespace ESender
{
    class Program
    {
        static void Main(string[] args)
        {
            ValueOfList[] lists = Parser.GetValues(ManagerOfNetworking.Get(@"https://api.esv2.com/v2/Api/Lists",
                @"apiKey=9DfWEl04zzEcnWsEc6mx"));

            Console.WriteLine(Parser.XmlText);
            IEnumerable<ValueOfList> listsSingleOptIn = lists.Where(i => i.OptInList == OptIn.SingleOptIn);
            IEnumerable<ValueOfList> listsDoubleOptIn = lists.Where(i => i.OptInList == OptIn.DoubleOptIn);

            Print(listsSingleOptIn);

            Print(listsDoubleOptIn);


            Console.ReadLine();
        }

        static void Print(IEnumerable<ValueOfList> lists)
        {
            foreach (var VARIABLE in lists)
            {
                Console.WriteLine(Environment.NewLine+" Name: " + VARIABLE.Name + "\n" + " OptIn: " + VARIABLE.OptInList);
            }
        }
    }
}