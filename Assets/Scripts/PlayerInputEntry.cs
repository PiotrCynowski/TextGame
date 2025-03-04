using System;
using UnityEngine;

public class PlayerInputEntry : MonoBehaviour
{
    public event Action OnEnterPressed;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            OnEnterPressed?.Invoke();
        }
    }
}