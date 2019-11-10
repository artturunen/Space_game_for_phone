using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Rigidbody2D rig;
    public GameObject player;
    public SpriteRenderer rendon;
    public SpriteRenderer rendoff;
    public bool isActive = false;
    bool lock1 = true;

    private player_collider script;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {

        script = player.GetComponentInChildren<player_collider>();
        rig = player.GetComponent<Rigidbody2D>();

    }


    // Update is called once per frame
    void Update()
    {
        
        if (script.cp_pos == this.transform.position)
        {
            isActive = true;
        }
        else {

            isActive = false;
        
        }

        rendon.enabled = isActive;
        rendoff.enabled = !(isActive);

        if (!player.active && lock1 && isActive)
        {
            lock1 = false;
            StartCoroutine(waiter());
        }
    }

    IEnumerator waiter()
    {

        yield return new WaitForSeconds(2);
        player.transform.position = script.cp_pos + new Vector3(0f,0.72f,0f);
        
        rig.constraints = RigidbodyConstraints2D.FreezeAll;
        player.transform.eulerAngles = new Vector3(0,0,0);
        rig.velocity = new Vector2(0,0);

        
        script.is_player_alive = true;
        player.SetActive(true);
        lock1 = true;
    }





}
