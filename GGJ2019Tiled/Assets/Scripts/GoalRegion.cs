using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalRegion : MonoBehaviour
{
    public TurretPlacementController placementController;

    private void Awake()
    {
        if (placementController == null)
        {
            placementController = GameObject.Find("Turret Placement Controller").GetComponent<TurretPlacementController>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // when the GameObjects collider arrange for this GameObject to travel to the left of the screen
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player") // Player
        {
            Debug.Log("Goal Region Entered!");

            placementController.StartPlacement(); //col.gameObject.GetComponent<PlayerFruitPerson_v1>());
        }
    }
}
