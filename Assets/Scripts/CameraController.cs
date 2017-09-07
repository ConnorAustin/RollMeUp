using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public Transform target;
    public float angle; // Angle on the x/z plane
    public float planeDistance; // Distance on the x/z plane to the target
    public float yOffset;
    public float orbitSpeed;

    void Start () {
    }

    public void Orbit(float dir)
    {
        angle += dir * orbitSpeed;
    }
	
	void Update () {
        Vector3 offset = new Vector3(0, 0, 0);
        offset.x = Mathf.Cos(angle) * planeDistance;
        offset.z = Mathf.Sin(angle) * planeDistance;
        offset.y = yOffset;

        transform.position = target.position + offset;
        transform.LookAt(target);
	}
}
