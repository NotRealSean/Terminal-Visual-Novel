using System.Net.Mime;
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

class coreGame
{
    public static void chapter1()
    {
        //textTool.textGen("enter smt",1 /*text speed*/, true /*clear console*/, true /*add press continue*/, 1 /*delay after text complete*/);
        textTool.textGen("<Chapter I - Beginning Adventure>", 100, true, true, 3000);
        textTool.textGen("Hi this is my first story test text genetator.", 1, true, true);
        textTool.textGen("Test story text generator 2", 1, true, true);

        textTool.textGen("This is very ", 1, true, false, 1000);
        textTool.textGen("very ", 1, false, false, 1000);
        textTool.textGen("cool text generation", 1, false, true);


        textTool.textGen("The End", 1, true, false, 1000);
        textTool.textGen("\n<Chapter I - Normal Ending>", 100, false, true, 3000);
    }
    public static void chapter2()
    {
        textTool.textGen("This is chapter 2 test text",1 ,true ,true);
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
            textTool.textGen("Key command -=>");
            string inPut = Console.ReadLine();
            if (inPut == "1")
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("=======================================================");
                    Console.WriteLine("\t\tSelect Chapter\n\tChapter 1\n\tChapter 2\n\n\t9 Back to main menu");
                    Console.WriteLine("=======================================================");
                    textTool.textGen("Key command -=>");
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
                //Some load-save code idk :/
                textTool.textGen("Sorry but this load-save system is still in development\nPlease stay tune <3\n\n",1 ,true);
                textTool.textGen("Press anykey to go back to main menu...");
                Console.ReadKey();
            }
            else if (inPut == "3")
            {
                //Guide
                Console.Clear();
                Console.WriteLine("\t\tHello and Welcome\n");
                Console.WriteLine("Welcome to my first text-base visual novel game! this game is NOT full game just yet(And it maybe demo forever)\n\n");
                Console.WriteLine("\t\tHow to play this game\n");
                Console.WriteLine("Just press \"space bar or enter\" to continue reading\n");

                textTool.textGen("Press anykey to go back to main menu...");
                Console.ReadKey();
            }
            else if (inPut == "4")
            {
                Console.Clear();
                Console.WriteLine("\t\tHead project\nNotRealSean\n\n\t\tStory writer\nClearX2\n");
                textTool.textGen("Press anykey to go back to main menu...");
                Console.ReadKey();
            }
            else if (inPut == "5")
            {
                Console.Clear();
                Console.WriteLine("\t\tUpdate");
                Console.WriteLine("- Add update option to keep things up-to-date\n- Update framework(add delay after text generate)\n- Change exit key to 9\n");
                textTool.textGen("Press anykey to go back to main menu...");
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
class textTool
{
    public static void textGen(string text, int textSpeed, bool clearConsole, bool pressOnKey, int delay)
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
    public static void textGen(string text, int textSpeed, bool clearConsole, bool pressOnKey)
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
    public static void textGen(string text, int textSpeed, bool clearConsole)
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
    public static void textGen(string text, int textSpeed)
    {
        for (int i = 0; i < text.Length; i++)
        {
            Console.Write(text[i]);
            Thread.Sleep(textSpeed);
        }
    }
    public static void textGen(string text)
    {
        for (int i = 0; i < text.Length; i++)
        {
            Console.Write(text[i]);
            Thread.Sleep(1);
        }
    }
}
class save
{
    //some save code
}