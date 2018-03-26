using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

    public static Score instance;
    private int score;
    private TextMesh tm; 

    private void Start()
    {
        instance = this;
        tm = GetComponent<TextMesh>();
    }
    
    public int ScoreValue
    {
        get { return score; }
        set { score = value; tm.text = score.ToString(); }
    }
}
