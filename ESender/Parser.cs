using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ESender
{
    class Parser
    {
        private static Regex _regInner = new Regex(@"<List>[\s\S]+?</List>");
        private static MatchCollection _collectionLists = default(MatchCollection);

        private static String _xmlTextGet = "";
        private static String _xmlTextPost = "";

        private static IEnumerable<ValueOfList> _listsSingleOptIn = new List<ValueOfList>();
        private static IEnumerable<ValueOfList> _listsDoubleOptIn = new List<ValueOfList>();

        private static ValueOfList[] _lists = default(ValueOfList[]);

        #region TextSections

        private static String _text_1 =
            @"<ApiRequest xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xs=""http://www.w3.org/2001/XMLSchema"">
   <ApiKey>9DfWEl04zzEcnWsEc6mx</ApiKey>
   <Data>
     <Recipients>
       <SubscriberLists>
         <SubscriberList></SubscriberList>
       </SubscriberLists>
        <SeedLists>
         <SeedList>2602</SeedList>
       </SeedLists>
     </Recipients>
     <Content><html><body><table>
                                    <tr>
                                      <th>Id</th>
                                      <th>Name</th>
                                      <th>FriendlyName</th>
                                      <th>Language</th>
                                      <th>OptInMode</th>
                                    </tr>";

        private static String _text_2 = @"</table><table>
                                    <tr>
                                      <th>Id</th>
                                      <th>Name</th>
                                      <th>FriendlyName</th>
                                      <th>Language</th>
                                      <th>OptInMode</th>
                                    </tr>";

        private static String _text_3 = @"</body><html></Content>
                        </Data>
                      </ApiRequest >";

        #endregion

        public static ValueOfList[] ListsSingleOptIn => _listsSingleOptIn.ToArray();
        public static ValueOfList[] ListsDoubleOptIn => _listsDoubleOptIn.ToArray();
        public static String XmlTextGet => _xmlTextGet;
        public static String XmlTextPost => _xmlTextPost;
        public static int Size => _lists.Length;

        public static ValueOfList[] GetValues(String xmlText)
        {
            _xmlTextGet = xmlText;
            _collectionLists = _regInner.Matches(xmlText);

            _lists = new ValueOfList[_collectionLists.Count];

            for (int i = 0; i < _lists.Length; i++)
            {
                _lists[i] = new ValueOfList(Int32.Parse(SearchDataInXml("Id", _collectionLists[i].Value)),
                    SearchDataInXml("Name", _collectionLists[i].Value),
                    SearchDataInXml("FriendlyName", _collectionLists[i].Value),
                    SearchDataInXml("Language", _collectionLists[i].Value),
                    SearchDataInXml("OptInMode", _collectionLists[i].Value) == OptIn.DoubleOptIn.ToString()
                        ? OptIn.DoubleOptIn
                        : OptIn.SingleOptIn);
            }

            return _lists;
        }

        public static String PostValues(ValueOfList[] valueOfLists)
        {
            _listsSingleOptIn = valueOfLists.Where(i => i.OptInList == OptIn.SingleOptIn);
            _listsDoubleOptIn = valueOfLists.Where(i => i.OptInList == OptIn.DoubleOptIn);

            TableCreator(_listsDoubleOptIn.ToArray());

            _text_1 += _text_2;

            TableCreator(_listsSingleOptIn.ToArray());

            _text_1 += _text_3;

            return _text_1;
        }

        private static void TableCreator(ValueOfList[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                _text_1 += String.Format(@"                                    <tr>
                                      <th>{0}</th>
                                      <th>{1}</th>
                                      <th>{2}</th>
                                      <th>{3}</th>
                                      <th>{4}</th>
                                    </tr>", array[i].Id, array[i].Name, array[i].FriendlyName, array[i].Language,
                    array[i].OptInList);
            }
        }

        private static String SearchDataInXml(String value, String text)
        {
            return new Regex(String.Format("(?<=<{0}>)(.*)(?=</{1}>)", value, value)).Match(text).Value;
        }
    }
}