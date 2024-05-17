enum Direction{
    Left, Right,
    Up, Down
}

enum GameStatus{
    Win, Lose, Idle, Full //    added full for checking if game over when board full but there's still a move to do
}

class Board{
    public Board(){
        Data = new int [4, 4];
    }
    private int [ , ] Data; 

    public int[,] getData(){
        return Data;
    }

    protected internal void setData(int[,] new_data){
        Data = new_data;
    }

    public bool Append_cell(){
        bool is_full = true;
        for (int i = 0; i < 4; i++) //checks if board is full
        {
            for (int j = 0; j < 4; j++)
            {
                if(getData()[i, j] == 0)
                    is_full = false;
            }
        }

        if(!is_full){
            bool filled = false;
            Random rnd = new Random();

            int rows;
            int cols;
            List<int> options = new List<int>(){2, 4};
            
            while(!filled){
                rows = rnd.Next(0, 4);
                cols = rnd.Next(0, 4);

                if(Data[rows, cols] == 0){
                    Data[rows, cols] = options[rnd.Next(options.Count)];
                    filled = true;
                }
            }
        }
        return is_full;
    }

    public int Move(Direction Direct){
        int no_change = -1;
        int [,] copy = new int [4,4];
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                copy[i, j] = Data[i,j];
            }
        }


        int sum = 0;
        switch(Direct){
            case Direction.Left:
                for(int col = 1; col < 4; col++){ //     going through all cells except those which are already left

                    for(int row = 0; row< 4; row++){

                        if(Data[row, col] == 0)
                            continue;
                        
                        for(int i = col - 1; i >= 0; i--){ //     when found a cell that's not empty we start moving it in the direction

                            if(Data[row, i] != 0){ //     if when moving our current cell we encountered a non empty cell...

                                if(Data[row, i] == Data[row,col]){ //     if current cell and the one which is in our way equal, we merge

                                    Data[row, i] *= 2;
                                    Data[row,col] = 0;
                                    sum += Data[row, i];
                                    continue;
                                }

                                if(i + 1 != col && Data[row, col] != 0){ //     if current cell does not equal the non empty cell, we stop right before the taken    

                                    Data[row, i + 1] = Data[row, col];
                                    Data[row, col] = 0;
                                    continue;
                                }
                                break;
                            }
                            else if(i == 0 && Data[row, i] == 0){ // if we reached the wall at the end, we stop there

                                Data[row, i] = Data[row, col];
                                Data[row, col] = 0;
                            }
                        }
                    }
                }
                break;
            
            case Direction.Right:
                for(int col = 2; col >= 0; col--){

                    for(int row = 0; row< 4; row++){

                        if(Data[row, col] == 0)
                            continue;
                        
                        for(int i = col + 1; i < 4; i++){

                            if(Data[row, i] != 0){

                                if(Data[row, i] == Data[row,col]){

                                    Data[row, i] *= 2;
                                    Data[row,col] = 0;
                                    sum += Data[row, i];
                                    continue;
                                }

                                if(i - 1 != col && Data[row, col] != 0){

                                    Data[row, i - 1] = Data[row, col];
                                    Data[row, col] = 0;
                                    continue;
                                }
                                break;
                            }
                            else if(i == 3 && Data[row, i] == 0){

                                Data[row, i] = Data[row, col];
                                Data[row, col] = 0;
                            }
                        }
                    }
                }
                break;

            case Direction.Up:
                for(int col = 0; col < 4; col++){

                    for(int row = 1; row < 4; row++){

                        if(Data[row, col] == 0)
                            continue;
                        
                        for(int i = row - 1; i >= 0; i--){

                            if(Data[i, col] != 0){

                                if(Data[i, col] == Data[row,col]){

                                    Data[i, col] *= 2;
                                    Data[row,col] = 0;
                                    sum += Data[i, col];
                                    continue;
                                }
                                if(i + 1 != row && Data[row, col] != 0){

                                    Data[i + 1, col] = Data[row, col];
                                    Data[row, col] = 0;
                                    continue;
                                }
                                break;
                            }
                            else if(i == 0 && Data[i, col] == 0){

                                Data[i, col] = Data[row, col];
                                Data[row, col] = 0;
                            }
                        }
                    }
                }
                break;

            case Direction.Down:
                for(int col = 0; col < 4; col++){

                    for(int row = 2; row >= 0; row--){

                        if(Data[row, col] == 0)
                            continue;
                        
                        for(int i = row + 1; i < 4; i++){

                            if(Data[i, col] != 0){ //   if we've reached a taken cell

                                if(Data[i, col] == Data[row,col]){ //   if they're same, we add them together

                                    Data[i, col] *= 2;
                                    Data[row,col] = 0;
                                    sum += Data[i, col];
                                    continue;
                                }
                                if(i - 1 != row && Data[row, col] != 0){

                                    Data[i - 1, col] = Data[row, col];
                                    Data[row, col] = 0;
                                    continue;
                                }
                                break;
                            }
                            else if(i == 3 && Data[i, col] == 0){

                                Data[i, col] = Data[row, col];
                                Data[row, col] = 0;
                            }
                        }
                    }
                }
                break;
        }

        for (int i = 0; i < 4; i++) //     checks if the move made any difference on board, if not, we do nothing 
        {
            for (int j = 0; j < 4; j++)
            {
                if(copy[i, j] != Data[i,j]){
                    Append_cell();
                    return sum; 
                }
            }
        }
        return no_change; //   signals that no change has happend
    }
}
