using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMover : MonoBehaviour
{
    public enum MovementDirection
    {
        Horizontal,
        Vertical,
        Custom
    }
    public float Amplitude;

    public MovementDirection MovementType = MovementDirection.Horizontal;
    public Vector3 CustomMovementVector;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    private void Update()
    {
        switch (MovementType)
        {
            case MovementDirection.Horizontal:
                _transform.Translate(Vector3.right * Amplitude * Time.deltaTime * Mathf.Sin(Time.timeSinceLevelLoad));
                break;

            case MovementDirection.Vertical:
                _transform.Translate(Vector3.up * Amplitude * Time.deltaTime * Mathf.Sin(Time.timeSinceLevelLoad));
                break;

            case MovementDirection.Custom:
                _transform.Translate(CustomMovementVector * Amplitude * Time.deltaTime * Mathf.Sin(Time.timeSinceLevelLoad));
                break;

            default:
                break;

        }
        
    }
}
