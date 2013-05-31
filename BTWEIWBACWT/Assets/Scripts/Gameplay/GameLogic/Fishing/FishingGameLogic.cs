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

    public int delaySpawn = 5;
    public int enemyDelaySpawn = 2;

    public GameObject enemyPrefab;
    public GameObject largeTrashPrefab;
    public GameObject tricubePrefab;
    public GameObject sTrashPrefab;
    public GameObject potionPrefab;

    public static readonly float spawnCreepersMargin = 0.1f;
     
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
            Application.LoadLevel(Application.loadedLevel);
        }

        if (Player.isGameOver && !isWaitingForAction)
        {
            levelTimer.pauseTimer();
            isWaitingForAction = true;
            audio.Play();
        }

        if (levelTimer.isTimeOver)
        {
            levelTimer.gameObject.SetActive(false);
            Player.isGameOver = true;
        }

        if (currentEnemyWaitTime > enemyDelaySpawn)
        {
            float spawnProbability = 1 - (levelTimer.seconds / (float)levelTimer.secondsGoal);
            spawnProbability += spawnCreepersMargin;

            if (Random.value < spawnProbability) Instantiate(enemyPrefab);
            currentEnemyWaitTime = 0;
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        if(currentTrashWaitTime > delaySpawn)
        {
            float rand = Random.value;

            if (rand > 0.90)
            {
                Instantiate(potionPrefab);
            }
            else if (rand > 0.60)
            {
                Instantiate(sTrashPrefab);
            }
            else if (rand > 0.30)
            {
                Instantiate(tricubePrefab);
            }
            else
            {
                Instantiate(largeTrashPrefab);
            }
            
            currentTrashWaitTime = 0;
        }
        

    }

}
