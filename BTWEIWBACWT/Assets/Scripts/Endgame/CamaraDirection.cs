using UnityEngine;
using System.Collections;

public class CamaraDirection : MonoBehaviour
{
    public float speed = 2.0f;
    public float maxFOW = 160;
    public float smoothFOW = 0.2f;
    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.identity, Time.deltaTime * speed);

        if (transform.rotation.eulerAngles.y < 0.2f)
        {
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, maxFOW, Time.deltaTime*smoothFOW);
        }

    }
}
