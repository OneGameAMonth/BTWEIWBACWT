using UnityEngine;
using System.Collections;

public class PickupArea : MonoBehaviour {
    public int scoreXOffset = -1;
    public GameObject trashScorePrefab;
    public GameObject tricubeScorePrefab;
    public GameObject sTrashScorePrefab;
    public AudioSource potionSound;

    void Start()
    {
        Player.trashLargeScore = 0;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.StartsWith("TrashLarge"))
        {
            addScoreObject(trashScorePrefab, Player.trashLargeScore, scoreXOffset);
            Player.trashLargeScore++;
        }
        
        if (collision.gameObject.name.StartsWith("Tricube"))
        {
            addScoreObject(tricubeScorePrefab, Player.tricubeScore, scoreXOffset*2);
            Player.tricubeScore++;
        }

        if (collision.gameObject.name.StartsWith("STrash"))
        {
            addScoreObject(sTrashScorePrefab, Player.sTrashScore, scoreXOffset*2);
            Player.sTrashScore++;
        }

        if (collision.gameObject.name.StartsWith("Potion"))
        {
            Player.magicPotions++;
            potionSound.Play();
        }
        else audio.Play();

        Destroy(collision.gameObject);
    }

    private void addScoreObject(GameObject prefab, float currentScore, int scoreXOffset)
    {
        GameObject clone = Instantiate(prefab) as GameObject;
        clone.transform.position = new Vector3(clone.transform.position.x + scoreXOffset * currentScore,
            clone.transform.position.y, clone.transform.position.z);

    }
}
