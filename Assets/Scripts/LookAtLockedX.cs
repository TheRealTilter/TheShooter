using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtLockedX : MonoBehaviour {

    public Transform toLookAt;

    // Update is called once per frame
    void Update () {
        var lookPos = toLookAt.position - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = rotation;
    }
}
