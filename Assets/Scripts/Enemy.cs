using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float health = 10f;
    public GameObject player;
    public bool facingRight = false;

    private Rigidbody2D rb2d;

	// Use this for initialization
	void Awake () {
        rb2d = GetComponent<Rigidbody2D>();

        //flip enemy depending on face direction
        //no movement for now -> simple one time flip
        if (facingRight)
            Flip();
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D other) {
        if (other.gameObject.tag == "Projectile") {
            Destroy(other.gameObject);
            if (--health <= 0)
                Destroy(this.gameObject);
        }
        else if (other.gameObject.tag == "Platform") {
            rb2d.velocity = new Vector2(0, 0);
        }
	}

    void OnCollisionEnter2D (Collision2D coll) {
        Debug.Log(coll.gameObject.tag);
        if (coll.gameObject.tag == "Player") {
            player.GetComponent<PlayerController>().health -= 1;
        }
    }

    private void Flip() {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
