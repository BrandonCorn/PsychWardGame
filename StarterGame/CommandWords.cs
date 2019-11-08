using System.Collections;
using System.Collections.Generic;
using System;

namespace StarterGame
{
    public class CommandWords
    {
        Dictionary<string, Command> commands;
        private static Command[] commandArray = { new GoCommand(), new QuitCommand(), new SpeakCommand(), new TaskCommand(), new BuyCommand(), new SellCommand() };
        //private static Command[] merchantCommands = { new BuyCommand(), new SellCommand(), new TaskCommand() };
        public CommandWords() : this(commandArray)
        {
        }

        public CommandWords(Command[] commandList)
        {
            commands = new Dictionary<string, Command>();
            foreach (Command command in commandList)
            {
                commands[command.name] = command;
            }
            Command help = new HelpCommand(this);
            commands[help.name] = help;
        }

        public Command get(string word)
        {
            Command command = null;
            commands.TryGetValue(word, out command);
            return command;
        }

        public string description()
        {
            string commandNames = "";
            Dictionary<string, Command>.KeyCollection keys = commands.Keys;
            foreach (string commandName in keys)
            {
                commandNames += " " + commandName;
            }
            return commandNames;
        }

        /*public void addMerchantCommands()
        {
            foreach(Command command in merchantCommands)
            {
                commands[command.name] = command;
            }

        }*/

        public string description(CommandType commandType)
        {
            string commandNames = "";
            Dictionary<string, Command>.ValueCollection values = commands.Values;
            foreach(Command command in values)
            {
                if (command.CommandType == commandType)
                {
                    commandNames += " " + command.name;
                }
            }
            return commandNames;
        }
    }
}
