namespace _Content.Scripts
{
    public interface IItemElement
    {
        /// <summary>
        /// Устанавливает значения для текущего предмета.
        /// Данные берутся из <see cref="IItem"/>
        /// </summary>
        public void SetValue(IItem item);
        
        /// <summary>
        /// Сравнивает текущий предмет с <see cref="IItem"/>.
        /// </summary>
        public bool CheckItem(IItem item);
        
        /// <summary>
        /// Скрывает предмет из списка предметов для поиска.
        /// </summary>
        void Hide(float duration);
        
        /// <summary>
        /// Показывает предмет в списке предметов для поиска.
        /// </summary>
        void Show(float duration);
    }
}