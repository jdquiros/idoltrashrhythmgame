using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Space : MonoBehaviour {

    public float earlyDistance;
    public float perfectDistance;

    public KeyCode toPress;

    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private void Awake()
    {
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(toPress))
        {
            onPress();
            /*
            sprite.color = Color.yellow;
            
        }*/
        }
    }

    private void onPress()
    {
        StartCoroutine(reColor(Color.grey));

        RaycastHit2D[] results = new RaycastHit2D[2];
        int hits = coll.Cast(new Vector2(0, 0), results);
        foreach (RaycastHit2D hit in results)
        {
            if (hit && hit.collider.gameObject.tag == "Beat")
            {
                hitBeat(hit.collider.gameObject);
            }
        }
    }

    private void hitBeat(GameObject beat)
    {
        if((transform.position - beat.transform.position).magnitude <= perfectDistance)
        {
            Score.instance.ScoreValue += 2;
            StartCoroutine(reColor(Color.green));
        }
        else
        {
            Score.instance.ScoreValue += 1;
            StartCoroutine(reColor(Color.yellow));
        }
        beat.GetComponent<Beat>().reset();
    }

    private IEnumerator reColor(Color c)
    {
        sprite.color = c;
        yield return new WaitUntil(() => { return !Input.GetKey(toPress); });
        sprite.color = Color.white;
    }
}
