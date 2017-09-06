﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Katamari : MonoBehaviour {
    public float speed;
    public Transform shadow;
    public AudioClip collectSound;

    new Rigidbody rigidbody;
    SphereCollider sphereCollider;

	void Start () {
        rigidbody = GetComponent<Rigidbody>();
        sphereCollider = GetComponent<SphereCollider>();
    }

    public void Move(Vector3 dir) {
        rigidbody.AddForce(dir * speed);
    }

    public void OnPickup(Pickup pickup) {
        sphereCollider.radius += pickup.radius;
        Camera.main.GetComponent<AudioSource>().PlayOneShot(collectSound, 0.1f);
    }

    void UpdateShadow() {
        int groundMask = LayerMask.GetMask("Ground");
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 20, groundMask)) {
            shadow.position = hit.point;
            shadow.position += Vector3.up * 0.001f; // Move it slightly up. No Z Fighting here!
            shadow.LookAt(shadow.position + hit.normal);
        }
        else 
            shadow.position = new Vector3(-9999, -9999, -9999);
    }
	
	void Update () {
        UpdateShadow();
	}
}
