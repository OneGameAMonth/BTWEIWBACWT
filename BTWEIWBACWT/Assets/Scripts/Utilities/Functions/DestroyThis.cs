using UnityEngine;
using System.Collections;

public class DestroyThis : MonoBehaviour
{
    public void destroyGameObject()
    {
        Destroy(this.gameObject);
    }
}
