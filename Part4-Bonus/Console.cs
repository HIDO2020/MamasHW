
class ConsoleGame{

    static void Main(string[] args){
        Game g = new Game();
        Board b = new Board();
        
        g.Append_cell(); //     added two cells for beginning
        g.Append_cell();

        Console.WriteLine("Here is your board: ");

        g.Print2DArray();
        Console.WriteLine("Use your arrows to move... Begin!");

        while(g.GetStatus() == GameStatus.Idle || g.GetStatus() == GameStatus.Full){
            Console.WriteLine("Enter a key ");
            switch(Console.ReadKey().Key){
                case ConsoleKey.UpArrow:
                    g.Move(Direction.Up);
                    break;
                
                case ConsoleKey.DownArrow:
                    g.Move(Direction.Down);
                    break;

                case ConsoleKey.LeftArrow:
                    g.Move(Direction.Left);
                    break;

                case ConsoleKey.RightArrow:
                    g.Move(Direction.Right);
                    break;

                default:
                    Console.WriteLine("invalid key!");
                    break;
            }
            Console.WriteLine("Your points: " + g.getPoints());
            g.Print2DArray();
        }
        
        if(g.GetStatus() == GameStatus.Lose){
            Console.WriteLine("Game over! You lost...");
            return;
        }
        else if(g.GetStatus() == GameStatus.Win){
            Console.WriteLine("Game over! You win!!");
            return;
        }
    }
}
