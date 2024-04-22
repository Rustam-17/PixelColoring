using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureReader
{
    private Color32[,] _colorsArray;
    private Color32[] _colorsNormalizedArray;

    public PictureReader(Texture2D picture)
    {
        int x = picture.width;
        int y = picture.height;

        _colorsArray = new Color32[x, y];
        _colorsNormalizedArray = new Color32[x * y];

        _colorsNormalizedArray = picture.GetPixels32();

        DenormalizeArray(x, y);
    }

    public Color32[,] GetColors()
    {
        return (Color32[,])_colorsArray.Clone();
    }

    public Color32[] GetNormalizedColors()
    {
        return _colorsNormalizedArray;
    }

    private void DenormalizeArray(int x, int y)
    {
        for (int j = 0; j < y; j++)
        {
            for (int i = 0; i < x; i++)
            {
                _colorsArray[i, j] = _colorsNormalizedArray[i + j * x];
            }
        }
    }
}
