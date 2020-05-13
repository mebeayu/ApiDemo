using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApiDemo.Coustom
{
    public interface IRepertJob
    {
        void DoJob();
        
    }
    public class JobService : IRepertJob
    {
        private bool is_stop = false;
        public bool IsStop
        {
            get { return is_stop; }
            set { is_stop = value; }
        }
        public void DoJob()
        {
            Thread thread = new Thread(JobThread);
            thread.Start();
        }
        public void JobThread()
        {
            while (!is_stop)
            {
                int n = CorsHandler.list.Count;
                if (n > 10) CorsHandler.list.RemoveAt(0);
                Thread.Sleep(1000);
                CorsHandler.list.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            }
        }
    }
}
