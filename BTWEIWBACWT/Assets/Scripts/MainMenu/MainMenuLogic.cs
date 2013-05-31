using UnityEngine;
using System.Collections;

public class MainMenuLogic : MonoBehaviour {
    private static string textAreaString = "Player";
    public int totalInScores = 5;
    public Font GUIFont;
    private GUIStyle guiStyle;

	// Use this for initialization
	void Start () {
        //GUI.skin.box.fontSize = 100;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
        {
            startGame();
        }

        if(Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
	}

    void OnGUI()
    {
        if (Event.current.keyCode == KeyCode.Return || Event.current.keyCode == KeyCode.KeypadEnter)
        {
            startGame();
        }

        if (guiStyle == null)
        {
            guiStyle = new GUIStyle(GUI.skin.textField);
            guiStyle.fontSize = 18;
        }
        showInputPlayerName();
        showBestRecords();

        if (GUI.Button(new Rect(Screen.width - 50, Screen.height - 50, 50, 50), "[FS]"))
        {
            Screen.fullScreen = !Screen.fullScreen;
        }
    }

    private void showInputPlayerName()
    {
        GUI.BeginGroup(new Rect(Screen.width / 2 - 200, Screen.height/2, 400, 300));

        Rect textArea = new Rect(105, 150, 150, 30);
        textAreaString = GUI.TextArea(textArea, textAreaString, 12, guiStyle);

        if (GUI.Button(new Rect(260, 150, 40, 30), "Fish!"))
        {
            startGame();
        }
  
        GUI.EndGroup();
    }

    private void startGame()
    {
        Player.playerName = textAreaString;
        Application.LoadLevel("FishGame");
    }

    private void showBestRecords()
    {
        GUI.Box(new Rect(0, 0, 200, 30 * totalInScores), string.Empty);
        AdvancedLabel.Draw(new Rect(10, 10, 200, 200), "<Best Heights>", new NewFontSize(18), new NewColor(Color.white), new NewFontStyle(FontStyle.Italic));

        for (int i = 1; i <= totalInScores; i++)
        {
            float playerScore = PlayerPrefs.GetFloat("Record" + i);

            string labelPlayer = string.Format("~{0}: {1} ·", PlayerPrefs.GetString("Name" + i, textAreaString), playerScore.ToString().Replace(".", "'"));
            AdvancedLabel.Draw(new Rect(10, 10 + (i * 20), 200, 200), labelPlayer, new NewFontSize(15), new NewColor(Color.white), new NewFontStyle(FontStyle.Italic));
        }
    }
}
