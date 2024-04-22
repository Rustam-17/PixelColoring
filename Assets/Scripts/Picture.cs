using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picture : MonoBehaviour
{
    [SerializeField] private CanvasMaker _canvasMaker;
    [SerializeField] private PaletteMaker _paletteMaker;

    private PictureReader _pictureReader;
    private PaletteDeterminant _paletteDeterminant;
    private Texture2D _picture;

    private void Start()
    {
        _picture = IntersceneData.GetPicture();

        if (_picture == null)
        {
            _picture = GetComponent<SpriteRenderer>().sprite.texture;
        }

        _pictureReader = new PictureReader(_picture);
        _paletteDeterminant = new PaletteDeterminant(_pictureReader.GetNormalizedColors());

        _canvasMaker.MakeCanvas(_paletteDeterminant.GetNumberColors(), _pictureReader.GetColors());
        _paletteMaker.MakePalette(_paletteDeterminant.GetNumberColors());
    }
}
