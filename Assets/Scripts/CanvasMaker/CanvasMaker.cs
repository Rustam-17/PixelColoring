using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasMaker : MonoBehaviour
{
    [SerializeField] private GameObject _pixelPrefab;
    [SerializeField] private GameObject _parentObject;
    [SerializeField] private Paintbrush _paintbrush;
    [SerializeField] Vector2 _canvasPosition = new Vector2(0.5f, 0.5f);

    private GameObject _pixelObject;
    private Pixel _pixel;
    private SpriteRenderer _pixelRenderer;
    private NumberColor[,] _numberColors;
    private Vector2 _placePosition;
    private Vector2Int _pixelCoordinates = Vector2Int.zero;

    private void Start()
    {
        _pixelRenderer = _pixelPrefab.GetComponent<SpriteRenderer>();
    }

    public void MakeCanvas(NumberColor[] paletteNumberColors, Color32[,] colors)
    {
        _numberColors = new NumberColor[colors.GetLength(0), colors.GetLength(1)];

        AssignNumbersToColors(paletteNumberColors, colors);

        CreatePixels();
    }

    private void CreatePixels()
    {
        for (int y = 0; y < _numberColors.GetLength(1); y++)
        {
            for (int x = 0; x < _numberColors.GetLength(0); x++)
            {
                _pixelCoordinates.x = x;
                _pixelCoordinates.y = y;

                _placePosition = _canvasPosition + _pixelCoordinates;

                CreatePixel(_numberColors[x, y]);
                Debug.Log($"Создан пиксель цвета {_numberColors[x, y].Color}, в позиции {_pixelCoordinates} ");
            }
        }
    }

    private void AssignNumbersToColors(NumberColor[] paletteNumberColors, Color32[,] colors)
    {
        int colorsLength0 = colors.GetLength(0);
        int colorsLength1 = colors.GetLength(1);

        Color32 paletteColor;
        Color32 color;

        for (int y = 0; y < colorsLength1; y++)
        {
            for (int x = 0; x < colorsLength0; x++)
            {
                for (int i = 0; i < paletteNumberColors.Length; i++)
                {
                    paletteColor = paletteNumberColors[i].Color;
                    color = colors[x, y];

                    if (paletteColor.r == color.r || paletteColor.g == color.g || paletteColor.b == color.b)
                    {
                        _numberColors[x, y] = paletteNumberColors[i];
                    }
                }                
            }
        }
    }

    private void CreatePixel(NumberColor numberColor)
    {
        _pixelObject = Instantiate(_pixelPrefab, _placePosition, Quaternion.identity);
        _pixelObject.transform.SetParent(_parentObject.transform);

        _pixel = _pixelObject.GetComponent<Pixel>();
        _pixel.Set(numberColor, _pixelCoordinates, _paintbrush);        
    }
}
