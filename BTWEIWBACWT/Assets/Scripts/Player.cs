using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public static float totalScore;
    public static string playerName;
    public static bool isGameOver;

	// Use this for initialization
	void Start () {
        restart();
	}

    void Update()
    {

    }

    public void restart()
    {
        totalScore = 0;
        isGameOver = false;
    }
}
