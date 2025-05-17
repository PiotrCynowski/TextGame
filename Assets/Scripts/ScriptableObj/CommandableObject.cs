using System.Collections.Generic;
using UnityEngine;

namespace TextGame
{
    public abstract class CommandableObject : ScriptableObject
    {
        [SerializeField] private string objectName;
        public string ObjectName
        {
            get => objectName.ToLower().Trim();
            private set => objectName = value;
        }
        public string responseSuccess;
        public string responseFailed;
        public Command command;
        public abstract CommandResult ProcessComand(string command, HashSet<string> currentInventory = null);
    }
}