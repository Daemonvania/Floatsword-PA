using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemyAI : MonoBehaviour
{
    public Sprite bodyMiddle;
    public Sprite handMiddle;
    
    public Sprite bodyRight;
    public Sprite handRight;
    
    public Sprite bodyLeft;
    public Sprite handLeft;
    
    [Space]
    public GameObject hand;
    public GameObject body;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
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
    }
}
