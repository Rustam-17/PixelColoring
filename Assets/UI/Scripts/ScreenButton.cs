using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenButton : MonoBehaviour
{
    [SerializeField] private List<Button> _buttons;
    [SerializeField] private Color32 _activatedColor;

    private int _count;
    private List<Image> _images;
    private List<Color32> _defaultColors;

    private void Start()
    {
        _count = _buttons.Count;
        _images = new List<Image>(_count);
        _defaultColors = new List<Color32>(_count);

        foreach (Button button in _buttons)
        {
            _images.Add(button.GetComponent<Image>());
        }

        foreach (Image image in _images)
        {
            _defaultColors.Add(image.color);
        }

        _images[0].color = _activatedColor;
    }

    public void SetAktivated(int buttonNumber)
    {
        for (int i = 0; i < _count; i++)
        {
            _images[i].color = _defaultColors[i];
        }

        _images[buttonNumber].color = _activatedColor;
    }
}
