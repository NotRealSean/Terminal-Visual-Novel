using System.Text.Json.Nodes;
using CSVNLib;

public class coreGame
{
    public static void prologue()
    {
        VNLib.Settings.check();
        int textspeed = Convert.ToInt32(VNLib.Settings.Read(0, "TextSpeed"));
        //Prologue
        string Respond = Console.ReadLine().ToLower();
        if (Respond == "y")
        {
            chapter1();
        }
    }
    public static void chapter1()
    {
        //Chapter 1
        int textspeed = Convert.ToInt32(VNLib.Settings.Read(0, "TextSpeed"));
        VNLib.TextTool.TextGen("Do you want to continue?[y] ", textspeed, true);
        string Respond = Console.ReadLine().ToLower();
        if (Respond == "y")
        {
            chapter2();
        }
    }
    public static void chapter2()
    {
        //chapter 2
        int textspeed = Convert.ToInt32(VNLib.Settings.Read(0, "TextSpeed"));
        VNLib.TextTool.TextGen("Testing chapter 2", textspeed, true, true);
    }
}
class Menu
{
    static void Main()
    {
        string reset = "reset";
        while (reset == "reset")
        {
            VNLib.TextTool.TextGen("", 1, true, false, 1000);
            VNLib.TextTool.TextGen("\n\n\t---< Game made by NotRealSean >---\n\n\nReport bug/suggestion at...\nDiscord - NotRealSean#4001\nTwitter - @Seankungzaza1\n\n\n", 1, true, false);
            Console.Write("Loading log :\nLoading settings...");
            VNLib.Settings.check();
            Console.WriteLine("Done");
            Console.Write("Checking save folder...");
            VNLib.FileTool.CheckCreatedFolder("save");
            Console.WriteLine("Done");
            Console.Write("Checking for update[Require internet]...");
            string version = "0.0.54 Dev.4";
            File.WriteAllText("gameVersion", version);
            bool connectEnable = VNLib.Settings.CheckConnect();
            if (connectEnable == true)
            {
                System.Net.WebClient gitversion = new System.Net.WebClient();
                string versionData = gitversion.DownloadString("https://raw.githubusercontent.com/NotRealSean/Console-Visual-Novel-Text-Base-Game/main/version");
                Console.WriteLine("Done");
                if (version != versionData)
                {
                    Console.WriteLine("Your game version is outdated\nYour game version : " + version + "\nNew version : " + versionData);
                    Console.WriteLine("Download new version here : https://github.com/NotRealSean/Terminal-Visual-Novel/releases");
                    Console.WriteLine("You can still play the game by press enter key to continue...");
                }
                else if (version == versionData)
                {
                    Console.WriteLine("Your game is up to date : " + versionData);
                    Console.WriteLine("Press enter key to continue...");
                }
            }
            else
            {
                Console.WriteLine("\nYou are in offline mode but you can still play the game");
                Console.WriteLine("Press enter key to continue...");
            }
            string devc = Console.ReadLine();
            string debugEnable = (devc == "debug_enable") ? "true" : (devc == "help") ? "help" : (devc == "offline_mode") ? "offline" : "online";
            connectEnable = (debugEnable == "offline") ? false : true;
            if (debugEnable == "help")
            {
                Console.WriteLine("debug_enable = enable debugging\noffline_mode = enable offline test\nPlease restart the game to re-enter debug commands");
                Console.ReadKey();
            }
            while (true)
            {
                //Get Textspeed and arrow
                JsonNode _jsonData = VNLib.Settings.Read()!;
                int textspeed = Convert.ToInt32(_jsonData[0]["TextSpeed"].ToString());
                int arrow = Convert.ToInt32(_jsonData[0]["Arrow"].ToString());
                string UIarrow = (arrow == 1) ? " -=>" : (arrow == 2) ? " -+>" : (arrow == 3) ? " :" : (arrow == 4) ? " >" : (arrow == 69) ? " <-+{69 NICE 69}-+>" : (arrow >= 5) ? " -=>": " <{[YOUR ARROW SETTINGS IS LOWER THAN 1!]}>>>";
                Console.Clear();

                //Main menu
                if (debugEnable == "true")
                {
                    Console.WriteLine("[Debug mode is enable]");
                    Console.WriteLine("TextSpeed [" + textspeed + " ms]");
                    Console.WriteLine("Arrow [" + arrow + "][" + UIarrow + "]");
                }
                Console.WriteLine("=======================================================");
                Console.WriteLine(" A Text-base game name(Can't think of name just yet)\n\t[1] New Game\n\t[2] Load\n\t[3] Quick Load\n\t[4] Settings\n\t[5] Guide[Require internet]\n\t[6] Credits[Require internet]\n\t[7] News[Require internet]\n\n\t[9] Exit\t\t\t\t" + version);
                Console.WriteLine("=======================================================");
                VNLib.TextTool.TextGen("Command" + UIarrow, textspeed);
                string inPut = Console.ReadLine();
                switch (inPut)
                {
                    case "help":
                    Console.WriteLine("Help: Type number and hit Enter to comfirm or type reset to restart the game");
                    Console.ReadKey();
                    break;
                    case "1":
                    while (true)
                    {
                        //chapter select
                        Console.Clear();
                        Console.WriteLine("=======================================================");
                        Console.WriteLine("\t\tSelect Chapter\n\t[1] Prologue\n\t[2] Chapter 1\n\t[3] Chapter 2\n\n\t[9] Back to main menu");
                        Console.WriteLine("=======================================================");
                        VNLib.TextTool.TextGen("Command" + UIarrow, textspeed);
                        string chapterSelect = Console.ReadLine();

                        switch (chapterSelect)
                        {
                            case "help":
                            Console.WriteLine("Help: Type number and hit Enter to comfirm");
                            Console.ReadKey();
                            break;
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
                    VNLib.FileTool.CheckCreatedFolder("save");
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
                        }
                        VNLib.TextTool.TextGen("Load file" + UIarrow, textspeed);
                        string LoadSelect = Console.ReadLine();
                        if (LoadSelect == "help")
                        {
                            Console.WriteLine("Help: Type file name and hit enter to continue or type del to enter delete mode");
                            Console.ReadKey();
                        }
                        if (LoadSelect == "9")
                        {
                            break;
                        }
                        if (LoadSelect.ToLower() == "del")
                        {
                            VNLib.TextTool.TextGen("Enter file name you want to delete" + UIarrow, textspeed);
                            string DelSelect = Console.ReadLine();
                            VNLib.FileTool.DeleteSave(DelSelect, "save");
                        }
                        else
                        {
                            VNLib.FileTool.LoadChapter(LoadSelect);
                        }
                    }
                    break;


                    case "3":
                    //Quick load
                    VNLib.FileTool.QLoadChapter();
                    break;


                    case "4":
                    //Settings
                    VNLib.Settings.check();
                    while (true)
                    {
                        string DBtextspeed = VNLib.Settings.Read(0, "TextSpeed");
                        string DBarrow = VNLib.Settings.Read(0, "Arrow");
                        Console.Clear();
                        if (debugEnable == "true")
                        {
                            Console.WriteLine("[Debug mode is enable]");
                            Console.WriteLine("JsonTextSpeed[" + DBtextspeed + "]");
                            Console.WriteLine("JsonArrow[" + DBarrow + "]");
                        }
                        Console.WriteLine("=======================================================");
                        Console.WriteLine("\t\tSettings\n\t[1] Text Speed[" + DBtextspeed + "]\n\t[2] Arrow[" + DBarrow + "]");
                        if (debugEnable == "true")
                        {
                            Console.WriteLine("\n\t[5] Disable debug_mode\n");
                        }
                        Console.WriteLine("\n\t[9] Back to main menu");
                        Console.WriteLine("=======================================================");
                        VNLib.TextTool.TextGen("Command" + UIarrow, textspeed);
                        string setting = Console.ReadLine();
                        if (setting == "help")
                        {
                            Console.WriteLine("Help: Type number and hit Enter to comfirm");
                            Console.ReadKey();
                        }
                        if (setting == "9")
                        {
                        break;
                        }
                        else if (setting == "1" || setting == "2" || setting == "5")
                        {
                            if (setting == "5" && debugEnable == "true")
                            {
                                Console.Write("Are you sure to disble this settings[Y/n]");
                                string DBdisableComfirm = Console.ReadLine().ToLower();
                                if (DBdisableComfirm == "y")
                                {
                                    debugEnable = "false";
                                    break;
                                }
                            }
                            if (setting == "5" && debugEnable == "false")
                            {
                                Console.WriteLine("You enter worng key!");
                                Console.ReadKey();
                            }
                            if (setting == "1")
                            {
                                Console.WriteLine("0 - 100(Higher you put is slower text can generate)\n[Default : 30]");
                            }
                            if (setting == "2")
                            {
                                Console.WriteLine("[1] -=>\n[2] -+>\n[3] :\n[4] >\nHigher than this will set to 1 by default");
                            }
                            if (setting == "1" || setting == "2")
                            {
                                VNLib.TextTool.TextGen("Value" + UIarrow, textspeed);
                                string value = Console.ReadLine();
                                try
                                {
                                    int result = int.Parse(value);
                                    if (result > 100)
                                    {
                                        Console.WriteLine("You can't do more then 100!");
                                        Console.ReadLine();
                                    }
                                    else if (result > 0)
                                    {
                                        string stringvalue = result.ToString();
                                        VNLib.Settings.Modify(setting, stringvalue);
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
                    if (connectEnable == true)
                    {
                        Console.WriteLine("Checking for update...[Require internet]");
                        string filename = @"./guide.txt";
                        //Write update
                        System.Net.WebClient wc = new System.Net.WebClient();
                        string webData = wc.DownloadString("https://raw.githubusercontent.com/NotRealSean/Console-Visual-Novel-Text-Base-Game/main/_guide.txt");
                        File.WriteAllText(filename, webData);

                        Console.Clear();
                        string update = File.ReadAllText("_guide.txt");
                        Console.WriteLine(update);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("You are in offline mode!");
                        if (!File.Exists(@"./_guide.txt"))
                        {
                            Console.WriteLine("You don't have _guide.txt file");
                        }
                        else
                        {
                            string update = File.ReadAllText("_guide.txt");
                            Console.WriteLine(update);
                        }
                    }
                    VNLib.TextTool.TextGen("Press anykey to go back to main menu...", 10);
                    Console.ReadKey();
                    break;


                    case "6":
                    //Credits
                    if (connectEnable == true)
                    {
                        Console.WriteLine("Checking for update...[Require internet]");
                        string _filename = @"./credits.txt";
                        //Write update
                        System.Net.WebClient _wc = new System.Net.WebClient();
                        string _webData = _wc.DownloadString("https://raw.githubusercontent.com/NotRealSean/Console-Visual-Novel-Text-Base-Game/main/credits.txt");
                        File.WriteAllText(_filename, _webData);

                        Console.Clear();
                        string _update = File.ReadAllText("credits.txt");
                        Console.WriteLine(_update);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("You are in offline mode!");
                        if (!File.Exists(@"./credits.txt"))
                        {
                            Console.WriteLine("You don't have credits.txt file");
                        }
                        else
                        {
                            string update = File.ReadAllText("credits.txt");
                            Console.WriteLine(update);
                        }
                    }
                    VNLib.TextTool.TextGen("Press anykey to go back to main menu...", 10);
                    Console.ReadKey();
                    break;

                    case "7":
                    //News
                    if (connectEnable == true)
                    {
                        Console.WriteLine("Checking for update...[Require internet]");
                        string __filename = "_update.txt";
                        //Write update
                        System.Net.WebClient __wc = new System.Net.WebClient();
                        string __webData = __wc.DownloadString("https://raw.githubusercontent.com/NotRealSean/Console-Visual-Novel-Text-Base-Game/main/_update.txt");
                        File.WriteAllText(__filename, __webData);

                        Console.Clear();
                        string __update = File.ReadAllText("_update.txt");
                        Console.WriteLine(__update);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("You are in offline mode!");
                        if (!File.Exists(@"./_update.txt"))
                        {
                            Console.WriteLine("You don't have _update.txt file");
                        }
                        else
                        {
                            string update = File.ReadAllText("_update.txt");
                            Console.WriteLine(update);
                        }
                    }

                    VNLib.TextTool.TextGen("Press anykey to go back to main menu...", 10);
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

                    case "reset":

                    break;

                    default:
                    Console.WriteLine("You enter worng key!");
                    Console.ReadKey();
                    break;
                }
                if (inPut == "9")
                {
                    reset = "exit";
                    break;
                }
                if (inPut == "reset")
                {
                    reset = "reset";
                    break;
                }
            }
        }
    }
}
