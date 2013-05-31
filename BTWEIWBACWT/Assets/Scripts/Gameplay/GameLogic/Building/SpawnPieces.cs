using UnityEngine;
using System.Collections;

public class SpawnPieces : MonoBehaviour {
    private Timer levelTimer;

    private float currentTrashWaitTime;

    public GameObject largeTrashPrefab;
    public GameObject tricubePrefab;
    public GameObject sTrashPrefab;

    public int secsMultiplier = 5;

	void Start () {
        levelTimer = GameObject.Find("LevelTimer").GetComponent<Timer>();
        Player.isGameOver = false;
        resetLevel();
	}

     private void resetLevel()
    {
        levelTimer.secondsGoal = (Player.sTrashScore + Player.trashLargeScore + Player.tricubeScore) * secsMultiplier;
        spawnAllPieces();
        levelTimer.startTimer();
    }

     private void spawnAllPieces()
     {
         while (Player.sTrashScore-- != 0) Instantiate(sTrashPrefab);
         while (Player.trashLargeScore-- != 0) Instantiate(largeTrashPrefab);
         while (Player.tricubeScore-- != 0) Instantiate(tricubePrefab);
     }

     void Update()
    {
        
        if (levelTimer.isTimeOver)
        {
            levelTimer.gameObject.SetActive(false);
            Player.isGameOver = true;
        }
    }

}
