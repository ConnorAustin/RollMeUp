using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    Katamari katamari;

	void Start () {
        katamari = GetComponent<Katamari>();	
	}
	
	void FixedUpdate () {
        if (GameManager.manager.state != GameState.Playing)
            return;

        var cam = Camera.main;

        // Since the camera is tilted either upwards or downwards, the forward direction has a y component
        // We don't want this as it pushes the katamari down in the ground
        // cam.transform.right is okay as we don't tilt the camera. Hackish but effective
        Vector3 forwardDir = transform.position - cam.transform.position;
        forwardDir.y = 0;
        forwardDir.Normalize();

        float XLeftstick = Input.GetAxis("XLeftstick");
        float YLeftstick = Input.GetAxis("YLeftstick");

        float XRightstick = Input.GetAxis("XRightstick");
        float YRightstick = Input.GetAxis("YRightstick");

        float YDiff = YLeftstick - YRightstick;

        if (YDiff > -1.5f && YDiff < 1.5f)
        {
            float Xavg = (XLeftstick + XRightstick) / 2.0f;
            float Yavg = (YLeftstick + YRightstick) / 2.0f;

            Vector3 right = forwardDir * -Yavg;
            Vector3 forward = cam.transform.right * Xavg;
            Vector3 dir = right + forward;
            dir.Normalize();
            katamari.Move(dir);
        }
        else {
            Camera.main.GetComponent<CameraController>().Orbit(YDiff);
        }
	}
}
