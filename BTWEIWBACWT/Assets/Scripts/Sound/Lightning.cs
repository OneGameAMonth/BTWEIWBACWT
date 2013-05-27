using UnityEngine;
using System.Collections;

public class Lightning : MonoBehaviour {
	// Update is called once per frame
	void Update () {
        if (renderer.enabled)
        {
            if(!audio.isPlaying) audio.Play();
        }
        else
        {
            audio.Stop();
        }
	}
}
