using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Paintbrush : MonoBehaviour
{
    public UnityAction Changed;

    private Camera _mainCamera;
    private GameObject _object;
    private Vector2 _mousePosition;
    private Collider2D _collider;
    private bool _isWorking;

    public NumberColor NumberColor { get; private set; }

    private void Start()
    {
        _mainCamera = Camera.main;
    }

    private void FixedUpdate()
    {
        if (_isWorking)
        {
            if (Input.GetMouseButton(0))
            {
                _mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
                _collider = Physics2D.OverlapPoint(_mousePosition);

                if (_collider != null)
                {
                    _object = _collider.gameObject;

                    if (_object.CompareTag("Pixel"))
                    {
                        _object.GetComponent<Pixel>().ChangeCurrentNumberColor(NumberColor);
                    }
                }
            }
        }
    }

    public void ChangeCurrentNumberColor(NumberColor newNumberColor)
    {
        if (NumberColor.Number != newNumberColor.Number)
        {
            NumberColor = newNumberColor;
            _isWorking = true;
            Changed?.Invoke();
        }        
    }
}
