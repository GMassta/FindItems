using _Content.Scripts;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(BoxCollider2D))]
public class Item : MonoBehaviour, IItem
{
    [Tooltip("Имя предмета для отображения в UI")]
    [SerializeField] private string itemName;
    [Tooltip("Иконка предмета для отображения в UI")]
    [SerializeField] private Sprite icon;

    public string GetName => itemName;
    public Sprite GetIcon => icon;

    private SpriteRenderer _renderer;
    private BoxCollider2D _collider;
    
    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _collider = GetComponent<BoxCollider2D>();
    }
    
    public void HideItem()
    {
        _renderer.DOFade(0, 1f);
    }
}
