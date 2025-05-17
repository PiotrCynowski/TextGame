using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TextGame
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] TMP_Text messageText;
        [SerializeField] TMP_Text commandsInfoText;
        [SerializeField] TMP_InputField inputField;
        private EventSystem eventSystem;

        private string accumulatedMessages = "";
        private string accumulatedCommands = "";

        private void Start()
        {
            eventSystem = EventSystem.current;
            FocusInputField();
        }

        public void DisplayMessage(string message)
        {
            accumulatedMessages += message + "\n\n";
            messageText.text = accumulatedMessages;
        }

        public void AddCommandsInfo(string[] commands)
        {
            foreach (string command in commands)
            {
                accumulatedCommands += command + "\n\n";
                commandsInfoText.text = accumulatedCommands;
            }
        }

        public string GetPlayerInput()
        {
            string input = inputField.text.ToLower().Trim();
            inputField.text = "";
            FocusInputField();
            return input;
        }

        private void FocusInputField()
        {
            if (inputField != null)
            {
                eventSystem.SetSelectedGameObject(inputField.gameObject);
                inputField.ActivateInputField();
            }
        }
    }
}