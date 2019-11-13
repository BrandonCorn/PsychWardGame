using System.Collections;
using System.Collections.Generic;
using System;

namespace StarterGame
{
    public class CommandWords
    {


        //Dictionary of commands is where they are stored so that they still have a key for an accessor. 
        Dictionary<string, Command> commands;

        private static Command[] commandArray = {new GoCommand(), new InteractCommand(), new TaskCommand(),
            new QuitCommand()};

        //These two arrays will be used in the stack implementation of the Commands, when a player enters a 
        //scenario in which the commands must be changed, the corresponding array of commands can be pushed
        //to the stack changing the available options. 
        public static Command[] merchantCommands = { new BuyCommand(), new SellCommand(), new QuitCommand() };
        public static Command[] battleCommands = { new FightCommand(), new RunCommand(), new QuitCommand()};

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
            //Below is for Stack implementation of commands
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
