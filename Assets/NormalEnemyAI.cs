using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemyAI : MonoBehaviour
{
    public GameObject torso;

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
       torso.transform.right = direction;
    }
}
