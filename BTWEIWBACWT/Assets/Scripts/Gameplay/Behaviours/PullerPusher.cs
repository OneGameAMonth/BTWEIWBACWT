using UnityEngine;
using System.Collections;

public class PullerPusher : MonoBehaviour {
    private float currentElapsedTime;
    public float applyForceInSeconds = 0.0f;
    public float power = 500.0f;
    public Transform basePosition;
    public bool isMagnitudeRelativeToScale = true;
    public bool isPullingToCenter = false;
    public static float speedBonus = 1;

    void OnCollisionStay(Collision collision)
    {
        if (currentElapsedTime >= applyForceInSeconds)
        {
            Vector3 pullVector;

            if (isPullingToCenter) pullVector = (basePosition.position - collision.rigidbody.position).normalized;
            else pullVector = transform.forward;

            if (isMagnitudeRelativeToScale) collision.rigidbody.AddForce(pullVector * power * collision.transform.localScale.magnitude * speedBonus);
            else collision.rigidbody.AddForce(pullVector * power);

            currentElapsedTime = 0;
        }
    }

    void FixedUpdate()
    {
        currentElapsedTime += Time.fixedDeltaTime;
    }

}
