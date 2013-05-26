using UnityEngine;
using System.Collections;

public class TranslateInTime : MonoBehaviour {
    public Vector3 additiveVector;
    public float damping = 0.3f;
	
	void FixedUpdate () {
        transform.position = Vector3.Lerp(transform.position, transform.position+additiveVector, 
            Time.fixedDeltaTime * damping);
	}
}
