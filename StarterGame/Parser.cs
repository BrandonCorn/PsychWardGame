using System.Collections;
using System.Collections.Generic;
using System;

namespace StarterGame
{
    public class Parser
    {
        private CommandWords commands;

        public Parser() : this(new CommandWords())
        {

        }

        public Parser(CommandWords newCommands)
        {
            commands = newCommands;
        }

        /*public Command parseCommand(string commandString)
        {
            Command command = null;
            string[] words = commandString.Split(' ');

            if (words.Length > 0)
            {
                command = commands.get(words[0]);
                if (command != null)
                {
                    if (words.Length > 1)
                    {
                        command.secondWord = words[1];
                        if (words.Length > 2)
                        {
                            command.ThirdWord = words[2];

                            if (words.Length > 3)
                            {
                                command.FourthWord = words[3];
                            }
                            else
                            {
                                command.FourthWord = null;
                            }
                        }

                        else
                        {
                            command.ThirdWord = null;
                        }
                    }
                    else
                    {
                        command.secondWord = null;
                    }
                }
                else
                {
                    Console.WriteLine(">>>Did not find the command " + words[0]);
                }
            }
            else
            {
                Console.WriteLine("No words parsed!");
            }
            return command;
        }*/

        /*
         * This function is a alternative parser that allows the users commands to be as many words as 
         * they want without the need to keep writing new variables for additional words
        */
        public Command parseCommand(string commandString)
        {
            Command command = null;
            string[] check = commandString.Split(" ");
            Queue<string> allWords = new Queue<string>(commandString.Split(" "));

            if (allWords.Count > 0)
            {
                string commandName = allWords.Peek();
                command = commands.get(allWords.Dequeue());
                command.Words = new Queue<string>(allWords);
                if (command.Words.Count == 0)
                {
                    Console.WriteLine(">>>Did not find the command " + commandName);
                }
            }
            else
            {
                Console.WriteLine("No words parsed");
            }
            return command; 
        }

        public string description()
        {
            return commands.description();
        }


    }
}
