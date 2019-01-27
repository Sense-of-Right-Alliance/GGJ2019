using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPlacementController : MonoBehaviour
{
    enum PlacementState { None, Positioning, Rotating };

    public float placeSpeed = 7.0f;

    private PlacementState state = PlacementState.None;

    //Guardian guardian;
    //RigidBody2d gBod;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartPlacement(/*Guardian g*/)
    {
        //guardian = g;
        Debug.Log("TurretPlacementController -> Starting Placement!");

        state = PlacementState.Positioning;
    }

    public void UpdatePlacement(Vector2 input)
    {
        switch(state)
        {
            case (PlacementState.Positioning):
                UpdatePositioning(input);
                break;
            case (PlacementState.Rotating):
                UpdateRotating(input);
                break;
        }
    }

    void UpdatePositioning(Vector2 input)
    {
        // move it
        Vector2 force = input * placeSpeed;


        //gBod.velocity = new Vector2(Mathf.Lerp(0, Input.GetAxis("Horizontal") * placeSpeed, 0.8f),
        //                                        Mathf.Lerp(0, Input.GetAxis("Vertical") * placeSpeed, 0.8f));
    }

    void UpdateRotating(Vector2 input)
    {
        // rotate to look direction 
        Vector3 look = new Vector3(input.x, input.y, 0.0f);

        float rot_z = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }
}
