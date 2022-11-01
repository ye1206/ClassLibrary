using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using ClassLibrary_Cheng3001.HelperEnum_Cheng3001;
using ClassLibrary_Cheng3001.HelperFunctions_Cheng3001;

namespace ClassLibrary_Cheng3001
{
    public class DataValidation_Cheng3001
    {
        //define fields and properties
        public bool GUI_ON { get; set; }
        public bool CONSOLE_ON { get; set; }
        public int inputIntValue = 0;
        public double inputDoubleValue = 0;
        public double inputValue = 0.0;
        public int TYPE_INT = (int)EnumForDataType.INT_TYPE;

        public DataValidation_Cheng3001() { }

        public DataValidation_Cheng3001(bool _guiOn, bool _consoleOn) 
        {
            GUI_ON = _guiOn;
            CONSOLE_ON = _consoleOn;
        }

        public void setNumberByTypeUsingIfElseClause(string dataString, int _typeInt)
        {
            if (_typeInt == (int)EnumForDataType.INT_TYPE)
            {
                inputIntValue = int.Parse(dataString);
                if (GUI_ON)
                    MessageBox.Show("inputIntValue (for INT_TYPE) = " + inputIntValue);
                if (CONSOLE_ON)
                    Console.WriteLine("inputIntValue(for INT_TYPE) = " + inputIntValue);
                inputValue = inputIntValue;
            }
            else if (_typeInt == (int)EnumForDataType.DOUBLE_TYPE)
            {
                inputDoubleValue = double.Parse(dataString);
                if (GUI_ON)
                    MessageBox.Show("inputDoubleValue (for DOUBLE_TYPE) = " + inputDoubleValue);
                inputValue = inputDoubleValue;
            }
        } //end of setNumberByTypeUsingIfElseClause

        public bool checkValueInRangeOfMinOP1ToMaxON1(string inputData_String, string KeyString, double minValue, double MaxValue, bool checkFlagMin0, bool checkFlagMax0, int _typeInt)
        {
            inputValue = 0.0;
            bool chkOK = false;
            string caption = KeyString + "(between" + minValue + (checkFlagMin0 ? "(>=)" : "(>)") + "and" + MaxValue + (checkFlagMax0 ? "(<=)!" : "(<)!)");
            string Qes = caption + "?";
            string reminder = "Re-input / Check" + caption;

            try
            {
                inputDoubleValue = double.Parse(inputData_String);
                if ((checkFlagMin0 ? (inputDoubleValue >= minValue) : (inputDoubleValue > minValue)) && (checkFlagMax0 ? (inputDoubleValue <= MaxValue) : (inputDoubleValue < minValue)))
                {
                    chkOK = true;
                    setNumberByTypeUsingIfElseClause(inputData_String, _typeInt);
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                if (CONSOLE_ON)
                    Console.WriteLine(ex.Message + "\r\n" + reminder);
                if (GUI_ON)
                    MessageBox.Show(ex.Message + "\r\n" + reminder);
            }

            return chkOK;
        }

        public string validateValueInRange(string KeyString, double minValue, double MaxValue, bool checkFlagMin0, bool checkFlagMax0, int _typeint)
        {
            var check_S_Num = false;
            var Qes = KeyString + "(between " + minValue + "(>=) " + "and" + MaxValue + "(<)!)" + "?";
            var stringInput = string.Empty;

            while (check_S_Num == false)
            {
                Console.WriteLine(Qes);
                stringInput = Console.ReadLine();

                check_S_Num = checkValueInRangeOfMinOP1ToMaxON1(stringInput, KeyString, minValue, MaxValue, checkFlagMin0, checkFlagMax0, _typeint);
            }

            return stringInput;
        }

        static string validateStringNotEmpty(string KeyString)
        {
            var stringInput = "";
            var check_S = false;
            var Qes = KeyString + "?";
            var exceptionMessage = KeyString + " (Cannot be empty!)";

            while (check_S == false)
            {
                Console.WriteLine(Qes);
                stringInput = Console.ReadLine();
                try
                {
                    if (stringInput.Trim() != string.Empty)  //trim只會留下非空格的字元
                    {
                        check_S = true;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Please re-input " + exceptionMessage);
                } //end of try-catch
            } // end of while

            return stringInput;
        } //end of validateStringNotEmpty

        public static string getReminderUsingFlagPNO(int flagValuePNO, double thresholdValue, string KeyString)
        {
            var reminder = "";
            if (flagValuePNO == 0)
                reminder = KeyString + "(Make sure: = " + thresholdValue + "!)";
            else if (flagValuePNO == +1)
                reminder = KeyString + "(Make sure: > " + thresholdValue + "!)";
            else
                reminder = KeyString + "(Make sure: < " + thresholdValue + "!)";
            return reminder;
        }

        static string validateValueUsingCompare_1flag(string KeyString, double thresholdValue, int flagValuePNO)
        {
            var stringInput = "";
            var check_S = false;
            var reminder = "";
            var inputDoubleValue = 0.0;
            reminder = getReminderUsingFlagPNO(flagValuePNO, thresholdValue, KeyString);
            var Question = reminder + "?";
            Console.WriteLine("\nInside validateValueUsingCompare_1flag");

            while (check_S == false)
            {
                Console.WriteLine(Question);
                try
                {
                    stringInput = Console.ReadLine();
                    inputDoubleValue = double.Parse(stringInput);
                    if (FunctionsUseOftenOrArray_Cheng3001.CompareTwoData(inputDoubleValue, thresholdValue) == flagValuePNO)
                        check_S = true;
                    else
                    {
                        Console.WriteLine(reminder);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error. " + ex.Message + reminder);
                }
            }
            return stringInput;
        } //end of validateValueUsingCompare_1flag 


    }
}
