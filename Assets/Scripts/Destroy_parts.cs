using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_parts : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(waiter());
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }

}
