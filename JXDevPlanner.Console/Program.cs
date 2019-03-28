using JXDevPlanner.Data;
using JXDevPlanner.WebMVC;
using JXDevPlanner.WebMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXDevPlanner.ConsoleApp
{
    //public class XConsole {
    //    public ConsoleColor fg { get { return Console.ForegroundColor; } set { Console.ForegroundColor = value; } }
    //    public ConsoleColor bg { get { return Console.BackgroundColor; } set { Console.BackgroundColor = value; } }

    //    public void WriteLineH(String s) {
    //        ConsoleColor p = fg;
    //        ConsoleColor q = bg;
    //        fg = q;
    //        bg = p;
    //        Console.WriteLine(s);
    //        fg = p;
    //        bg = q;
    //    }

    //    public int Select(string[] options) {
    //        bool running = true;
    //        int index = 0;

    //        while (running) {
    //            // Draw...
    //            Console.Clear();
    //            for (int i = 0; i < options.Length; i++) {
    //                if (i == index) WriteLineH(options[i]); else Console.WriteLine(options[i]);
    //            }

    //            // Accept Input...
    //            var keyInfo = Console.ReadKey();

    //            switch (keyInfo.Key) {
    //                case ConsoleKey.UpArrow:
    //                    index--;
    //                    if (index < 0) index = options.Length - 1;
    //                    break;
    //                case ConsoleKey.DownArrow:
    //                    index++;
    //                    if (index >= options.Length) index = 0;
    //                    break;
    //                case ConsoleKey.Enter:
    //                    return index;
    //            }
    //        }
    //        return -1;
    //    }

    //    public string ReadLine() { return Console.ReadLine(); }
    //    public void WriteLine(object data) { Console.WriteLine(data); }
    //    public void Write(object data) { Console.WriteLine(data); }
    //    public string ReadPassword() {
    //        string str = "";
    //        ConsoleKeyInfo keyInfo;
    //        while ((keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Enter) {
    //            switch (keyInfo.Key)
    //            {
    //                case ConsoleKey.Backspace:
    //                    str = str.Substring(0,str.Length-1);
    //                    Console.WriteLine("\b");
    //                    break;
    //                default:
    //                    str += keyInfo.KeyChar;
    //                    Console.Write("*");
    //                    break;
    //            }
    //        }
    //        return str;
    //    }
    //}

    //class ProjectView {
    //    XConsole console;
    //    ApplicationDbContext dbc;

    //    public ProjectView(ProjectService) {
    //        this.dbc = ctx;
    //    }

    //    public void Draw() {
    //        Console.Clear();
    //        dbc.Projects.Single();
    //    }
    //}

    public class Program
    {
        public static void Main(string[] args) { }
        //static SqlConnection conn;

        //static void Init() {
        //    string connectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\JXDevPlanner.mdf;Initial Catalog=JXDevPlanner;Integrated Security=True";
        //    conn = new SqlConnection(connectionString);
        //    conn.Open();
        //}
        //public static bool TryLogin(string user,string pass)
        //{
        //    //conn.
        //    return false;
        //}

        ////public static int 

        //public static void Main(string[] args)
        //{
        //    XConsole console = new XConsole();
        //    Console.Clear();
        //    Console.WriteLine("Welcome to JXDevPlanner!");
        //    switch (console.Select(new string[] {
        //        "Login",
        //        "Exit"
        //    }))
        //    {
        //        case 0:
        //            Console.Clear();
        //            Console.Write("Username: ");
        //            string user = Console.ReadLine();
        //            Console.Write("Password: ");
        //            string pass = console.ReadPassword();
        //            if (TryLogin(user,pass)) {
        //            }

        //            break;
        //        case 1:
        //            // ?
        //            break;
        //    }
        //}
    }
}
