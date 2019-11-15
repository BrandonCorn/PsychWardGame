using System.Collections;
using System.Collections.Generic;
using System;

namespace StarterGame
{
    public class Parser
    {
        //private CommandWords commands;
        private Stack<CommandWords> allCommands;

        public Parser() : this(new CommandWords())
        {
            //NotificationCenter.Instance.addObserver("PushBattleCommands", PushBattleCommands);
            //NotificationCenter.Instance.addObserver("BattleSequence", battleSequence);
        }

        public Parser(CommandWords newCommands)
        {
            //commands = newCommands;
            allCommands = new Stack<CommandWords>();
            allCommands.Push(newCommands);
            NotificationCenter.Instance.addObserver("PushBattleCommands", PushBattleCommands);
            NotificationCenter.Instance.addObserver("PushMerchantCommands", PushMerchantCommands);
            NotificationCenter.Instance.addObserver("PopCommands", PopCommands);
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
                
                command = allCommands.Peek().get(allWords.Dequeue());
                if (command != null)
                {
                    command.Words = new Queue<string>(allWords);
                }
                else
                {
                    Console.WriteLine(">>>Did not find the command " + commandName);
                }
            }
            else
            {
                //Console.WriteLine(">>>Did not find the command " + commandName);
            }
            return command; 
        }

        public string description()
        {
            return allCommands.Peek().description();
        }

        //Add the group of battle commands as the available commands 
        public void PushBattleCommands(Notification notification)
        {
            allCommands.Push(new CommandWords(CommandWords.battleCommands));            
        }

        //Remove battle commands as the available commands
        public void PopCommands(Notification notification)
        {
            allCommands.Pop();
        }

        public void PushMerchantCommands(Notification notification)
        {
            allCommands.Push(new CommandWords(CommandWords.merchantCommands));
        }

    }
}
