using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] TouchControl _touchControl;

    private Vector2 _touchPosition;
    private Vector2 _moveVector;
    private Touch _touch;

    private Vector2 CurrentMousePosition => Camera.main.ScreenToWorldPoint(Input.mousePosition);

    private void FixedUpdate()
    {
        if (_touchControl.CanCameraMove)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _touchPosition = CurrentMousePosition;
            }

            if (Input.GetMouseButton(0))
            {
                _moveVector = _touchPosition - CurrentMousePosition;
                transform.position += (Vector3)_moveVector;
            }
        }
        

        //if (Input.touchCount == 1)
        //{
        //    if (Input.GetMouseButtonDown(0))
        //    {
        //        _touchPosition = CurrentMousePosition;
        //    }

        //    if (Input.GetMouseButton(0))
        //    {
        //        _moveVector = _touchPosition - CurrentMousePosition;
        //        transform.position += (Vector3)_moveVector;
        //    }
        //}        

        //if (Input.touchCount == 1)
        //{
        //    _touch = Input.GetTouch(0);

        //    transform.position -= (Vector3)_touch.deltaPosition * Time.fixedDeltaTime;
        //}
        //else
        //{
        //    if (Input.GetMouseButtonDown(0))
        //    {
        //        _touchPosition = CurrentMousePosition;
        //    }

        //    if (Input.GetMouseButton(0))
        //    {
        //        _moveVector = _touchPosition - CurrentMousePosition;
        //        transform.position += _moveVector;
        //    }
        //}
    }
}
