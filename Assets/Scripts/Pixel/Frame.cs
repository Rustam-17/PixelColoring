using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frame : MonoBehaviour
{
    [SerializeField] private List<Transform> _sides;
    [SerializeField] private Color32 _selectedColor;
    [SerializeField] private Vector2 _selectedScale;
    [SerializeField] private float _selectedWidth;

    private List<SpriteRenderer> _sideSpriteRenderers;
    private float _originalOffset;
    private float _originalWidth;
    private Color32 _originalColor;
    private int _originalSortingOrder;
    private int _forwardSortingOrder = 32767;

    private void Start()
    {
        _sideSpriteRenderers = new List<SpriteRenderer>();

        foreach (Transform side in _sides)
        {
            _sideSpriteRenderers.Add(side.GetComponent<SpriteRenderer>());
        }

        _originalOffset = _sides[0].localPosition.y;
        _originalWidth = _sides[0].localScale.y;
        _originalColor = _sideSpriteRenderers[0].color;
        _originalSortingOrder = _sideSpriteRenderers[0].sortingOrder;
    }

    public void Select()
    {
        ChangeColor(_selectedColor);
        ChangeSortingOrder(_forwardSortingOrder);
    }

    public void Deselect()
    {
        ChangeColor(_originalColor);
        ChangeSortingOrder(_originalSortingOrder);
    }

    private void ChangeColor(Color32 color)
    {
        foreach (SpriteRenderer sideSpriteRenderer in _sideSpriteRenderers)
        {
            sideSpriteRenderer.color = color;
        }
    }

    private void ChangeSortingOrder(int sortingOrder)
    {
        foreach (SpriteRenderer sideSpriteRenderer in _sideSpriteRenderers)
        {
            sideSpriteRenderer.sortingOrder = sortingOrder;
        }
    }

    private void ChangePosition(float offset)
    {
        foreach (SpriteRenderer sideSpriteRenderer in _sideSpriteRenderers)
        {
            
        }
    }
}
