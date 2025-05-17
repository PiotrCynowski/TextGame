using UnityEngine;

namespace TextGame
{
    [CreateAssetMenu(fileName = "NewCommand", menuName = "EscapeTheDungeon/Command")]
    public class Command : ScriptableObject
    {
        [SerializeField] private string commandText;
        public string CommandText
        {
            get => commandText.ToLower().Trim();
            private set => commandText = value;
        }
    }
}