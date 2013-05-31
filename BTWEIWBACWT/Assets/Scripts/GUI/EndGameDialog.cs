using UnityEngine;
using System.Collections;

public class EndGameDialog : MonoBehaviour {
    private GUIStyle guiStyle;

    void OnGUI()
    {
        if (guiStyle == null)
        {
            guiStyle = new GUIStyle(GUI.skin.label);
            guiStyle.alignment = TextAnchor.MiddleCenter;
            guiStyle.fontSize = 20;
            guiStyle.fontStyle = FontStyle.Bold;
        }

        
        if (Player.isGameOver)
        {
            GUI.BeginGroup(new Rect(Screen.width / 2 - 250, 50, 400, 300));
            GUI.Box(new Rect(50, 0, 400, 200), string.Empty);

            if (Player.lifeCount > 0)
            {
                Player.isAWinner = true;
                GUI.Label(new Rect(125, 50, 200, 75), "You have fished all the materials", guiStyle);
            }
            else
            {
                GUI.Label(new Rect(125, 50, 200, 75), "The end is nigh, live to see it live", guiStyle);
                Player.isAWinner = false;
            }

            if (GUI.Button(new Rect(125, 150, 200, 25), (!Player.isAWinner) ? "PRESS TO RETURN" : "Go to Build Phase"))
            {
                if (Player.isAWinner)
                {
                    Application.LoadLevel("ConstructGame");
                }
                else
                {
                    Application.LoadLevel(0);
                }
            }
            GUI.EndGroup();
        }
    }
}
