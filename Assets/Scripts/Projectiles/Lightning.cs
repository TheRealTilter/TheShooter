using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour {

    private LineRenderer lineRenderer;

    public float EndPoint = 8f;

    public int noSegments = 12;

    private Color color = Color.white;
    [SerializeField]
    private float posRange = 0.15f;
    private float timerRange = 0.05f;
    private float timerCurrent = 0;

	// Use this for initialization
	void Start ()
    {
        lineRenderer = GetComponent<LineRenderer>();
	}

    private void Update()
    {
        
    }

    public void DrawLine(float endPoint, int noSegments, float posRange)
    {
        lineRenderer.positionCount = noSegments;

        for (int i = 1; i < noSegments-1; i++)
        {
            float z = ((float)i) * (endPoint) / (float)(noSegments - 1);

            lineRenderer.SetPosition(i, new Vector3(Random.Range(-posRange, posRange), Random.Range(-posRange, posRange), z));
        }

        lineRenderer.SetPosition(0, new Vector3(0f, 0f, 0f));
        lineRenderer.SetPosition(noSegments - 1, new Vector3(0f, 0f, endPoint));
    }
}
