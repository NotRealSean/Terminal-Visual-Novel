using System.Linq.Expressions;
using System.Xml.Linq;
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
        //textTool.textGen("enter smt",1 /*text speed*/, true /*clear console*/, true /*add press continue*/, 1 /*delay after text complete*/);
        TextTool.TextGen("<Chapter I - Beginning Adventure>", 100, true, true, 3000);
        TextTool.TextGen("Hi this is my first story test text genetator.", 1, true, true);
        TextTool.TextGen("Test story text generator 2", 1, true, true);

        TextTool.TextGen("This is very ", 1, true, false, 1000);
        TextTool.TextGen("very ", 1, false, false, 1000);
        TextTool.TextGen("cool text generation", 1, false, true);


        TextTool.TextGen("The End", 1, true, false, 1000);
        TextTool.TextGen("\n<Chapter I - Normal Ending>", 100, false, true, 3000);
        Saveload.save("1","1");
    }
    public static void chapter2()
    {
        TextTool.TextGen("This is chapter 2 test text",1 ,true ,true);
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
            Console.WriteLine("\t\tA Text-base game name(Demo)\n\t1 Play\n\t2 Load(Not work yet)\n\t3 Guide\n\t4 Credits\n\t5 Update\n\n\t9 Exit");
            Console.WriteLine("=======================================================");
            TextTool.TextGen("Key command -=>");
            string inPut = Console.ReadLine();
            if (inPut == "1")
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("=======================================================");
                    Console.WriteLine("\t\tSelect Chapter\n\tChapter 1\n\tChapter 2\n\n\t9 Back to main menu");
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
                while (true)
                {
                    Console.Clear();
                    JsonNode _nodedata = Saveload.read();
                    string _stringSaveList = _nodedata[0]["save"].ToString();
                    Console.WriteLine("Your last save is " + _stringSaveList + "(9 Exit)");
                    TextTool.TextGen("Key command -=>");
                    string loadChapter = Console.ReadLine();
                    if (loadChapter == "9")
                    {
                        break;
                    }
                    try
                    {
                        int loadChapterInt = Convert.ToInt32(loadChapter);
                        string _stringChapter = _nodedata[loadChapterInt-1]["save"].ToString();
                        Saveload.load(_stringChapter);
                    }
                    catch (Exception)
                    {
                        TextTool.TextGen("You enter worng key or chapter doesn\'t exist");
                        Console.ReadKey();
                    }
                }
            }
            else if (inPut == "3")
            {
                //Guide
                Console.Clear();
                Console.WriteLine("\t\tHello and Welcome\n");
                Console.WriteLine("Welcome to my first text-base visual novel game! this game is NOT full game just yet(And it maybe demo forever)\n\n");
                Console.WriteLine("\t\tHow to play this game\n");
                Console.WriteLine("Just press \"space bar or enter\" to continue reading\n");

                TextTool.TextGen("Press anykey to go back to main menu...");
                Console.ReadKey();
            }
            else if (inPut == "4")
            {
                Console.Clear();
                Console.WriteLine("\t\tHead project\nNotRealSean\n\n\t\tStory writer\nClearX2\n");
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