using System;
using System.Collections.Generic;
using System.Resources;
using System.Xml.Schema;

namespace Custom_Battle_Royal
{
    public class Game
    {
        public List<FighterStatus> fighterReset1 = new List<FighterStatus>();
        public List<FighterStatus> fighterReset2 = new List<FighterStatus>();
        public Fighter player { get;  }
        public Fighter opponent { get; }

        public Game(Fighter player, Fighter opponent)
        {
            this.player = player;
            this.opponent = opponent;

        }

        public void writeFighter(Fighter fighter, string property)
        {
            if (fighter.name == player.name)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            switch (property)
            {
                case "name": 
                    Console.Write(fighter.name);
                    break;
                
                case "health":
                    Console.Write(fighter.health);
                    break;
            }
            
            Console.ResetColor();
        }
        public void play(Fighter player, Fighter foe, string mode)
        {
            if (foe.name == player.name)
            {
                foe.name += " the Second";
            }
            Console.Clear();
            Console.WriteLine("How long would you like the match?");

            var gameLength = new Menu();
            gameLength.options = new[]
            {
                "Short (50HP each)",
                "Medium (100HP each)",
                "Long (200HP each)",
                "Custom (Chose the HP yourself)"
            };
            
            gameLength.Render();

            switch (gameLength.getSelected())
            {
                case 0:
                    player.health = 50;
                    player.maxHealth = 50;
                    foe.maxHealth = 50;
                    foe.health = 50;
                    break;
                
                case 1:
                    player.health = 100;
                    player.maxHealth = 100;
                    foe.maxHealth = 100;
                    foe.health = 100;
                    break;
                
                case 2:
                    player.health = 200;
                    player.maxHealth = 100;
                    foe.maxHealth = 100;
                    foe.health = 200;
                    break;
                
                case 3:
                    var health = "";
                    int hp;
                    while (!int.TryParse(health, out hp))
                    {
                        Console.Clear();
                        if (health != "")
                        {
                            Console.WriteLine($"'{health}' is not a valid number");
                        }
                    Console.WriteLine("Please enter the desired health bellow (only numbers):");
                     health = Console.ReadLine();
                    }

                    player.health = Int32.Parse(health);
                    player.maxHealth = Int32.Parse(health);
                    foe.maxHealth = Int32.Parse(health);
                    foe.health = Int32.Parse(health);
                    break;
                    
            }



            fighterReset1 = new List<FighterStatus>();
            writeFighter(player, "name");
            Console.Write(" VS ");
            writeFighter(foe, "name");
            Console.WriteLine("");
            Console.WriteLine("FIGHT!");
            Console.ReadLine();
            fighterReset1.Add(new FighterStatus("Heal", 4));
            fighterReset1.Add(new FighterStatus("Rage", 0));
            fighterReset1.Add(new FighterStatus("Rage soak", 0));
            fighterReset2.Add(new FighterStatus("Heal", 4));
            fighterReset2.Add(new FighterStatus("Rage", 0));
            fighterReset2.Add(new FighterStatus("Rage soak", 0));
            player.fighterStatus = new List<FighterStatus>(fighterReset1);
            foe.fighterStatus = new List<FighterStatus>(fighterReset2);

            while (true)
            {
                if (player.health < 1)
                {
                    break;
                }

                if (foe.health < 1)
                {
                    break;
                }
                if (mode == "1P")
                {
                    Rnd(player, foe);
                    FoeAttack(foe, player);
                    Console.ReadLine();
                    continue;
                }

                Rnd(player, foe);
                if (player.health < 1)
                {
                    break;
                }

                if (foe.health < 1)
                {
                    break;
                }
                Rnd(foe, player);


            }

            if (player.health > foe.health)
            {
                writeFighter(player, "name");
                Console.Write(" wins over ");
                writeFighter(foe, "name");
                Console.Write(" with ");
                writeFighter(player, "health");
                Console.Write("HP left!");
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("CONGRATUALATIONS!");
                Console.ResetColor();
            }

            if (player.health < foe.health)
            {
                writeFighter(foe, "name");
                Console.Write(" wins over ");
                writeFighter(player, "name");
                Console.Write(" with ");
                writeFighter(foe, "health");
                Console.Write("HP left!");
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Better luck next time!");
                Console.ResetColor();
            }
            


        }

        public void FoeAttack(Fighter foe, Fighter target)
        {
            if (foe.health < 1)
            {
                return;
            }
            int attackIndex = foe.randomAttack;
            if (foe.attacks[attackIndex].effect == "Heal")
            {
                
                if (foe.health == foe.maxHealth)
                {
                    FoeAttack(foe, target);
                    return;
                }

                if (foe.findStatus(foe, "Heal").statusDuration < 1)
                {
                    FoeAttack(foe, target);
                    return;
                }

                
                foe.attacks[attackIndex].invokeAttacks( foe, target);
                return;
            }
            if (foe.findStatus(foe, "Stunned") != null)
            {
                if (foe.attacks[attackIndex].StunCheck(foe, target))
                {
                    return;
                }
            }

            if (foe.findStatus(foe, "Rage").statusDuration > 0)
            {
                var rageAttackIndex = foe.attacks.FindIndex(attackEffect => attackEffect.effect == "Rage");
                
                foe.attacks[rageAttackIndex].invokeAttacks( foe, target);
                return;
            }

            if (foe.findStatus(foe, "Prone") != null)
            {
                if (foe.findStatus(foe, "Prone").statusDuration == 1)
                {
                    writeFighter(foe, "name");
                    Console.Write("{'s starts to get back on their feet...");
                    foe.findStatus(foe, "Prone").statusDuration = 2;
                    Console.ReadLine();
                    return;
                }
                writeFighter(foe, "name");
                Console.Write(" is back up again!");
                foe.fighterStatus.Remove(foe.findStatus(foe, "Prone"));
                Console.ReadLine();
                return;
            }

            switch (attackIndex)
            {
                case 0:
                    
                    foe.attacks[0].invokeAttacks( foe,target);
                    break;
                
                case 1:
                    
                    foe.attacks[1].invokeAttacks(foe,target);
                    break;
                
                case 2:
                    
                    foe.attacks[2].invokeAttacks( foe,target);
                    break;
                
                case 3:
                    foe.attacks[3].invokeAttacks(foe,target);
                    break;
            }
        }
        
        public void Rnd(Fighter fighter, Fighter target)
        {
            Console.Clear();
            if (fighter.name == player.name)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.WriteLine($"{fighter.name}: {fighter.health}HP");
            if (target.name == player.name)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.WriteLine($"{target.name}: {target.health}HP");
            Console.ResetColor();
            Console.WriteLine();
            
            
            

            

            if (fighter.findStatus(fighter, "Rage").statusDuration > 0)
            {
                
                var rageAttackIndex = fighter.attacks.FindIndex(attackEffect => attackEffect.effect == "Rage");
                
                fighter.attacks[rageAttackIndex].invokeAttacks( fighter, target);
                Console.ReadLine();
                return;
            }
            if (fighter.findStatus(fighter, "Prone") != null)
            {
                if (fighter.findStatus(fighter, "Prone").statusDuration == 1)
                {
                    Console.WriteLine("");
                    writeFighter(fighter, "name");
                    Console.Write("'s starts to get back on their feet...");
                    fighter.findStatus(fighter, "Prone").statusDuration = 2;
                    Console.ReadLine();
                    return;
                }

                Console.WriteLine("");
                writeFighter(fighter, "name");
                Console.ResetColor();
                Console.Write(" is back up again!");
                fighter.fighterStatus.Remove(fighter.findStatus(fighter, "Prone"));
                Console.ReadLine();
                return;
            }

            Console.WriteLine("");
            Console.WriteLine("");
            Console.Write("What will ");
            writeFighter(fighter, "name");
            Console.Write(" do?");

            var selectAction = new Menu();
            Console.ReadLine();
            selectAction.options = new[]
            {
                $"{fighter.attacks[0].attack} ({fighter.attacks[0].effect})",
                $"{fighter.attacks[1].attack} ({fighter.attacks[1].effect})",
                $"{fighter.attacks[2].attack} ({fighter.attacks[2].effect})",
                $"{fighter.attacks[3].attack} ({fighter.attacks[3].effect})",
                "Do nothing",
                "Give up"
               
            };
            
            selectAction.Render();
            if (selectAction.getSelected() < 4)
            {
                if (fighter.attacks[selectAction.getSelected()].effect == "Heal")
                {
                
                    if (fighter.health == fighter.maxHealth)
                    {
                        Console.WriteLine("");
                        writeFighter(fighter, "name");
                        Console.Write("'s health is already full!");
                        Console.ReadLine();
                        Rnd(fighter, target);
                        return;
                    }

                    if (fighter.findStatus(fighter, "Heal").statusDuration < 1)
                    {
                        Console.WriteLine("You're out of Heals!");
                        Console.ReadLine();
                        Rnd(fighter, target);
                        return;
                    }

                
                    fighter.attacks[selectAction.getSelected()].invokeAttacks( fighter, target);
                    return;
                }
            }
           
            
            if (fighter.findStatus(fighter, "Stunned") != null && selectAction.getSelected() < 4)
            {
                if (fighter.attacks[selectAction.getSelected()].StunCheck(fighter, target))
                {
                    return;
                }
            }

            switch (selectAction.getSelected())
            {
                case 0:

                 
                    fighter.attacks[0].invokeAttacks(fighter, target);

                    break;
                
                case 1:
              
                    
                    fighter.attacks[1].invokeAttacks(fighter,target);
                    break;
                
                case 2:
  
                    fighter.attacks[2].invokeAttacks(fighter,target);
                    break;
                
                case 3:
       
                    fighter.attacks[3].invokeAttacks(fighter, target);
                    break;
                
                case 4:
                    Console.WriteLine("");
                    writeFighter(fighter, "name");
                    Console.Write(" chose not to attack.");
                    break;
                
                case 5:
                    Console.WriteLine("");
                    writeFighter(fighter, "name");
                    Console.Write(" surrendered!");
                    fighter.health = 0;
                    break;
                    
                
            }

            Console.ReadLine();
            Console.Clear();
       
            
            
        }


        public void gameOver(Fighter fighter, Fighter target)
        {
            Console.WriteLine("");
            writeFighter(fighter, "name");
            Console.Write(" surrendered!");
            Console.WriteLine("The winner is ");
            writeFighter(target, "name");
            Console.Write(" with");
            writeFighter(target, "health");
            Console.Write("HP remaning!");
            
        }
        
        
    }
}