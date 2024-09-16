using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //bullet needs fast speed
    public float speed = 500f;
    //Project in certain direction by adding force to rigid body
    public float maxLifetime = 10f;
    private Rigidbody2D rb;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    //get direction of bullet based on rotation of player
    //the player will inform the bullet where to project
    public void Project(Vector2 direction) {
        //when bullet is fired, add force and stay on screen until it hits something or 10 seconds pass
        rb.AddForce(direction * speed);
        Destroy(this.gameObject, maxLifetime);
    }

    //collision detection for destroy
    private void OnCollisionEnter2D(Collision2D collision) {
        Destroy(this.gameObject);
    }
}
