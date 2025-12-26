using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Content.Scripts
{
    public class InputService: IInputService, IDisposable
    {
        private readonly GameInput _input;

        public Action<Vector2> ClickAction { get; set; }

        public InputService()
        {
            _input = new GameInput();
            _input.Enable();

            _input.Game.Click.performed += Click;
            _input.Game.Exit.performed += Exit;
        }

        private void Exit(InputAction.CallbackContext obj)
        {
            Application.Quit();
        }

        private void Click(InputAction.CallbackContext obj)
        {
            var position = _input.Game.MousePosition.ReadValue<Vector2>();
            ClickAction?.Invoke(position);
        }

        public void Dispose()
        {
            _input.Game.Click.performed -= Click;
            _input.Disable();
        }
    }
}