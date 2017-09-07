using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {
    public float radius;

    public void OnTriggerEnter(Collider c)
    {
        var other = c.gameObject;

        // See if we hit something related to the player
        GameObject player;
        if (other.tag == "Player")
        {
            player = other;
        }
        else if (other.tag == "ConnectedPickup")
        {
            player = other.transform.parent.gameObject;
        }
        else
        {
            return;
        }

        // We hit the player

        transform.SetParent(player.transform);

        // Remove rigidbody if we have one
        var rigidbody = GetComponent<Rigidbody>();
        if (rigidbody)
        {
            Destroy(rigidbody);
        }

        // Change Tag
        tag = "ConnectedPickup";

        player.GetComponent<Katamari>().OnPickup(this);
    }
}
