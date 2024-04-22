using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pixel : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private Frame _frame;
    [SerializeField] private Color32 _currentColor;

    private NumberColor _currentNumberColor;
    private NumberColor _targetNumberColor;
    private Vector2Int _coordinates;
    private Paintbrush _paintbrush;
    private bool _isSelected;

    public bool IsCorrectlyColored => _currentNumberColor.Number == _targetNumberColor.Number;

    private void Start()
    {
        _paintbrush.Changed += OnPaintbrushChanged;
    }

    private void Update()
    {
        _currentColor = _targetNumberColor.Color;
    }

    private void OnDisable()
    {
        _paintbrush.Changed -= OnPaintbrushChanged;
    }

    public void Set(NumberColor numberColor, Vector2Int coordinates, Paintbrush paintbrush)
    {
        _targetNumberColor = numberColor;
        _coordinates = coordinates;
        _paintbrush = paintbrush;
    }

    public void ChangeCurrentNumberColor(NumberColor newNumberColor)
    {
        _currentNumberColor = newNumberColor;

        ChangeCurrentColor();
    }

    private void ChangeCurrentColor()
    {
        _renderer.color = _currentNumberColor.Color;
    }

    private void OnPaintbrushChanged()
    {
        if (_paintbrush.NumberColor.Number == _targetNumberColor.Number)
        {
            _frame.Select();
        }
        else
        {
            _frame.Deselect();
        }
    }
}
