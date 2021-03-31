using System;

namespace Custom_Battle_Royal
{
    public class Attack
    {
        public string attack { get; set; }
        public string effect { get; set; }

        public static Game Writer = Program.gameInstance; 
        
        

        // TODO rewrite the stun, dodge, guard boolenas, and set them to fighter.findStatus;
        // Run debug to see if some variabels doesn\t get set properly.
        // TODO fix Guard not absorbing damage.
  
        public void invokeAttacks(Fighter attacker, Fighter target)
        {
            
            switch (this.effect)
            {
                case "Tackle":
                    Tackle(attacker,target, attack);
                    return;
                
                case "Heal":
                    Heal(attacker, target, attack);
                    return;
                
                case "Stun":
                    Stun( attacker, target, attack);
                    return;
                
                case "Guard":
                    Guard( attacker, target, attack);
                    return;
                
                case "Trip":
                    Trip( attacker, target, attack);
                    return;
                
                case "Dodge":
                    Dodge( attacker, target, attack);
                    return;
                
                case "Rage":
                    Rage( attacker, target, attack);
                    return;
                
            }
        }
        public Attack( string attack, string effect)
        {
            this.attack = attack;
            
            this.effect = effect;

        }

        
        private void Tackle(Fighter attacker, Fighter target, string customAttack)
        {
            Console.WriteLine("");
                Writer.writeFighter(attacker, "name");
                Console.Write($" used {customAttack}!");
            
            if (target.findStatus(target, "Prone") == null)
            {
                if (attacker.die < target.die)
                {
                    Console.WriteLine("");
                    Writer.writeFighter(attacker, "name");
                    Console.Write("'s attack missed.");
          
                    return;
                }
            }
            

            if (target.findStatus(target, "Dodge") != null)
            {
                Console.WriteLine("");
                Writer.writeFighter(target, "name");
                Console.Write(" dodged the attack!");
                target.fighterStatus.Remove(target.findStatus(target, "Dodge"));
                return;
            }

            if (target.findStatus(target, "Guard") != null)
            {
                Console.WriteLine("");
                Writer.writeFighter(target, "name");
                Console.Write(" was prepared for the attack and took only 5HP Damage.");
                target.health += -5;
                target.fighterStatus.Remove(target.findStatus(target, "Guard"));
                Console.ReadLine();
                return;
            }

            if (target.findStatus(target, "Rage soak").statusDuration > 0)
            {
                target.findStatus(target, "Rage soak").statusDuration += 10;
            }

            Console.WriteLine("");
            Writer.writeFighter(target, "name");
            Console.Write(" took 10HP Damage.");
            target.health += -10;
            

        }

        private void Heal(Fighter target, Fighter attacker, string customAttack)
        {
            if (attacker.findStatus(attacker, "Dodge") != null)
            {
                target.fighterStatus.Remove(target.findStatus(target, "Dodge"));
            }
            
            if (attacker.findStatus(attacker, "Guard") != null)
            {
                attacker.fighterStatus.Remove(attacker.findStatus(target, "Guard"));
            }
            
            if (attacker.findStatus(attacker, "Dodge") != null)
            {
                attacker.fighterStatus.Remove(target.findStatus(target, "Dodge"));
            }
            Writer.writeFighter(target, "name");
            Console.Write($" used {customAttack}.");
            if (attacker.findStatus(attacker, "Prone") == null)
            {
                if (attacker.die > target.die)
                {
                    Console.WriteLine("");
                    Writer.writeFighter(attacker, "name");
                    Console.Write(" prevented the healing.");
                    target.findStatus(target, "Heal").statusDuration--;
                    Console.ReadLine();
                    return;
                }
            }
            
           

            var healthLost =  target.maxHealth - target.health;
            if (healthLost >= 30)
            {
                Console.WriteLine("");
                Writer.writeFighter(target, "name");
                Console.Write(" recovered 30HP.");
                target.health += 30;
                target.findStatus(target, "Heal").statusDuration--;
                Console.ReadLine();
                return;
            }
            Writer.writeFighter(target, "name");
            Console.Write($" recovered {healthLost}HP.");
            target.findStatus(target, "Heal").statusDuration--;
            target.health += healthLost;
            
        }

        public void Stun(Fighter attacker, Fighter target, string customAttack)
        {
            if (target.findStatus(target, "Stunned") != null)
            {
                Console.WriteLine("");
                Writer.writeFighter(target, "name");
                Console.Write("'s already stunned.");
                Console.WriteLine("");
                Writer.writeFighter(attacker, "name");
                Console.Write("'s attack had no added effect");
                return;
            }

            Console.WriteLine("");
            Writer.writeFighter(attacker, "name");
            Console.Write($" used {customAttack}.");
            if (target.findStatus(target, "Dodge") != null)
            {
                Console.WriteLine("");
                Writer.writeFighter(target, "name");
                Console.Write(" dodged the attack!");
                target.fighterStatus.Remove(target.findStatus(target, "Guard"));
                return;

            }
            
            if(target.findStatus(target, "Prone") == null)
            {
                if (attacker.die < target.die)
                {
                    Console.WriteLine("");
                    Writer.writeFighter(attacker, "name");
                    Console.Write("'s attack missed.");
                
                    return;
                }
            }
            
            if (target.findStatus(target, "Guard") != null)
            {
                target.fighterStatus.Remove(target.findStatus(target, "Guard"));
            }
            Console.WriteLine("");
            Writer.writeFighter(target, "name");
            Console.Write(" is dazed.");
            target.fighterStatus.Add(new FighterStatus("Stunned", 4));
            target.fighterStatus.Add(new FighterStatus("Is Stunned", 0));
            StunCheck( target, attacker);
            
            
        }

        public bool StunCheck(Fighter attacker, Fighter target)
        {
            
            if (target.findStatus(target, "Guard") != null)
            {
                target.fighterStatus.Remove(target.findStatus(target, "Guard"));
            }
            
            int duration = attacker.findStatus(attacker, "Stunned").statusDuration;
            if (duration == 0)
            {

                Console.WriteLine("Uh-oh...");
                Writer.writeFighter(attacker, "name");
                Console.Write(" is no longer dazed!");
                attacker.fighterStatus.Remove(attacker.findStatus(attacker, "Stunned"));
                attacker.fighterStatus.Remove(attacker.findStatus(attacker, "Is Stunned"));
                
                return false;
            }

            if (attacker.die > 2)
            {
                attacker.findStatus(attacker, "Is Stunned").statusDuration = 0;
                attacker.findStatus(attacker, "Stunned").statusDuration--;
                return false;
            }

            Console.WriteLine("");
            Writer.writeFighter(attacker, "name");
            Console.Write(" is still weary from ");
            Writer.writeFighter(target, "name");
            Console.Write("'s attack");
            attacker.findStatus(attacker, "Stunned").statusDuration--;
            attacker.findStatus(attacker, "Is Stunned").statusDuration = 1;
            return true;

        }


        private void Guard(Fighter target, Fighter attacker, string customAttack)
        {
            Console.WriteLine("");
            Writer.writeFighter(target, "name");
            Console.Write($" used {customAttack}");
            Console.WriteLine("");
            Writer.writeFighter(target, "name");
            Console.Write(" is bracing for impact.");
            target.fighterStatus.Add(new FighterStatus("Guard", 1));
            
        }

        private void Trip(Fighter attacker, Fighter target, string customAttack)
        {
            if (target.findStatus(target, "Prone") != null)
            {
                Console.WriteLine("");
                Writer.writeFighter(target, "name");
                Console.Write("'s Already prone.");
                return;
            }
            if (target.findStatus(target, "Dodge") != null)
            {
                Writer.writeFighter(target, "name");
                Console.Write(" dodged the attack!");
                target.fighterStatus.Remove(target.findStatus(target, "Guard"));
                return;
                
            }

            if (target.findStatus(target, "Rage").statusDuration > 0)
            {
                Console.WriteLine("");
                Writer.writeFighter(attacker, "name");
                Console.Write(" made ");
                Writer.writeFighter(target, "name");
                Console.Write(" stumble... for a minute...");
                Console.ReadLine();
                Console.WriteLine("... ");
                Writer.writeFighter(target, "name");
                Console.Write(" does not look happy about it...");
                target.findStatus(target, "Rage soak").statusDuration += 10;
                return;
            }
            Console.WriteLine("");
            Writer.writeFighter(attacker, "name");
            Console.Write($" used {customAttack}");
            if (target.die > 3)
            {
                Console.WriteLine("");
                Writer.writeFighter(target, "name");
                Console.Write(" evaded the attack");
                return;
            }
            if (attacker.findStatus(attacker, "Guard") != null)
            {
                attacker.fighterStatus.Remove(attacker.findStatus(target, "Guard"));
            }
            
            if (attacker.findStatus(attacker, "Dodge") != null)
            {
                attacker.fighterStatus.Remove(attacker.findStatus(target, "Dodge"));
            }

            Console.WriteLine("");
            Writer.writeFighter(target, "name");
            Console.Write(" fell to ground with a hard smash.");
            target.fighterStatus.Add(new FighterStatus("Prone", 1));
        }

        
        public void Dodge(Fighter target, Fighter attacker, string customAttack)
        {
            if (target.findStatus(attacker, "Dodge") != null)
            {
                target.fighterStatus.Remove(target.findStatus(target, "Dodge"));
            }

            Console.WriteLine("");
            Writer.writeFighter(target, "name");
            Console.Write(" is trying to predict {attacker.name}'s movement.");
            if (target.die < 4)
            {
                target.fighterStatus.Add(new FighterStatus("Dodge", 1));
              
            }
            if (attacker.findStatus(attacker, "Guard") != null)
            {
                attacker.fighterStatus.Remove(attacker.findStatus(target, "Guard"));
            }

         

        }

        public void Rage(Fighter attacker, Fighter target, string customAttack)
        {
            
            var duration = attacker.findStatus(attacker, "Rage").statusDuration;
            var rageSoak = attacker.findStatus(attacker, "Rage soak").statusDuration;
            if (duration == 2)
            {
                Console.WriteLine("");
                Writer.writeFighter(attacker, "name");
                
                Console.Write(" unleached his frenzy in a might blow!");
                attacker.findStatus(attacker, "Rage soak").statusDuration += 10;
                rageSoak = attacker.findStatus(attacker, "Rage soak").statusDuration;
                
                if (target.findStatus(target, "Dodge") != null)
                {
                    Writer.writeFighter(target, "name");
                    Console.Write(" dodged the attack!");
                    target.fighterStatus.Remove(target.findStatus(target, "Dodge"));
                    return;
                
                }
                if (target.findStatus(target, "Guard") != null)
                {
                    Console.WriteLine("");
                    Writer.writeFighter(target, "name");
                    Console.Write($" was prepared for the attack and took only {rageSoak/2}HP Damage.");
                    target.health -= (rageSoak / 2);
                    target.fighterStatus.Remove(target.findStatus(target, "Guard"));
                    return;
                }

                Console.WriteLine("");
                Writer.writeFighter(target, "name");
                Console.Write($" took {rageSoak} damage!");
                target.health -= rageSoak;
                attacker.findStatus(attacker, "Rage").statusDuration = 0;
                attacker.findStatus(attacker, "Rage soak").statusDuration = 0;
                if (target.findStatus(target, "Rage soak").statusDuration > 0)
                {
                    target.findStatus(target, "Rage soak").statusDuration += rageSoak;
                }
                return;

            }

            if (duration == 1)
            {
                if (target.findStatus(target, "Dodge") != null)
                {
                    target.fighterStatus.Remove(target.findStatus(target, "Dodge"));
                }

                Console.WriteLine("");
                Writer.writeFighter(attacker, "name");
                Console.Write("'s rage is building...");
                attacker.findStatus(attacker, "Rage soak").statusDuration += 10;
                attacker.findStatus(attacker, "Rage").statusDuration = 2;
                return;
            }
            
            if (target.findStatus(target, "Dodge") != null)
            {
                target.fighterStatus.Remove(target.findStatus(target, "Dodge"));
            }

            Console.WriteLine("");
            Writer.writeFighter(attacker, "name");
            Console.Write(" has begun gathering his rage for ");
            Writer.writeFighter(target, "name");
            attacker.findStatus(attacker, "Rage").statusDuration = 1;
            
            attacker.findStatus(attacker, "Rage soak").statusDuration = 10;
            
            
        }
    }
    
    
}