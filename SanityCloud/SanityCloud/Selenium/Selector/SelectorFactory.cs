using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SanityCloud.Contracts;
using SanityCloud.Settings;

namespace SanityCloud.Selenium.Selector
{
    internal class SelectorFactory
    {
        public ISelector GetInstance(string elementType)
        {
            if (elementType.ToLower() == Cconf.Instance.elemenType[0]) //id
            {
                return new IdSelector();
            }

            if (elementType.ToLower() == Cconf.Instance.elemenType[1]) //css
            {
                return new CssSelector();
            }

            if (elementType.ToLower() == Cconf.Instance.elemenType[2]) //xpath
            {
                return new XpathSelector();
            }

            return new CssSelector();
        }
    }
}
