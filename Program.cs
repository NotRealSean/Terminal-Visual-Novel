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
    public static void chapter1()
    {
      Settings.check();
      JsonNode _jsonData = Settings.Read()!;
      string speed = _jsonData[0]["TextSpeed"].ToString();
      int textspeed = Convert.ToInt32(speed);
        //TextTool.textGen("enter smt",1 /*text speed*/, true /*clear console*/, true /*add press continue*/, 1 /*delay after text complete*/);
        TextTool.TextGen("This is chapter 1 test text", textspeed, true);
        string choose = FileTool.ChoiceRoute("Do you like this game?", "Yes", "Kinda", "No");
        if (choose == "1")
        {
          FileTool.SaveChaper("save1-1", "save", 1, 1, true);
        }
        if (choose == "2")
        {
          FileTool.SaveChaper("save1-2", "save", 1, 2, true);
        }
        if (choose == "3")
        {
          TextTool.TextGen(":(", textspeed, true, true);
          FileTool.SaveChaper("save1-3", "save", 1, 3, true);
        }
    }
    public static void chapter2()
    {
      Settings.check();
      JsonNode _jsonData = Settings.Read()!;
      string speed = _jsonData[0]["TextSpeed"].ToString();
      int textspeed = Convert.ToInt32(speed);
        TextTool.TextGen("This is chapter 2 test text", textspeed, true);
        string choose = FileTool.ChoiceRoute("Rate this game", "Like", "Normal", "Hate");
        if (choose == "1")
        {
          FileTool.SaveChaper("save2-1", "save", 2, 1, true);
        }
        if (choose == "2")
        {
          FileTool.SaveChaper("save2-2", "save", 2, 2, true);
        }
        if (choose == "3")
        {
          TextTool.TextGen("Fine", textspeed, true, true);
          FileTool.SaveChaper("save2-3", "save", 2, 3, true);
        }
    }
}
class Menu
{
    static void Main(string[] args)
    {
        TextTool.TextGen("", 1, true, false, 1000);
        TextTool.TextGen("\n\n\t---< Game made by NotRealSean >---\n\n\nReport bug/suggestion at...\nDiscord - NotRealSean#4001\nTwitter - @Seankungzaza1\n", 1, true, false);
        Console.WriteLine("\nLoading settings...");
        Settings.check();
        Console.WriteLine("Settings loaded press any key to continue");
        Console.ReadKey();
        while (true)
        {
          JsonNode _jsonData = Settings.Read()!;
          string speed = _jsonData[0]["TextSpeed"].ToString();
          int textspeed = Convert.ToInt32(speed);
            Console.Clear();
            //Main menu
            Console.WriteLine("=======================================================");
            Console.WriteLine(" A Text-base game name(Can't think of name just yet)\n\t1 New Game\n\t2 Load\n\t3 Quick Load\n\t4 Settings\n\t5 Guide\n\t6 Credits\n\t7 Update\n\n\t9 Exit\t\t\t\t0.0.43");
            Console.WriteLine("=======================================================");
            TextTool.TextGen("Key command -=>", textspeed);
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
                    TextTool.TextGen("Key command -=>", textspeed);
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
                  DirectoryInfo d = new DirectoryInfo(@"save"); //Assuming Test is your Folder

                  FileInfo[] Files = d.GetFiles(""); //Getting Text files
                  string str = "";

                  foreach(FileInfo file in Files)
                  {
                    str = str + "\n" + file.Name;
                    Console.Clear();
                    Console.WriteLine("=======================================================");
                    Console.WriteLine("\t\tYour save file\n"+ str +"\n\n\t9 Exit");
                    Console.WriteLine("=======================================================");
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
            }
            else if (inPut ==  "3")
            {
                //Quick load
                FileTool.QLoadChapter();
            }
            else if (inPut == "4")
            {
                //Settings
                Settings.check();
                  while (true)
                  {
                    Console.Clear();
                    Console.WriteLine("=======================================================");
                    Console.WriteLine("\t\tSettings\n\t1 Text Speed(Delay in ms)\n\t2 Test\n\n\t9 Return to menu");
                    Console.WriteLine("=======================================================");
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
                        if (value == "exit")
                        {
                            break;
                        }
                        try
                        {
                            int intvalue = Convert.ToInt32(value);
                            if (intvalue.GetType().Equals(typeof(int)));
                            {
                                if (intvalue > 500)
                                {
                                    Console.WriteLine("You can't do more that 500!");
                                    Console.ReadKey();
                                }
                                else if (intvalue > 0)
                                {
                                    string stringvalue = intvalue.ToString();
                                    Settings.Modify(setting, stringvalue);
                                }
                                else if (intvalue <= 0)
                                {
                                    Console.WriteLine("Are you trying to set value to 0 or lower?\nToo bad you can't");
                                    Console.ReadKey();
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Something went worng...\nMore detail:\n");
                            Console.WriteLine(e);
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.WriteLine("You enter worng key!");
                        Console.ReadKey();
                    }
                }
            }
            else if (inPut == "5")
            {
                //Guide
                Console.WriteLine("Checking for update...");
                string _filename = @"./guide.txt";
                if (!File.Exists(_filename) || File.Exists(_filename))
                {
                    string filename = "_guide.txt";
                    System.Net.WebClient wc = new System.Net.WebClient();
                    string webData = wc.DownloadString("https://raw.githubusercontent.com/NotRealSean/Console-Visual-Novel-Text-Base-Game/main/_guide.txt");
                    File.WriteAllText(filename, webData);
                }
                Console.Clear();
                string update = File.ReadAllText("_guide.txt");
                Console.WriteLine(update);
                TextTool.TextGen("Press anykey to go back to main menu...", 10);
                Console.ReadKey();
            }
            else if (inPut == "6")
            {
                //Credits
                Console.WriteLine("Checking for update...");
                string _filename = @"./credits.txt";
                if (!File.Exists(_filename) || File.Exists(_filename))
                {
                    string filename = "credits.txt";
                    System.Net.WebClient wc = new System.Net.WebClient();
                    string webData = wc.DownloadString("https://raw.githubusercontent.com/NotRealSean/Console-Visual-Novel-Text-Base-Game/main/credits.txt");
                    File.WriteAllText(filename, webData);
                }
                Console.Clear();
                string update = File.ReadAllText("credits.txt");
                Console.WriteLine(update);
                TextTool.TextGen("Press anykey to go back to main menu...", 10);
                Console.ReadKey();
            }
            else if (inPut == "7")
            {
                //Update
                Console.WriteLine("Checking for update...");
                string _filename = @"./_update.txt";
                if (!File.Exists(_filename) || File.Exists(_filename))
                {
                    string filename = "_update.txt";
                    System.Net.WebClient wc = new System.Net.WebClient();
                    string webData = wc.DownloadString("https://raw.githubusercontent.com/NotRealSean/Console-Visual-Novel-Text-Base-Game/main/_update.txt");
                    File.WriteAllText(filename, webData);
                }
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
          File.WriteAllText(Path.Combine(dir, "_QuickSave"), savedata);
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
      string filename = "_QuickSave";
      string fullqpath = @"save/_QuickSave";
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
        if (DelComfirm.ToLower() == "y")
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
          break;
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
