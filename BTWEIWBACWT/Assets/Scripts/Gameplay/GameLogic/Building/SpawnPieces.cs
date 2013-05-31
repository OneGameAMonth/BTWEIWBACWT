using UnityEngine;
using System.Collections;

public class SpawnPieces : MonoBehaviour {
    public GameObject largeTrashPrefab;
    public GameObject tricubePrefab;
    public GameObject sTrashPrefab;

    public int secsMultiplier = 5;

    public void spawnAllPieces()
    {
        while (Player.sTrashScore-- != 0) Instantiate(sTrashPrefab);
        while (Player.trashLargeScore-- != 0) Instantiate(largeTrashPrefab);
        while (Player.tricubeScore-- != 0) Instantiate(tricubePrefab);
    }
}
