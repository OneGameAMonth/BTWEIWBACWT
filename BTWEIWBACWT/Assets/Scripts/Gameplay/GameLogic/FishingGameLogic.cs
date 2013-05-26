using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class FishingGameLogic : MonoBehaviour
{
    private Timer levelTimer;

    private float currentTrashWaitTime;
    private float currentEnemyWaitTime;
    

    private static FishingGameLogic instance;

    private bool isWaitingForAction;

    private static readonly int storeNScores = 5;

    public int delaySpawn = 5;
    public int enemyDelaySpawn = 2;

    public GameObject enemyPrefab;
    public GameObject largeTrashPrefab;


    public static FishingGameLogic Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("FishingGameLogic").AddComponent<FishingGameLogic>();
            }

            return instance;
        }
    }

    public void OnApplicationQuit()
    {
        instance = null;
    }

	// Use this for initialization
	void Start () {
        if (instance == null) instance = gameObject.GetComponent<FishingGameLogic>();

        levelTimer = GameObject.Find("LevelTimer").GetComponent<Timer>();
         
        resetLevel();
	}

    private void resetLevel()
    {
        levelTimer.startTimer();
    }

    void Update()
    {
        currentTrashWaitTime += Time.deltaTime;
        currentEnemyWaitTime += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.LoadLevel(0);
        }

        if (Player.isGameOver && !isWaitingForAction)
        {
            levelTimer.pauseTimer();

            submitScore();
            isWaitingForAction = true;
        }

        if (levelTimer.isTimeOver)
        {
            levelTimer.gameObject.SetActive(false);
            Player.isGameOver = true;
        }

        if (currentEnemyWaitTime > enemyDelaySpawn)
        {
            float spawnProbability = 1 - (levelTimer.seconds / (float)levelTimer.secondsGoal);
            if (Random.value < spawnProbability) Instantiate(enemyPrefab);
            currentEnemyWaitTime = 0;
        }

        if(currentTrashWaitTime > delaySpawn)
        {
            Instantiate(largeTrashPrefab);
            currentTrashWaitTime = 0;
        }
        

    }

    private void submitScore()
    {
        for (int i = 1; i <= storeNScores; i++)
        {
            if(Player.totalScore > PlayerPrefs.GetFloat("Record" + i))
            {
                for (int j = i + 1; j <= storeNScores; j++)
                {
                    PlayerPrefs.SetFloat("Record" + j, PlayerPrefs.GetFloat("Record" + (j-1)));
                    PlayerPrefs.SetString("Name" + j, PlayerPrefs.GetString("Name" + (j-1)));
                }

                PlayerPrefs.SetFloat("Record" + i, Player.totalScore);
                PlayerPrefs.SetString("Name" + i, Player.playerName);
            }
        }
    }

}
