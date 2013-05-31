using UnityEngine;
using System.Collections;

public class PullCane : MonoBehaviour {
    public float caneFallingTime = 0.1f;
    public float maxScale = 1.0f;
    public float minScale = 0.1f;
    public float smoothDamp = 100.0f;
    private float currentTime;
    public float descendStep = 0.02f;
    public float riseStep = 0.01f;
    public Vector3 scaleVector = new Vector3(0, 1);
    public Vector3 targetScale;
    public float micLoudnessModifier = 0.1f;

    void Start()
    {
        targetScale = transform.localScale;
    }

    void FixedUpdate()
    {
        if (Player.isGameOver) return;

        currentTime += Time.fixedDeltaTime;

        if (Input.GetKey(KeyCode.W))
        {
            if (this.transform.localScale.y >= minScale)
            {
                targetScale = new Vector3(
                    targetScale.x - riseStep * scaleVector.x,
                    targetScale.y - riseStep * scaleVector.y,
                    targetScale.z - riseStep * scaleVector.z);
            }
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            if (this.transform.localScale.y < maxScale)
            {
                targetScale = new Vector3(
                                    targetScale.x + descendStep * scaleVector.x,
                                    targetScale.y + descendStep * scaleVector.y,
                                    targetScale.z + descendStep * scaleVector.z);
            }

            currentTime = 0;
        };

        if (targetScale.y <= minScale)
        {
            targetScale = new Vector3(targetScale.x, minScale, targetScale.z);
        }

        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.fixedDeltaTime * smoothDamp);
    }
}
