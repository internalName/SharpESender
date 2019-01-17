using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESender
{
    class ValueOfList
    {
        private OptIn _optInList = default(OptIn);
        private string _name = default(String);
        private string _friendlyName = default(String);
        private int _id = default(Int32);
        private string _language = default(String);


        public string FriendlyName => _friendlyName;

        public int Id => _id;

        public string Language => _language;

        public string Name => _name;

        public OptIn OptInList => _optInList;

        public ValueOfList(int id, String name, String friendlyName, string language, OptIn optIn)
        {
            _id = id;
            _friendlyName = friendlyName;
            _language = language;
            _optInList = optIn;
            _name = name;
        }
    }
}