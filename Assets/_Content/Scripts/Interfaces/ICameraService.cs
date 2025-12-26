using UnityEngine;

namespace _Content.Scripts
{
    public interface ICameraService
    {
        /// <summary>
        /// Возвращает текущую игровую камеру.
        /// </summary>
        public Camera Camera { get; }
    }
}