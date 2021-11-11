using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Web;

namespace PE22
{
    class Trivia
    {
        public int response_code;
        public List<TriviaResult> results;
    }

    class TriviaResult
    {
        public string category;
        public string type;
        public string difficulty;
        public string question;
        public string correct_answer;
        public List<string> incorrect_answers;
    }

    class Program
    {
        public static bool TriviaQuestion()
        {
            string url = null;
            string s = null;
            string answer = null;

            Random rand = new Random();
            int randomNum = rand.Next(0, 4);
            string[] choices = new string[4];
            int choiceNum = 0;

            HttpWebRequest request;
            HttpWebResponse response;
            StreamReader reader;

            url = "https://opentdb.com/api.php?amount=1";

            request = (HttpWebRequest)WebRequest.Create(url);
            response = (HttpWebResponse)request.GetResponse();
            reader = new StreamReader(response.GetResponseStream());
            s = reader.ReadToEnd();
            reader.Close();

            Trivia trivia = JsonConvert.DeserializeObject<Trivia>(s);

            trivia.results[0].question = HttpUtility.HtmlDecode(trivia.results[0].question);
            trivia.results[0].correct_answer = HttpUtility.HtmlDecode(trivia.results[0].correct_answer);
            for (int i = 0; i < trivia.results[0].incorrect_answers.Count; ++i)
            {
                trivia.results[0].incorrect_answers[i] = HttpUtility.HtmlDecode(trivia.results[0].incorrect_answers[i]);
            }

            choices[randomNum] = trivia.results[0].correct_answer;
            for (int i = 0; i < 4; i++)
            {
                if (i == randomNum)
                {
                    continue;
                }
                else
                {
                    choices[i] = trivia.results[0].incorrect_answers[choiceNum];
                    choiceNum++;
                }
            }

            Console.WriteLine(trivia.results[0].question);
            for(int i = 0; i < 4; i++)
            {
                Console.WriteLine(choices[i]);
            }

            answer = Console.ReadLine();

            if(answer.Equals(trivia.results[0].correct_answer))
            {
                Console.WriteLine("You got it correct!");
                return true;
            }
            else
            {
                Console.WriteLine("You got it wrong!");
                return false;
            }
        }

        // neighboring points can be determined by if (maxtrixGraph[x, y].Item1 == x)
        // relative direction is Item1 in the tuple
        // cost is Item2 in the tuple
        static (string, int)[,] matrinullGraph = new (string, int)[,]
        {
                 //    A           B           C           D           E           F           G           H
          /*A*/  {("NE", 0),  ("S", 2),   (null, -1), (null, -1), (null, -1), (null, -1), (null, -1), (null, -1)},
          /*B*/  {(null, -1), (null, -1), ("S", 2),   ("E", 3),   (null, -1), (null, -1), (null, -1), (null, -1)},
          /*C*/  {(null, -1), ("N", 2),   (null, -1), (null, -1), (null, -1), (null, -1), (null, -1), ("S", 20)},
          /*D*/  {(null, -1), ("W", 3),   ("S", 5),   (null, -1), ("N", 2),   ("E", 4),   (null, -1), (null, -1)},
          /*E*/  {(null, -1), (null, -1), (null, -1), (null, -1), (null, -1), ("S", 3),   (null, -1), (null, -1)},
          /*F*/  {(null, -1), (null, -1), (null, -1), (null, -1), (null, -1), (null, -1), ("E", 1),   (null, -1)},
          /*G*/  {(null, -1), (null, -1), (null, -1), (null, -1), ("N", 0),   (null, -1), (null, -1), ("S", 2)},
          /*H*/  {(null, -1), (null, -1), (null, -1), (null, -1), (null, -1), (null, -1), (null, -1), (null, -1)}
        };

        //Item1 is the index of the neighbor, Item2 is the direction and Item3 is the cost
        /*
        * 0 = A 
        * 1 = B 
        * 2 = C 
        * 3 = D 
        * 4 = E 
        * 5 = F 
        * 6 = G 
        * 7 = H
        */
        static (int, string, int)[][] listGraph = new (int, string, int)[][]
        {
            new (int, string, int)[] {(0, "N", 0), (0, "E", 0), (1, "S", 2)},
            new (int, string, int)[] {(2, "S", 2), (3, "E", 3)},
            new (int, string, int)[] {(1, "N", 2), (7, "S", 20)},
            new (int, string, int)[] {(1, "W", 3), (2, "S", 5), (4, "N", 2), (5, "E", 4)},
            new (int, string, int)[] {(5, "S", 3)},
            new (int, string, int)[] {(6, "E", 1)},
            new (int, string, int)[] {(4, "N", 0), (7, "S", 2)},
            null
        };

        static void Main(string[] args)
        {
            int startRoom = 0;
            int currentRoom = startRoom;
            int playerHealth = 1;

            Random rand = new Random();

            string[] roomDescription =
            {
                /*A*/ "You are in a red room.",
                /*B*/ "You are in an orange room.",
                /*C*/ "You are in a yellow room.",
                /*D*/ "You are in a green room.",
                /*E*/ "You are in a blue room.",
                /*F*/ "You are in a indigo room.",
                /*G*/ "You are in a velvet room."
            };
            string[] damageCause =
            {
                "You were attacked by a bat!",
                "You tripped over a rock!",
                "You were hit with an arrow from a wall trap!",
                "A spider bit you!",
                "You hit your head on a low hanging doorframe due to the darkness!",
                "You slipped on a banana peel!",
                "You were attacked by a snake!",
                "You tripped onto a piece of wood and got a splinter!"
            };

            do
            {
                bool noDoor = true;
                bool triviaAnswer;
                int wagerAmount;
                string leaveOrWager;
                string doorPicked;

                if(currentRoom != startRoom)
                {
                    if (playerHealth > 1)
                    {
                        int randomDamage = rand.Next(1, playerHealth);
                        int randomDamageCause = rand.Next(0, 8);

                        Console.WriteLine(damageCause[randomDamageCause] + "\nYou lost " + randomDamage + " health.");

                        playerHealth -= randomDamage;
                    }
                }

                start:

                //Console.WriteLine();
                Console.WriteLine(roomDescription[currentRoom]);
                for(int i = 0; i < listGraph[currentRoom].Length; i++)
                {
                    if(playerHealth > listGraph[currentRoom][i].Item3)
                    {
                        Console.WriteLine("There is a door you can enter at the " + listGraph[currentRoom][i].Item2 + " location.");
                        noDoor = false;
                    }
                }
                if (noDoor)
                {
                    Console.WriteLine("There are currently no doors you will survive exiting out of. You will need to wager your health.");
                    Console.WriteLine("Current Health: " + playerHealth);
                    Console.WriteLine("How much health will you wager?");
                    wagerAmount = Int32.Parse(Console.ReadLine());

                    triviaAnswer = TriviaQuestion();

                    if (triviaAnswer)
                    {
                        playerHealth += wagerAmount;
                        goto start;
                    }
                    else
                    {
                        playerHealth -= wagerAmount;

                        if (playerHealth == 0)
                        {
                            break;
                        }
                    }
                }

                askAgain:

                Console.WriteLine("Current Health: " + playerHealth);
                Console.WriteLine("Would you like to leave through a door (type leave) or would you like to wager your health (type wager)?");
                leaveOrWager = Console.ReadLine();

                if(leaveOrWager.Equals("leave"))
                {
                    Console.WriteLine("Type the single letter direction of the door you'd like to enter (N, E, S, W)");
                    doorPicked = Console.ReadLine();

                    for(int i = 0; i < listGraph[currentRoom].Length; i++)
                    {
                        if(doorPicked.Equals(listGraph[currentRoom][i].Item2))
                        {
                            Console.WriteLine("You have gone through the " + listGraph[currentRoom][i].Item2 + " door.");
                            playerHealth -= listGraph[currentRoom][i].Item3;
                            currentRoom = listGraph[currentRoom][i].Item1;
                            Console.WriteLine();
                            break;
                        }
                    }

                    continue;
                }
                else if(leaveOrWager.Equals("wager"))
                {
                    Console.WriteLine("How much health will you wager?");
                    wagerAmount = Int32.Parse(Console.ReadLine());

                    triviaAnswer = TriviaQuestion();

                    if (triviaAnswer)
                    {
                        playerHealth += wagerAmount;
                        goto start;
                    }
                    else
                    {
                        playerHealth -= wagerAmount;

                        if (playerHealth == 0)
                        {
                            break;
                        }

                        goto start;
                    }
                }
                else
                {
                    goto askAgain;
                }
            } while (currentRoom != 7);

            if (playerHealth == 0)
            {
                Console.WriteLine("GAME OVER: You have died");
            }
            else if(currentRoom == 7)
            {
                Console.WriteLine("CONGRATULATIONS, YOU HAVE ESCAPED!");
            }
        }
    }
}