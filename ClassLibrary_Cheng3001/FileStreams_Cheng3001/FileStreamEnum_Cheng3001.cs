using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace ClassLibrary_Cheng3001.FileStreams_Cheng3001
{
    public class FileStreamEnum_Cheng3001
    {
    }

    public enum FileStreamBasedEnumNew
    {
        [Description("Character-Based")]
        CHARACTER_BASED = 1,
        [Description("Byte-Based")]
        BYTE_BASED = 2,
        [Description("Text-Based")]
        TEXT_BASED = 3,
        [Description("Exit")]
        EXIT = 4
    } //end of enum FileStreamBasedEnumNew
}
