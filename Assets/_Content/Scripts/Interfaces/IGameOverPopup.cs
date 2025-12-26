namespace _Content.Scripts
{
    public interface IGameOverPopup
    {
        /// <summary>
        /// Показать окно оканчания игры.
        /// <param name="message">Сообщение о статусе окончания игры</param>
        /// </summary>
        public void Show(string message);
    }
}