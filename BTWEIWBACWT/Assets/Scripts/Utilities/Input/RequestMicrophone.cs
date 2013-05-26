using UnityEngine;
using System.Collections;

public class RequestMicrophone : MonoBehaviour {
    private GUIStyle guiStyle;
    public static bool isSetMic = false;

    IEnumerator Start()
    {
        yield return Application.RequestUserAuthorization(UserAuthorization.Microphone);
        if (Application.HasUserAuthorization(UserAuthorization.Microphone))
        {
            isSetMic = true;
        }
        else
        {

        }
    }

    void OnGUI()
    {
        if (guiStyle == null)
        {
            guiStyle = new GUIStyle(GUI.skin.label);
            guiStyle.alignment = TextAnchor.MiddleCenter;
            guiStyle.fontSize = 20;
            guiStyle.fontStyle = FontStyle.Bold;
        }
        
        GUI.BeginGroup(new Rect(Screen.width / 2 - 250, 50, 400, 300));
        GUI.Box(new Rect(50, 0, 400, 200), string.Empty);

        if(!isSetMic)
        GUI.Label(new Rect(50, 25, 350, 150), "Use Z to pull up your cane, pickup the trash and make the Mad God happy", guiStyle);
        else
        GUI.Label(new Rect(50, 25, 350, 150), "Blow your Microphone to pull up your cane, pickup the trash and make the Mad God happy", guiStyle);


        if (GUI.Button(new Rect(125, 150, 200, 25), "PRESS TO CONTINUE"))
        {
            Application.LoadLevel("FishGame");
        }
        GUI.EndGroup();
    }
}
