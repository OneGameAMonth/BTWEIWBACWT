using UnityEngine;
using System.Collections;

public class EnemyFish : MonoBehaviour {
    private static readonly string target = "BallMagnet";
    private static readonly string rendererName = "Lightning";
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == target)
        {
            GameObject.Find(rendererName).GetComponent<LineRenderer>().enabled = true;
        }
    }

    void OnCollisionExit(Collision collisionInfo)
    {
        if (collisionInfo.transform.name == target)
        {
            if (!Player.isGameOver && !Player.isAWinner)
            {
                GameObject.Find(rendererName).GetComponent<LineRenderer>().enabled = false;
                Player.instance.harmPlayer();
            }
            else
            {
                GameObject.Find(rendererName).GetComponent<LineRenderer>().material.color = Color.red;
            }
        }
    }
}
