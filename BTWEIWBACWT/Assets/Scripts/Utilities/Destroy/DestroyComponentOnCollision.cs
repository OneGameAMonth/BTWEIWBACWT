using UnityEngine;
using System.Collections;

public class DestroyComponentOnCollision : MonoBehaviour {
    public string componentType = "TranslateInTime";
    public string destroyerName = "BallMagnet";

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name == destroyerName)
        {
            Destroy(GetComponent(componentType));
            Destroy(this);
        }
    }
}
