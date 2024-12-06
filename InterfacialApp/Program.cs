using System.Runtime.CompilerServices;

namespace InterfacialApp
{
    public interface Ilogger
    {
        void Event(string message);
        void Error(string message);
    }

    public class Logger : Ilogger
    {
        public void Error(string message)
        {
           Console.WriteLine(message); 
        }

        public void Event(string message)
        {
            //отправка в бд
            //отправка на почту
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(message);
        }
    }

    public interface IWorker
    {
        void RunWorker();
    }

    public interface IManager
    {
        void Create();
        void Read();
        void Update();
        void Delete();
    }

    public class Manager : IManager
    {
        public void Create()
        {

        }

        public void Read()
        {

        }

        public void Update()
        {

        }

        public void Delete()
        {

        }
    }

    public interface IPenWriter
    {
        void Write(string message);
    }

    public interface IPencilWriter
    {
        void Write(string message);
    }

    public class Writer :IPenWriter, IPencilWriter
    {
        public void Write(string message)
        {
            throw new NotImplementedException();
        }
       
    }

    internal class Program
    {
        
        static Ilogger logger {  get; set; }
        static void Main()
        {
           logger = new Logger();
            var worker1 = new Worker1(logger);
            var worker2 = new Worker2(logger);
            var worker3 = new Worker3(logger);
            worker1.RunWorker();
            worker2.RunWorker();
            worker3.RunWorker();

            Writer writer = new Writer();
            (IPenWriter(writer)).Write();
        
            Console.ReadKey();
        }
    }
}
