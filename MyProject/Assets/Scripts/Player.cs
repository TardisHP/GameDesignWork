using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerStateMachine stateMachine { get; private set; }

    public void Awake()
    {
        stateMachine = new PlayerStateMachine();
    }

    private void Start()
    {
        //stateMachine.Initialize(idleState??);
    }


    void Update()
    {
        stateMachine.currentState.Update();

        // move
    }
}


