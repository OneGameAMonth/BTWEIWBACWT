using UnityEngine;
using System.Collections;
using System.Linq;
using MoreLinq;
using System.Collections.Generic;

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
        levelTimer.secondsGoal = (Player.sTrashScore + Player.trashLargeScore + Player.tricubeScore) * secsMultiplier;
        levelTimer.startTimer();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

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
                Player.higherY = topTrash.position.y;
                saveHighScore(Player.playerName, Player.higherY);
				PlayerPrefs.Save();
                GameObject character = Instantiate(characterPrefab) as GameObject;
                character.transform.position =
                    topTrash.position + new Vector3(0, +6, 0);
            }
        }
    }


    public class Score
    {
        public float score;
        public string name;

        public Score(float score, string name)
        {
            this.score = score;
            this.name = name;
        }
    }

    public void saveHighScore(string name, float score)
    {
        List<Score> highScores = new List<Score>();

        for (int i = 1; i <= storeNScores && PlayerPrefs.HasKey("Record" + i); i++)
            highScores.Add(new Score(PlayerPrefs.GetFloat("Record" + i), PlayerPrefs.GetString("Name" + i)));

        if (highScores.Count == 0) {                        
                highScores.Add (new Score(score, name));
        } else {
            for (int i = 1; i <= highScores.Count && i <= storeNScores; i++)
            {
                if (score > highScores [i - 1].score) {
                        highScores.Insert (i - 1, new Score (score, name));
                        break;
                }
                if (i == highScores.Count && i < storeNScores)
                {
                    highScores.Add(new Score(score, name));
                    break;
                }
            }
        }
                
        for (int i = 1; i <= storeNScores && i <= highScores.Count; i++)
        {
            PlayerPrefs.SetString("Name" + i, highScores[i - 1].name);
            PlayerPrefs.SetFloat("Record" + i, highScores[i - 1].score);
        }
    }
}
