using UnityEngine;
using System.Collections;

public class TimerControl : MonoBehaviour {
    public static Timer finalTimer;
    private float startFadeAfterSecs;
    public static bool hasBegunTrueEnd;

	// Use this for initialization
	void Start () {
        finalTimer = GetComponent<Timer>();
        finalTimer.rposition = new Rect(new Rect(Screen.width / 2, Screen.height - 100, 200, 200));
        startFadeAfterSecs = (Player.higherY * 2);
        hasBegunTrueEnd = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (!hasBegunTrueEnd && finalTimer.seconds > startFadeAfterSecs)
        {
            audio.Play();
            hasBegunTrueEnd = true;
            finalTimer.pauseTimer();
            CameraFade.StartAlphaFade(Color.white, false, 3, 1, () => { Application.LoadLevel("Main"); });
        }
	}
}
