using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using XML2List.Interface;
using MyExtensions;
namespace XML2List
{
    public class ElementSelector:IItemSelect
    {
        private string _elementPath;

        public ElementSelector(string elementPath)
        {
            this._elementPath = elementPath;
        }

        public XElement SelectItem(XElement item)
        {
            //TODO change this in something more pretty
            string [] elementsPaths = _elementPath.Split('/').Where(x => x.IsNotEmptyOrNull()).ToArray();
            IEnumerable<XElement> collection = item.Elements(elementsPaths[0]);
            
            
            for (int index = 1; index < elementsPaths.Length; index++)
            {
                collection = collection.Elements(elementsPaths[index]);
            }

            try
            {
                return collection.First();
            }
            catch (Exception)
            {

                return null;
            }
        }

        public string Value
        {
            get { return _elementPath; }
        }
    }
}
