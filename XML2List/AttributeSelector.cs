using System.Xml.Linq;
using XML2List;

namespace XML2List
{
    class AttributeSelector : IItemSelect{
        private string attribute;
        public AttributeSelector(string attribute)
        {
            this.attribute = attribute;
        }

        public XElement SelectItem(XElement item)
        {
            return null;
        }

        public string Name
        {
            get { return attribute; }
        }
    }
}
