using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour
{
    public float stepY = 1;
    private static float targetY;
    private float minY;
    public float damping = 0.3f;

    void Start()
    {
        minY = transform.position.y;
        targetY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            targetY += stepY;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            targetY -= stepY;
        }

        targetY = Mathf.Max(minY, targetY);
        transform.position = 
            Vector3.Lerp(transform.position, 
            new Vector3(transform.position.x, targetY, transform.position.z), Time.deltaTime*damping);
    }
}
