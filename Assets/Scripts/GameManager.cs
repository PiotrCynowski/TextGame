using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<Room> rooms;
    private int currentRoomIndex = 0;

    [SerializeField] private PlayerInputEntry playerInput;
    [SerializeField] private UIManager uiManager;

    private RoomCommandProcessor roomCommandProcess;

    private void Start()
    {
        playerInput.OnEnterPressed += PlayerExecuteCommand;
        PrepareNewRoom(currentRoomIndex);
    }

    public void PlayerExecuteCommand()
    {
        string inputCommand = uiManager.GetPlayerInput();

        if (string.IsNullOrWhiteSpace(inputCommand) || roomCommandProcess == null)
        {
            uiManager.DisplayMessage("Invalid command.");
            return;
        }

        string colorNameorHex = "#2866b8";
        string inputMessageColor = $"<color={colorNameorHex}>{inputCommand}</color>";
        uiManager.DisplayMessage(inputMessageColor);

        CommandData commandData = new(inputCommand);
        CommandResult result = roomCommandProcess.ProcessCommand(commandData);
        uiManager.DisplayMessage(result.Message);

        if (result.Success)
        {
            currentRoomIndex++;
            PrepareNewRoom(currentRoomIndex);
        }
    }

    private void PrepareNewRoom(int roomIndex)
    {
        if (roomIndex < rooms.Count)
        {
            roomCommandProcess = new RoomCommandProcessor(rooms[currentRoomIndex]);
            uiManager.DisplayMessage(rooms[currentRoomIndex].welcomeMessage);

            uiManager.AddCommandsInfo(rooms[currentRoomIndex].GetAvailableCommands());
        }
        else
        {
            roomCommandProcess = null;
            uiManager.DisplayMessage(GetEndGameMessage());
        }
    }

    private string GetEndGameMessage()
    {
        return "Beyond the door lies a bright, open world.You step out into freedom, leaving the dungeon behind";
    }
}