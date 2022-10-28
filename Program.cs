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
    public static void Game()
    {
        /*
        string story0 = "";
        textGenStory(story0);
        */
        Console.Clear();
        string story0 = "Hi this is my first story test text genetator.";
        textTool.textGen(story0, 1, true, true);
        string story1 = "Test story text generator 2";
        textTool.textGen(story1, 1, true, true);

        string story2s1 = "This is very ";
        string story2s2 = "very ";
        string story2s3 = "cool text generation";
        Console.Clear();
        textTool.textGen(story2s1);
        Thread.Sleep(1000);
        textTool.textGen(story2s2);
        Thread.Sleep(1000);
        textTool.textGen(story2s3, 1, false, true);


        string storyEnd = "The End";
        textTool.textGen(storyEnd, 1, true, true);
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
            Console.WriteLine("\t\tA Text-base game name(Demo)\n\t1 Play\n\t2 Guide\n\t3 Exit\n\n");
            Console.WriteLine("=======================================================");
            string keyCom = "Key command -=>";
            textTool.textGen(keyCom);
            string inPut = Console.ReadLine();
            if (inPut == "1")
            {
                coreGame.Game();
            }
            else if (inPut == "2")
            {
                //Guide
                Console.Clear();
                Console.WriteLine("\t\tHello and Welcome\n");
                Console.WriteLine("Welcome to my first text-base game! this game is NOT full game just yet(And it maybe demo forever)\n\n");
                Console.WriteLine("\t\tHow to play this game\n");
                Console.WriteLine("just press \"space bar or enter\" to continue reading(That's all no save file)\n");

                string end  = "Press anykey to go back to main menu...";
                textTool.textGen(end);
                Console.ReadKey();
            }
            else if (inPut == "3")
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
                Console.Write("You input worng key!");
                Console.ReadKey();
            }
        }
    }
}
class textTool
{
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