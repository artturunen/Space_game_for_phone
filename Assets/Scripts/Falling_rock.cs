using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling_rock : MonoBehaviour
{
    private player_collider script;
    public GameObject player;
    public Rigidbody2D rb;
    private Vector3 ogPos;
    private Quaternion ogRot;

    void Start()
    {
        rb.bodyType = RigidbodyType2D.Static;
        ogPos = this.transform.position;
        ogRot = this.transform.rotation;
    }

    private void Awake()
    {

        script = player.GetComponentInChildren<player_collider>();
    
    }

    private void Update()
    {
        if (!script.is_player_alive) {

            reset_rock();
        }
    }


    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.tag == "Player") {
            rb.bodyType = RigidbodyType2D.Dynamic;
            this.tag = "Falling";
        }
        
    }

    private void reset_rock() {

        rb.bodyType = RigidbodyType2D.Static;
        transform.position = ogPos;
        transform.rotation = ogRot;

    }

}
