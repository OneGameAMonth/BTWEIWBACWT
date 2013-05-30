using UnityEngine;
using System.Collections;

public class OnColliderEnterStop : MonoBehaviour {
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.rigidbody) collision.gameObject.rigidbody.velocity = Vector2.zero;
    }
}
