using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PrototypeGuiCompositor30
{
    public static class CommandManager
    {
        private static readonly List<ICommand> _commands = new List<ICommand>();
        private static readonly List<ICommand> _redocommands = new List<ICommand>();



        public static void AddCommand(ICommand stockOperation)
        {
            _commands.Add(stockOperation);

            _redocommands.Clear();
        }


        public static void UndoCommand()
        {
            ICommand lastComand;
            Console.WriteLine($"count commands {_commands.Count}");
            if ((_commands.Count - 1) >= 0)
            {
                lastComand = _commands[_commands.Count - 1];
                lastComand.Undo();
                _commands.RemoveAt(_commands.Count - 1);

                _redocommands.Add(lastComand);
            }

        }

        public static void RedoCommand()
        {
            ICommand lastComand;
           // Console.WriteLine($"aa {_redocommands.Count}");
            if ((_redocommands.Count) > 0)
            {
                lastComand = _redocommands[_redocommands.Count - 1];
                _commands.Add(lastComand);
                _redocommands.RemoveAt(_redocommands.Count - 1);

                lastComand.Execute();
            }

        }

    }
}
