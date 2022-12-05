using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    #region Variables
    [SerializeField] private float _speed = 3f;
    private Vector3 _moveDir;
    #endregion
    #region Properties
    public float Speed
    {
        get => _speed;
        set => _speed = value;
    }
    public Vector3 MoveDir
    {
        get => _moveDir;
        private set => _moveDir = value;
    }
    #endregion

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
    }
    
    private void CalculateMovement()
    {
        MoveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (MoveDir.sqrMagnitude > 1)
        {
            MoveDir = MoveDir.normalized;
        }
    }
    
    private void FixedUpdate()
    {
        ApplyMovement();
    }
    
    private void ApplyMovement()
    {   
        transform.Translate((MoveDir * Speed) * Time.deltaTime);
    }
}
