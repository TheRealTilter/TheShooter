using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//A modified Lissajous Curve to get an U shape
public class LissajousCurve : MonoBehaviour {
    

    public Vector3 Calculate(Vector3 startPositions, float amplitude1, float amplitude2, float bobStart)
    {
        float t = bobStart;
        float x = amplitude1 * Mathf.Sin(t*4f);
        float y = -Math.Abs(amplitude2 * Mathf.Cos(t*4f));

        return new Vector3( x, y, startPositions.z);
    }
}