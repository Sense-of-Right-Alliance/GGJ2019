using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPlacementController
{
    enum PlacementState { None, Positioning, Rotating };

    public float placeSpeed = 7.0f;
    public float rotateSpeed = 7.0f;

    private PlacementState state = PlacementState.None;

    Player player;
    Guardian guardian;
    Rigidbody2D gBod;

    Vector2 currentDir = Vector2.left;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartPlacement(Guardian g, Player p)
    {
        //Debug.Log("TurretPlacementController -> Starting Placement!");

        player = p;
        guardian = g;
        gBod = guardian.GetComponent<Rigidbody2D>();

        state = PlacementState.Positioning;
    }

    public void UpdatePlacement(Vector2 input, float deltaTime)
    {
        switch(state)
        {
            case (PlacementState.Positioning):
                UpdatePositioning(input);
                break;
            case (PlacementState.Rotating):
                UpdateRotating(input, deltaTime);
                break;
        }
    }

    void UpdatePositioning(Vector2 input)
    {
        // move it
        Vector2 force = input * placeSpeed;

        gBod.velocity = new Vector2(Mathf.Lerp(0, Input.GetAxis("Horizontal") * placeSpeed, 0.8f),
                                                Mathf.Lerp(0, Input.GetAxis("Vertical") * placeSpeed, 0.8f));

        if (input.magnitude > 0.01f) // only change direction if has input
        {
            // rotate to look direction 
            Vector3 look = new Vector3(input.x, input.y, 0.0f);

            float rot_z = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg;
            guardian.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

            currentDir = input;
        }

        // TODO: Don't collide with projectiles

    }

    void UpdateRotating(Vector2 input, float deltaTime)
    {
        // TODO: Rotate towards direction, not by look

        float amount = rotateSpeed * input.x * -1; 

        guardian.transform.RotateAround(guardian.transform.position, guardian.transform.forward, amount);

        /*
        // rotate to look direction 
        Vector3 look = new Vector3(input.x, input.y, 0.0f);

        float rot_z = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg;
        guardian.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
            
        currentDir = input;
        */

        currentDir = guardian.transform.up;
    }

    public void HandleAccept()
    {
        switch (state)
        {
            case (PlacementState.Positioning):
                guardian.GetComponent<Collider2D>().enabled = false;
                gBod.velocity = Vector2.zero;

                state = PlacementState.Rotating;
                break;
            case (PlacementState.Rotating):
                guardian.SetDirection(currentDir.normalized);

                state = PlacementState.None;
                player.DonePlacement();
                break;
        }
    }
}
