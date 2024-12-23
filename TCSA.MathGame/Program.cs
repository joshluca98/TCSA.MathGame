using System.Collections.Generic;

//Console.WriteLine("What is your name?");
//string name = Console.ReadLine();
//DateTime date = DateTime.UtcNow;
//Console.WriteLine($"Hello {name}. It's {date.DayOfWeek}. Welcome to the math game.\n");

while (true)
{
    
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
            Console.WriteLine("Goodbye");
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Invalid selection");
            break;
    }
}

void StartGame(string mathOperator)
{
    Console.WriteLine("\nEnter 'q' to return to the menu at anytime");
    Random random = new();
    while (true)
    {
        int number1;
        int number2;
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

        Console.WriteLine($"\nWhat is {number1} {mathOperator} {number2}?");
        
        string userAnswer = Console.ReadLine();
        double number;
        if (double.TryParse(userAnswer, out number)) 
        {
            if (number == actualAnswer)
            {
                Console.WriteLine("That's correct!");
            }
            else
            {
                Console.WriteLine("That's NOT correct!");
            }
        }
        else if (userAnswer.ToUpper().Trim() == "Q")
        {
            Console.WriteLine("Returning to menu...\n");
            Thread.Sleep(300);
            Console.Clear();
            break;
        }

    }
}