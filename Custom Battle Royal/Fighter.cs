using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.IO;
using System.Text.Json;

namespace Custom_Battle_Royal
{
    public class Fighter
    {
        public string name;
        public int health = 100;
        public int maxHealth = 100;
        public List<Attack> attacks = new List<Attack>();
        public List<FighterStatus> fighterStatus = new List<FighterStatus>();
        

        static Random random = new Random();
        public int die => random.Next(1, 7);
        public int randomAttack => random.Next(0, 4);

        public Fighter pvpMenus(Fighter player)
        {
            while (true)
                    {


                        Console.WriteLine($"{player.name}, Would you like to make a new fighter or try an exisiting one?");
                        var useExsistingdData = new Menu();
                        useExsistingdData.options = new[] {"Make New Fighter", "Browse exsisting Fighters"};

                        useExsistingdData.Render();


                        if (useExsistingdData.getSelected() == 0)
                        {

                            player.Create();
                            break;
                            
                        }

                          
                        var playerFighter = player.Load(player);
                        Console.Clear();
                        Console.WriteLine($"You've accepted: {player.name}!");
                        return playerFighter;

                            



                         //exit fighter selection

                    }

            return player;

        }



        
        public Fighter Load(Fighter player)
        {
            while (true)
            {
                Console.WriteLine("Please chose any of the listed fighters below:");
                var selectFighter = new Menu();
                DirectoryInfo d = new DirectoryInfo("attacks"); //Folder to search
                FileInfo[] Files = d.GetFiles("*.json"); //Getting fighters
                var FilesMenu = new List<String>();
                foreach (var fileData in Files)
                {
                    FilesMenu.Add(fileData.Name);
                }

                FilesMenu.Add("Create new Fighter!");
                selectFighter.options = FilesMenu.ToArray();

                selectFighter.Render();
                if (selectFighter.getSelected() !=
                    Array.LastIndexOf(selectFighter.options, "Create new Fighter!"))
                {
                    player.name = selectFighter.options[selectFighter.getSelected()];
                    player.name = player.name.Replace(".json", "");
                    var jsonLoad = File.ReadAllText($"attacks/{selectFighter.options[selectFighter.getSelected()]}");
                    player.attacks = JsonSerializer.Deserialize<List<Attack>>(jsonLoad);
                    Console.Clear();

                    Console.WriteLine($"Fighter {player.name}, Loaded Successfully!");
                    Console.SetCursorPosition(10, 5);
                    Console.WriteLine("Following attacks have been applied:");
                    Console.SetCursorPosition(10, 6);
                    Console.WriteLine($"{player.attacks[0].attack} ({player.attacks[0].effect})");
                    Console.SetCursorPosition(10, 7);
                    Console.WriteLine($"{player.attacks[1].attack} ({player.attacks[1].effect})");
                    Console.SetCursorPosition(10, 8);
                    Console.WriteLine($"{player.attacks[2].attack} ({player.attacks[2].effect})");
                    Console.SetCursorPosition(10, 9);
                    Console.WriteLine($"{player.attacks[3].attack} ({player.attacks[3].effect})");
                    Console.WriteLine("");
                    if (selectFighter.comfirm("you would like to use this fighter"))
                    {

                        Console.Clear();
                        Console.WriteLine($"You've accepted: {player.name}!");
                        return player;

                    }
                    player = Load(player);
                    return player;
                    
                }

                player = player.Create();
                return player;
            }
        }
        
        public FighterStatus findStatus(Fighter fighter, string statusEffect)
        {
            var EffectIndex = fighter.fighterStatus.FindIndex(status => status.statusEffect == statusEffect);
            if (EffectIndex == -1)
            {
                return null;
            }
            return fighter.fighterStatus[EffectIndex];
        }

        public Fighter LoadRandom(Menu selectFighter, Fighter fighter, Fighter opponent)
        {
            DirectoryInfo d = new DirectoryInfo("attacks"); //Folder to search
            FileInfo[] Files = d.GetFiles("*.json"); //Getting fighters
            var FilesMenu = new List<String>();
            foreach (var fileData in Files)
            {
                FilesMenu.Add(fileData.Name);
            }

            
            
            
            var randomFighter = random.Next(0, FilesMenu.Count-1);
            /*while (selectFighter.options[randomFighter] == "test.json")
            {
                randomFighter = random.Next(0, find-1);
            }*/
            fighter.name = FilesMenu[randomFighter];
            fighter.name = fighter.name.Replace(".json", "");
            
            var jsonLoad = File.ReadAllText($"attacks/{FilesMenu[randomFighter]}");
            fighter.attacks = JsonSerializer.Deserialize<List<Attack>>(jsonLoad);
            Console.Clear();

                return fighter;
            
        }
        
        public Fighter Create()
        {
            Console.WriteLine("Please type down your fighter bellow:");
            
            this.name = Console.ReadLine();
            Console.WriteLine($"Type down 4 attacks {this.name} should know. (Add one at a time):");
            List<string> attackList = new List<string>();

            for (int i = 1; i < 5; i++)
            {
                var attack = Console.ReadLine();
                attackList.Add(attack);
                Console.WriteLine($"{attack}, added!");
            }

            Console.WriteLine("Done!");

            Console.Clear();

            foreach (var attack in attackList)
            {
                while (true)
                {
                    
                
                    Console.WriteLine($"What do you want {attack} to do?:");
        
                    var attackType = new Menu();
                    attackType.options = new[]
                    {
                        "Attack (enemy -10 HP)",
                        "Heal (player +20 HP, 4 uses/match)",
                        "Stun (Target has 33% to miss his attack, 4 rounds)",
                        "Guard (Player takes 50% less from next attack)",
                        "Trip (Target has a 50% chance to lose 2 attacks.)",
                        "Dodge (Player has 33% to take 0HP damage from next attack)",
                        "Rage (Player waits 1 rnd, then combines his attacks with the damage received)"
                    };
                    
                    attackType.Render();

                    if (attackType.comfirm($"{attack} should {attackType.options[attackType.position]}?"))
                    {
                        Console.WriteLine($"{attack} set to {attackType.options[attackType.position]}");
                        string effect = "";
                        
                        switch (attackType.position)
                        {
                            case 0:
                                effect = "Tackle";
                                
                                break;
                            case 1:
                                effect = "Heal";
                                break;
                            case 2:
                                effect = "Stun";
                                break;
                            case 3:
                                effect = "Guard";
                                break;
                            case 4:
                                effect = "Trip";
                                break;
                            case 5:
                                effect = "Dodge";
                                break;
                            case 6:
                                effect = "Rage";
                                break;
                            
                        }
                        attacks.Add(new Attack(attack, effect));
                        
                        break;
                    }
                    Console.Clear();


                }

                
            }

            while (true)
            {


                Console.WriteLine("Would you like to change any attacks?");



                var attackEdit = new Menu();

                attackEdit.options = new[]
                {
                    $"Attack: {attacks[0].attack} Effect: {attacks[0].effect}",
                    $"Attack: {attacks[1].attack} Effect: {attacks[1].effect}",
                    $"Attack: {attacks[2].attack} Effect: {attacks[2].effect}",
                    $"Attack: {attacks[3].attack} Effect: {attacks[3].effect}",
                    "Save and Continue."
                };


                attackEdit.Render();

                if (attackEdit.position == 4)
                {
                    // skriv
                    var json = JsonSerializer.Serialize(attacks);
                    
                    File.WriteAllText($"attacks/{this.name}.json", json);
                    
                    break;
                }
                
               while(true)
                {
                    
                
                    Console.WriteLine($"What do you want {attacks[attackEdit.position].attack} to do?:");
        
                    var attackType = new Menu();
                    attackType.options = new[]
                    {
                        "Attack (enemy -10 HP)",
                        "Heal (player +20 HP, 4 uses/match)",
                        "Stun (Target has 33% to miss his attack, 4 rounds)",
                        "Guard (Player takes 50% less from next attack)",
                        "Trip (Target has a 50% chance to lose 2 attacks.)",
                        "Dodge (Player has 33% to take 0HP damage from next attack)",
                        "Rage (Player waits 1 rnd, then combines his attacks with the damage received)"
                    };
                    
                    attackType.Render();

                    if (attackType.comfirm($"{attacks[attackEdit.position].attack} should {attackType.options[attackType.position]}"))
                    {
                        Console.WriteLine($"{attacks[attackEdit.position].attack} set to {attackType.options[attackType.position]}");
                        string effect = "";
                        
                        switch (attackType.position)
                        {
                            case 0:
                                effect = "Tackle";
                                break;
                            case 1:
                                effect = "Heal";
                                break;
                            case 2:
                                effect = "Stun";
                                break;
                            case 3:
                                effect = "Guard";
                                break;
                            case 4:
                                effect = "Trip";
                                break;
                            case 5:
                                effect = "Dodge";
                                break;
                            case 6:
                                effect = "Rage";
                                break;
                            
                        }
                        attacks[attackEdit.position] = new Attack(attacks[attackEdit.position].attack, effect);
                        break;
                    }
                    Console.Clear();


                }  

            }

            Console.WriteLine("Fighter saved!");

            Fighter player = new Fighter();
            player.name = name;
            player.attacks = attacks;
            return player;

        }

        
        
        
        
        
        public void Attack(Fighter robot, bool cheat)
        {
            Console.WriteLine($"{this.name} attacks Wild {robot.name}.");
            if (this.die > robot.die)
            {
                robot.health = robot.health - this.die;
                Console.WriteLine($"Wild {robot.name} took {this.die} damage!");
                
                
            }
            else
            {
                Console.WriteLine($"{this.name}'s attack missed!");
            }

            if (robot.health > 0)
            {
                Console.WriteLine($"Wild {robot.name} has {robot.health}HP left.");
            }

            if (robot.health < 0 && cheat == true)
            {
                Console.WriteLine($"What's this?! {robot.name} is charging his final attack!");
            }

            if (robot.health < 0 && cheat == false)
            {
                Console.WriteLine($"Wild {robot.name} was defeated!");
            }
            
            
        }
    }
}