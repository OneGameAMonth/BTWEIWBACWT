using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {
    public float rigthLimit;
    public float leftLimit;
    public float moveStep = 0.2f;
    public float smoothDamp = 100.0f;
    private Vector3 targetPosition;

    void Start()
    {
        targetPosition = transform.position;
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.A))
        {
            if (this.transform.localScale.y >= leftLimit)
            {
                targetPosition -= new Vector3(moveStep, 0); 
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (this.transform.localScale.y < rigthLimit)
            {
                targetPosition += new Vector3(moveStep, 0); 
            }
        }

        if (targetPosition.x <= leftLimit)
            targetPosition = new Vector3(leftLimit, targetPosition.y, targetPosition.z);

        if (targetPosition.x > rigthLimit)
            targetPosition = new Vector3(rigthLimit, targetPosition.y, targetPosition.z);

        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.fixedDeltaTime * smoothDamp);
	}
}