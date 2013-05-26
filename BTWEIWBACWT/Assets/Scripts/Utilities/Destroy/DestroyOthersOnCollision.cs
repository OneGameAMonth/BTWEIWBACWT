using UnityEngine;
using System.Collections;

public class DestroyOthersOnCollision : MonoBehaviour {
    void OnCollisionExit(Collision collisionInfo)
    {
        Destroy(collisionInfo.gameObject);
    }
}