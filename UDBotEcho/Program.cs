using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDGroup
{

    public class UDBot 
    {
        private int input_text_size { get; set; }

        private int[] SearchNumber(string number_text_input, int index_input = 0)
        {
            string number_text = null;
            int index = 0;

            for (int i = index_input; i < number_text_input.Length; i++)
            {
                if (int.TryParse(number_text_input[i].ToString(), out int number))
                {
                    number_text += number_text_input[i];
                }
                else
                {
                    index = i;
                    break;
                }
            }

            if (number_text != null)
            {
                return new int[] { Convert.ToInt32(number_text), index };
            }
            else
            {
                return new int[] { -1, -1 };
            }
        }

        public void SearchAnswer(string text_input, int index_input = 0)
        {
            int[] array_of_values = new int[2];
            bool point = false;
            int index_type = 0;
            bool lenght_check = true;
            for (int i = 0; i < text_input.Length; i++)
            {
                if (point)
                {
                    if (SearchNumber(text_input, index_input)[0] != -1)
                    {
                        if (lenght_check)
                        {
                            array_of_values[1] = SearchNumber(text_input, i)[0];
                            i += SearchNumber(text_input, index_input)[1];
                            point = true;
                            input_text_size += i - input_text_size;
                            lenght_check = false;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        array_of_values = null;
                        Console.WriteLine($"reply: you sent '{text_input}'");
                        break;
                    }
                }
                else
                {
                    if (SearchNumber(text_input, index_input)[0] != -1)
                    {
                        array_of_values[0] = SearchNumber(text_input, index_input)[0];
                        i = SearchNumber(text_input, index_input)[1];
                        point = true;
                        index_type = i;
                        input_text_size += i;
                    }
                    else
                    {
                        array_of_values = null;
                        Console.WriteLine($"reply: you sent '{text_input}'");
                        break;
                    }
                }
            }

            if (text_input.Length <= input_text_size)
            {
                switch (text_input[index_type])
                {
                    case '+':
                        Console.WriteLine($"reply: Первое число -> {array_of_values[0]} \n" +
                        $"reply: Второе число -> {array_of_values[1]} \n" +
                        $"reply: Арифметический оператор -> + \n" +
                        $"reply: Результат = {array_of_values[0] + array_of_values[1]}");

                        break;
                    case '-':
                        Console.WriteLine($"reply: Первое число -> {array_of_values[0]} \n" +
                        $"reply: Второе число -> {array_of_values[1]} \n" +
                         $"reply: Арифметический оператор -> - \n" +
                        $"reply: Результат = {array_of_values[0] - array_of_values[1]}");
                        break;
                    case '*':
                        Console.WriteLine($"reply: Первое число -> {array_of_values[0]} \n"
                        + $"reply: Второе число -> {array_of_values[1]} \n" +
                         $"reply: Арифметический оператор -> * \n" +
                        $"reply: Результат = {array_of_values[0] * array_of_values[1]}");
                        break;
                    case '/':
                        Console.WriteLine($"reply: Первое число -> {array_of_values[0]} \n" +
                        $"reply: Второе число -> {array_of_values[1]} \n" +
                        $"reply: Арифметический оператор -> / \n" +
                        $"reply: Результат = {array_of_values[0] / array_of_values[1]}");
                        break;
                }
            }
            else
            {
                Console.WriteLine($"reply: you sent '{text_input}'");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Console EchoBot is online. I will repeat any message you send me!\n Say \"quit\" to end.");
            while (true)
            {
                string input_text = Console.ReadLine();

                if (input_text != "quit")
                {
                    UDBot s = new UDBot();
                    s.SearchAnswer(input_text);
                }
                else
                {
                    break;
                }
            }
        }
    }
}
