using UnityEngine;
using System.Collections;
 
public class DrawLazer : MonoBehaviour {
 
    public GameObject gameObject1;          // Reference to the first GameObject
    private GameObject gameObject2;          // Reference to the second GameObject


    [HideInInspector] public float lazerWidth = 0.001f;
    private LineRenderer line;                           // Line Renderer
 
    // Use this for initialization
    void Start () {
        gameObject2 = GameObject.FindWithTag("Player");
        // Add a Line Renderer to the GameObject
        line = gameObject.AddComponent<LineRenderer>();
        // Set the width of the Line Renderer
        lazerWidth = 0.5f;
        // Set the number of vertex fo the Line Renderer
        line.SetVertexCount(2);
        
        line.startColor = Color.red;
        line.endColor = Color.red;
    }
     
    // Update is called once per frame
    void Update () {
        // Check if the GameObjects are not null
        if (gameObject1 != null && gameObject2 != null)
        {
            // Update position of the two vertex of the Line Renderer
            line.SetPosition(0, gameObject1.transform.position);
            line.SetPosition(1, gameObject2.transform.position);
        }

        line.startWidth = lazerWidth;
        line.endWidth = lazerWidth;
    }
}