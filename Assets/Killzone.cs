using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killzone : MonoBehaviour {

    public static Killzone instance;

    private SpriteRenderer sp;

    public void Start()
    {
        instance = this;
        sp = GetComponent<SpriteRenderer>();
    }

	public void killBeat()
    {
        StopAllCoroutines();
        StartCoroutine(flash());
    }

    private IEnumerator flash()
    {
        float timer = 0;
        while(timer < 1)
        {
            sp.color = Color.Lerp(Color.red, Color.clear, timer);
            timer += Time.deltaTime;
            yield return null;

        }
    }
}
