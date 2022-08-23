using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RotateSword : MonoBehaviour
{
    [HideInInspector] public bool isShowingRotation = false;
    [HideInInspector] public bool ignoreParentRot = false;  
    
    public GameObject sword;
    public GameObject slash;

    public Transform swordPos;
    public Quaternion baseRotation;
    
    // Start is called before the first frame update
    private void Start()
    {
        baseRotation = transform.rotation;
        sword.transform.position = swordPos.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (ignoreParentRot)
        {
         //   transform.rotation = Quaternion.identity;
        }
        if (isShowingRotation)
        {
            RotateToCursor();
        }
    }
    
    public void Attack()
    {
        //TODO rework so you can attack up to a certain Range ourside the player, at any point in that space. 
        // RotateToCursor();
        // Instantiate(slash, sword.transform.position, new Quaternion(transform.rotation.x , transform.rotation.y, transform.rotation.z + 90, 0));
        // StartCoroutine(EndAttack());
    }
    private void RotateToCursor()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        transform.up = direction;
    }
    // public IEnumerator EndAttack()
    // {
    //     yield return new WaitForSeconds(0.3f);
    //     sword.transform.position = swordPos.position;
    //     transform.rotation = baseRotation;
    // }
}
