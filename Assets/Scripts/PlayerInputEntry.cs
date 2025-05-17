using System;
using UnityEngine;

namespace TextGame
{
    public class PlayerInputEntry : MonoBehaviour
    {
        public event Action OnEnterPressed;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                OnEnterPressed?.Invoke();
            }
        }
    }
}