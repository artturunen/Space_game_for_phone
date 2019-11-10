using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_moving : MonoBehaviour
{

    public float speed = 0.001f;
    public Renderer rend;
    public GameObject camera;
    public Vector3 init_offset;
 

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 offset = camera.transform.position + init_offset;
        offset.z = 202;

        rend.material.mainTextureOffset = offset*speed;

    }
}
