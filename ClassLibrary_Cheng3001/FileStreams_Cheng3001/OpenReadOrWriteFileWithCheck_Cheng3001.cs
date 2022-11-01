using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;

namespace ClassLibrary_Cheng3001.FileStreams_Cheng3001
{
    public class OpenReadOrWriteFileWithCheck_Cheng3001 
    {
        #region global
        bool writeON = false, readON = false; 
        public bool isOpenFileOK = false;  //confirm if the file open successfully

        public FileStream input = null, output = null; // maintains the connection to the file
        
        public StreamWriter fileWriter = null; 
        public StreamReader fileReader = null; // reads data from text file
        
        public BinaryFormatter readformatter = null, writeformatter = null;     // object for serializing(序列化) RecordSerializables in binary format

        public string outputFileName = null, inputFileName = null;

        public int streamBased = (int)FileStreamBasedEnumNew.TEXT_BASED; //default use text-based file

        public DialogResult result;
        #endregion global

        public OpenReadOrWriteFileWithCheck_Cheng3001(bool _writeON, bool _readON)  //check to write or read file
        {
            writeON = _writeON;
            readON = _readON;
        }

        public OpenReadOrWriteFileWithCheck_Cheng3001(bool _writeON, bool _readON, int _streambased)  
        {
            writeON = _writeON;
            readON = _readON;
        }

        public string openDialogToChooseFile(string _initialDir)
        {
            // create dialog box enabling user to open file         
            DialogResult result;
            string fileName;

            using (OpenFileDialog fileChooser = new OpenFileDialog())
            {
                fileChooser.InitialDirectory = _initialDir; //default location for open file
                fileChooser.CheckFileExists = false; //let user create file
                result = fileChooser.ShowDialog();
                fileName = fileChooser.FileName;
            }

            // exit event handler if user clicked Cancel
            if (result == DialogResult.OK)
            {
                // show error if user specified invalid file
                if (string.IsNullOrEmpty(fileName))
                {
                    MessageBox.Show("Invalid File Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    isOpenFileOK = false; //fail to open file
                } //end of if
                else
                {
                    MessageBox.Show("File name selected -->" + fileName);
                    isOpenFileOK = true; //open file successfully
                } //end of else
            } //end of outer if

            else if (result == DialogResult.Cancel) 
                MessageBox.Show("There is no file selected \nor \nDialogResult.Cancel!", "Exit or Re-select a new file!");

             return fileName;
        } //end of openDialogToChooseFile

        public FileStream getFileStreamAndReadAccess(string _fileName, string _initialDir, int _streamBased)
        {
            streamBased = _streamBased;

            //show error if user specified invalid file
            if (string.IsNullOrEmpty(_fileName)) //if file name is empty
            {
                _fileName = openDialogToChooseFile(_initialDir);
            }
            else //search file
            {
                #region create FileStream to obtain read access to file
                try
                {
                    input = new FileStream(_fileName, FileMode.Open, FileAccess.Read); //create FileStream to obtain read access to file
                    //MessageBox.Show("FileName = " + _fileName);

                    if (streamBased == (int)FileStreamBasedEnumNew.TEXT_BASED)
                    {
                        fileReader = new StreamReader(input); //original
                        //fileReader = new StreamReader(input, System.Text.Encoding.UTF8, true); //solution for Chinese garbled problem
                    }
                    else if (streamBased == (int)FileStreamBasedEnumNew.BYTE_BASED)
                    {
                        readformatter = new BinaryFormatter();
                    }

                    inputFileName = _fileName;
                }
                #endregion create FileStream to obtain read access to file
                #region catch Exception
                catch (IOException)
                {
                    MessageBox.Show("Error reading from file: " + _fileName, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (ArgumentException ex)
                {
                   MessageBox.Show(ex.Message + "\n" + "System.ArgumentNullException: Path cannot be null", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (NullReferenceException ne)
                {
                    MessageBox.Show(ne.Message + "\n" + "No such file!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                #endregion catch Exception
            } //end of else

            return input;
        } //end of getFileStreamAndReadAccess

        public FileStream CreateFileStreamAndWriteAccess(string _fileName, string _initialDir, int _streamBased)
        {
            streamBased = _streamBased;

            //show error if user specified invalid file
            if (string.IsNullOrEmpty(_fileName))
            {
                _fileName = openDialogToChooseFile(_initialDir);
            }
            else
            {
                #region create FileStream to obtain write access to file
                try
                {
                    output = new FileStream(_fileName, FileMode.OpenOrCreate, FileAccess.Write); //create FileStream to obtain read access to file
                    //MessageBox.Show("FileName = " + _fileName);

                    if (streamBased == (int)FileStreamBasedEnumNew.TEXT_BASED)
                    {
                        fileWriter = new StreamWriter(output); //original
                        //fileWriter = new StreamWriter(output, System.Text.Encoding.UTF8); //solution for Chinese garbled problem
                    }
                    else if (streamBased == (int)FileStreamBasedEnumNew.BYTE_BASED)
                    {
                        writeformatter = new BinaryFormatter();
                    }

                    outputFileName = _fileName;
                }
                #endregion create FileStream to obtain write access to file
                #region catch Exception
                catch (IOException)
                {
                    MessageBox.Show("Error reading from file: " + _fileName, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //catch (ArgumentException ex)
                //{
                //     MessageBox.Show(ex.Message + "\n" + "System.ArgumentNullException: Path cannot be null", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
                #endregion catch Exception
            } //end of else

            return output;
        } //end of CreateFileStreamAndWriteAccess

        public void CloseFile()
        {
            #region Close SreamReader and underlying file
            // close file and StreamReader
            try
            {
                if (streamBased == (int)FileStreamBasedEnumNew.TEXT_BASED)
                {
                    if (writeON)
                        fileWriter?.Close();
                    if (readON)
                        fileReader?.Close();
                }
                else //Byte-Based
                {
                    if (writeON)
                        output?.Close();
                    if (readON)
                        input?.Close();
                }
            }
            #endregion Close SreamReader and underlying file
            #region Handle exception if there is a problem opening a file
            catch (IOException)
            {
                // notify user of error closing file
                MessageBox.Show("Cannot close file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #endregion Handle exception if there is a problem opening a file
        } //end of CloseFile
    }
}
