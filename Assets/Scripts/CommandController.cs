using Commands;
using System.Collections.Generic;
using UI;
using UnityEngine;
using Utilities;

public class CommandController : MonoBehaviour
{
    [SerializeField]
    private byte _maxCapacity;
    [SerializeField]
    private CommandListSelector _commandListSelector;
    [SerializeField]
    private EventChannel _eventChannel;

    private List<Command> _commands = new();
    private byte _index;

    private void Awake()
    {
        _eventChannel.OnReset += ClearCommands;
        _eventChannel.OnPlayStart += _commandListSelector.BlockTouch;
        _eventChannel.OnPlayEnd += _commandListSelector.AllowTouch;
    }

    private void OnDestroy()
    {
        _eventChannel.OnReset -= ClearCommands;
        _eventChannel.OnPlayStart -= _commandListSelector.BlockTouch;
        _eventChannel.OnPlayEnd -= _commandListSelector.AllowTouch;
    }

    public void AddCommand(Command command, CommandListItem commandListItem)
    {
        if (_commands.Count >= _maxCapacity)
        {
            Debug.Log("Cant add more command");
            return;
        }
        Debug.Log("Command added");
        _commands.Add(command);

        var item = Instantiate(commandListItem);
        item.Initialize(command);
        _commandListSelector.AddCommandVisual(item.transform);
    }

    public void RemoveCommand(Command command, GameObject visual)
    {
        if (_commands.Contains(command) == false)
        {
            Debug.Log("This command is not available");
            return;
        }
        Debug.Log("Command removed");
        _commands.Remove(command);
        Destroy(visual);
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

    public void ClearCommands()
    {
        _commands.Clear();
        _commandListSelector.ClearVisuals();
    }

}
