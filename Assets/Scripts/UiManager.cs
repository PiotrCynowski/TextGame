using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    public TMP_Text messageText;
    public TMP_InputField inputField;
    private EventSystem eventSystem;

    private string accumulatedMessages = "";

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