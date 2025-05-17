public class RoomCommandProcessor
{
    private readonly RoomCommands availableCommands;
    private readonly RoomState currentRoomState;
    private readonly Room currentRoom;
    public string[] wordsToHighlight;

    public RoomCommandProcessor(Room currentRoom)
    {
        this.currentRoom = currentRoom;
        availableCommands = new RoomCommands(currentRoom);
        currentRoomState = new RoomState(currentRoom);
        wordsToHighlight = CollectHighlited(currentRoom);
    }

    public CommandResult ProcessCommand(CommandData commandData)
    {
        if (!availableCommands.Contains(commandData.command))
        {
            return new(false, "I can't do it here.");
        }

        if (string.IsNullOrWhiteSpace(commandData.target))
        {
            (bool isSuccess, string roomMessage) = currentRoom.GetRoomIndividualCommand(commandData.command);

            return new(false, isSuccess ? ColorWords(roomMessage, wordsToHighlight, "green") : roomMessage);
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

    private string[] CollectHighlited(Room currentRoom)
    {
        string[] wordsToHighlight = new string[currentRoom.objects.Length];
        for (int i = 0; i < currentRoom.objects.Length; i++)
        {
            wordsToHighlight[i] = currentRoom.objects[i].ObjectName;
        }

        return wordsToHighlight;
    }

    private string ColorWords(string input, string[] words, string colorNameOrHex)
    {
        foreach (string word in words)
        {
            string pattern = $@"\b{word}\b";
            string replacement = $"<color={colorNameOrHex}>{word}</color>";
            input = System.Text.RegularExpressions.Regex.Replace(input, pattern, replacement);
        }
        return input;
    }
}