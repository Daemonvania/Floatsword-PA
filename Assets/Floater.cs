using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Makes objects float up & down while gently spinning.
public class Floater : MonoBehaviour
{
    [Range(-1f, 1f)]
    public float horizontalSpeed;
    [Range(0, 5)]
    public float verticalSpeed;
    [Range(0, 2)]
    public float amplitude;

    public float time = 0;
    private Vector3 originalPos;
    private Vector3 tempPosition;

    //TODO Fix problem with not staying in same spot, lock it in a specific position maybe
    void Start()
    {
        tempPosition = originalPos = transform.position;
    }

    void Update()
    {
        time += Time.deltaTime;
        transform.position += new Vector3(0,amplitude * Mathf.Sin(time * verticalSpeed));
            
        float differential = (3 * Mathf.Cos(3 * time))/2000;
        float roundedDiff = Mathf.Round(differential * 10000) / 10000;
        if (roundedDiff == 0)  
       {
            
          //   print( transform.position.y.ToString("F2") );
       }

       // print((3 * Mathf.Cos(3 * time)) / 2000);
    }

    private void OnEnable()
    {
        print("fixingPos");
        time = 0;
        transform.localPosition = new Vector3(0, 0, 0);
    }
}