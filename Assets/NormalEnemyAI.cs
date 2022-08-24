using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class NormalEnemyAI : MonoBehaviour
{
    public Sprite bodyRight;
    public Sprite handRight;
    
    public Sprite bodyLeft;
    public Sprite handLeft;
    
    [Space]
    public GameObject hand;
    public GameObject body;

    private DrawLazer _drawLazer;

    private GameObject player;


    private bool isAttacking;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        _drawLazer = GetComponent<DrawLazer>();


    }

    // Update is called once per frame
    void Update()
    { 
        Vector2 direction = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.z - transform.position.y);
       hand.transform.right = direction;

       if (direction.x < 0)
       {
           hand.GetComponentInChildren<SpriteRenderer>().sprite = handLeft;
           body.GetComponent<SpriteRenderer>().sprite = bodyLeft;
       }
       if (direction.x > 0)
       {
           hand.GetComponentInChildren<SpriteRenderer>().sprite = handRight;
           body.GetComponent<SpriteRenderer>().sprite = bodyRight;
       }
       Attack();
    }

    void Attack()
    {   
        //Countdown To Attack
        _drawLazer.lazerWidth -= 0.4f * Time.deltaTime;
        
        if (_drawLazer.lazerWidth <= 0)
        {
            //kill player
            RaycastHit2D hit = Physics2D.Raycast(transform.position, player.transform.position - transform.position,Mathf.Infinity, 3);
            Debug.DrawRay(transform.position,  player.transform.position - transform.position,Color.green, 30);
            print(hit.collider);
            if (hit.collider.CompareTag("Player"))
            {
                if (player != null)
                {
                    player.SetActive(false);
                }
            }
            else
            {
                gameObject.GetComponent<NormalEnemyAI>().enabled = false;
                //Reset Attack
                // _drawLazer.lazerWidth = 0.5f;
            }
  
        }
    }
    
}
