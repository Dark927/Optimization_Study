using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHead : MonoBehaviour
{
    [SerializeField] private float _lookSensitivity = 100f;
    private Vector2 _lookRotation = new();

    private void Awake()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        Look();
    }

    private void Look()
    {
        _lookRotation.x -= Input.GetAxis("Mouse Y") * Time.deltaTime * _lookSensitivity;
        _lookRotation.y += Input.GetAxis("Mouse X") * Time.deltaTime * _lookSensitivity;

        _lookRotation.x = Mathf.Clamp(_lookRotation.x, -90f, 90f);  // to stop the player from looking above/below 90

        transform.localEulerAngles = (Vector3)_lookRotation;
    }
}
