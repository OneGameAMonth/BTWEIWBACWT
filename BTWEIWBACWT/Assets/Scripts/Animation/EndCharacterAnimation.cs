using UnityEngine;
using System.Collections;

public class EndCharacterAnimation : MonoBehaviour {
    public GameObject leftEye;
    public GameObject ritghEye;


    void ScaleEyesInY()
    {
        leftEye.AddComponent<ScaleInTime>();
        ritghEye.AddComponent<ScaleInTime>();

        ritghEye.GetComponent<ScaleInTime>().additiveVector = new Vector3(0, 10);
        leftEye.GetComponent<ScaleInTime>().additiveVector = new Vector3(0, 10);
    }

    void ScaleEyesInX()
    {
        ritghEye.GetComponent<ScaleInTime>().additiveVector = new Vector3(10, 10, 10);
        leftEye.GetComponent<ScaleInTime>().additiveVector = new Vector3(10, 10, 10);
    }

    void loadEnd()
    {
        Application.LoadLevel("TheEnd");
    }
}
