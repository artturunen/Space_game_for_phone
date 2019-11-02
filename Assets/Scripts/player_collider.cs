using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_collider : MonoBehaviour
{

    public bool is_player_alive = true;

    public Vector3 cp_pos;
    public GameObject player;
    public GameObject broken;
    public Component[] parts;
    public SpriteRenderer rend;
    public PolygonCollider2D polcol;
    public Rigidbody2D rb;

    public float acc = 0;
    public float last_vel = 0;
    public float hp = 100f;

    private void Update()
    {

        if (hp <= 0) {
            Kill_Player();
        }

    }

    private void Awake()
    {
        rb = player.GetComponent<Rigidbody2D>();
    }

  

    private void OnCollisionEnter2D(Collision2D col)
    {
        
        float force = GetImpactForce(col); 
        if ( force >= 100f) {
            hp -= force * 0.1f;
        }

        if (col.collider.tag == "cp") {
            cp_pos = col.collider.transform.position;
            }

        if (col.collider.tag == "bad") {
            Kill_Player();
        }

        if (col.collider.tag == "Falling") {

            hp -= col.otherCollider.attachedRigidbody.velocity.magnitude * 5f;
            
        };

    }

    public void Kill_Player() {

        if (player.active) {

            is_player_alive = false;
            GameObject obj = (GameObject)Instantiate(broken, transform.position, transform.rotation);
            parts = obj.GetComponentsInChildren<Rigidbody2D>();

            foreach (Rigidbody2D rig in parts)
            {

                float x = Random.Range(-1.0f, 1.0f);
                float y = Random.Range(-1.0f, 1.0f);
                rig.velocity = new Vector2(x, y) * 5;
                rig.angularVelocity = Random.Range(-1.0f, 1.0f) * 5;
            }

            hp = 100f;
            player.SetActive(false);
        }
    }


    public float GetImpactForce(Collision2D collision)
    {
        float impulse = 0F;

        foreach (ContactPoint2D point in collision.contacts)
        {
            impulse += point.normalImpulse;
        }

        return impulse / Time.fixedDeltaTime;
    }


}



