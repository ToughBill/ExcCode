using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication2
{
    public enum TextBoxElem
    {
        Link,
        Choose,
        TextBox
    }
    public class PickerClickArgs
    {
        public TextBoxElem Element;
        public TextBoxEx TextBoxEx;
        public PickerClickArgs(TextBoxEx txtBox, TextBoxElem elem)
        {
            TextBoxEx = txtBox;
            Element = elem;
        }
    }
    public delegate void PickerClickHandler(object sender, PickerClickArgs e);
}
