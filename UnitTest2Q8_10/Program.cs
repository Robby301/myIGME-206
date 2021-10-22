using System;

namespace UnitTest2Q8_10
{
    public abstract class Game
    {
        public string title;

        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                this.title = value;
            }
        }
        public abstract void Play();
        public virtual void StopPlaying()
        {
            Console.WriteLine("You have stopped playing the game.");
        }
    }
    public interface VideoGameInterface
    {
        string VideoGameConsole
        {
            get;
            set;
        }
        void View();
    }
    public interface BoardGameInterface
    {
        int NumOfPieces
        {
            get;
            set;
        }
    }

    public class RegularVideoGame : Game, VideoGameInterface
    {
        public string videoGameConsole;

        public string VideoGameConsole
        {
            get
            {
                return this.videoGameConsole;
            }
            set
            {
                this.videoGameConsole = value;
            }
        }
        public void View()
        {
            Console.WriteLine("You are viewing the game from a normal display screen");
        }
        public override void Play()
        {
            Console.WriteLine("Time to play a video game!");
        }
    }
    public class VRVideoGame : Game, VideoGameInterface
    {
        public string videoGameConsole;

        public string VideoGameConsole
        {
            get
            {
                return this.videoGameConsole;
            }
            set
            {
                this.videoGameConsole = value;
            }
        }
        public void View()
        {
            Console.WriteLine("You are viewing the game from a VR Headset display screen");
        }
        public override void Play()
        {
            Console.WriteLine("Time to play a virtual reality game!");
        }
    }
    public class BoardGame : Game, BoardGameInterface
    {
        public int numOfPieces;

        public int NumOfPieces
        {
            get
            {
                return this.numOfPieces;
            }
            set
            {
                this.numOfPieces = value;
            }
        }
        public override void Play()
        {
            Console.WriteLine("Time to play a boardgame!");
        }
    }

    class Program
    {
        static void CheckGameDisplay(object obj)
        {
            if (obj.GetType() == typeof(RegularVideoGame))
            {
                VideoGameInterface gameInterface = (VideoGameInterface)obj;
                gameInterface.View();
            }
            else if (obj.GetType() == typeof(VRVideoGame))
            {
                VideoGameInterface gameInterface = (VideoGameInterface)obj;
                gameInterface.View();
            }
        }
        static void Main(string[] args)
        {
            RegularVideoGame metroid = new RegularVideoGame();
            VRVideoGame halfLifeAlyx = new VRVideoGame();

            CheckGameDisplay(metroid);
            CheckGameDisplay(halfLifeAlyx);
        }
    }
}