using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TextGame
{
    [CreateAssetMenu(fileName = "New Conditional Item", menuName = "EscapeTheDungeon/ConditionalItem")]
    public class CondtitionalItem : CommandableObject
    {
        public CommandableObject[] conditions;
        public string responseMissingCondition;

        public override CommandResult ProcessComand(string command, HashSet<string> doneConditions)
        {
            if (this.command.CommandText == command)
            {
                if (CheckConditions(doneConditions))
                {
                    return new(true, responseSuccess);
                }
                else
                {
                    return new(false, responseMissingCondition);
                }
            }
            else
            {
                return new(false, responseFailed);
            }
        }

        public bool CheckConditions(HashSet<string> inventory)
        {
            if (inventory == null || inventory.Count == 0)
            {
                return false;
            }

            if (conditions == null || conditions.Length == 0)
            {
                return true;
            }

            return conditions.All(c => inventory.Contains(c.ObjectName));
        }
    }
}