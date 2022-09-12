using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRotation : MonoBehaviour
{
    public enum RotationAxis
    {
        MouseX, MouseY
    }
    
    #region Variables
    [Header("Rotation")] 
    [SerializeField] private RotationAxis _axis;
    [Header("Sensitivity")] 
    [Range(0, 500)] [SerializeField]
    private float _sensitivity = 10f;

    [Header("Rotation Clamp")] 
    [SerializeField] private float _minY = -60f;
    [SerializeField] private float _maxY = 60f;
    private float _rotY;
    [SerializeField] private bool _invert = false;
    #endregion
    #region Properties
    public RotationAxis Axis
    {
        get => _axis;
        private set => _axis = value;
    }
    public float Sensitivity
    {
        get => _sensitivity;
        private set => _sensitivity = value;
    }
    public bool Invert
    {
        get => _invert;
        private set => _invert = value;
    }
    #endregion

    private void Start()
    {
        if (GetComponent<Rigidbody>()) GetComponent<Rigidbody>().freezeRotation = true;
        if (GetComponent<Camera>()) Axis = RotationAxis.MouseY;
    }

    private void Update()
    {
        switch (Axis)
        {
            case RotationAxis.MouseX:
                transform.Rotate(0, Input.GetAxis("Mouse X") * Sensitivity, 0);
                break;
            case RotationAxis.MouseY:
                _rotY += Input.GetAxis("Mouse Y") * Sensitivity;
                _rotY = Mathf.Clamp(_rotY, _minY, _maxY);

                switch (Invert)
                {
                    case true:
                        transform.localEulerAngles = new Vector3(_rotY, 0, 0);
                        break;
                    case false:
                        transform.localEulerAngles = new Vector3(-_rotY, 0, 0);
                        break;
                }
                
                break;
        }
    }
}
