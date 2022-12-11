using Commands;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandController : MonoBehaviour
{
    [SerializeField]
    private byte _maxCapacity;

    private List<Command> _commands = new();
    private byte _index;

    public void AddCommand(Command command)
    {
        if (_commands.Count >= _maxCapacity)
        {
            Debug.Log("Cant add more command");
            return;
        }
        Debug.Log("Command added");
        _commands.Add(command);
    }

    public void RemoveCommand(Command command)
    {
        if (_commands.Contains(command) == false)
        {
            Debug.Log("This command is not available");
            return;
        }
        Debug.Log("Command removed");
        _commands.Remove(command);
    }

    public void ExecuteCommands()
    {
        if (_index >= _commands.Count)
        {
            Debug.Log("End of Commands");
            _index = 0;
            return;
        }

        _commands[_index].Execute();
        _index++;
        //delay
        ExecuteCommands();
    }

    public Command ActiveCommand()
    {
        if (_index >= _commands.Count)
        {
            Debug.Log("End of Commands");
            _index = 0;
            return null;
        }

        _index++;
        return _commands[_index - 1];
    }

    public void ClearCommands() => _commands.Clear();

}
