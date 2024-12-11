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

    public interface IWriter
    {
        void Write();
    }    

    public class Writer :IWriter
    {
        public void Write()
        {
            Console.WriteLine("Written."); 
        }
       
    }

    public interface IBuilder
    {
        void Build();
    }

    public class Builder: IBuilder
    {
        public void Build()
        {
            Console.WriteLine("Builder built a building.");
        }
    }

    public interface IFile
    {
        void ReadFile();
    }

    public interface IBinarryFile
    {
        void ReadFile();
        void OpenBinarryFile();
    }

    public class FileReader : IFile, IBinarryFile
    {
        public void OpenBinarryFile()
        {
            Console.WriteLine("Binarry file has opened.");
        }

        void IFile.ReadFile()
        {
            Console.WriteLine("Commencing ordinary file reading.");
        }

        void IBinarryFile.ReadFile()
        {
            Console.WriteLine("Commencing binarry file reading.");
        }

        public void Search(string text)
        { 
            Console.WriteLine(text);
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
            ((IWriter)writer).Write();

            Builder builder = new Builder();
            ((IBuilder)builder).Build();

            IBinarryFile BiFile = new FileReader();
            IFile OrdFile = new FileReader();
            FileReader fileInfo = new FileReader();
            OrdFile.ReadFile();
            BiFile.OpenBinarryFile();
            BiFile.ReadFile();
            fileInfo.Search("Search line.");
            

            Console.ReadKey();
        }
    }
}
