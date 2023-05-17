using System.Net.NetworkInformation;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace CSVNLib
{
    public class VNLib
    {
        public class TextTool
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

        public class Settings
        {
            public static bool CheckConnect()
            {
                string host = "8.8.8.8";
                bool result = false;
                Ping p = new Ping();
                try
                {
                    PingReply reply = p.Send(host, 3000);
                    if (reply.Status == IPStatus.Success)
                        return true;
                }
                catch { }
                return result;
            }
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
                        _loadJson[0]["Arrow"] = value;

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
                    Arrow = "1"
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
                    TextTool.TextGen("Your answer(1-3)- >");
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
            public string Arrow {get; set;}
        }
        public class dataSave
        {
            public string chapter {get; set;}
            public string route {get; set;}
        }

    }
}
