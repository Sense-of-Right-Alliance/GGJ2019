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
}
