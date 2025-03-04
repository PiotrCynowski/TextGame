public class RoomCommandProcessor
{
    private readonly RoomCommands availableCommands;
    private readonly RoomState currentRoomState;
    private readonly Room currentRoom;

    public RoomCommandProcessor(Room currentRoom)
    {
        this.currentRoom = currentRoom;
        availableCommands = new RoomCommands(currentRoom);
        currentRoomState = new RoomState(currentRoom);
    }

    public CommandResult ProcessCommand(CommandData commandData)
    {
        if (!availableCommands.Contains(commandData.command))
        {
            return new(false, "I can't do it here.");
        }

        if (string.IsNullOrWhiteSpace(commandData.target))
        {
            return new(false, currentRoom.GetRoomIndividualCommand(commandData.command));
        }

        if (!currentRoomState.HasObject(commandData.target))
        {
            return new CommandResult(false, "I can't find it in the room.");
        }

        CommandableObject processItem = currentRoomState.GetObject(commandData.target);
        CommandResult itemResult = processItem.ProcessComand(commandData.command, currentRoomState.doneConditions);

        if (itemResult.Success)
        {
            currentRoomState.doneConditions.Add(processItem.ObjectName);
            return new CommandResult(currentRoom.leaveCondition == processItem, itemResult.Message);
        }

        return new CommandResult(false, itemResult.Message);
    }
}