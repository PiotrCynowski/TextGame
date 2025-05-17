using System.Collections.Generic;
using UnityEngine;

namespace TextGame
{
    [CreateAssetMenu(fileName = "New Interactable Item", menuName = "EscapeTheDungeon/InteractableItem")]
    public class InteractableItem : CommandableObject
    {
        public string responseAlreadyDone;

        public override CommandResult ProcessComand(string command, HashSet<string> doneConditions)
        {
            if (this.command.CommandText == command)
            {
                if (!doneConditions.Contains(ObjectName))
                {
                    return new(true, responseSuccess);
                }
                else
                {
                    return new(false, responseAlreadyDone);
                }
            }
            else
            {
                return new(false, responseFailed);
            }
        }
    }
}