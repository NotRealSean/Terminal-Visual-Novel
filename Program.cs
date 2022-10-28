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
        textGenStory(story0);
        string story1 = "Test story text generator 2";
        textGenStory(story1);
        string story3 = "Test story text generator 3";
        textGenStory(story3);
        string story4 = "Test story text generator 4";
        textGenStory(story4);
        string story5 = "Test story text generator 5";
        textGenStory(story5);

        string storyEnd = "The End";
        textGenStory(storyEnd);
    }
    static void textGenStory(string text)
    {
        Console.Clear();
        for (int i = 0; i < text.Length + 1; i++)
        {
            if (i >= text.Length)
            {
                Thread.Sleep(500);
                Console.WriteLine("\n\n-\tPress any key to continue\t-");
                break;
            }
            Console.Write(text[i]);
            Thread.Sleep(1);
        }
        Console.ReadKey();
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
            Console.Write("Key command -=>");
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
                Console.WriteLine("just press \"any key\" to continue reading(That's all no save file)\n");

                string end  = "Press anykey to go back to main menu...";
                textGen(end);
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
                Console.WriteLine("You input worng key!");
                Console.ReadKey();
            }
        }
    }
    static void textGen(string text)
    {
        for (int i = 0; i < text.Length; i++)
        {
            Console.Write(text[i]);
            Thread.Sleep(1);
        }
    }
}