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
        private static String _xmlText = default(String);
        private static ValueOfList[] _lists = default(ValueOfList[]);

        public static String XmlText => _xmlText;
        public static int Size => _lists.Length;

        public Parser(String xmlText)
        {
            _collectionLists = _regInner.Matches(xmlText);
        }

        public static ValueOfList[] GetValues(String xmlText)
        {
            _xmlText = xmlText;
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

        private static String SearchDataInXml(String value, String text)
        {
            return new Regex(String.Format("(?<=<{0}>)(.*)(?=</{1}>)", value, value)).Match(text).Value;
        }
    }
}