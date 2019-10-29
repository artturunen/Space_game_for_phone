using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_collider : MonoBehaviour
{

    public Vector3 cp_pos;
    public GameObject player;
    public GameObject broken;
    public Component[] parts;
    public SpriteRenderer rend;
    public PolygonCollider2D polcol;

    private void OnCollisionEnter2D(Collision2D col)
    {

        if (col.collider.tag == "cp") {
            cp_pos = col.collider.transform.position;
            }

        if (col.collider.tag == "bad") {

            

            GameObject obj = (GameObject)Instantiate(broken, transform.position, transform.rotation);
            parts = obj.GetComponentsInChildren<Rigidbody2D>();

            foreach (Rigidbody2D rig in parts) {
                
                float x = Random.Range(-1.0f, 1.0f);
                float y = Random.Range(-1.0f, 1.0f);
                rig.velocity = new Vector2(x,y)*5;
                rig.angularVelocity = Random.Range(-1.0f, 1.0f) * 5;
            }

            player.SetActive(false);
            //rend.enabled = false;
            //Destroy(player);
            //Instantiate(player, new Vector3(-0.4f, 2.2f, 7.3f), transform.rotation);

        }

    }


}
