internal class Program
{
    private static string _password = "khaled";
    private static List<Action> _actions = new()
    {
        Log.NewLog,
        Log.OldLogs,
        Exit
    };

    public static void Main(string[] args)
    {
        // Setup Phase
        SetupEnviroment();
        ForcePassword();
        
        // menu part
        while (true)
        {
            _actions[MainMenu()].Invoke();
        }
    }

    static void SetupEnviroment()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.CursorVisible = false;
    }

    static void ForcePassword()
    {
        bool hasLoggedIn = false;
        do
        {
            Console.Write("Enter password: ");
            if (Console.ReadLine() == _password)
            {
                hasLoggedIn = true;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Wrong password!");
                Console.WriteLine("--------------------");
            }
            
        } while (!hasLoggedIn);
    }

    static int MainMenu()
    {
        int currentSelection = 0;
        int oldSelection = 0;
        while (currentSelection != 99)
        {
            oldSelection = currentSelection;
            RenderMenuOnSelection(currentSelection);
            currentSelection = KeyInputHandler(currentSelection);
        }

        return oldSelection;
    }

    static int KeyInputHandler(int currentSelection)
    {
        ConsoleKey key = Console.ReadKey(true).Key;
        
        if (key == ConsoleKey.Enter) return 99;

        if (key == ConsoleKey.W || key == ConsoleKey.UpArrow) currentSelection--;
        else if (key == ConsoleKey.S || key == ConsoleKey.DownArrow) currentSelection++;

        if (currentSelection <= -1) currentSelection = 2;
        else if (currentSelection >= 3) currentSelection = 0;

        return currentSelection;
    }

    static void RenderMenuOnSelection(int selection)
    {
        List<string> menuList = new List<string>
        {
            "New log",
            "See old logs",
            "Exit"
        };

        menuList[selection] = "--> " + menuList[selection];
        
        Console.Clear();
        menuList.ForEach(Console.WriteLine);
    }

    static void Exit()
    {
        Console.Clear();
        Console.Write("Goodbye!");
        Environment.Exit(0);
    }
}