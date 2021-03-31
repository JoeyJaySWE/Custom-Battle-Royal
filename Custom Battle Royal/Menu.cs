using System;
using System.Runtime.CompilerServices;
using System.Web;
using Microsoft.VisualBasic.CompilerServices;

namespace Custom_Battle_Royal
{
    public class Menu
    {
 
        public string[] options;
        ConsoleKeyInfo input = Console.ReadKey(false);
        
            public int position;
            public int carretY = Console.GetCursorPosition().Top+5;
            private int prev = -1;
            


      
            
            

            public void SelectUp()
            {
                position--;
                if (position < 0)
                {
                    position = this.options.Length-1;
                }
                Render();
            }

            public void SelectDown()
            {
                position++;
                if (position > (this.options.Length-1))
                {
                    position = 0;
                }
                
                Render();
            }

            public void Render()
            {
                if (prev > -1)
                {
                    Console.SetCursorPosition(8, carretY + prev);
                    Console.Write(" ");
                }

                for (int i = 0; i < this.options.Length; i++)
                {
                    Console.CursorVisible = false;
                    
                    Console.SetCursorPosition(10, carretY+i);
                    Console.WriteLine(this.options[i]);
                }
            
                Console.SetCursorPosition(8, carretY + position);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("> ");
                Console.ResetColor();

                prev = position;
                
                
                
                while (input.Key != ConsoleKey.Enter)
                {
                    // listen to key presses
                    if (Console.KeyAvailable)
                    {
                        input = Console.ReadKey(true);

                        switch  (input.Key)
                        {
                            // send key presses to the game if it's not paused
                            case ConsoleKey.UpArrow:
                                this.SelectUp();
                                break;
                            case ConsoleKey.DownArrow:
                                this.SelectDown();
                                break;
                            case ConsoleKey.Enter:
                                Console.WriteLine();
                                Console.Clear();
                                
                                Console.WriteLine("you selected: " + this.options[position]);
                                Console.CursorVisible = true;
                                break;
                            
            
                        }
                        



                    }
                  
               


                }

               

            }

            public bool comfirm(string condition)
            {
                Console.WriteLine($"Are you sure that {condition}?");
                var comfirmation = new Menu();
                comfirmation.options = new[] {"Yes", "No"};
                
                
                    comfirmation.Render();

                if (comfirmation.getSelected() == 0)
                {
                    return true;
                }

                return false;
            }
           public int getSelected()
           {
               
                return this.position;
            }

    }
}