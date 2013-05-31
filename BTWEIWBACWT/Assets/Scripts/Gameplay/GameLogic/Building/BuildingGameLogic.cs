using UnityEngine;
using System.Collections;
using System.Linq;
using MoreLinq;

public class BuildingGameLogic : MonoBehaviour {
    private Timer levelTimer;
    public int secsMultiplier = 10;
    private static readonly int storeNScores = 5;
    public GameObject characterPrefab;
    private bool isLevelFinished;
    public float waitBeforeAppearPlayer = 3;
    private float currentWaitBeforeAppearPlayer;

	// Use this for initialization
	void Start () {
        levelTimer = GameObject.Find("LevelTimer").GetComponent<Timer>();
        Player.isGameOver = false;
        resetLevel();
        this.GetComponent<SpawnPieces>().spawnAllPieces();
    }

    private void resetLevel()
    {
        levelTimer.secondsGoal = (Player.sTrashScore + Player.trashLargeScore + Player.tricubeScore) * 1;
        levelTimer.startTimer();
    }

    void Update()
    {
        if (!Player.isGameOver && levelTimer.isTimeOver)
        {
            levelTimer.gameObject.SetActive(false);
            Player.isGameOver = true;
        }

        if (!isLevelFinished && Player.isGameOver)
        {
            currentWaitBeforeAppearPlayer += Time.deltaTime;
            if (currentWaitBeforeAppearPlayer > waitBeforeAppearPlayer)
            {
                isLevelFinished = true;
                Transform topTrash = GameObject.FindGameObjectsWithTag("ParentTrash").MaxBy(trash => trash.transform.position.y).transform;
                Player.highgerY = topTrash.position.y;
                submitScore();
                GameObject character = Instantiate(characterPrefab) as GameObject;
                character.transform.position =
                    topTrash.position + new Vector3(0, +6, 0);
            }
        }
    }




    private void submitScore()
    {
        for (int i = 1; i <= storeNScores; i++)
        {
            if (Player.trashLargeScore > PlayerPrefs.GetFloat("Record" + i))
            {
                for (int j = i + 1; j <= storeNScores; j++)
                {
                    PlayerPrefs.SetFloat("Record" + j, PlayerPrefs.GetFloat("Record" + (j - 1)));
                    PlayerPrefs.SetString("Name" + j, PlayerPrefs.GetString("Name" + (j - 1)));
                }

                PlayerPrefs.SetFloat("Record" + i, Player.trashLargeScore);
                PlayerPrefs.SetString("Name" + i, Player.playerName);
            }
        }
    }
}
