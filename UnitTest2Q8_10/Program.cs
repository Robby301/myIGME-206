using System;

namespace UnitTest2Q8_10
{
    // Class: Game
    // Author: Robert Gregory Disbrow
    // Purpose: The game class is abstract, and is the parent class of a few of the other classes in the program. It includes a variable, a property, an abstract
    //          method and a virtual method.
    // Restrictions: None
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
    // Interface: VideoGameInterface
    // Author: Robert Gregory Disbrow
    // Purpose: This interface sets up the template for classes that can be categorized as video games (which will be seen later in the program)
    //          The interface includes a property and a void method.
    // Restrictions: None
    public interface VideoGameInterface
    {
        string VideoGameConsole
        {
            get;
            set;
        }
        void View();
    }
    // Interface: BoardGameInterface
    // Author: Robert Gregory Disbrow
    // Purpose: This interface sets up the template for classes that can be categorized as board games (which will be seen later in the program)
    //          The interface includes one property.
    // Restrictions: None
    public interface BoardGameInterface
    {
        int NumOfPieces
        {
            get;
            set;
        }
    }

    // Class: RegularVideoGame
    // Author: Robert Gregory Disbrow
    // Purpose: The RegularVideoGame class is the child of the Game class and implements the VideoGameInterface interface
    //          The view and play methods both have a Console.WriteLine output that helps later in the program to test for polymorphism
    // Restrictions: None
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
    // Class: VRVideoGame
    // Author: Robert Gregory Disbrow
    // Purpose: The VRVideoGame class is the child of the Game class and implements the VideoGameInterface interface
    //          The view and play methods both have a Console.WriteLine output that helps later in the program to test for polymorphism
    // Restrictions: None
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
    // Class: BoardGame
    // Author: Robert Gregory Disbrow
    // Purpose: The BoardGame class is the child of the Game class and implements the BoardGameInterface interface
    // Restrictions: None
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

    // Class: Program
    // Author: Robert Gregory Disbrow
    // Purpose: The program class is where the program will be tested for polymorphism
    // Restrictions: None
    class Program
    {
        // Method: CheckGameDisplay
        // Purpose: This method handles checking to see if the program has polymorphism
        // Restrictions: None
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
        // Method: Main
        // Purpose: The main is used to test the polymorphism of the program
        // Restrictions: None
        static void Main(string[] args)
        {
            RegularVideoGame metroid = new RegularVideoGame();
            VRVideoGame halfLifeAlyx = new VRVideoGame();

            CheckGameDisplay(metroid);
            CheckGameDisplay(halfLifeAlyx);
        }
    }
}