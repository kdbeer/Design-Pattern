using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorRealWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create book
            Book book = new Book("Worley", "Inside ASP.NET", 10);
            book.Display();

            // Create video
            Video video = new Video("Spielberg", "Jaws", 23, 92);
            video.Display();

            // Make video borrowable, then borrow and display
            Console.WriteLine("\nMaking book borrowable:");
            BorrowAble borrowBook = new BorrowAble(book);
            book.Display();

            Console.WriteLine("\nMaking video borrowable:");
            BorrowAble borrowVideo = new BorrowAble(video);
            borrowVideo.BorrowItem("Cus #1");
            borrowVideo.BorrowItem("Cus #2");

            borrowVideo.Display();

            //wait
            Console.ReadKey();
        }
    }

    abstract class LibraryItem
    {
        private int _numCopies;

        public int NumCopies
        {
            get { return this._numCopies; }
            set { this._numCopies = value; }
        }

        public abstract void Display();
    }

    class Book : LibraryItem
    {
        private string _author;
        private string _title;

        public Book(string auther, string title, int numCopies)
        {
            _author = auther;
            _title = title;
            this.NumCopies = numCopies;
        }

        public override void Display()
        {
            Console.WriteLine("\nBook ------ ");
            Console.WriteLine(" Author: {0}", _author);
            Console.WriteLine(" Title: {0}", _title);
            Console.WriteLine(" # Copies: {0}", NumCopies);
        }
    }

    class Video : LibraryItem
    {
        private string _director;
        private string _title;
        private int _playTime;

        public Video(string director, string title, int numCopies, int playTime)
        {
            _director = director;
            _title = title;
            _playTime = playTime;
            this.NumCopies = numCopies;
        }

        public override void Display()
        {
            Console.WriteLine("\nVideo ----- ");
            Console.WriteLine(" Director: {0}", _director);
            Console.WriteLine(" Title: {0}", _title);
            Console.WriteLine(" # Copies: {0}", NumCopies);
            Console.WriteLine(" Playtime: {0}\n", _playTime);
        }
    }


    abstract class Decorator : LibraryItem
    {
        protected LibraryItem libraryItem;

        public Decorator(LibraryItem libraryItem)
        {
            this.libraryItem = libraryItem;
        }

        public override void Display()
        {
            libraryItem.Display();
        }
    }

    class BorrowAble : Decorator
    {
        protected List<string> borrowers = new List<string>();

        public BorrowAble(LibraryItem libraryItem) : base(libraryItem)
        {
        }

        public void BorrowItem(string name)
        {
            borrowers.Add(name);
            libraryItem.NumCopies--;
        }

        public void ReturnItem(string name)
        {
            borrowers.Remove(name);
            libraryItem.NumCopies++;
        }

        public override void Display()
        {
            base.Display();
            foreach (string borrower in borrowers)
                Console.WriteLine(" borrower: " + borrower);
        }
    }

}
