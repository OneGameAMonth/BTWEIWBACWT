using UnityEngine;
using System.Collections;

public class ScaleInTime : MonoBehaviour {
    public Vector3 additiveVector;
    public float damping = 2f;

    void FixedUpdate()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, transform.localScale + additiveVector,
            Time.fixedDeltaTime * damping);
    }

}
