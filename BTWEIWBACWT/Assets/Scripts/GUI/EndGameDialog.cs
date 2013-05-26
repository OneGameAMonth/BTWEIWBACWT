using UnityEngine;
using System.Collections;

public class EndGameDialog : MonoBehaviour {
    private GUIStyle guiStyle;
    public Font GUIFont;

    void OnGUI()
    {
        if (guiStyle == null)
        {
            guiStyle = new GUIStyle(GUI.skin.label);
            guiStyle.alignment = TextAnchor.MiddleCenter;
            guiStyle.fontSize = 20;
            guiStyle.font = GUIFont;
            guiStyle.fontStyle = FontStyle.Bold;
        }

        if (Player.isGameOver)
        {
            GUI.BeginGroup(new Rect(Screen.width / 2 - 250, 50, 400, 300));
            GUI.Box(new Rect(50, 0, 400, 200), string.Empty);

            if (Player.totalScore > 200)
                GUI.Label(new Rect(50, 25, 350, 50), "The mad god is happy!", guiStyle);
            else
                GUI.Label(new Rect(50, 25, 350, 50), "The Mad god Blew your arm!", guiStyle);

            if (GUI.Button(new Rect(125, 150, 200, 25), "PRESS TO RETURN"))
            {
                Application.LoadLevel(0);
            }
            GUI.EndGroup();
        }
    }
}
