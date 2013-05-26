using UnityEngine;
using System.Collections;

public class OnDestroyKillParent : MonoBehaviour {

    void OnDisable()
    {
        Destroy(transform.parent.gameObject);
    }
}
