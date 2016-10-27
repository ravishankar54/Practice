using System.Collections.Generic;
namespace FirstTest
{
    public class RoverInputStringCommandParser
    {
        private string commandString;
        private static Dictionary<string, ICommand> stringToCommandMap = new Dictionary<string, ICommand>()
                                                                        {
                                                                            { "L", new RotateLeftCommand() },
                                                                            { "R", new RotateRightCommand() },
                                                                            { "M", new MoveCommand() }
                                                                        };

        public RoverInputStringCommandParser(string commandString)
        {
            this.commandString = commandString;
        }

        public List<ICommand> ToCommands()
        {
            if (string.IsNullOrWhiteSpace(commandString)) return new List<ICommand>();
            return BuildCommandsList(commandString);
        }

        private List<ICommand> BuildCommandsList(string commandString)
        {
            List<ICommand> commands = new List<ICommand>();

            foreach (string commandCharacter in CommandCharactersFrom(commandString))
            {
                if (commandCharacter == null) break;
                ICommand mappedCommand = LookupEquivalentCommand(commandCharacter);
                commands.Add(mappedCommand);
            }
            return commands;
        }

        private IEnumerable<string> CommandCharactersFrom(string commandString)
        {
            foreach (var item in commandString.ToUpper().ToCharArray())
            {
                yield return item.ToString();
            }
        }

        private ICommand LookupEquivalentCommand(string commandString)
        {
            return stringToCommandMap[commandString];
        }

    }
}
