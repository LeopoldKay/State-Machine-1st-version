using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

public class AIStateMachineConfigurator : MonoBehaviour
{
    private FiniteStateMachine<AISharedContexts> _finiteStateMachine;
    private AISharedContexts _aISharedContexts;

    void Start()
    {
        _finiteStateMachine = new FiniteStateMachine<AISharedContexts>();
        CreateSharedContext();
        AddNecessaryStates();
        _finiteStateMachine.Switch(typeof(IdleState));
    }

    private void CreateSharedContext()
    {
        var human = GetComponent<HumanBehaviour>();
        var shootable = GetComponent<ShootableComponent>();
        var motion = GetComponent<AIMotionBehaviour>();
        _aISharedContexts = new AISharedContexts() { Human = human, Shootable = shootable, MotionBehaviour = motion };
    }

    private void AddNecessaryStates()
    {
        _finiteStateMachine.AddState(new IdleState(_aISharedContexts));
        _finiteStateMachine.AddState(new FindWeaponState(_aISharedContexts));
        _finiteStateMachine.AddState(new FindEnemyState(_aISharedContexts));
    }
}
