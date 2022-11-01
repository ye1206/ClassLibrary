using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace ClassLibrary_Cheng3001.HelperEnum_Cheng3001
{
    internal class DataTypeForEnum_Cheng3001
    {
    }

    public enum EnumForDataType
    {
        [Description("Interger Type")]
        INT_TYPE = 1,
        [Description("Double Type")]
        DOUBLE_TYPE = 2,
        [Description("Float Type")]
        FLOAT_TYPE = 3,
    }
}
