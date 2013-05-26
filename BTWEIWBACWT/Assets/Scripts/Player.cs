using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public static float totalScore;
    public static string playerName;
    public static bool isGameOver;
    public static int lifeCount;
    public int maxLives = 5;
    public static Player instance;
    public float harmColorVariationFactor = 0.1f;

	// Use this for initialization
	void Start () {
        instance = this;
        restart();
	}

    public void harmPlayer()
    {
        Player.isGameOver = --lifeCount == 0;
        renderer.material.color = new Color(renderer.material.color.r + harmColorVariationFactor, renderer.material.color.g - harmColorVariationFactor, renderer.material.color.b -harmColorVariationFactor, renderer.material.color.a);
    }

    public void restart()
    {
        totalScore = 0;
        isGameOver = false;
        lifeCount = maxLives;
    }
}
