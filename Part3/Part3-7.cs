
using Microsoft.VisualBasic;

class NumericalExpression{
    NumericalExpression(long num){
        this.num = num;
        basic_nums = new Dictionary<int, String>(){{1, "one"}, {2, "two"}, {3, "three"}, {4, "four"}    //here you can easily change language...
        , {5, "five"}, {6, "six"}, {7, "seven"}, {8, "eight"}, {9, "nine"}, {10, "ten"}, {11, "eleven"}
        , {12, "twelve"}, {13, "thirteen"}, {14, "fourteen"}, {15, "fifteen"}, {16, "sixteen"}, {17, "seventeen"}
        , {18, "eighteen"}, {19, "nineteen"}
        , {20, "twenty"}, {30, "thirty"}, {40, "fourty"}, {50, "fifty"}, {60, "sixty"}, {70, "seventy"}, {80, "eighty"}, {90, "ninety"}, {100, "hundred"}};

        big_digits = new List<String>(){"thousand", "million", "billion"};     //if you want a bigger num than 999 billion just add it here
    }

    private long num;

    Dictionary<int, String> basic_nums;

    List<String> big_digits;

    public long GetValue(){
        return num;
    }

    public static int SumLetters(int num){
        String str;
        int sum = 0;
        NumericalExpression numer;

        for(long i = 0; i < num; i++){
            numer = new NumericalExpression(i);

            str = numer.ToString();
            str.Replace(" ", "");
            sum += str.Length;
        }
        return sum;
    }

    //method oveloading 
    public static int SumLetters(NumericalExpression numer){
        String str;
        long num = numer.num;
        int sum = 0;

        for(long i = 0; i < num; i++){
            numer = new NumericalExpression(i);

            str = numer.ToString();
            str.Replace(" ", "");
            sum += str.Length;
        }
        return sum;
    }
    public override string ToString(){
        if(num == 0)
            return "zero";
        

        String num_str = num.ToString();
        String final_str = "";
        int counter;
        IEnumerable<String> trios = SplitInParts(num_str);
        int add_big_digit = trios.Count() - 2; 

        foreach(string trio in trios){

            if(trio == "000"){     //skips 0's
                add_big_digit--;
                continue;
            }

            for (int index = 0; index < trio.Length; index++)
            {

                counter = index % 3;

                if(trio.Length == 2)    //if double digits only
                    counter += 1;   //skip hundred

                if(trio.Length == 1)    //if it's a single digit
                    counter += 2;   //go straight to third 'if'

                int digit = Int32.Parse(trio[index].ToString());

                if(counter == 0){   //first digit of the trio represents the hundreds

                    if(digit != 0){     // we skip 0's
                        final_str += basic_nums[digit] + " " + basic_nums[100];
                    }
                    continue;
                }

                else if(counter == 1){  //second digit of the trio

                    if(digit != 0){
                        
                        if(final_str.Length > 0 && final_str[final_str.Length - 1] != ' ')
                            final_str += " ";
                        
                        if(digit == 1){     //if the second dig is 1 like the trio: 512, I would get the next digit and add it to the str

                            final_str += basic_nums[digit * 10 + Int32.Parse(trio[index + 1].ToString())];
                            index++;    //we skip the next digit cause its just been addea
                            continue;
                        }

                        final_str += basic_nums[digit * 10]; 
                    }
                }
                else if(counter == 2){     //third and last digit of the trio which is singles

                    if(digit != 0){

                        if(final_str.Length > 0 && final_str[final_str.Length - 1] != ' ')
                            final_str += " ";

                        final_str += basic_nums[digit]; 
                    }
                }
            }
            if(add_big_digit >= 0)
                final_str += " " + big_digits[add_big_digit] + " ";

            add_big_digit--;
        }

        return final_str;
    }


    public static IEnumerable<String> SplitInParts(String s) {
        if (s == null)
            throw new ArgumentNullException(nameof(s));

        int correction = s.Length % 3;
        if(correction > 0){
            yield return s.Substring(0, correction);
            s = s.Substring(correction, s.Length - correction);
        }
           
        for (var i = 0; i < s.Length; i += 3)
            yield return s.Substring(i, Math.Min(3, s.Length - i));
           
    }

    static void Main(String[] args)
    {
        NumericalExpression numer = new NumericalExpression(999999999999);
        Console.WriteLine(numer.ToString());
        Console.WriteLine(SumLetters(4));
    }
}