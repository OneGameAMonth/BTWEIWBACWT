using UnityEngine;
using System.Collections;

public class DestroyOthersOnCollision : MonoBehaviour {
    void OnCollisionStay(Collision collision)
    {
        Destroy(collision.gameObject);
    }
}