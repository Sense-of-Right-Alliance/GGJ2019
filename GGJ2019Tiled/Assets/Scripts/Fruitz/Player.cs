using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Fruitz;
using UnityEngine;

public class Player : MonoBehaviour
{
    enum PlayerState { Waiting, Invading, Placing };
    
    public GameObject TurretPlacementPrefab;

    public Transform[] entrances;

    PlayerState state = PlayerState.Waiting;
    
    private Invader invader;
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
        Vector3 position = Vector3.zero;
        if (entrances.Length > 0)
        {
            position = entrances[Mathf.Min(Random.Range(0, entrances.Length))].position;
        }
        //invader = GameManager.SpawnInvader();
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
    }

    public void HandleEnterGoalRegion()
    {
        //guardian = GameManager.SpawnGuardian(invader.identity);
        turretPlacer = Instantiate<GameObject>(TurretPlacementPrefab, Vector3.zero, Quaternion.identity).GetComponent<TurretPlacementController>();

        turretPlacer.StartPlacement(guardian);

        state = PlayerState.Placing;
    }

    void UpdatePlacing()
    {
        Vector2 input = Vector2.zero;
        // get input
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");

        turretPlacer.UpdatePlacement(input);
    }
}
