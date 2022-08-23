using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Serialization;

public class ReturnSwordSpecial : MonoBehaviour
{
    private Transform swordPos;
    [SerializeField] private float speed = 2;
    [SerializeField] private float acceleration = 1;
    [SerializeField] private float rotSpeed = 1;
    [SerializeField] private RotateSword _rotateSword;
    [SerializeField] private Attack attack;
     private Floater _floater;

     [FormerlySerializedAs("attackPos")] public GameObject attackPosEmpty;
     private Transform attackPos;
     public bool isAttacking;
     private Rigidbody2D _rigidbody2D;
     
    private void Start()
    {
        _floater = GetComponentInChildren<Floater>();
        swordPos = GameObject.Find("SwordPos").transform;
    }

    public void StartAttack()
    {
                //Look at cursor
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        Instantiate(attackPosEmpty, mousePosition, Quaternion.identity);
        attackPos = GameObject.FindWithTag("AttackPos").transform;
        //attackPos.right = -direction;
        _floater.enabled = false;
      StopAllCoroutines();
        //swordPos.transform.Rotate(0, 0, 60);
        isAttacking = true;
    }

    public void EndAttack()
    {
        if (attackPos != null)
        {
            Destroy(attackPos.gameObject);
        }
        isAttacking = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        speed += acceleration * Time.deltaTime;
        speed = Mathf.Clamp(speed, 0, 50);
        //TODO rework so that the move and rotation always take the same amount of time regardless of distance

        if (!isAttacking)
        {
            transform.position = Vector2.MoveTowards(transform.position, swordPos.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, swordPos.rotation, rotSpeed * Time.deltaTime);
        }

        //Sending object to empty and rotating it to attack
        if (isAttacking)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                _floater.enabled = false;
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                attackPos.position = new Vector3(mousePosition.x, mousePosition.y, attackPos.transform.position.z);
            }
            
           transform.position = Vector2.MoveTowards(transform.position, attackPos.position, speed * Time.deltaTime);
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, attackPos.rotation, rotSpeed * Time.deltaTime);

            Vector3 offset = attackPos.position - transform.position;

        // Construct a rotation as in the y+ case.
            Quaternion rotation = Quaternion.LookRotation(
                Vector3.forward,
                offset
            );

        // Apply a compensating rotation that twists x+ to y+ before the rotation above.

       
            //transform.rotation = rotation * Quaternion.Euler(0, 0, -90);

            if (transform.position == attackPos.position) 
            {
              //  print("rotatingEmpty");
              //  attackPos.Rotate(0, 0, -60);
              if (_floater.enabled == false)
              {
                  _floater.enabled = true;
              }

              //  StartCoroutine(EndAttack());
            }
            else
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation  * Quaternion.Euler(0, 0, -90), 2500/*speed*/ * Time.deltaTime);
            }
        }
        else if (transform.rotation == swordPos.rotation && _rotateSword.transform.rotation == _rotateSword.baseRotation)
        {
            _floater.enabled = true;
            //StopAllCoroutines();
           // StartCoroutine(enableFloater());
        }
        else
        {
            _floater.enabled = false;
        }

        IEnumerator EndAttack()
        {
            yield return new WaitForSeconds(0.3f);
            if (attackPos != null)
            {
                Destroy(attackPos.gameObject);
            }

            isAttacking = false;
            attack.enableActions(true);
        }
      
    }

    // void FixedUpdate()
    // {
    //     if (!isAttacking)
    //     {
    //         return;
    //     }
    //      _rigidbody2D.AddForce((attackPos.position - transform.position) * 15 );
    // }

    IEnumerator enableFloater()
    {
        yield return new WaitForSeconds(0.5f);
        _floater.enabled = true;
    }
}