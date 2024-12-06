using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacialApp
{
    public class Worker1: IWorker
    {
        Ilogger Logger {get;}
        public Worker1 (Ilogger logger)
        {
            Logger = logger;
        }

        public void RunWorker()
        {
            Logger.Event("Worker 1 event has occured");
            Thread.Sleep(3000);
            Logger.Event("Worker 1 event has ended");
        }
       
    }

    public class Worker2 : IWorker
    {
        Ilogger Logger { get; }
        public Worker2(Ilogger logger)
        {
            Logger = logger;
        }

        public void RunWorker()
        {
            Logger.Event("Worker 2 event has occured");
            Thread.Sleep(3000);
            Logger.Event("Worker 2 event has ended");
        }
    }

    public class Worker3 : IWorker
    {
        Ilogger Logger { get; }
        public Worker3(Ilogger logger)
        {
            Logger = logger;
        }

        public void RunWorker()
        {
            Logger.Event("Worker 3 event has occured");
            Thread.Sleep(3000);
            Logger.Event("Worker 3 event has ended");
        }
    }


}
