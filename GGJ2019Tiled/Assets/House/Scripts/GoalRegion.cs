using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalRegion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // when the GameObjects collider arrange for this GameObject to travel to the left of the screen
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Goal Region Entered!");
    }
}
