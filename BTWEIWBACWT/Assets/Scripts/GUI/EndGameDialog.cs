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

            if (Player.totalScore >= 7)
            {
                Player.isAWinner = true;
                GUI.Label(new Rect(50, 25, 350, 50), "Thou be'st The Mad God!", guiStyle);
            }
            else
            {
                GUI.Label(new Rect(75, 50, 325, 75), "The Mad God will put thee in eternal suffering... <FOREVER>", guiStyle);
                Player.isAWinner = false;
            }

            if (GUI.Button(new Rect(125, 150, 200, 25), "PRESS TO RETURN"))
            {
                Application.LoadLevel(0);
            }
            GUI.EndGroup();
        }
    }
}
