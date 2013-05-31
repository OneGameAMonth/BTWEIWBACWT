using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public static float highgerY;
    public static int trashLargeScore = 1;
    public static int tricubeScore = 1;
    public static int sTrashScore = 1;
    public static float magicPotions;    
    public static string playerName;
    public static bool isGameOver;
    public static int lifeCount;
    public int maxLives = 5;
    public static Player instance;
    public float harmColorVariationFactor = 0.1f;
    public static bool isAWinner;

	// Use this for initialization
	void Start () {
        instance = this;
        restart();
	}

    public void harmPlayer()
    {
        Player.isGameOver = --lifeCount <= 0;
        
        Color harmedColor = new Color(renderer.material.color.r + harmColorVariationFactor, renderer.material.color.g - harmColorVariationFactor, renderer.material.color.b -harmColorVariationFactor, renderer.material.color.a);
        renderer.material.color = harmedColor;
        foreach (Renderer r in GetComponentsInChildren<Renderer>()) r.material.color = harmedColor;
    }

    public void restart()
    {
        trashLargeScore = 0;
        tricubeScore = 0;
        sTrashScore = 0;
        isGameOver = false;
        lifeCount = maxLives;
        isAWinner = false;
    }
}
