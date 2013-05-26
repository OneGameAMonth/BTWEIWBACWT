using UnityEngine;
using System.Collections;

public class LightningEffect : MonoBehaviour {
public GameObject target;
public LineRenderer lineRenderer;
public float arcLength = 2.0f;
public float arcVariation = 2.0f;
public float inaccuracy = 1.0f;

    void Update() {
        var lastPoint = transform.position;

        var i = 1;

        lineRenderer.SetPosition(0, transform.position);//make the origin of the LR the same as the transform

        while (Vector3.Distance(target.transform.position, lastPoint) >.5) {//was the last arc not touching the target? 

                lineRenderer.SetVertexCount(i + 1);//then we need a new vertex in our line renderer

                Vector3 fwd = target.transform.position - lastPoint;//gives the direction to our target from the end of the last arc

                fwd.Normalize();//makes the direction to scale

                fwd = Randomize(fwd, inaccuracy);//we don't want a straight line to the target though

                fwd *= Random.Range(arcLength * arcVariation, arcLength);//nature is never too uniform

                fwd += lastPoint;//point + distance * direction = new point. this is where our new arc ends

                lineRenderer.SetPosition(i, fwd);//this tells the line renderer where to draw to

                i++;

                lastPoint = fwd;//so we know where we are starting from for the next arc
             }
    }

 

    private Vector3 Randomize (Vector3 v3, float inaccuracy2) { 

       v3 += new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)) * inaccuracy2; 

       v3.Normalize(); 

       return v3; 
    }
}
