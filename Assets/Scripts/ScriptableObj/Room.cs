using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Room", menuName = "EscapeTheDungeon/Room")]
public class Room : ScriptableObject
{
    public CondtitionalItem leaveCondition;
    public CommandableObject[] objects;
    public RoomCommand roomCommand;
    public string roomName;
    public string welcomeMessage;

    public bool IsLeaveRoomConditionsMet(string collectedCondition)
    {
        return leaveCondition.ObjectName == collectedCondition;
    }

    public string GetRoomIndividualCommand(string command)
    {
        if(roomCommand.command.CommandText == command)
        {
            return roomCommand.commandResponse;
        }

        return "I can't do it here.";
    }

    [Serializable]
    public class RoomCommand
    {
        public Command command;
        public string commandResponse;
    }
}