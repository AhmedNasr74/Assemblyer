using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assembler
{
    class FileHandler
    {
        private static FileStream File;
        public static StreamReader Reader;
        public static StreamWriter Writter;
        public static void Set(string FileName , FileMode Mode)
        {
            File = new FileStream(FileName , Mode);
            Reader = new StreamReader(File);
            Writter = new StreamWriter(File);
        }
        public static void CloseReader()
        {
            Reader.Close();
        }
        public static void CloseWritter()
        {
            Writter.Close();
        }
    }
}
