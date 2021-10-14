using System;
using System.IO;

namespace SortLinesFiles
{
    class Program
    {
        const string myword1 = "abcdefghijklmnñopqrstuvwxyz0123456789";
        const string myword2 = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz0123456789";
        static void ReadAndWrite(string filepath, string path2Write)
        {
            string a = "", b = "", c = "";
            string abc = a + b + c;
            string ofilepath = a + '/' + a + b + '/' + a + b + c;
            bool af = true, bf = true, cf = true;
            try
            {
                foreach (string line in File.ReadLines(filepath))
                {
                    af = true;
                    bf = true;
                    cf = true;
                    a = "";
                    b = "";
                    c = "";
                    if (line.Length < 60 && line.Length > 9)
                    {
                        try
                        {
                            for (int i = 0; i < myword2.Length; i++)
                            {
                                if (af && myword2[i] == line[0])
                                {
                                    a = Char.ToLower(line[0]).ToString();
                                    af = false;
                                }
                                if (bf && myword2[i] == line[1])
                                {
                                    b = Char.ToLower(line[1]).ToString();
                                    bf = false;
                                }
                                if (cf && myword2[i] == line[2])
                                {
                                    c = Char.ToLower(line[2]).ToString();
                                    cf = false;
                                }

                            }
                        }
                        catch (Exception e)
                        {

                            using (StreamWriter sw = File.AppendText(ofilepath))
                            {
                                sw.WriteLine("Error ToLower: " + e.Message);
                            }
                        }
                        
                        a = "" == a ? "symbol" : a;
                        b = "" == b ? "symbol" : b;
                        c = "" == c ? "symbol" : c;

                        abc = a + b + c;
                        ofilepath = a + '/' + a + b + '/' + abc;
                        if ("con" == abc || "prn" == abc || "aux" == abc || "nul" == abc)
                        {
                            ofilepath += "-WindowsBannedWord";
                        }
                        try
                        {
                            using (StreamWriter sw = File.AppendText(path2Write + ofilepath))
                            {
                                sw.WriteLine(line);
                            }
                        }
                        catch (Exception e)
                        {

                            using (StreamWriter sw = File.AppendText(ofilepath))
                            {
                                sw.WriteLine("Error:"+ e.Message +"\nescribiendo la linea: " + line + "\nen fichero: "+ ofilepath);
                            }
                        }
                        
                    }
                }
            }
            catch (Exception e)
            {
                using (StreamWriter sw = File.AppendText(ofilepath))
                {
                    sw.WriteLine("Error leyendo archivo: "+ e.Message);
                }
            }
                           
            
        }

        static void createFolders(string path2Write)
        {
            string a = "", b = "";
            for (int i = 0; i < myword1.Length; i++)
            {
                a = myword1[i].ToString();
                Directory.CreateDirectory(path2Write + a);
                Directory.CreateDirectory(path2Write + a + '/' + a + "symbol");
                for (int j = 0; j < myword1.Length; j++)
                {
                    b = myword1[j].ToString();
                    Directory.CreateDirectory(path2Write + a + '/' + a + b);
                }
            }
            Directory.CreateDirectory(path2Write + "symbol");
            for (int i = 0; i < myword1.Length; i++)
            {
                a = myword1[i].ToString();
                Directory.CreateDirectory(path2Write + "symbol/symbol" + a);
            }
            Directory.CreateDirectory(path2Write + "symbol/symbolsymbol");
        }

        static void createFiles(string path2Write)
        {
            string a = "", b = "", c = "", abc = "", bannedWords = "";
            for (int i = 0; i < myword1.Length; i++)
            {
                a = myword1[i].ToString();
                using (File.Create(path2Write + a + '/' + a + "symbol" + '/' + a + "symbol" + "symbol"))
                for (int j = 0; j < myword1.Length; j++)
                {
                    b = myword1[j].ToString();
                    using (File.Create(path2Write + a + '/' + a + "symbol" + '/' + a + "symbol" + b))
                    using (File.Create(path2Write + a + '/' + a + b + '/' + a + b + "symbol"))

                    for (int k = 0; k < myword1.Length; k++)
                    {
                        bannedWords = "";
                        c = myword1[k].ToString();
                        abc = a + b + c;
                        if ("con" == abc || "prn" == abc || "aux" == abc || "nul" == abc)
                        {
                            bannedWords = "-WindowsBannedWord";
                        }
                                using (File.Create(path2Write + a + '/' + a + b + '/' + a + b + c + bannedWords)) ;
                    }
                }
            }

            for (int i = 0; i < myword1.Length; i++)
            {
                a = myword1[i].ToString();
                using (File.Create(path2Write + "symbol/symbol" + a + '/' + "symbol" + a + "symbol"))
                for (int j = 0; j < myword1.Length; j++)
                {
                    b = myword1[j].ToString();
                        using (File.Create(path2Write + "symbol/symbol" + a + '/' + "symbol" + a + b)) ;
                }
            }

            for (int i = 0; i < myword1.Length; i++)
            {
                a = myword1[i].ToString();
                using (File.Create(path2Write + "symbol/symbolsymbol/symbolsymbol" + a)) ;
            }
            using (File.Create(path2Write + "symbol/symbolsymbol/symbolsymbolsymbol")) ;
        }

        static void Main()
        {
            string option;
            string path2Read;
            Console.WriteLine("Path of the folder where is going to be writed");
            string path2Write = Console.ReadLine();
            path2Write += path2Write[path2Write.Length - 1] == '/' || path2Write[path2Write.Length - 1] == '\\' ? "" : "/";
            do
            {
                Console.WriteLine("1. Create Folders");
                Console.WriteLine("2. Create Files");
                Console.WriteLine("3. Read Folder with files");
                Console.WriteLine("Select: ");
                string option2 = Console.ReadLine();

                switch (option2)
                {
                    case "1":
                        createFolders(path2Write);
                        break;
                    case "2":
                        createFiles(path2Write);
                        break;
                    case "3":
                        Console.WriteLine("\nPath of the folder is going to be READed:");
                        path2Read = Console.ReadLine();
                        Console.OutputEncoding = System.Text.Encoding.UTF8;
                        foreach (string file in Directory.EnumerateFiles(path2Read, "*.*", SearchOption.AllDirectories))
                        {
                            if (!file.Contains(".exe"))
                            {
                                using (StreamWriter sw = File.AppendText("logfile"))
                                {
                                    sw.WriteLine("Start: " + file);
                                    Console.WriteLine("Start: " + file);
                                }
                                ReadAndWrite(file, path2Write);
                                using (StreamWriter sw = File.AppendText("logfile"))
                                {
                                    sw.WriteLine("End: " + file + "\n");
                                }
                            }
                            Console.WriteLine("End: " + file);
                        }
                        using (StreamWriter sw = File.AppendText("logfile"))
                        {
                            sw.WriteLine("FINISH");
                        }
                        break;
                }
                Console.WriteLine("\nFINISH. Write 'e' to exit or 'n' to continue:");
                option = Console.ReadLine();
            } while ("e" != option);
            
        }
    }
}
