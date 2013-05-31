using UnityEngine;
using System.Collections;

public class RotateWithKeys : MonoBehaviour
{
    public float speed = 1;

    // Update is called once per frame
    void Update()
    {
        if (Drag.dragTransform)
        {
            if (Input.GetKey(KeyCode.A))
            {
                Drag.dragTransform.Rotate(Vector3.forward * speed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.D))
            {
                Drag.dragTransform.Rotate(-Vector3.forward * speed * Time.deltaTime);
            }
        }
    }
}
