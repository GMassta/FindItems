using UnityEngine;

namespace _Content.Scripts
{
    public interface IItem
    {
        /// <summary>
        /// Возвращает имя предмета для поиска.
        /// </summary>
        public string GetName { get; }
        
        /// <summary>
        /// Возвращает иконку предмета.
        /// </summary>
        public Sprite GetIcon { get; }
        
        /// <summary>
        /// Прячет предмет при его нахождении.
        /// </summary>
        void HideItem();
    }
}