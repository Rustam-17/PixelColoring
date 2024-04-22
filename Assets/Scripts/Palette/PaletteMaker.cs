using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaletteMaker : MonoBehaviour
{
    [SerializeField] private GameObject _colorButtonPrefab;
    [SerializeField] private GameObject _content;
    [SerializeField] private Paintbrush _paintbrush;

    private GameObject _colorButton;
    private Transform _colorButtonTransform;

    public void MakePalette(NumberColor[] numberColors)
    {
        foreach (NumberColor numberColor in numberColors)
        {
            MakeColorButton(numberColor);
        }
    }

    private void MakeColorButton(NumberColor numberColor)
    {
        _colorButton = Instantiate(_colorButtonPrefab);
        _colorButton.GetComponent<ColorButton>().Set(numberColor, _paintbrush);

        _colorButtonTransform = _colorButton.GetComponent<RectTransform>();
        _colorButtonTransform.SetParent(_content.transform);
        _colorButtonTransform.localScale = Vector3.one;
        _colorButtonTransform.localPosition = Vector3.zero;
    }
}
