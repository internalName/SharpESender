using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace ESender
{
    class Program
    {
        private const string URI = @"https://api.esv2.com/v2/Api/Lists";
        private const string KEY = @"9DfWEl04zzEcnWsEc6mx";
        static void Main(string[] args)
        {
            ValueOfList[] lists = Parser.GetValues(ManagerOfNetworking.Get(URI,
                @"apiKey="+KEY));

            
            String postValues = Parser.PostValues(lists);
            Printer.Print(Parser.ListsDoubleOptIn);
            Printer.Print(Parser.ListsSingleOptIn);
            //ManagerOfNetworking.Post(URI, KEY, Parser.PostValues(lists));

            Console.ReadLine();
        }

        private void Test()
        {
      //      string result = @"<!DOCTYPE HTML>
      //                          <ApiKey>9DfWEl04zzEcnWsEc6mx</ApiKey>
      //                          <SeedLists>
      //                               <SeedList>2602</SeedList>
      //                          </SeedLists>
      //                          <body>
      //                          <table>
      //                              <tr>
      //                                <th>Id</th>
      //                                <th>Name</th>
      //                                <th>FriendlyName</th>
      //                                <th>Language</th>
      //                                <th>OptInMode</th>
      //                              </tr>";
      //
      //      for (int i = 0; i < lists.Length; i++)
      //      {
      //          result += String.Format(@"                                    <tr>
      //                                <th>{0}</th>
      //                                <th>{1}</th>
      //                                <th>{2}</th>
      //                                <th>{3}</th>
      //                                <th>{4}</th>
      //                              </tr>", lists[i].Id, lists[i].Name, lists[i].FriendlyName, lists[i].Language,
      //              lists[i].OptInList);
      //      }
      //
      //      result += @"</table>
      //                  </body>";
        }
    }
}