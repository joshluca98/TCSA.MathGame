﻿namespace TCSA.MathGame;

internal class GameEngine
{
    internal int highScore = 0;
    List<string> games = new();

    internal void StartGame(string mathOperator)
    {

        int score = 0;
        int count = 0;
        string gameType = "";

        Random random = new();
        while (count < 5)
        {

            int number1 = 3;
            int number2 = 2;
            if (mathOperator == "-")
            {
                gameType = "Subtraction";
                number1 = random.Next(1, 20);
                number2 = random.Next(1, number1);
            }
            else if (mathOperator == "/")
            {
                gameType = "Division";
                //number2 = random.Next(1, 11);
                //number1 = number2 * random.Next(1, 11);
                while (number1 % number2 != 0)
                {
                    number1 = random.Next(1, 99);
                    number2 = random.Next(2, 99);
                }
            }
            else if (mathOperator == "*")
            {
                gameType = "Multiplication";
                number1 = random.Next(1, 20);
                number2 = random.Next(1, 20);
            }
            else
            {
                gameType = "Addition";
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

            Console.Clear();
            Console.WriteLine("\nEnter 'q' to quit the game");
            Console.WriteLine($"\nWhat is {number1} {mathOperator} {number2}?");

            string userAnswer = Console.ReadLine();
            double number;
            if (double.TryParse(userAnswer, out number))
            {
                if (number == actualAnswer)
                {
                    score++;
                    count++;
                    Console.WriteLine("That's correct! Hit ENTER for next question..");
                    Console.ReadLine();
                }
                else
                {
                    count++;
                    Console.WriteLine("That's incorrect! Hit ENTER for next question..");
                    Console.ReadLine();

                }
            }
            else if (userAnswer.ToUpper().Trim() == "Q")
            {
                Console.WriteLine("Quitting...\n");
                Thread.Sleep(250);
                Console.Clear();
                break;
            }
            else
            {
                Console.WriteLine("INVALID ENTRY -> You lose a turn!\n");
                Thread.Sleep(1000);
                count++;
            }
        }
        LogScore(score, gameType);
        Console.Clear();
        Console.WriteLine($"Your final score is {score}!\n");
        Console.WriteLine("Press ENTER to return to the menu..");
        Console.ReadLine();
    }
    private void LogScore(int score, string gameType)
    {
        if (score > highScore)
        {
            highScore = score;
        }
        games.Add($"{DateTime.Now} | {gameType} Game | Score: {score}");
    }

    internal void ViewScores()
    {
        if (games.Count == 0)
        {
            Console.WriteLine("\nNo previous scores were found.");
        }
        else
        {
            foreach (var game in games)
            {

                Console.WriteLine(game);
            }
        }
        Console.WriteLine("\nPress ENTER to return to the menu..");
    }
}