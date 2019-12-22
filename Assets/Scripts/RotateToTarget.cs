using UnityEngine;
using System.Collections;

public class RotateToTarget : MonoBehaviour
{
	// rotation axis
	public Vector3 axis;
	// the object to rotate around
	public Transform target;
	// the speed of rotation
	public int speed;

	void Start ()
	{
		if (target == null) {
			target = this.gameObject.transform;
			Debug.Log ("RotateAround target not specified. Defaulting to this GameObject.");
		}
	}

	// Update is called once per frame
	void Update ()
	{
		// RotateAround takes three arguments, first is the Vector to rotate around
		// second is a vector that axis to rotate around
		// third is the degrees to rotate, in this case the speed per second
		transform.RotateAround (target.transform.position, axis, speed * Time.deltaTime);
	}
}
