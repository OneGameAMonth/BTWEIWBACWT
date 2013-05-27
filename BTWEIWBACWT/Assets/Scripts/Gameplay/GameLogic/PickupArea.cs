using UnityEngine;
using System.Collections;

public class PickupArea : MonoBehaviour {
    public int scoreXOffset = -1;
    public GameObject trashScorePrefab;

    void Start()
    {
        Player.totalScore = 0;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.StartsWith("TrashLarge"))
        {
            GameObject clone = Instantiate(trashScorePrefab) as GameObject;
            clone.transform.position = new Vector3(clone.transform.position.x+scoreXOffset*Player.totalScore,
                clone.transform.position.y, clone.transform.position.z);
            Player.totalScore++;
            audio.Play();
        }

        Destroy(collision.gameObject);
    }
}
