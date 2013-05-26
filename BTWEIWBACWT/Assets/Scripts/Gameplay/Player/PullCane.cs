using UnityEngine;
using System.Collections;

public class PullCane : MonoBehaviour {
    public float caneFallingTime = 0.1f;
    public float maxScale = 1.0f;
    public float minScale = 0.1f;
    public float smoothDamp = 100.0f;
    private float currentTime;
    public float augmentationStep = 0.02f;
    public float disminutionStep = 0.01f;
    public Vector3 scaleVector = new Vector3(0, 1);
    public Vector3 targetScale;

    void Start()
    {
        targetScale = transform.localScale;
    }

    void FixedUpdate()
    {
        currentTime += Time.fixedDeltaTime;

        if (Input.GetKeyDown(KeyCode.Z) && !Player.isGameOver)
        {
            if (this.transform.localScale.y >= minScale)
            {
                targetScale = new Vector3(
                    targetScale.x - disminutionStep * scaleVector.x,
                    targetScale.y - disminutionStep * scaleVector.y,
                    targetScale.z - disminutionStep * scaleVector.z);
            }
        }
        else if (currentTime >= caneFallingTime)
        {
            if (this.transform.localScale.y < maxScale)
            {
                targetScale = new Vector3(
                                    targetScale.x + augmentationStep * scaleVector.x,
                                    targetScale.y + augmentationStep * scaleVector.y,
                                    targetScale.z + augmentationStep * scaleVector.z);
            }

            currentTime = 0;
        };

        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.fixedDeltaTime * smoothDamp);
    }
}
