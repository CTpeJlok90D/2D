using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Windows;

namespace Dialog
{
    public class NPC : MonoBehaviour, IInteracteble
    {
        [SerializeField] private Dialog _dialog;

        public void Interact(InteractInfo interactInfo)
        {
            InputHandler.Input.WorldMovement.Disable();
            InputHandler.Input.Dialog.Enable();
            interactInfo.DialogView.StartDialog(_dialog);
        }
    }
}