using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatMap : MonoBehaviour {

    public static BeatMap instance;

    public Transform[] spaces;

    private Beat[] beats;

    private void Start()
    {
        instance = this;
        beats = GetComponentsInChildren<Beat>();
        foreach(Beat b in beats)
        {
            setupBeat(b);
        }
    }

    private void setupBeat(Beat b)
    {
        roundToLane(b);
    }

    public void roundToLane(Beat b)
    {
        float minDistance = float.MaxValue;
        int lane = 0;
        for (int i = 0; i < spaces.Length; ++i)
        {
            if (Mathf.Abs(spaces[i].position.x - b.transform.position.x) < minDistance)
            {
                lane = i;
                minDistance = spaces[i].position.x - b.transform.position.x;
            }
        }

        Vector2 pos = new Vector2(spaces[lane].position.x, b.transform.position.y);
        b.transform.position = pos;
    }
}
