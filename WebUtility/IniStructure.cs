using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MOD.WebUtility {
    public class IniStructure {
        #region Ini structure code
        private SortedList Categories = new SortedList();

        /// <summary>
        /// Initialies a new IniStructure
        /// </summary>
        public IniStructure() {
            return; // There's nothing to do...
        }


        /// <summary>
        /// 添加节点Section
        /// </summary>
        /// <param name="Name">The name.</param>
        /// <returns></returns>
        public bool AddCategory( string Name ) {
            if (Name == "" | Categories.ContainsKey(Name))
                return false;
            if (Name.IndexOf('=') != -1
                | Name.IndexOf('[') != -1
                | Name.IndexOf(']') != -1) // these characters are not allowed in a category name
                return false;

            Categories.Add(Name, new SortedList());
            return true;
        }


        /// <summary>
        /// 删除节点Section
        /// </summary>
        /// <param name="Name">The name.</param>
        /// <returns></returns>
        public bool DeleteCategory( string Name ) {
            if (Name == "" | !Categories.ContainsKey(Name))
                return false;
            Categories.Remove(Name);
            return true;
        }


        /// <summary>
        /// 重命名节点Section
        /// </summary>
        /// <param name="Name">The name.</param>
        /// <param name="NewName">The new name.</param>
        /// <returns></returns>
        public bool RenameCategory( string Name, string NewName ) { //		Or rather moves a category to a new name
            if (Name == "" | !Categories.ContainsKey(Name) | NewName == "")
                return false;

            if (NewName.IndexOf('=') != -1
                | NewName.IndexOf('[') != -1
                | NewName.IndexOf(']') != -1) // these characters are not allowed in a category name
                return false;

            SortedList Category = (SortedList)(Categories[Name]);
            Categories.Add(NewName, Category);
            this.DeleteCategory(Name);
            return true;
        }


        /// <summary>
        /// 获取节点名称集合
        /// </summary>
        /// <returns></returns>
        public string[] GetCategories() {
            string[] CatNames = new string[Categories.Count];
            IList KeyList = Categories.GetKeyList();
            int KeyCount = Categories.Count;
            for (int i = 0; i < KeyCount; i++) {
                CatNames[i] = KeyList[i].ToString();
            }
            return CatNames;
        }


        /// <summary>
        /// 按索引获取节点名称
        /// </summary>
        /// <param name="Index">The index.</param>
        /// <returns></returns>
        public string GetCategoryName( int Index ) {
            if (Index < 0 | Index >= Categories.Count)
                return null;
            return Categories.GetKey(Index).ToString();
        }


        /// <summary>
        /// 为节点添加 键值对
        /// </summary>
        /// <param name="CategoryName">Name of the category.</param>
        /// <param name="Key">The key.</param>
        /// <param name="Value">The value.</param>
        /// <returns></returns>
        public bool AddValue( string CategoryName, string Key, string Value ) {
            if (CategoryName == "" | Key == "")
                return false;
            if (Key.IndexOf('=') != -1
                | Key.IndexOf('[') != -1
                | Key.IndexOf(']') != -1	// these chars are not allowed for keynames
                | Key.IndexOf(';') != -1
                | Key.IndexOf('#') != -1
                )
                return false;
            if (!Categories.ContainsKey(CategoryName))
                return false;
            SortedList Category = (SortedList)(Categories[CategoryName]);
            if (Category.ContainsKey(Key))
                return false;
            Category.Add(Key, Value);
            return true;
        }


        /// <summary>
        /// 通过名称-获取某个节点的某个键的值
        /// </summary>
        /// <param name="CategoryName">Name of the category.</param>
        /// <param name="Key">The key.</param>
        /// <returns></returns>
        public string GetValue( string CategoryName, string Key ) {
            if (CategoryName == "" | Key == "")
                return null;
            if (!Categories.ContainsKey(CategoryName))
                return null;
            SortedList Category = (SortedList)(Categories[CategoryName]);
            if (!Category.ContainsKey(Key))
                return null;
            return Category[Key].ToString();
        }


        /// <summary>
        /// 通过索引-获取某个节点的某个键的值
        /// </summary>
        /// <param name="CatIndex">Index of the cat.</param>
        /// <param name="KeyIndex">Index of the key.</param>
        /// <returns></returns>
        public string GetValue( int CatIndex, int KeyIndex ) {
            if (CatIndex < 0 | KeyIndex < 0
                | CatIndex >= Categories.Count)
                return null;
            SortedList Category = (SortedList)(Categories.GetByIndex(CatIndex));
            if (KeyIndex >= Category.Count)
                return null;
            return Category.GetByIndex(KeyIndex).ToString();
        }


        /// <summary>
        /// 通过索引 - 获取某个节点某个键的名称
        /// </summary>
        /// <param name="CatIndex">Index of the cat.</param>
        /// <param name="KeyIndex">Index of the key.</param>
        /// <returns></returns>
        public string GetKeyName( int CatIndex, int KeyIndex ) {
            if (CatIndex < 0 | KeyIndex < 0
                | CatIndex >= Categories.Count)
                return null;
            SortedList Category = (SortedList)(Categories.GetByIndex(CatIndex));
            if (KeyIndex >= Category.Count)
                return null;
            return Category.GetKey(KeyIndex).ToString();
        }



        /// <summary>
        /// 通过名称删除某个节点的某个键
        /// </summary>
        /// <param name="CategoryName">Name of the category.</param>
        /// <param name="Key">The key.</param>
        /// <returns></returns>
        public bool DeleteValue( string CategoryName, string Key ) {
            if (CategoryName == "" | Key == "")
                return false;
            if (!Categories.ContainsKey(CategoryName))
                return false;
            SortedList Category = (SortedList)(Categories[CategoryName]);
            if (!Category.ContainsKey(Key))
                return false;
            Category.Remove(Key);
            return true;
        }


        /// <summary>
        /// 重命名某个节点的某个键的名称.
        /// </summary>
        /// <param name="CategoryName">Name of the category.</param>
        /// <param name="KeyName">Name of the key.</param>
        /// <param name="NewKeyName">New name of the key.</param>
        /// <returns></returns>
        public bool RenameKey( string CategoryName, string KeyName, string NewKeyName ) {
            if (CategoryName == "" | KeyName == "" | NewKeyName == "")
                return false;
            if (!Categories.ContainsKey(CategoryName))
                return false;
            if (NewKeyName.IndexOf('=') != -1
                | NewKeyName.IndexOf('[') != -1
                | NewKeyName.IndexOf(']') != -1	// these chars are not allowed for keynames
                | NewKeyName.IndexOf(';') != -1
                | NewKeyName.IndexOf('#') != -1
                )
                return false;
            SortedList Category = (SortedList)(Categories[CategoryName]);
            if (!Category.ContainsKey(KeyName))
                return false;

            object value = Category[KeyName];
            Category.Remove(KeyName);
            Category.Add(NewKeyName, value);
            return true;
        }


        /// <summary>
        /// 修改某个节点的某个键的值
        /// </summary>
        /// <param name="CategoryName">Name of the category.</param>
        /// <param name="KeyName">Name of the key.</param>
        /// <param name="NewValue">The new value.</param>
        /// <returns></returns>
        public bool ModifyValue( string CategoryName, string KeyName, string NewValue ) {
            if (CategoryName == "" | KeyName == "")
                return false;
            if (!Categories.ContainsKey(CategoryName))
                return false;
            SortedList Category = (SortedList)(Categories[CategoryName]);
            if (!Category.ContainsKey(KeyName))
                return false;

            Category[KeyName] = NewValue;
            return true;
        }


        /// <summary>
        /// 获取某个节点的键的结合
        /// </summary>
        /// <param name="CategoryName">Name of the category.</param>
        /// <returns></returns>
        public string[] GetKeys( string CategoryName ) {
            SortedList Category = (SortedList)(Categories[CategoryName]);
            if (Category == null)
                return null;
            int KeyCount = Category.Count;
            string[] KeyNames = new string[KeyCount];
            IList KeyList = Category.GetKeyList();
            for (int i = 0; i < KeyCount; i++) {
                KeyNames[i] = KeyList[i].ToString();
            }
            return KeyNames;
        }

        #endregion

        #region Ini writing code

        /// <summary>
        /// 写入一个Ini文件信息  包含注释
        /// </summary>
        /// <param name="IniData">The ini data.</param>
        /// <param name="Filename">The filename.</param>
        /// <param name="comment">The comment.</param>
        /// <returns></returns>
        public static bool WriteIni( IniStructure IniData, string Filename, string comment ) {
            string DataToWrite = CreateData(IniData, BuildComment(comment));
            return WriteFile(Filename, DataToWrite);
        }


        /// <summary>
        /// 写入一个Ini文件信息  不包含注释
        /// </summary>
        /// <param name="IniData">The ini data.</param>
        /// <param name="Filename">The filename.</param>
        /// <returns></returns>
        public static bool WriteIni( IniStructure IniData, string Filename ) {
            string DataToWrite = CreateData(IniData);
            return WriteFile(Filename, DataToWrite);
        }

        /// <summary>
        /// 写文件函数
        /// </summary>
        /// <param name="Filename">The filename.</param>
        /// <param name="Data">The data.</param>
        /// <returns></returns>
        private static bool WriteFile( string Filename, string Data ) {	// Writes a string to a file
            try {
                FileStream IniStream = new FileStream(Filename, FileMode.Create);
                if (!IniStream.CanWrite) {
                    IniStream.Close();
                    return false;
                }
                StreamWriter writer = new StreamWriter(IniStream);
                writer.Write(Data);
                writer.Flush();
                writer.Close();
                IniStream.Close();
                return true;
            } catch {
                return false;
            }
        }

        /// <summary>
        /// 创建注释信息
        /// </summary>
        /// <param name="comment">The comment.</param>
        /// <returns></returns>
        private static string BuildComment( string comment ) { // Adds a # at the beginning of each line
            if (comment == "")
                return "";
            string[] Lines = DivideToLines(comment);
            string temp = "";
            foreach (string line in Lines) {
                temp += "# " + line + "\r\n";
            }
            return temp;
        }

        /// <summary>
        /// 创建无注释的Ini对象.
        /// </summary>
        /// <param name="IniData">The ini data.</param>
        /// <returns></returns>
        private static string CreateData( IniStructure IniData ) {
            return CreateData(IniData, "");
        }

        /// <summary>
        /// 创建有注释的Ini对象
        /// </summary>
        /// <param name="IniData">The ini data.</param>
        /// <param name="comment">The comment.</param>
        /// <returns></returns>
        private static string CreateData( IniStructure IniData, string comment ) {	//Iterates through all categories and keys and appends all data to Data
            int CategoryCount = IniData.GetCategories().Length;
            int[] KeyCountPerCategory = new int[CategoryCount];
            string Data = comment;
            string[] temp = new string[2]; // will contain key-value pair

            for (int i = 0; i < CategoryCount; i++) // Gets keycount per category
			{
                string CategoryName = IniData.GetCategories()[i];
                KeyCountPerCategory[i] = IniData.GetKeys(CategoryName).Length;
            }

            for (int catcounter = 0; catcounter < CategoryCount; catcounter++) {
                Data += "\r\n[" + IniData.GetCategoryName(catcounter) + "]\r\n";
                // writes [Category] to Data
                for (int keycounter = 0; keycounter < KeyCountPerCategory[catcounter]; keycounter++) {
                    temp[0] = IniData.GetKeyName(catcounter, keycounter);
                    temp[1] = IniData.GetValue(catcounter, keycounter);
                    Data += temp[0] + "=" + temp[1] + "\r\n";
                    // writes the key-value pair to Data
                }
            }
            return Data;
        }
        #endregion

        #region Ini reading code


        /// <summary>
        /// 读取Ini文件
        /// </summary>
        /// <param name="Filename">The filename.</param>
        /// <returns></returns>
        public static IniStructure ReadIni( string Filename ) {
            string Data = ReadFile(Filename);
            if (Data == null)
                return null;

            IniStructure data = InterpretIni(Data);

            return data;
        }

        /// <summary>
        /// 将读取到的Ini文件转换成 Ini 类的对象
        /// </summary>
        /// <param name="Data">The data.</param>
        /// <returns></returns>
        public static IniStructure InterpretIni( string Data ) {
            IniStructure IniData = new IniStructure();
            string[] Lines = RemoveAndVerifyIni(DivideToLines(Data));
            // Divides the Data in lines, removes comments and empty lines
            // and verifies if the ini is not corrupted
            // Returns null if it is.
            if (Lines == null)
                return null;

            if (IsLineACategoryDef(Lines[0]) != LineType.Category) {
                return null;
                // Ini is faulty - does not begin with a categorydef
            }
            string CurrentCategory = "";
            foreach (string line in Lines) {
                switch (IsLineACategoryDef(line)) {
                    case LineType.Category:	// the line is a correct category definition
                        string NewCat = line.Substring(1, line.Length - 2);
                        IniData.AddCategory(NewCat); // adds the category to the IniData
                        CurrentCategory = NewCat;
                        break;
                    case LineType.NotACategory: // the line is not a category definition
                        string[] keyvalue = GetDataFromLine(line);
                        IniData.AddValue(CurrentCategory, keyvalue[0], keyvalue[1]);
                        // Adds the key-value to the current category
                        break;
                    case LineType.Faulty: // the line is faulty
                        return null;
                }
            }
            return IniData;
        }

        /// <summary>
        /// 读取文件的函数
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <returns></returns>
        private static string ReadFile( string filename ) {		// Reads a file to a string.
            if (!File.Exists(filename))
                return null;
            StringBuilder IniData;
            try {
                FileStream IniStream = new FileStream(filename, FileMode.Open, FileAccess.Read);
                if (!IniStream.CanRead) {
                    IniStream.Close();
                    return null;
                }
                StreamReader reader = new StreamReader(IniStream);
                IniData = new StringBuilder();
                IniData.Append(reader.ReadToEnd());
                reader.Close();
                IniStream.Close();
                return IniData.ToString();
            } catch {
                return null;
            }
        }

        /// <summary>
        /// 根据键值对的行返回一个键值对数据 
        /// </summary>
        /// <param name="Line">The line.</param>
        /// <returns></returns>
        private static string[] GetDataFromLine( string Line ) {
            // returns the key and the value of a key-value pair in "key=value" format.
            int EqualPos = 0;
            EqualPos = Line.IndexOf("=", 0);
            if (EqualPos < 1) {
                return null;
            }
            string LeftKey = Line.Substring(0, EqualPos);
            string RightValue = Line.Substring(EqualPos + 1);

            string[] ToReturn = { LeftKey, RightValue };
            return ToReturn;
        }

        private enum LineType // return type for IsLineACategoryDef and LineVerify
        {
            NotACategory,
            Category,
            Faulty,
            Comment,
            Empty,
            Ok
        }

        /// <summary>
        /// Determines whether [is line A category def] [the specified line].
        /// 被调用
        /// </summary>
        /// <param name="Line">The line.</param>
        /// <returns></returns>
        private static LineType IsLineACategoryDef( string Line ) {
            if (Line.Length < 3)
                return LineType.NotACategory; // must be a short keyname like "k="

            if (Line.Substring(0, 1) == "[" & Line.Substring(Line.Length - 1, 1) == "]")
            // seems to be a categorydef
			{
                if (Line.IndexOf("=") != -1)
                    //  '=' found -> is incorrect for category def
                    return LineType.Faulty;
                if (ContainsMoreThanOne(Line, '[') | ContainsMoreThanOne(Line, ']'))
                    // two or more '[' or ']' found -> incorrect
                    return LineType.Faulty;
                return LineType.Category;
            }
            return LineType.NotACategory;
        }

        /// <summary>
        /// Divides to lines.
        /// 被调用
        /// </summary>
        /// <param name="Data">The data.</param>
        /// <returns></returns>
        private static string[] DivideToLines( string Data ) {		// Divides a string into lines
            string[] Lines = new string[Data.Length];
            int oldnewlinepos = 0;
            int LineCounter = 0;
            for (int i = 0; i < Data.Length; i++) {
                if (Data.ToCharArray(i, 1)[0] == '\n') {
                    Lines[LineCounter] = Data.Substring(oldnewlinepos, i - oldnewlinepos - 1);
                    oldnewlinepos = i + 1;
                    LineCounter++;
                }
            }

            // Lines[] array is too big: needs to be trimmed

            Lines[LineCounter] = Data.Substring(oldnewlinepos, Data.Length - oldnewlinepos);
            string[] LinesTrimmed = new string[LineCounter + 1];
            for (int i = 0; i < LineCounter + 1; i++) {
                LinesTrimmed[i] = Lines[i];
            }
            return LinesTrimmed;
        }

        /// <summary>
        /// Determines whether [contains more than one] [the specified data].
        /// 被调用
        /// </summary>
        /// <param name="Data">The data.</param>
        /// <param name="verify">The verify.</param>
        /// <returns>
        /// 	<c>true</c> if [contains more than one] [the specified data]; otherwise, <c>false</c>.
        /// </returns>
        private static bool ContainsMoreThanOne( string Data, char verify ) {	// returns true if Data contains verify more than once
            char[] data = Data.ToCharArray();
            int count = 0;
            foreach (char c in data) {
                if (c == verify)
                    count++;
            }
            if (count > 1)
                return true;
            return false;
        }

        /// <summary>
        /// Lines the verify.
        /// 判断某行的类型  是节点行，还是键值行
        /// </summary>
        /// <param name="line">The line.</param>
        /// <returns></returns>
        private static LineType LineVerify( string line ) {		// Verifies a line of an ini
            if (line == "")
                return LineType.Empty;

            if (line.IndexOf(";") == 0 | line.IndexOf("#") == 0 | line.IndexOf("//") == 0) {
                return LineType.Comment; // line is a comment: ignore
            }

            int equalindex = line.IndexOf('=');
            if (equalindex == 0)
                return LineType.Faulty; // an '=' cannot be on first place

            if (equalindex != -1) // if = is found in line
			{
                // Verify: no '[' , ']' ,';' or '#' before the '='
                if (line.IndexOf('[', 0, equalindex) != -1
                    | line.IndexOf(']', 0, equalindex) != -1
                    | line.IndexOf(';', 0, equalindex) != -1
                    | line.IndexOf('#', 0, equalindex) != -1)
                    return LineType.Faulty;
            }

            return LineType.Ok;
        }

        private static string[] RemoveAndVerifyIni( string[] Lines ) {
            // removes empty lines and comments, and verifies every line
            string[] temp = new string[Lines.Length];
            int TempCounter = 0; // number of lines to return
            foreach (string line in Lines) {
                switch (LineVerify(line)) {
                    case LineType.Faulty: // line is faulty
                        return null;
                    case LineType.Comment:	//	line is a comment
                        continue;
                    case LineType.Ok:	// line is ok
                        temp[TempCounter] = line;
                        TempCounter++;
                        break;
                    case LineType.Empty: // line is empty
                        continue;
                }
            }
            // the temp[] array is too big: needs to be trimmed.
            string[] OKLines = new string[TempCounter];
            for (int i = 0; i < TempCounter; i++) {
                OKLines[i] = temp[i];
            }
            return OKLines;
        }
        #endregion
    }
}
