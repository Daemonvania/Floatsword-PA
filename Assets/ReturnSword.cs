using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnSword : MonoBehaviour
{
    private Transform swordPos;
    private GameObject sword;
    [SerializeField] private float speed = 2;
    [SerializeField] private float rotSpeed = 1;

    private void Start()
    {
        swordPos = GameObject.Find("SwordPos").transform;
        sword = GameObject.Find("ReturnSwordSpecial");
    }

    // Update is called once per frame
    void Update()
    {
        //TODO rework so that the move and rotation always take the same amount of time regardless of distance
        
        transform.position = Vector2.MoveTowards(transform.position, swordPos.position, speed * Time.deltaTime);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, swordPos.rotation, rotSpeed * Time.deltaTime);
        if (transform.position == swordPos.position && transform.rotation == swordPos.rotation)
        {
            //TODO enable attack here, not on rotate script
            sword.GetComponent<SpriteRenderer>().enabled = true;
            Destroy(gameObject);
        } 
    }
}
