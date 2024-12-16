using System.Runtime.CompilerServices;
using static System.Net.Mime.MediaTypeNames;

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

    public interface IFileWriter
    {
        void Write();
    }

    public interface IReader
    {
        void Read();
    }

    public interface IMailer
    {
        void SendEmail();
    }

    public class FileManager : IFileWriter, IReader, IMailer
    {
        public void Read()
        {
            Console.WriteLine("File is read.");
        }

        public void SendEmail()
        {
            Console.WriteLine("File is sent via email.");
        }

        public void Write()
        {
            Console.WriteLine("New info is written in the file.");
        }
    }

    public interface IBook
    {
        void Read();
    }

    public interface IDevice
    {
        void TurnOn();
        void TurnOff();
    }

    public class ElectronicBook : IBook, IDevice
    {
        void IBook.Read()
        {
            Console.WriteLine("Presenting reading optons.");
        }

        void IDevice.TurnOff()
        {
            Console.WriteLine("Turning device off.");
        }

        void IDevice.TurnOn()
        {
            Console.WriteLine("Turning device on.");
        }
    }

    public interface IUpdater<in T>
    {
        void Update(T entity);
    }

    public class User
    {

    }

    public class Account : User
    {

    }

    public class UserService : IUpdater<User>
    {
        public void Update(User User)
        {
            Console.WriteLine("User updated.");
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

            IReader fileReader = new FileManager();
            IFileWriter fileWriter = new FileManager();
            IMailer fileMailer = new FileManager();
            fileReader.Read();
            fileWriter.Write();
            fileMailer.SendEmail();

            IDevice Device = new ElectronicBook();
            IBook Book = new ElectronicBook();
            Device.TurnOn();
            Book.Read();
            Device.TurnOff();

            var User = new User();
            var Account = new Account();
            IUpdater<Account> Updater = new UserService();
            var UserService = new UserService();
            UserService.Update(User);

            Console.ReadKey();
        }
    }
}
