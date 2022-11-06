using System;
using System.Net.NetworkInformation;
using System.Dynamic;
using System.Globalization;
using System.IO.Compression;
using System.Security.Cryptography;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Nodes;

public class coreGame
{
    public static void chapter1()
    {
        //TextTool.textGen("enter smt",1 /*text speed*/, true /*clear console*/, true /*add press continue*/, 1 /*delay after text complete*/);
        TextTool.TextGen("This is chapter 1 test text", 1, true, true);
        Saveload.save("1","1");
    }
    public static void chapter2()
    {
        TextTool.TextGen("This is chapter 2 test text", 1, true, true);
        Saveload.save("2","1");
    }
}
class Menu
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            //Main menu
            Console.WriteLine("=======================================================");
            Console.WriteLine("\t\tA Text-base game name(Demo)\n\t1 Play\n\t2 Quick Load\n\t3 Guide\n\t4 Credits\n\t5 Update\n\n\t9 Exit");
            Console.WriteLine("=======================================================");
            TextTool.TextGen("Key command -=>");
            string inPut = Console.ReadLine();
            if (inPut == "1")
            {
                while (true)
                {
                    //chapter select
                    Console.Clear();
                    Console.WriteLine("=======================================================");
                    Console.WriteLine("\t\tSelect Chapter\n\tChapter 1\n\tChapter 2\n\n\t9 Back to main menu teest");
                    Console.WriteLine("=======================================================");
                    TextTool.TextGen("Key command -=>");
                    string chapterSelect = Console.ReadLine();
                    if (chapterSelect == "1")
                    {
                        coreGame.chapter1();
                    }
                    else if (chapterSelect == "2")
                    {
                        coreGame.chapter2();
                    }
                    else if (chapterSelect == "9")
                    {
                        break;
                    }
                    else
                    {
                        Console.Write("You enter worng key");
                        Console.ReadKey();
                    }
                }
            }
            else if (inPut ==  "2")
            {
                //Quick load
                JsonNode _jsonData = Saveload.read()!;
                string _loadData = _jsonData[0]["save"].ToString();
                Console.WriteLine("Warning:\nYour last auto save is Chapter " + _loadData + "\nAre you sure to load this chapter?[Press Y to continue]");
                if (Console.ReadKey(true).Key == ConsoleKey.Y)
                {
                    Saveload.load(_loadData);
                }
            }
            else if (inPut == "3")
            {
                //Guide
                Console.Clear();
                TextTool.TextGen("\t\tNew better guide is coming soon\n");

                TextTool.TextGen("Press anykey to go back to main menu...");
                Console.ReadKey();
            }
            else if (inPut == "4")
            {
                //Credits
                Console.Clear();
                TextTool.TextGen("New better credits is coming soon");
                TextTool.TextGen("Press anykey to go back to main menu...");
                Console.ReadKey();
            }
            else if (inPut == "5")
            {
                Console.Clear();
                string update = File.ReadAllText("_update.txt");
                Console.WriteLine(update);
                TextTool.TextGen("Press anykey to go back to main menu...");
                Console.ReadKey();
            }
            else if (inPut == "9")
            {
                break;
            }
            else if (inPut == "" || inPut == " ")
            {
                Console.Write("You enter nothing...");
                Console.ReadKey();
            }
            else
            {
                Console.Write("You enter worng key");
                Console.ReadKey();
            }
        }
    }
}
/*






*    WARNING THIS IS TOOLS FUNCTION ZONE!

*   IF YOU EDIT ANYTHING IN THIS YOUR FUNCTION MIGHT BROKE OR CANT BE USE!
*   BECAREFUL IF YOU WANT TO EDIT SOMETHING.






*/
class TextTool
{
    public static void TextGen(string text, int textSpeed, bool clearConsole, bool pressOnKey, int delay)
    {
        if (clearConsole == true)
        {
            Console.Clear();
        }
        if (pressOnKey == true)
        {
            for (int i = 0; i < text.Length + 1; i++)
            {
                if (i >= text.Length)
                {
                    Thread.Sleep(delay);
                    Console.WriteLine("\n\n-\tPress space bar or enter to continue\t-");
                    break;
                }
                Console.Write(text[i]);
                Thread.Sleep(textSpeed);
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Enter && Console.ReadKey(true).Key != ConsoleKey.Spacebar){}
        }
        if (pressOnKey == false)
        {
            for (int i = 0; i < text.Length; i++)
            {
                Console.Write(text[i]);
                Thread.Sleep(textSpeed);
            }
            Thread.Sleep(delay);
        }
    }
    public static void TextGen(string text, int textSpeed, bool clearConsole, bool pressOnKey)
    {
        if (clearConsole == true)
        {
            Console.Clear();
        }
        if (pressOnKey == true)
        {
            for (int i = 0; i < text.Length + 1; i++)
            {
                if (i >= text.Length)
                {
                    Thread.Sleep(500);
                    Console.WriteLine("\n\n-\tPress space bar or enter to continue\t-");
                    break;
                }
                Console.Write(text[i]);
                Thread.Sleep(textSpeed);
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Enter && Console.ReadKey(true).Key != ConsoleKey.Spacebar){}
        }
        if (pressOnKey == false)
        {
            for (int i = 0; i < text.Length; i++)
            {
                Console.Write(text[i]);
                Thread.Sleep(textSpeed);
            }
        }
    }
    public static void TextGen(string text, int textSpeed, bool clearConsole)
    {
        if (clearConsole == true)
        {
            Console.Clear();
        }
        for (int i = 0; i < text.Length; i++)
        {
            Console.Write(text[i]);
            Thread.Sleep(textSpeed);
        }
    }
    public static void TextGen(string text, int textSpeed)
    {
        for (int i = 0; i < text.Length; i++)
        {
            Console.Write(text[i]);
            Thread.Sleep(textSpeed);
        }
    }
    public static void TextGen(string text)
    {
        for (int i = 0; i < text.Length; i++)
        {
            Console.Write(text[i]);
            Thread.Sleep(1);
        }
    }
}
public class Saveload : coreGame
{
    public static void save(string chapter, string route)
    {
        string _filename = "save.json";
        object[] arr = new object[1];
        var _save = new dataSave
        {
            save = chapter,
            route = route
        };

        arr[0] = _save;

        string _savedata = JsonSerializer.Serialize(arr);
        File.WriteAllText(_filename, _savedata);
    }
    public static void load(string chapter)
    {
        if (chapter == "1")
        {
            chapter1();
        }
        else if (chapter == "2")
        {
            chapter2();
        }
        else
        {
            Console.WriteLine("Chapter not found");
        }
    }
    public static void delete(string chapter)
    {
        string _filename = "save.json";
        string del = "";
        File.WriteAllText(_filename,del);
    }
    public static JsonNode read()
    {
        string _filename = "save.json";
        string jsondata = File.ReadAllText(_filename);
        var _loadJson = JsonNode.Parse(jsondata);
        return _loadJson;
    }
}
public class dataSave
{
    public string save {get; set;}
    public string route {get; set;}
}