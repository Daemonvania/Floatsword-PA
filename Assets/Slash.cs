using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : MonoBehaviour
{
    //Manages sword going to slash position and being invisible for duration of slash
    private GameObject sword;

    [SerializeField] private GameObject returnSword;
    // Start is called before the first frame update
    void Start()
    {
        sword = GameObject.Find("ReturnSwordSpecial");
        sword.GetComponent<SpriteRenderer>().enabled = false;
        StartCoroutine(DestroySelf());
    }
    

    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(0.25f);
        Instantiate(returnSword, transform.position, transform.rotation);
        //    sword.GetComponent<SpriteRenderer>().enabled = true;
        Destroy(gameObject);
    }
}
