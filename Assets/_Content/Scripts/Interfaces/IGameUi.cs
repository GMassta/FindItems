using UnityEngine.AddressableAssets;

namespace _Content.Scripts
{
    public interface IGameUi
    {
        /// <summary>
        /// Создает пул элементов для предметов
        /// </summary>
        void CreateElements(AssetReference prefab, int count);
        
        /// <summary>
        /// Добавляет новый <see cref="IItem"/> в поле предметов для поиска.
        /// </summary>
        void AddNewItem(IItem nextItem);
        
        /// <summary>
        /// Удаляет найденный <see cref="IItem"/> из списка.
        /// </summary>
        void RemoveItem(IItem item);

        /// <summary>
        /// Обновление игрового таймера.
        /// </summary>
        void UpdateTimer(string time);
        
        /// <summary>
        /// Показать игровой таймер, если он включен.
        /// </summary>
        void ShowTimer();
    }
}