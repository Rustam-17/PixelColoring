using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PaletteDeterminant
{
    private Color32[] _allColors;
    private Color32[] _colors;
    private NumberColor[] _numberColors;

    public PaletteDeterminant(Color32[] pictureColors)
    {
        _allColors = pictureColors;

        SelectColors();

        _numberColors = new NumberColor[_colors.Length];

        AssignNumbersToColors();
    }

    public Color32[] GetColors()
    {
        return _colors;
    }

    public NumberColor[] GetNumberColors()
    {
        return _numberColors;
    }

    private void SelectColors()
    {
        _colors = _allColors.Distinct().ToArray();
    }

    private void AssignNumbersToColors()
    {
        for (int i = 0; i < _colors.Length; i++)
        {
            _numberColors[i].Number = i + 1;
            _numberColors[i].Color = _colors[i];
        }
    }
}
