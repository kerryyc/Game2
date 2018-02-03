using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed = 10f;
    public float fallSpeed = 10f;
    public bool canMove = true;
    public float health = 10f;

    public GameObject bulletPrefab;

    public float jumpForce = 700f;
    private bool isGrounded = false;
    public Transform groundCheck;
    public Vector2 groundRadius;
    public LayerMask whatIsGround;

    private Rigidbody2D rb2d;

	// Use this for initialization
	void Awake () {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.freezeRotation = true;
    }
	

	// Update is called once per frame
	void FixedUpdate () {
        //check ground
        isGrounded = Physics2D.OverlapBox(groundCheck.position, groundRadius, 0, whatIsGround);


        //move horizontal
        if (canMove)
            Move();
	}

    void Update() {
        //jump
        if (health <= 0)
            Destroy(this.gameObject);
        else if (canMove && isGrounded && Input.GetButtonDown("Jump")) {
            rb2d.AddForce(new Vector2(0, jumpForce));
        }
        Shoot();
    }

    private void Move() {
        float newSpeed;
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        //rb2d.AddForce(new Vector2(moveHorizontal * speed, 0));
        newSpeed = moveHorizontal * speed;
        rb2d.velocity = new Vector2(newSpeed, rb2d.velocity.y);

    }

    private void Shoot() {
        if (Input.GetButtonDown("Fire1"))
            Instantiate(bulletPrefab, new Vector3(transform.position.x + 1, transform.position.y, 0), transform.rotation);
    }
}
