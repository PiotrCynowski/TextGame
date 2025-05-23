using System;
using UnityEngine;

namespace TextGame
{
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

        public (bool, string) GetRoomIndividualCommand(string command)
        {
            if (roomCommand.command.CommandText == command)
            {
                return (true, roomCommand.commandResponse);
            }

            return (false, "I can't do it here.");
        }

        public string[] GetAvailableCommands()
        {
            string[] commands = new string[objects.Length + 2];
            for (int i = 0; i < objects.Length; i++)
            {
                commands[i] = objects[i].command.CommandText;
            }

            commands[objects.Length] = leaveCondition.command.CommandText;
            commands[objects.Length+1] = roomCommand.command.CommandText;

            return commands;
        }

        [Serializable]
        public class RoomCommand
        {
            public Command command;
            public string commandResponse;
        }
    }
}