using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorButton : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Frame _frame;

    private NumberColor _numberColor;
    private Paintbrush _paintbrush;
    private bool _isSelected;

    private void Start()
    {
        _paintbrush.Changed += OnPaintbrushChanged;
    }

    private void OnDisable()
    {
        _paintbrush.Changed -= OnPaintbrushChanged;
    }

    public void Set(NumberColor numberColor, Paintbrush paintbrush)
    {
        _numberColor = numberColor;
        _paintbrush = paintbrush;

        _image.color = _numberColor.Color;
    }

    public void OnButtonClick()
    {
        _paintbrush.ChangeCurrentNumberColor(_numberColor);
        _frame.Select();
        _isSelected = true;
    }

    private void OnPaintbrushChanged()
    {
        if (_isSelected && _paintbrush.NumberColor.Number != _numberColor.Number)
        {
            _frame.Deselect();
            _isSelected = false;
        }
    }
}
