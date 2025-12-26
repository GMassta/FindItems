using System;
using UnityEngine;

namespace _Content.Scripts
{
    public interface IInputService
    {
        /// <summary>
        /// Возвращает точку <see cref="Vector2"/> клика по экрану.
        /// </summary>
        public Action<Vector2> ClickAction { get; set; }
    }
}