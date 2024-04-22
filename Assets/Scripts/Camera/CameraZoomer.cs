using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomer : MonoBehaviour
{
    [SerializeField] TouchControl _touchControl;
    [SerializeField] private float _zoomMin;
    [SerializeField] private float _zoomMax;
    [SerializeField] private int _zoomStep;
    [SerializeField] private int _zoomLerpSpeed;

    private Camera _camera;
    private Touch _touch0;
    private Touch _touch1;
    private Vector2 _touch0CurrentPosition;
    private Vector2 _touch1CurrentPosition;
    private Vector2 _touch0LastPosition;
    private Vector2 _touch1LastPosition;
    private float _touchesLastDistance;
    private float _touchesCurrentDistance;
    private float _touchesDeltaDistanse;
    private float _newSize;

    private void Start()
    {
        _camera = GetComponent<Camera>();
        _newSize = _camera.orthographicSize;
    }

    private void FixedUpdate()
    {
        if (_touchControl.CanCameraZoom)
        {
            _newSize -= Input.GetAxis("Mouse ScrollWheel") * _zoomStep;
            _newSize = Mathf.Clamp(_newSize, _zoomMin, _zoomMax);

            _camera.orthographicSize = Mathf.Lerp(_camera.orthographicSize, _newSize, Time.deltaTime * _zoomLerpSpeed);
        }

        if (Input.touchCount == 2)
        {
            _touch0 = Input.GetTouch(0);
            _touch1 = Input.GetTouch(1);

            _touch0CurrentPosition = _touch0.position;
            _touch1CurrentPosition = _touch1.position;

            _touch0LastPosition = _touch0CurrentPosition - _touch0.deltaPosition;
            _touch1LastPosition = _touch1CurrentPosition - _touch1.deltaPosition;

            _touchesLastDistance = (_touch0LastPosition - _touch1LastPosition).magnitude;
            _touchesCurrentDistance = (_touch0CurrentPosition - _touch1CurrentPosition).magnitude;

            _touchesDeltaDistanse = _touchesCurrentDistance - _touchesLastDistance;

            _camera.orthographicSize = Mathf.Clamp(_camera.orthographicSize - _touchesDeltaDistanse * Time.fixedDeltaTime, _zoomMin, _zoomMax);
        }
        else
        {
            
        }
    }
}
