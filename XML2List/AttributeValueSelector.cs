using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using XML2List.Interface;

namespace XML2List
{
    public class AttributeValueSelector: IElementGroupSelect
    {
        private string attribute;
        private string value;

        public AttributeValueSelector(string attr, string value)
        {
            attribute = attr;
            this.value = value;
        }
        IEnumerable<XElement> IElementGroupSelect.SelectItems(IEnumerable<XElement> listofXElements)
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

        public string Value
        {
            get { return attribute + "=" + value; }
        }
    }
}
