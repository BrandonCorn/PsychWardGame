using System.Collections;
using System.Collections.Generic;
using System;

namespace StarterGame
{
    public class CommandWords
    {
        Dictionary<string, Command> commands;
        private static Command[] commandArray = { new GoCommand(), new InteractCommand(),
             new BuyCommand(), new SellCommand(), new TaskCommand(), new FightCommand(),
            new RunCommand(),new QuitCommand()};

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

        //A method to grab only commands that can be used during battle from the original commands list
        public void setBattleCommands()
        {
            Dictionary<string, Command>.ValueCollection values = commands.Values;
            commands = new Dictionary<string, Command>();
            foreach (Command command in values)
            {
                if (command.CommandTypes.ContainsKey(CommandType.BattleCommand))
                {
                    commands[command.name] = command;
                }
            }
            
        }

        public void setMerchantCommands()
        {
            Dictionary<string, Command>.ValueCollection values = commands.Values;
            commands = new Dictionary<string, Command>();
            foreach (Command command in values)
            {
                if (command.CommandTypes.ContainsKey(CommandType.MerchantCommand))
                {
                    commands[command.name] = command;
                }
            }

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



        public string description(CommandType commandType)
        {
            string commandNames = "";
            Dictionary<string, Command>.ValueCollection values = commands.Values;
            foreach(Command command in values)
            {
                if (command.CommandTypes.ContainsKey(commandType))
                {
                    commandNames += " " + command.name;
                }
            }
            return commandNames;
        }
    }
}
