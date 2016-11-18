﻿using UnityEngine;
using System.Collections;

public class Reflecter : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "EnemyShot")
        {
            // acquire the rigid body for the character that the shield is attatched too
            Rigidbody2D parent = transform.parent.GetComponent<Rigidbody2D>();

            // acquire the rigid body for the bullet the shield is colliding with
            Rigidbody2D bullet = col.gameObject.GetComponent<Rigidbody2D>();

            // the new Vector for the bullet to be traveling in
            Vector2 reflection = new Vector2(bullet.velocity.x, bullet.velocity.y);

            // reverses the x velocity of the coliding object if its velocity is towards 
            // the shield
            if (bullet.velocity.x < 0 && parent.velocity.x >= 0 ||
                bullet.velocity.x > 0 && parent.velocity.x <= 0)
            {
                reflection.x *= -1;
            }
            if (bullet.velocity.y < 0 && parent.velocity.y >= 0 ||
                bullet.velocity.y > 0 && parent.velocity.y <= 0)
            {
                reflection.y *= -1;
            }

            // adds the players velocity to the reflection vector
            reflection.x += parent.velocity.x;
            reflection.y += parent.velocity.y;

            //sets the bullets velocity to the reflection that was calculated
            col.gameObject.GetComponent<Rigidbody2D>().velocity = reflection;

            col.gameObject.tag = "PlayerShot";
        }
    }
}
