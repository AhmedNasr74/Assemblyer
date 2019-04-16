using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembler
{
    class MIPS
    {
        static int OffsetCounter;
        public static List<string> Errors;
        static Dictionary<string, int> RFunct;
        static Dictionary<string, int> OpCodes;
        static Dictionary<string, int> Variabls;
        static Dictionary<string, int> Registers;
        static Dictionary<string, int> LabelsOffset;
        public static Dictionary<string, List<string>> Code;
        public static void Initialize()
        {
            OffsetCounter = 0;
            OpCodes = new Dictionary<string, int>();
            RFunct = new Dictionary<string, int>();
            LabelsOffset = new Dictionary<string, int>();
            Code = new Dictionary<string, List<string>>();
            Variabls = new Dictionary<string, int>();
            Code.Add(".data", new List<string>());
            Code.Add(".text", new List<string>());
            Code.Add(".dataTranslation", new List<string>());
            Code.Add(".textTranslation", new List<string>());
            Registers = new Dictionary<string, int>();
            Errors = new List<string>();
            LoadData();
            LoadRegistersData();
        }
        private static void LoadRegistersData()
        {
            int i = 0;
            Registers.Add("$zero", i++);
            Registers.Add("$at", i++);

            for (int k = 0; k < 2; k++)
                Registers.Add("$v"+k, i++);

            for (int k = 0; k < 4; k++)
                 Registers.Add("$a"+k, i++);

            for (int k = 0; k < 8; k++)
                Registers.Add("$t" + k, i++);

            for (int k = 0; k < 8; k++)
                Registers.Add("$s" + k, i++);

            for (int k = 8; k < 10; k++)
                Registers.Add("$t" + k, i++);

            for (int k = 0; k < 2; k++)
                Registers.Add("$k" + k, i++);

            Registers.Add("$gp", i++);
            Registers.Add("$sp", i++);
            Registers.Add("$fp", i++);
            Registers.Add("$ra", i++);



        }
        private static void LoadData()
        {
            //R-Type Instrucrtions OP _Code
            OpCodes.Add("or", 0);
            OpCodes.Add("add", 0);
            OpCodes.Add("sub", 0);
            OpCodes.Add("and", 0);
            OpCodes.Add("nor", 0);
            OpCodes.Add("slt", 0);
            RFunct.Add("or", 37);//
            RFunct.Add("add", 32);
            RFunct.Add("sub", 34);
            RFunct.Add("and", 36);
            RFunct.Add("nor", 39);
            RFunct.Add("slt", 42);

            //I-Type Instrucrtions OP _Code
            OpCodes.Add("addi", 8);
            OpCodes.Add("lw", 35);
            OpCodes.Add("sw", 43);
            OpCodes.Add("beq", 4);
            OpCodes.Add("bne", 5);

            //J-Type Instrucrtions OP _Code
            OpCodes.Add("j", 2);
        }
        public static void Clear(string option)
        {
            if(option == "*")
            {
                LabelsOffset.Clear();
                foreach (var item in Code)
                {
                    Code[item.Key].Clear();
                }
                Variabls.Clear();
                OffsetCounter = 0;
            }
            else if( option == "code")
            {
                MIPS.Code[".data"].Clear();
                MIPS.Code[".text"].Clear();
            }
        }
        private static string ConvertToBinary(int Number, int Size)
        {
            if (Number >= 0)
                return Convert.ToString(Number, 2).PadLeft(Size, '0');
            else // Number is Negative , Then Find 2'S Complememt
            {
                Number *= -1;
                string num = Convert.ToString(Number, 2).PadLeft(Size, '0');
                return FindTwosComplement(num);
            }
        }
        private static string FindTwosComplement(string str)
        {
            char[] original = str.ToArray();
            string result = "";
            int i = original.Length - 1;
            for (; i >= 1; i--)
            {
                if (original[i] == '1')
                {
                    result = original[i] + result;
                    break;
                }
                else
                    result = original[i] + result;
            }
            for (; i >= 0; i--)
            {
                if (original[i] == '1')
                    result = '0' + result;
                else
                    result = '1' + result;
            }
            return result;
        } 
        public static string FilterStringFromWhiteSpaces(string str)
        {
            return str.Replace("\t", string.Empty);
        }
        private static bool IsLabeldLine(string Line)
        {
            return Line.Contains(':');
        }
        private static char InstrctionType(string Line)
        {
            Line = Line.Split(' ')[0]; // Getting Instruction
            Line = Line.ToLower();
            if (
                    Line == "and" ||
                    Line == "add" ||
                    Line == "sub" ||
                    Line == "nor" ||
                    Line == "or" ||
                    Line == "slt" 
                )
                   { return 'R'; }
            else if (
                    Line == "addi" ||
                    Line == "lw" ||
                    Line == "sw"||
                    Line == "beq" ||
                    Line == "bne"
                )   {return 'I';}
            else if (Line == "j" )    { return 'J';  }

            return '0';
        }
        private static void TranslateDataSegment() 
        {
            OffsetCounter = 0;
            string Line , varName , dataType ;
            List<int> Number = new List<int>();
            string[] temp;
            // example => fibs: .space 12
            for (int i = 0; i < Code[".data"].Count; i++) // loopin on every line @ .data segment
            {
                Line = Code[".data"][i];
                Line = Line.Replace(":", string.Empty).Replace("\t", string.Empty);
                temp = Line.Split(' ');

                varName = temp[0];
                dataType = temp[1];

                Variabls.Add(varName, OffsetCounter);

                string[] num = FilterStringFromWhiteSpaces(temp[2]).Split(',');
                for (int k = 0; k < num.Length; k++)
                    Number.Add(int.Parse(num[k])); //getting numbers after data type

                if(dataType == ".space")
                {
                    OffsetCounter += 4 * Number[0];
                    for (int j = 0; j < Number[0]; j++)//Creating an array with dumy data with size -> number after .space
                         Code[".dataTranslation"].Add("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
                }
                else
                {
                    OffsetCounter += 4 * Number.Count;
                    for (int n = 0; n < Number.Count; n++)// creating variables with given data
                        Code[".dataTranslation"].Add(ConvertToBinary(Number[n] , 32));
                }
                Number.Clear();
            }
        }
        private static void ScanLabels()
        {
            for (int i = 0; i < Code[".text"].Count; i++)
                if (IsLabeldLine(Code[".text"][i]))
                    LabelsOffset.Add(Code[".text"][i].Replace("\t", string.Empty).Split(' ')[0].Replace(":", string.Empty), i);
        }
        private static int GetInstructionOffset(string instruction)
        {
            for (int i = 0; i < Code[".text"].Count; i++)
            {
                if (Code[".text"][i].Contains(instruction))
                    return i;
            }
            return 0;
        }
        private static void TranslateRInstruction(string[] temp) // Translates R Instruction
        {
            string instruction, fsource, ssource, dist;
            instruction = temp[0].ToLower();
            dist = temp[1].ToLower();
            fsource = temp[2].ToLower();
            ssource = temp[3].ToLower();

            string BinaryCode = ConvertToBinary(OpCodes[instruction], 6);//instruction op code
            BinaryCode       += ConvertToBinary(Registers[fsource], 5);  // first source
            BinaryCode       += ConvertToBinary(Registers[ssource], 5);  //  seconde source
            BinaryCode       += ConvertToBinary(Registers[dist], 5);     // distination
            BinaryCode       += ConvertToBinary(0, 5);                   // shift amount
            BinaryCode       += ConvertToBinary(RFunct[instruction], 6); // instruction function

            Code[".textTranslation"].Add(BinaryCode);
        }
        private static void TranslateIInstruction(string[] temp)// Translates I Instruction
        {
            string instruction;
            instruction = temp[0].ToLower();
            if (instruction == "beq" || instruction == "bne")
            {
                string reg1, offset, reg2;
                int offsetNumber;
                instruction = temp[0].ToLower();
                reg2 = temp[1].ToLower();
                offset = temp[3].ToLower();
                reg1 = temp[2].ToLower();
                int instructionOffset = GetInstructionOffset(instruction + " " + reg2 + ", " + reg1 + ", " + offset);
                offsetNumber = LabelsOffset[offset] - (instructionOffset + 1);
                string BinaryCode = ConvertToBinary(OpCodes[instruction], 6);
                BinaryCode += ConvertToBinary(Registers[reg2], 5);
                BinaryCode += ConvertToBinary(Registers[reg1], 5);
                BinaryCode += ConvertToBinary(offsetNumber, 16);

                Code[".textTranslation"].Add(BinaryCode);
            }
            else if (instruction == "addi")
            {
                string source, immed, dist;
                int ImmVal = 0;
                instruction = temp[0].ToLower();
                dist = temp[1].ToLower();
                source = temp[2].ToLower();
                immed = temp[3].ToLower();
                bool parse = int.TryParse(immed, out ImmVal);
                string BinaryCode = ConvertToBinary(OpCodes[instruction], 6);
                BinaryCode += ConvertToBinary(Registers[dist], 5);
                BinaryCode += ConvertToBinary(Registers[source], 5);
                BinaryCode += ConvertToBinary(ImmVal, 16);

                Code[".textTranslation"].Add(BinaryCode);
            }
            else
            {
                string source, offset, dist;
                int offsetNumber;
                instruction = temp[0].ToLower();
                dist = temp[1].ToLower();
                if (temp.Length == 3)
                {
                    offset = temp[2].Split('(', ')')[0].ToLower();
                    source = temp[2].Split('(', ')')[1].ToLower();
                }
                else
                {
                    offset = temp[2].ToLower();
                    temp[3] = temp[3].Replace(")", string.Empty);
                    temp[3] = temp[3].Replace("(", string.Empty);
                    source = temp[3].ToLower();
                }
                int.TryParse(offset, out offsetNumber);
                if (Variabls.ContainsKey(offset))
                    offsetNumber = Variabls[offset];
                string BinaryCode = ConvertToBinary(OpCodes[instruction], 6);
                BinaryCode += ConvertToBinary(Registers[source], 5);
                BinaryCode += ConvertToBinary(Registers[dist], 5);
                BinaryCode += ConvertToBinary(offsetNumber, 16);
                Code[".textTranslation"].Add(BinaryCode);
            }
        }
        private static void TranslateJInstruction(string[] temp)// Translates J Instruction
        {
            string BinaryCode = ConvertToBinary(OpCodes[temp[0].ToLower()], 6);
            BinaryCode += ConvertToBinary(LabelsOffset[temp[1]], 26);
            Code[".textTranslation"].Add(BinaryCode);
        }
        private static string[] RemoveUselessSpaces(string [] temp)
        {
            List<string> clearedList = temp.ToList();
            for (int u = 0; u < clearedList.Count; u++)
                clearedList.Remove("");
            return clearedList.ToArray();
        }
        public static void Translate()
        {
            TranslateDataSegment();
            ScanLabels();
            string Instruction;
            List<string> CopyCode = Code[".text"];
            for (int i = 0; i < CopyCode.Count; i++)
            {
                Instruction = CopyCode[i].Replace("\t",string.Empty);
                if (IsLabeldLine(Instruction))
                {
                     Instruction = Instruction.Split(':')[1]; // if it has label then remove it
                    if(Instruction.ToCharArray()[0] == ' ')
                     Instruction = Instruction.Remove(0, 1);
                }
                Instruction = Instruction.Replace(",", string.Empty);

                string[]  temp = RemoveUselessSpaces(Instruction.Split(' '));

                char InsrtctionType = InstrctionType(Instruction);
             
                if (InsrtctionType == 'R')      TranslateRInstruction(temp);

                else if (InsrtctionType == 'I') TranslateIInstruction(temp);

                else if (InsrtctionType == 'J') TranslateJInstruction(temp);

                else if (InsrtctionType == '0') Errors.Add("Syntax Error at Line " + (i + Code[".data"].Count));
            }
        }
    }
}
