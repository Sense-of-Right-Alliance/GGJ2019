using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum PlayerState { Waiting, Invading, Placing };
    
    public GameManager GameManager { get; set; }

    public PlayerState State
    {
        get { return state; }
    }

    PlayerState state = PlayerState.Waiting;
    
    private Invader invader;
    private Guardian guardian;
    private TurretPlacementController turretPlacer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (state)
        {
            case PlayerState.Waiting:
                UpdateWaiting();
                break;
            case PlayerState.Invading:
                UpdateInvading();
                break;
            case PlayerState.Placing:
                UpdatePlacing();
                break;
        }
    }

    void UpdateWaiting()
    {
        // wait for player join
        if (Input.GetButton("Jump"))
        {
            NewIdentity();
            state = PlayerState.Invading; // move to next state
        }
    }

    void NewIdentity()
    {
        invader = GameManager.SpawnInvader();
        invader.SetPlayer(this);
    }

    void UpdateInvading()
    {
        Vector2 move = Vector2.zero;
        // get input
        move.x = Input.GetAxis("Horizontal");
        move.y = Input.GetAxis("Vertical");

        invader.UpdateMovement(move);
    }

    public void HandleInvaderKilled()
    {
        state = PlayerState.Waiting;

        Destroy(invader.gameObject);
    }

    public void HandleEnterGoalRegion()
    {
        guardian = GameManager.SpawnGuardian(invader.Identity);

        Destroy(invader.gameObject);

        turretPlacer = new TurretPlacementController();

        turretPlacer.StartPlacement(guardian, this);

        state = PlayerState.Placing;
    }

    void UpdatePlacing()
    {
        Vector2 input = Vector2.zero;
        // get input
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");

        turretPlacer.UpdatePlacement(input, Time.deltaTime);

        if (Input.GetButtonUp("Jump"))
        {
            turretPlacer.HandleAccept();
        }
    }

    public void DonePlacement()
    {
        state = PlayerState.Waiting;
    }
}
