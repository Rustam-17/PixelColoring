using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControl : MonoBehaviour
{
    [SerializeField] private Palette _palette;
    [SerializeField] private Picture _picture;

    public bool CanCameraMove { get; private set; }
    public bool CanCameraZoom { get; private set; }
    public bool IsRelateToPalette { get; private set; }
    public bool IsRelateToPicture { get; private set; }

    private RectTransform _paletteRectTransform;
    private float _paletteHeight;


    private void Start()
    {
        _paletteRectTransform = _palette.GetComponent<RectTransform>();
        _paletteHeight = _paletteRectTransform.sizeDelta.y;
    }

    private void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            if (Input.touches[0].position.y < _paletteHeight)
            {
                CanCameraMove = false;
                CanCameraZoom = false;
            }
            else
            {
                CanCameraMove = true;
                CanCameraZoom = true;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (Input.mousePosition.y < _paletteHeight)
            {
                CanCameraMove = false;
            }
            else
            {
                CanCameraMove = true;
            }
        }

        if (Input.mousePosition.y < _paletteHeight)
        {
            CanCameraZoom = false;
        }
        else
        {
            CanCameraZoom = true;
        }
    }
}
