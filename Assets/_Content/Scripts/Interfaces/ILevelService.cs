using System.Collections.Generic;
using UnityEngine;

namespace _Content.Scripts
{
    public interface ILevelService
    {
        /// <summary>
        /// Возвращает спрайт бэкграунда текущего уровня
        /// </summary>
        public SpriteRenderer LevelBackground { get; }
        
        /// <summary>
        /// Возвращает лист со всеми предметами <see cref="IItem"/> на уровне.
        /// </summary>
        public List<IItem> Items { get; }
    }
}