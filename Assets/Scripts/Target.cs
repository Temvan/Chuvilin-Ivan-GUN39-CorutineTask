using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody _body;

    [SerializeField, Min(0f)]
    private float _maxVelocity = 3f;
    [SerializeField, Min(0.2f)]
    private float _movespeed = .5f;

    private void Start()
    {
        _body = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        var hor = Input.GetAxis("Horizontal");
        var vert = Input.GetAxis("Vertical");
        var force = new Vector3 (hor, 0f, vert).normalized * _movespeed;
        force = transform.TransformDirection(force);
        
        var velocity = _body.velocity;
        velocity = Vector3.ClampMagnitude(velocity + force, _maxVelocity);
        _body.velocity = velocity;
    }

}
