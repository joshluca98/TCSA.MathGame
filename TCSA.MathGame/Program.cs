using System.Collections.Generic;

DateTime date = DateTime.UtcNow;
string? name = GetName();
int highScore = 0;

string GetName()
{
    Console.WriteLine("What is your name?");
    string name = Console.ReadLine();
    return name;
}
void menu(string name)
{
    while (true)
    {
        Console.Clear();
        Console.WriteLine($"Previous High Score: {highScore}");
        Console.WriteLine($"Hello {name}. It's {date.DayOfWeek}. Welcome to the math game.\n");
        Console.WriteLine($@"Choose a game:
    A - Addition
    S - Subtraction
    M - Multiplication
    D - Division
    Q - Quit the program");

        string gameSelected = Console.ReadLine().ToUpper().Trim();

        switch (gameSelected)
        {
            case "A":
                Console.WriteLine("Addition game selected");
                StartGame("+");
                break;
            case "S":
                Console.WriteLine("Subtraction game selected");
                StartGame("-");
                break;
            case "M":
                Console.WriteLine("Multiplication game selected");
                StartGame("*");
                break;
            case "D":
                Console.WriteLine("Division game selected");
                StartGame("/");
                break;
            case "Q":
                Console.WriteLine("\nGoodbye!");
                Environment.Exit(0);
                break;
            default:
                Console.Clear();
                Console.WriteLine("Invalid selection!\n");
                break;
        }
    }
}
void StartGame(string mathOperator)
{

    int score = 0;
    int count = 0;

    Console.WriteLine("\nEnter 'q' to return to the menu at anytime");
    Random random = new();
    while (count < 5)
    {
        
        int number1, number2;
        if (mathOperator == "-")
        {
            number1 = random.Next(1, 20);
            number2 = random.Next(1, number1);
        }
        else if (mathOperator == "/")
        {
            number2 = random.Next(1, 20);
            number1 = number2 * random.Next(1, 8);
        }
        else
        {
            number1 = random.Next(1, 20);
            number2 = random.Next(1, 20);
        }
        
        int actualAnswer = 0;
        switch (mathOperator)
        {
            case "+":
                actualAnswer = number1 + number2;
                break;
            case "_":
                actualAnswer = number1 - number2;
                break;
            case "*":
                actualAnswer = number1 * number2;
                break;
            case "/":
                actualAnswer = number1 / number2;
                break;
        }

        Console.WriteLine($"What is {number1} {mathOperator} {number2}?");
        
        string userAnswer = Console.ReadLine();
        double number;
        if (double.TryParse(userAnswer, out number)) 
        {
            if (number == actualAnswer)
            {
                Console.WriteLine("That's correct!\n");
                score++;
                count++;
            }
            else
            {
                count++;
                Console.WriteLine("That's NOT correct!\n");
            }
        }
        else if (userAnswer.ToUpper().Trim() == "Q")
        {
            Console.WriteLine("Returning to menu...\n");
            Thread.Sleep(300);
            Console.Clear();
            break;
        }
        else
        {
            Console.WriteLine("Invalid entry, you lose a turn..\n");
            count++;
        }

    }
    if (score > highScore) 
    { 
        highScore = score;
    }
    Console.WriteLine($"Your score was {score}!\n");
    Console.WriteLine("Press ENTER to return to the menu..");
    Console.ReadLine();
}

menu(name);