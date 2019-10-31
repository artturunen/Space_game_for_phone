using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text txt;
    private player_collider script;
    public GameObject player;

    private void Awake()
    {
        script = player.GetComponentInChildren<player_collider>();
    }

    void Start()
    {
        txt.text = script.hp.ToString("F0");
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = script.hp.ToString("F0");
    }
}
