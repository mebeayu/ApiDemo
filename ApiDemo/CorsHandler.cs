using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApiDemo
{
    public static class CorsHandler 
    {
        public static List<string> list = new List<string>();
        public static void Tread_1()
        {
            while (true)
            {
                int n = list.Count;
                if (n > 10) list.RemoveAt(0);
                Thread.Sleep(1000);
                list.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            
        }
        public static void StartJob()
        {
            Thread thread = new Thread(Tread_1);
            thread.Start();
        }
    }
}
