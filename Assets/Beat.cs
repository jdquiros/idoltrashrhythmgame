using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beat : MonoBehaviour {

    private Rigidbody2D body;
    public float speed = 1;
    public float xRange = 7;

	void Start () {
        body = GetComponent<Rigidbody2D>();
        body.velocity = new Vector2(0, -speed);
    }

    public void reset()
    {
        transform.position = new Vector2(Random.Range(-xRange, xRange), 6);
        BeatMap.instance.roundToLane(this);
    }

    private void die()
    {
        Killzone.instance.killBeat();
        reset();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Killzone")
        {
            die();
        }
    }
}
