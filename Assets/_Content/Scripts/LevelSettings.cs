using UnityEngine;
using UnityEngine.AddressableAssets;

[CreateAssetMenu(fileName = "LevelSettings", menuName = "Levels/LevelSettings")]
public class LevelSettings : ScriptableObject
{
    [Tooltip("Префаб уровня")]
    public AssetReference LevelPrefab;
    
    [Tooltip("Префабы объектов для поиска")]
    public AssetReference[] Items;

    [Tooltip("Префаб объектов в UI")] 
    public AssetReference UiItemPrefab;

    [Tooltip("Количество доступных к поиску предметов")]
    public int MaxItemsCount;
    
    [Tooltip("Объекты для поиска будут выбираться подряд, если галочка стоит, то случайно")]
    public bool RandomItems;
    
    [Tooltip("Включение, отключение игрового таймера")]
    public bool EnableTimer;
    
    [Tooltip("Время таймера в секундах")]
    public float TimerTime;
}
