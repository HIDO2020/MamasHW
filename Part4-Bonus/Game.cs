
class Game : Board{
    public Game(){
        b = new Board();
        status = GameStatus.Idle;
        Points = 0;
    }
    Board b;
    GameStatus status;
    int Points;

    public int getPoints(){
        return Points;
    }

    public void set_Data(Board bo){
        b = bo;
    }

    public GameStatus GetStatus(){
        return status;
    }
    public new void Append_cell(){
        b.Append_cell();
    }

    protected void setPoints(int newP){
        Points = newP;
    }

    public new void Move(Direction dirct){
        int added_points = 0;
        if(status == GameStatus.Lose){
            Console.WriteLine("Game over! You lost...");
            return;
        }
        else if(status == GameStatus.Win){
            Console.WriteLine("Game over! You win!!");
            return;
        }

        added_points += b.Move(dirct);

        if(added_points == -1) //   if signals that no change occoured, we skip the next process 
            return;

        Points += added_points;

        status = check_status(b);
    }

    public GameStatus check_status(Board b){
        Board copy = new Board(); //make deep copy of b
        int[, ] cell_list = new int [4, 4];

        bool check_move = true;
        int count = 0;

        for (int i = 0; i < 4; i++) //     got through board
        {
            for (int j = 0; j < 4; j++)
            {
                if(b.getData()[i, j] == 2048){
                    status = GameStatus.Win;
                    return status;
                }

                if(b.getData()[i, j] != 0) //     to check if the board is full
                    count++;
                
                cell_list[i, j] = b.getData()[i, j]; //     deep copy for further checks
            }
        }
        copy.setData(cell_list);

        if(count == 16){
            check_move = can_move(copy);
        
            if(!check_move)
                status = GameStatus.Lose;
            else    
                status = GameStatus.Full;
        } //    which means all cells are taken
        return status;
    }

    public bool can_move(Board copy1){
        int points = 0;
        List<Direction> directions = new List<Direction>(){Direction.Down, Direction.Up
            ,Direction.Left ,Direction.Right};

        foreach(Direction dir in directions){ //     checks every direction to make sure there are still possible moves when board is full
            points += copy1.Move(dir);
        }
        
        if(points > 0)
            return true;
        return false;
    }

    public void Print2DArray()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                Console.Write(b.getData()[i,j] + "\t");
            }
            Console.WriteLine();
        }
    }

}
