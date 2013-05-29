using UnityEngine;
using System.Collections;

public class ConstantVelocity : MonoBehaviour {
    public Vector3 velocity = new Vector3(2, 0);
	
	void FixedUpdate () {
        rigidbody.velocity = velocity;
	}
}
