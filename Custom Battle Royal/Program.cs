using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace Custom_Battle_Royal
{
    class Program
    {
        public static Game gameInstance { get; set; }
        static void Main(string[] args)
        {

            string fighter = "";


            List<Fighter> list = new List<Fighter>();

            Console.WriteLine("");
            Console.WriteLine("Welcome to text based Battle Royal!");
            Console.WriteLine("");
            Console.WriteLine("Please select game mode using the arrow keys. (Select with enter):");


            // adds the main menue for game mode
            var mode = new Menu();
            mode.options = new[] {"Solo VS AI", "Player VS Player"};


            mode.Render();



            if (mode.getSelected() == 0)
            {
                Console.Clear();
                Console.WriteLine("You selected 'Solo VS AI'");
                var player = new Fighter();
                var foe = new Fighter();
                

                Console.WriteLine("Would you like to make a new fighter or try an exisiting one?");
                var useExsistingdData = new Menu();
                useExsistingdData.options = new[] {"Make New Fighter", "Browse exsisting Fighters"};

                useExsistingdData.Render();


                if (useExsistingdData.getSelected() == 0)
                { 
                    player = player.Create();
                    

                }

                if (useExsistingdData.getSelected() == 1)
                { 
                    player= player.Load(player);
                 
                }
                
                // AI opponent mode
                Console.WriteLine("Would you like to have a random AI selected, or choose your own?");

                var aiType = new Menu();
                aiType.options = new[]
                {
                    "Generate Random AI",
                    "Let me pick AI manualy"
                };
                aiType.Render();

                if (aiType.getSelected() == 0)
                {
                    foe = foe.LoadRandom(aiType, foe, player);
                }

                if (aiType.getSelected() == 1)
                {
                    foe = foe.Load(foe);
                }



                // Launch the game Player VS AI
                var match = new Game(player, foe);
                gameInstance = match;
                match.play(player, foe, "1P");

            
                while (true)
                {
                    var rematch = new Menu();
                    rematch.options = new[] {"Rematch", "Quit"};

                    Console.WriteLine("Would you like a rematch?");

                    rematch.Render();

                    if (rematch.getSelected() == 1)
                    {
                        break;
                    }
                    
                    player.fighterStatus = null;
                    foe.fighterStatus = null;
                    match.play(player, foe, "1P");
                    
                }
                

            } // closes "Selected AI"

            if (mode.getSelected() == 1)
            {
                Console.Clear();
                Console.WriteLine("You selected 'Player VS Player'");
                Console.WriteLine();
                var player1 = new Fighter();
                player1.name = "player1";
                player1 = player1.pvpMenus(player1);
                var player2 = new Fighter();
                player2.name = "player2";
                player2 = player2.pvpMenus(player2);


                var match = new Game(player1, player2);
                gameInstance = match;
                match.play(player1, player2, "2P");

                while (true)
                {
                    var rematch = new Menu();
                    rematch.options = new[] {"Rematch", "Quit"};

                    Console.WriteLine("Would you like a rematch?");

                    rematch.Render();

                    if (rematch.getSelected() == 1)
                    {
                        break;
                    }
                    
                    player1.fighterStatus = null;
                    player2.fighterStatus = null;
                    match.play(player1, player2, "2P");
                    
                }

                


            }

        }

    }

}   