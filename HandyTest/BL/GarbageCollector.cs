using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandyTest.BL
{
    class GarbageCollector
    {
        public static void DeleteAllScreenshoots(string pathToScreenshoots)
        {
            if (!Directory.Exists(pathToScreenshoots))
                Directory.CreateDirectory(pathToScreenshoots);
            DirectoryInfo di = new DirectoryInfo(pathToScreenshoots);
            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
        }
    }
}
