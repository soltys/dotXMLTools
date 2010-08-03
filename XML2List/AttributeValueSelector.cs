using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
namespace XML2List
{
    public class AttributeValueSelector: IListSelect
    {
        private string attribute;
        private string value;

        public AttributeValueSelector(string attr, string value)
        {
            attribute = attr;
            this.value = value;
        }
        IEnumerable<XElement> IListSelect.SelectItems(IEnumerable<XElement> listofXElements)
        {
            List<XElement> listAfterSelection = new List<XElement>();
            foreach (var element in listofXElements)
            {
                if(element.Attribute(attribute) != null && element.Attribute(attribute).Value == value)
                {
                    listAfterSelection.Add(element);
                }
            }
            return listAfterSelection;
        }

        public string Name
        {
            get { return attribute + "=" + value; }
        }
    }
}
