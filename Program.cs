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
        TextTool.TextGen("This is chapter 1 test text", 20, true, true);
        Saveload.save("1","1");
    }
    public static void chapter2()
    {
        TextTool.TextGen("This is chapter 2 test text", 20, true, true);
        Saveload.save("2","1");
    }
}
class Menu
{
    static void Main(string[] args)
    {
        TextTool.TextGen("", 1, true, false, 1000);
        TextTool.TextGen("\n\n\t---< Game made by NotRealSean >---\n\n\nReport bug/suggestion at...\nDiscord - NotRealSean#4001\nTwitter - @Seankungzaza1\n", 30, true, false, 2500);
        while (true)
        {
            Console.Clear();
            //Main menu
            Console.WriteLine("=======================================================");
            Console.WriteLine(" A Text-base game name(Can't think of name just yet)\n\t1 Play\n\t2 Load\n\t3 Quick Load\n\t4 Settings\n\t5 Guide\n\t6 Credits\n\t7 Update\n\n\t9 Exit");
            Console.WriteLine("=======================================================");
            TextTool.TextGen("Key command -=>", 20);
            string inPut = Console.ReadLine();
            if (inPut == "1")
            {
                while (true)
                {
                    //chapter select
                    Console.Clear();
                    Console.WriteLine("=======================================================");
                    Console.WriteLine("\t\tSelect Chapter\n\tChapter 1\n\tChapter 2\n\n\t9 Back to main menu");
                    Console.WriteLine("=======================================================");
                    TextTool.TextGen("Key command -=>", 20);
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

                    //Joke zone
                    else if (chapterSelect == "0")
                    {
                        Console.WriteLine("Why are you trying to return 0?");
                        Console.ReadKey();
                    }

                    //Worng key handler
                    else if (chapterSelect == "" || chapterSelect == " ")
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
            else if (inPut == "2")
            {
                TextTool.TextGen("\t\tLoad is coming soon\n", 20, true);
                TextTool.TextGen("Press anykey to go back to main menu...", 10);
                Console.ReadKey();
            }
            else if (inPut ==  "3")
            {
                //Quick load
                JsonNode _jsonData = Saveload.read()!;
                string _loadData = _jsonData[0]["save"].ToString();
                Console.WriteLine("Warning:\nYour last auto save is Chapter " + _loadData + "\nAre you sure to load this chapter?\n[Press Y to continue/Press others key to return]");
                if (Console.ReadKey(true).Key == ConsoleKey.Y)
                {
                    Saveload.load(_loadData);
                }
            }
            else if (inPut == "4")
            {
                //Settings
            }
            else if (inPut == "5")
            {
                //Guide
                TextTool.TextGen("\t\tGuide is coming soon\n", 20, true);
                TextTool.TextGen("Press anykey to go back to main menu...", 10);
                Console.ReadKey();
            }
            else if (inPut == "6")
            {
                //Credits
                TextTool.TextGen("\t\tCredits is coming soon\n", 20, true);
                TextTool.TextGen("Press anykey to go back to main menu...", 10);
                Console.ReadKey();
            }
            else if (inPut == "7")
            {
                //Update
                Console.Clear();
                string update = File.ReadAllText("_update.txt");
                Console.WriteLine(update);
                TextTool.TextGen("Press anykey to go back to main menu...", 10);
                Console.ReadKey();
            }
            else if (inPut == "9")
            {
                //Exit game
                break;
            }

            //Joke zone
            else if (inPut == "0")
            {
                Console.WriteLine("Why are you trying to return 0?");
                Console.ReadKey();
            }
            else if (inPut == "SECRET_UNLOCK")
            {
                Console.WriteLine("Secret unlocked!(Joke)");
                Console.ReadKey();
            }
            else if (inPut == "SECRET_LOCK")
            {
                Console.WriteLine("Secret locked!");
                Console.ReadKey();
            }

            //Worng key handler
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
                    Console.WriteLine("\n\n-\tContinue\t-->>");
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
