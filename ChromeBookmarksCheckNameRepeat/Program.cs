using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ChromeBookmarksCheck.Model;
using Newtonsoft.Json;

namespace ChromeBookmarksCheckNameRepeat
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            var sw = new Stopwatch();
            sw.Start();

            var filePath = ConfigurationManager.AppSettings["BookmarksPath"];

            using (var streamReader = new StreamReader(filePath))
            {
                using (var reader = new JsonTextReader(streamReader))
                {
                    var rootObject = new JsonSerializer().Deserialize<Rootobject>(reader);

                    if (rootObject != null)
                    {
                        await ProcessChildren(rootObject.roots.bookmark_bar.children, string.Empty);
                    }
                }
            }

            sw.Stop();
            Console.WriteLine($"總共花費{sw.Elapsed.Hours}:{sw.Elapsed.Minutes}:{sw.Elapsed.Seconds}");

            Console.WriteLine("Enter any key!");
            Console.ReadKey();
        }

        private static async Task ProcessChildren(Child[] childArr, string folderPath)
        {
            //排序讓資料夾先處理
            var childrenSort = from e in childArr
                               orderby e.type, e.name
                               select e;

            var nameList = new List<string>();

            foreach (var item in childrenSort)
            {
                if (item.type == "folder")
                {
                    folderPath += "/" + item.name;
                    //如果有資料夾，就先處理
                    await ProcessChildren(item.children, folderPath);
                    folderPath = folderPath.Replace("/" + item.name, string.Empty);
                }
                else
                {
                    try
                    {
                        int index = nameList.FindIndex(x => x == item.name);
                        if (index < 0)
                            nameList.Add(item.name);
                        else
                        {
                            Console.WriteLine($"資料夾：{folderPath}");
                            Console.WriteLine($"名稱：{item.name}");
                            Console.WriteLine($"網址：{item.url}");
                            Console.WriteLine(string.Empty);
                        }
                    }
                    catch (HttpRequestException e)
                    {
                        Console.WriteLine($"錯誤訊息：{e.Message}");
                        if (e.InnerException != null)
                        {
                            Console.WriteLine($"內部錯誤訊息：{e.InnerException.Message}");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"錯誤訊息：{e.Message}");
                        if (e.InnerException != null)
                        {
                            Console.WriteLine($"內部錯誤訊息：{e.InnerException.Message}");
                        }
                    }
                }
            }
        }
    }
}
