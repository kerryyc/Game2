using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed = 8f;
    public float secondsToDestroy;

    private Rigidbody2D rb2d;
    private GameObject player;
    private Camera camera;

	// Use this for initialization
	private void Awake () {
        rb2d = GetComponent<Rigidbody2D>();
        Invoke("DestroySelf", secondsToDestroy);
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        rb2d.MovePosition(rb2d.position + new Vector2(speed, 0) * Time.deltaTime);
	}

    private void DestroySelf() {
        Destroy(gameObject);
    }

    public void changeDirection() {
        speed = -speed;
    }
}
