using System;
using System.Collections;
using Dictionary.Models;

namespace Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            var mainDict = new MainDict<int, string>();
            mainDict.Add(new Item<int, string>(1, "One"));
            mainDict.Add(new Item<int, string>(1, "One"));
            mainDict.Add(new Item<int, string>(2, "Two"));
            mainDict.Add(new Item<int, string>(3, "Three"));
            mainDict.Add(new Item<int, string>(4, "Four"));
            mainDict.Add(new Item<int, string>(5, "Five"));
            mainDict.Add(new Item<int, string>(101, "HundrenOne"));

            ShowResult(mainDict);

            Console.WriteLine(mainDict.Search(7) ?? "Not found");
            Console.WriteLine(mainDict.Search(3) ?? "Not found");
            Console.WriteLine(mainDict.Search(101) ?? "Not found");
            Console.WriteLine();

            mainDict.Remove(7);
            mainDict.Remove(3);
            mainDict.Remove(1);
            mainDict.Remove(101);

            ShowResult(mainDict);

            Console.ReadLine();
            Console.WriteLine("------------------------");
            var easyDict = new EasyDict<int, string>();
            easyDict.Add(new Item<int, string>(1, "One"));
            easyDict.Add(new Item<int, string>(2, "Two"));
            easyDict.Add(new Item<int, string>(3, "Three"));
            easyDict.Add(new Item<int, string>(4, "Four"));
            easyDict.Add(new Item<int, string>(5, "Five"));

            ShowResult(easyDict);

            Console.WriteLine(easyDict.Search(7) ?? "Not found");
            Console.WriteLine(easyDict.Search(3) ?? "Not found");
            Console.WriteLine();

            easyDict.Remove(3);
            easyDict.Remove(1);

            ShowResult(easyDict);

            Console.ReadLine();
        }

        private static void ShowResult(IEnumerable list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
        }
    }
}
