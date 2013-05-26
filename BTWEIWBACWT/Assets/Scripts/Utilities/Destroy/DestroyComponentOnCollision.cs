using UnityEngine;
using System.Collections;

public class DestroyComponentOnCollision : MonoBehaviour {
    public string componentType = "TranslateInTime";

    void OnCollisionStay(Collision collision)
    {
        Destroy(GetComponent(componentType));
        Destroy(this);
    }
}
