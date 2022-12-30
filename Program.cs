using System;
using System.Net;
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
    public static void prologue()
    {
        Settings.check();
        int textspeed = Convert.ToInt32(Settings.Read(0, "TextSpeed"));
        //Prologue
        TextTool.TextGen("England 2079\n", textspeed, true, false, 2000);
        TextTool.StoryGen("Girl", "I-Is this ok...?", textspeed, true, true);
        TextTool.StoryGen("Boss", "Is this all you can do in one week? USELESS. Don't come back if there's no progress at all!", textspeed, true, true);
        TextTool.StoryGen("Girl", "!\n", textspeed, true, false, 1000);
        TextTool.StoryGen("Girl", "...\n", textspeed, false, false, 1200);
        TextTool.StoryGen("Girl", "yes...", textspeed, false, true);
        TextTool.TextGen("An office worker girl had been working hard for a month straight, but her boss complains again. She tries her best on her work, but other co-workers like to put their work on her, and only her, for some reason, which makes her work not progress at all. All the co-workers already know this, but they don't care.", textspeed, true, true, 500);
        TextTool.StoryGen("Girl", "...", textspeed, true, true);
        TextTool.StoryGen("Co-worker 1", "Can you help me with this work?", textspeed, true, true);
        TextTool.StoryGen("Girl", "I-I still hav- \n", textspeed, true, false, 200);
        TextTool.StoryGen("Co-worker 1", "Thank you.", textspeed, false, false, 2000);
        TextTool.StoryGen("Girl", "... ", textspeed, true, false, 1000);
        TextTool.TextGen("Again...", textspeed, false, true);
        TextTool.TextGen("She sometimes thinks about quitting her job and finding a better one, but no one wants to hire her to work because they already have a lot of employees at their office.", textspeed, true, true);
        TextTool.StoryGen("Girl", "... ", textspeed, true, false, 1200);
        TextTool.TextGen("Maybe... ", textspeed, false, false, 1200);
        TextTool.TextGen("Just maybe... ", textspeed, false, false, 1200);
        TextTool.TextGen("What if I die and was reborn in another world like in isekai novel.", textspeed, false, true);
        TextTool.StoryGen("Girl", "Just saying ", textspeed, true, false, 1000);
        TextTool.TextGen("Haha...", textspeed, false, true);
        TextTool.TextGen("She likes to read isekai novels during her free time. She often thinks about killing herself and living a happier life in the afterlife.", textspeed, true, true);
        TextTool.StoryGen("Girl", "It's 8 PM already? ", textspeed, true , false, 1000);
        TextTool.TextGen("Maybe I should go home and make something to eat for dinne-", textspeed, false, false, 1200);
        TextTool.TextGen("", textspeed, true, false, 3000);
        TextTool.StoryGen("Girl", "... ", textspeed, true, false, 1200);
        TextTool.TextGen("Why is everything black... ", textspeed, false, false, 1200);
        TextTool.TextGen("I can't see anything.... ", textspeed, false, false, 1200);
        TextTool.TextGen("What happened to me?", textspeed, false, true);
        TextTool.TextGen("To be continue...", textspeed, true, true);
        FileTool.SaveChaper("save1-1", "save", 1, 1, true);
    }
    public static void chapter1()
    {
        //Chapter 1
    }
    public static void chapter2()
    {
        //chapter 2
    }
}
class Menu
{
    static void Main()
    {
        TextTool.TextGen("", 1, true, false, 1000);
        TextTool.TextGen("\n\n\t---< Game made by NotRealSean >---\n\n\nReport bug/suggestion at...\nDiscord - NotRealSean#4001\nTwitter - @Seankungzaza1\n\n\n", 1, true, false);
        Console.WriteLine("Loading log :\nLoading settings[Require internet]");
        Settings.check();
        FileTool.CheckCreatedFolder("save");
        Console.WriteLine("Settings loaded");
        Console.WriteLine("Checking for update[Require internet]");
        string version = "0.0.53";
        System.Net.WebClient gitversion = new System.Net.WebClient();
        string versionData = gitversion.DownloadString("https://raw.githubusercontent.com/NotRealSean/Console-Visual-Novel-Text-Base-Game/main/version");
        if (version != versionData)
        {
            Console.WriteLine("Your game version is outdated\nYour game version : " + version + "\nNew version : " + versionData);
            Console.WriteLine("Download new version here : https://github.com/NotRealSean/Console-Visual-Novel-Text-Base-Game/releases");
            Console.WriteLine("You can still play the game by press any key to continue...");
        }
        else if (version == versionData)
        {
            Console.WriteLine("Your game is up to date : " + versionData);
            Console.WriteLine("Press any key to continue...");
        }
        Console.ReadKey();
        while (true)
        {
          JsonNode _jsonData = Settings.Read()!;
          string speed = _jsonData[0]["TextSpeed"].ToString();
          int textspeed = Convert.ToInt32(speed);
            Console.Clear();
            //Main menu
            Console.WriteLine("=======================================================");
            Console.WriteLine(" A Text-base game name(Can't think of name just yet)\n\t[1] New Game\n\t[2] Load\n\t[3] Quick Load\n\t[4] Settings\n\t[5] Guide[Require internet]\n\t[6] Credits[Require internet]\n\t[7] News[Require internet]\n\n\t[9] Exit\t\t\t\t" + version);
            Console.WriteLine("=======================================================");
            Console.WriteLine("[Type number and hit Enter to comfirm]");
            TextTool.TextGen("Key command -=>", textspeed);
            string inPut = Console.ReadLine();
            switch (inPut)
            {
                case "1":
                while (true)
                {
                    //chapter select
                    Console.Clear();
                    Console.WriteLine("=======================================================");
                    Console.WriteLine("\t\tSelect Chapter\n\t[1] Prologue\n\t[2] Chapter 1\n\t[3] Chapter 2\n\n\t[9] Back to main menu");
                    Console.WriteLine("=======================================================");
                    Console.WriteLine("[Type number and hit Enter to comfirm]");
                    TextTool.TextGen("Key command -=>", textspeed);
                    string chapterSelect = Console.ReadLine();

                    switch (chapterSelect)
                    {
                        case "1":
                            coreGame.prologue();
                            break;
                        case "2":
                            coreGame.chapter1();
                            break;
                        case "3":
                            coreGame.chapter2();
                            break;
                        case "0":
                            Console.WriteLine("Why are you trying to return 0?");
                            Console.ReadKey();
                            break;

                        case "9":
                            break;
                        case "":
                            Console.WriteLine("You enter nothing...");
                            break;
                        case " ":
                            Console.WriteLine("You enter nothing...");
                            break;
                        default:
                            Console.Write("You enter worng key");
                            Console.ReadKey();
                            break;
                    }
                    if (chapterSelect == "9")
                    {
                        break;
                    }
                }
                break;


                case "2":
                FileTool.CheckCreatedFolder("save");
                //Load
                while (true)
                {
                  string dir = @"save";
                  int dircount = Directory.GetFiles(dir).Length;
                  if (dircount <= 0)
                  {
                    Console.WriteLine("You don't have save file");
                    Console.ReadKey();
                    break;
                  }
                  DirectoryInfo d = new DirectoryInfo(@"save");

                  FileInfo[] Files = d.GetFiles("");
                  string str = "";

                  foreach(FileInfo file in Files)
                  {
                    str = str + "\n" + file.Name;
                    Console.Clear();
                    Console.WriteLine("=======================================================");
                    Console.WriteLine("\t\tYour save file\n"+ str +"\n\n\t[9] Exit");
                    Console.WriteLine("=======================================================");
                    Console.WriteLine("[Type filename and hit Enter to comfirm / Type del to select delete file]");
                  }
                  TextTool.TextGen("Load file -=>", textspeed);
                  string LoadSelect = Console.ReadLine();
                  if (LoadSelect == "9")
                  {
                      break;
                  }
                  if (LoadSelect.ToLower() == "del")
                  {
                      TextTool.TextGen("Delete file -=>", textspeed);
                      string DelSelect = Console.ReadLine();
                      FileTool.DeleteSave(DelSelect, "save");
                  }
                  else
                  {
                      FileTool.LoadChapter(LoadSelect);
                  }
                }
                break;


                case "3":
                //Quick load
                FileTool.QLoadChapter();
                break;


                case "4":
                //Settings
                Settings.check();
                  while (true)
                  {
                    Console.Clear();
                    Console.WriteLine("=======================================================");
                    Console.WriteLine("\t\tSettings\n\t[1] Text Speed(Delay in ms)\n\t[2] Test\n\n\t[9] Return to menu");
                    Console.WriteLine("=======================================================");
                    Console.WriteLine("[Type number and hit Enter to comfirm]\n[You can't see change until you exit settings(But value is saved)]");
                    TextTool.TextGen("Key command -=>", textspeed);
                    string setting = Console.ReadLine();
                    if (setting == "9")
                    {
                       break;
                    }
                    else if (setting == "1" || setting == "2")
                    {
                        TextTool.TextGen("Key value -=>", textspeed);
                        string value = Console.ReadLine();
                        try
                        {
                            int result = int.Parse(value);
                            if (result > 500)
                            {
                                Console.WriteLine("You can't do more then 500!");
                                Console.ReadLine();
                            }
                            else if (result > 0)
                            {
                                string stringvalue = result.ToString();
                                Settings.Modify(setting, stringvalue);
                            }
                            else
                            {
                                Console.WriteLine("You can't do 0 or less!");
                                Console.ReadKey();
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("You didn't enter integer value!");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.WriteLine("You enter worng key!");
                        Console.ReadKey();
                    }
                }
                break;


                case "5":
                //Guide
                Console.WriteLine("Checking for update...[Require internet]");
                string filename = @"./guide.txt";
                //Write update
                System.Net.WebClient wc = new System.Net.WebClient();
                string webData = wc.DownloadString("https://raw.githubusercontent.com/NotRealSean/Console-Visual-Novel-Text-Base-Game/main/_guide.txt");
                File.WriteAllText(filename, webData);

                Console.Clear();
                string update = File.ReadAllText("_guide.txt");
                Console.WriteLine(update);
                TextTool.TextGen("Press anykey to go back to main menu...", 10);
                Console.ReadKey();
                break;


                case "6":
                //Credits
                Console.WriteLine("Checking for update...[Require internet]");
                string _filename = @"./credits.txt";
                //Write update
                System.Net.WebClient _wc = new System.Net.WebClient();
                string _webData = _wc.DownloadString("https://raw.githubusercontent.com/NotRealSean/Console-Visual-Novel-Text-Base-Game/main/credits.txt");
                File.WriteAllText(_filename, _webData);

                Console.Clear();
                string _update = File.ReadAllText("credits.txt");
                Console.WriteLine(_update);
                TextTool.TextGen("Press anykey to go back to main menu...", 10);
                Console.ReadKey();
                break;

                case "7":
                //News
                Console.WriteLine("Checking for update...[Require internet]");
                string __filename = "_update.txt";
                //Write update
                System.Net.WebClient __wc = new System.Net.WebClient();
                string __webData = __wc.DownloadString("https://raw.githubusercontent.com/NotRealSean/Console-Visual-Novel-Text-Base-Game/main/_update.txt");
                File.WriteAllText(__filename, __webData);

                Console.Clear();
                string __update = File.ReadAllText("_update.txt");
                Console.WriteLine(__update);
                TextTool.TextGen("Press anykey to go back to main menu...", 10);
                Console.ReadKey();
                break;


                //Joke zone
                case "0":
                Console.WriteLine("Why are you trying to return 0?");
                Console.ReadKey();
                break;


                case "":
                Console.Write("You enter nothing...");
                Console.ReadKey();
                break;


                case " ":
                Console.Write("You enter nothing...");
                Console.ReadKey();
                break;

                case "9":
                break;

                default:
                Console.WriteLine("You enter worng key!");
                break;
            }
            if (inPut == "9")
            {
                break;
            }
        }
    }
}
/*






*    WARNING THIS IS TOOLS FUNCTION ZONE!

*   IF YOU EDIT ANYTHING IN THIS YOUR FUNCTION MIGHT BROKE OR CANT BE USE!
*   BESURE WHAT YOU'RE DOING BEFORE EDIT FUNCTION!






*/
class TextTool
{
    //Normal text generation
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
                    Console.WriteLine("\n\n--\tContinue\t-->>");
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
                    Console.WriteLine("\n\n--\tContinue\t-->>");
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

    //Story text generation[WIP]
    public static void StoryGen(string name, string text, int textSpeed, bool clearConsole, bool pressOnKey, int delay)
    {
        if (clearConsole == true)
        {
            Console.Clear();
        }
        if (pressOnKey == true)
        {
            Console.Write("[" + name + "]: ");
            for (int i = 0; i < text.Length + 1; i++)
            {
                if (i >= text.Length)
                {
                    Thread.Sleep(delay);
                    Console.WriteLine("\n\n--\tContinue\t-->>");
                    break;
                }
                Console.Write(text[i]);
                Thread.Sleep(textSpeed);
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Enter && Console.ReadKey(true).Key != ConsoleKey.Spacebar){}
        }
        if (pressOnKey == false)
        {
            Console.Write("[" + name + "]: ");
            for (int i = 0; i < text.Length; i++)
            {
                Console.Write(text[i]);
                Thread.Sleep(textSpeed);
            }
            Thread.Sleep(delay);
        }
    }
    public static void StoryGen(string name, string text, int textSpeed, bool clearConsole, bool pressOnKey)
    {
        if (clearConsole == true)
        {
            Console.Clear();
        }
        if (pressOnKey == true)
        {
            Console.Write("[" + name + "]: ");
            for (int i = 0; i < text.Length + 1; i++)
            {
                if (i >= text.Length)
                {
                    Thread.Sleep(500);
                    Console.WriteLine("\n\n--\tContinue\t-->>");
                    break;
                }
                Console.Write(text[i]);
                Thread.Sleep(textSpeed);
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Enter && Console.ReadKey(true).Key != ConsoleKey.Spacebar){}
        }
        if (pressOnKey == false)
        {
            Console.Write("[" + name + "]: ");
            for (int i = 0; i < text.Length; i++)
            {
                Console.Write(text[i]);
                Thread.Sleep(textSpeed);
            }
        }
    }
    public static void StoryGen(string name, string text, int textSpeed, bool clearConsole)
    {
        if (clearConsole == true)
        {
            Console.Clear();
        }
        Console.Write("[" + name + "]: ");
        for (int i = 0; i < text.Length; i++)
        {
            Console.Write(text[i]);
            Thread.Sleep(textSpeed);
        }
    }
    public static void StoryGen(string name, string text, int textSpeed)
    {
        Console.Write("[" + name + "]: ");
        for (int i = 0; i < text.Length; i++)
        {
            Console.Write(text[i]);
            Thread.Sleep(textSpeed);
        }
    }
    public static void StoryGen(string name, string text)
    {
        Console.Write("[" + name + "]: ");
        for (int i = 0; i < text.Length; i++)
        {
            Console.Write(text[i]);
            Thread.Sleep(1);
        }
    }
}

class Settings
{
    public static JsonNode Read()
    {
        string _filename = "setting.json";
        string jsondata = File.ReadAllText(_filename);
        var _loadJson = JsonNode.Parse(jsondata);
        return _loadJson;
    }
    public static string Read(int slot, string name)
    {
        string _filename = "setting.json";
        string jsondata = File.ReadAllText(_filename);
        var _loadJson = JsonNode.Parse(jsondata);
        string data = _loadJson[slot][name].ToString();
        return data;
    }
    public static void Modify(string type, string value)
    {
      string _filename = "setting.json";
      try
      {
          if (type == "1")
          {
              string jsondata = File.ReadAllText(_filename);
              var _loadJson = JsonNode.Parse(jsondata);
              _loadJson[0]["TextSpeed"] = value;

              string _save = JsonSerializer.Serialize(_loadJson);
              File.WriteAllText(_filename, _save);
          }
          else if (type == "2")
          {
              string jsondata = File.ReadAllText(_filename);
              var _loadJson = JsonNode.Parse(jsondata);
              _loadJson[0]["Test"] = value;

              string _save = JsonSerializer.Serialize(_loadJson);
              File.WriteAllText(_filename, _save);
          }
          else
          {
              Console.WriteLine("Setting not found!");
          }
      }
      catch (Exception e)
      {
          Console.WriteLine("Something went worng...\nMore detail:\n");
          Console.WriteLine(e);
      }
    }
    public static void check()
    {
      string _filename = @"./setting.json";
      if (!File.Exists(_filename))
      {
          string filename = "setting.json";
          object[] arr = new object[1];
          var _save = new settingsave
          {
              TextSpeed = "30",
              Test = "1"
          };

          arr[0] = _save;

          string _savedata = JsonSerializer.Serialize(arr);
          File.WriteAllText(filename, _savedata);
        }
    }
}

public class FileTool : coreGame
{
    public static void SaveChaper(string filename, string path, int chapter, int route, bool quicksave)
    {
      string schapter = chapter.ToString();
      string sroute = route.ToString();
      string dir = path;
      if (!Directory.Exists(dir))
      {
          Directory.CreateDirectory(dir);
      }
      object[] obj = new object[1];
      var save = new dataSave
      {
          chapter = schapter,
          route = sroute
      };
      obj[0] = save;

      string savedata = JsonSerializer.Serialize(obj);
      File.WriteAllText(Path.Combine(dir, filename), savedata);
      if (quicksave = true)
      {
          File.WriteAllText(Path.Combine(dir, "QuickSave"), savedata);
      }
    }
    public static void CheckCreatedFolder(string foldername)
    {
      if (!Directory.Exists(foldername))
      {
          Directory.CreateDirectory(foldername);
      }
    }
    public static void LoadChapter(string filename)
    {
      string[] path = {"save", filename};
      string fullpath = Path.Combine(path);
      if (!File.Exists(fullpath))
      {
          Console.WriteLine("File save not found");
          Console.ReadKey();
      }
      if (File.Exists(fullpath))
      {
        string _filename = fullpath;
        string jsondata = File.ReadAllText(_filename);
        var loadJson = JsonNode.Parse(jsondata);
        string Lchapter = loadJson[0]["chapter"].ToString();
        if (Lchapter == "1")
        {
            chapter1();
        }
        else if (Lchapter == "2")
        {
            chapter2();
        }
        else
        {
            Console.WriteLine("Save file not found");
            Console.ReadKey();
        }
      }
    }
    public static void QLoadChapter()
    {
      string filename = "QuickSave";
      string fullqpath = @"save/QuickSave";
      if (!File.Exists(fullqpath))
      {
          Console.WriteLine("You don't have quick save file");
          Console.ReadKey();
      }
      if (File.Exists(fullqpath))
      {
        string _filename = fullqpath;
        string jsondata = File.ReadAllText(_filename);
        var loadJson = JsonNode.Parse(jsondata);
        string Lchapter = loadJson[0]["chapter"].ToString();
        Console.WriteLine("Warning:\nYour last saved checkpoint is Chapter " + Lchapter + "\nDo you want to load this chapter?\n[Type Y to continue/Type anything else to return]");
        string Cload = Console.ReadLine();
        if (Cload.ToLower() == "y")
        {
          if (Lchapter == "1")
          {
              chapter1();
          }
          else if (Lchapter == "2")
          {
              chapter2();
          }
          else
          {
              Console.WriteLine("Save file not found");
              Console.ReadKey();
          }
        }
      }
    }
    public static void DeleteSave(string filename, string path)
    {
      //Doing
      if (filename == "")
      {
        Console.WriteLine("You didn't enter save file name");
        Console.ReadKey();
      }
      else
      {
        Console.WriteLine("Are you sure to delete " + filename +"?[Type Y to confirm]");
        string DelComfirm = Console.ReadLine();
        if (DelComfirm.ToLower() == "y" || DelComfirm == "")
        {
          try
          {
            string[] fpath = {path, filename};
            string fullpath = Path.Combine(fpath);
            File.Delete(fullpath);
          }
          catch (Exception e)
          {
            Console.WriteLine("Something went worng\nMore info:");
            Console.WriteLine(e);
            Console.ReadLine();
          }
        }
      }
    }
    public static void Choice(string Question, string Choice1, string Choice2, string Choice3)
    {
      //Choice that doesn't affect anything

    }
    public static string ChoiceRoute(string Question, string Choice1, string Choice2, string Choice3)
    {
      //Choice that affect gameplay/ending
      while (true)
      {
        TextTool.TextGen("\n" + Question);
        Console.WriteLine("\n1 " + Choice1 + "\n2 " + Choice2 + "\n3 " + Choice3 + "\n");
        TextTool.TextGen("Your answer(1-3) >");
        string Choose = Console.ReadLine();
        if (Choose == "1" || Choose == "2" || Choose == "3")
        {
          return Choose;
        }
        else
        {
          Console.Clear();
        }
      }
    }
}




//Data zone
public class settingsave
{
    public string TextSpeed {get; set;}
    public string Test {get; set;}
}
public class dataSave
{
    public string chapter {get; set;}
    public string route {get; set;}
}
