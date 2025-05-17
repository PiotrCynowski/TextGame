using System.Collections.Generic;

namespace TextGame
{
    public class RoomState
    {
        private readonly Dictionary<string, CommandableObject> availableObjects;
        public HashSet<string> doneConditions;

        public RoomState(Room currentRoom)
        {
            availableObjects = new Dictionary<string, CommandableObject>();
            doneConditions = new HashSet<string>();

            foreach (var obj in currentRoom.objects)
            {
                if (!availableObjects.ContainsKey(obj.ObjectName))
                {
                    availableObjects.Add(obj.ObjectName, obj);
                }
            }

            if (!availableObjects.ContainsKey(currentRoom.leaveCondition.ObjectName))
            {
                availableObjects.Add(currentRoom.leaveCondition.ObjectName, currentRoom.leaveCondition);
            }
        }

        public bool HasObject(string target)
        {
            return availableObjects.ContainsKey(target);
        }

        public CommandableObject GetObject(string target)
        {
            return availableObjects[target];
        }
    }

    public class RoomCommands
    {
        private readonly HashSet<string> commands;

        public RoomCommands(Room room)
        {
            commands = new HashSet<string>();
            foreach (var obj in room.objects)
            {
                commands.Add(obj.command.CommandText);
            }
            commands.Add(room.leaveCondition.command.CommandText);
            commands.Add(room.roomCommand.command.CommandText);
        }

        public bool Contains(string command)
        {
            return commands.Contains(command);
        }
    }
}