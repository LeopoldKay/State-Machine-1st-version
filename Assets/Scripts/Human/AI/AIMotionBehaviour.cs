using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMotionBehaviour : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private LayerMask _layerMask;

    private float _attackRange = 3f;
    private float _rayDistance = 5.0f;
    private float _stoppingDistance = 1.5f;

    private Vector3 _destination;
    private Quaternion _desiredRotation;
    private Vector3 _direction;

    Quaternion startingAngle = Quaternion.AngleAxis(-60, Vector3.up);
    Quaternion stepAngle = Quaternion.AngleAxis(5, Vector3.up);

    public void SetTarget(Vector3 position)
    {
        _agent.SetDestination(position);
    }

    void Update()
    {
        var targetToAggro = CheckForAggro();
    }

    private Transform CheckForAggro()
    {
        Debug.DrawLine(transform.position, _destination, Color.blue);
        float aggroRadius = 5f;

        RaycastHit hit;
        var angle = transform.rotation * startingAngle;
        var direction = angle * Vector3.forward;
        var pos = transform.position;
        for (var i = 0; i < 72; i++)
        {
            if (Physics.Raycast(pos, direction, out hit, aggroRadius))
            {
                var human = hit.collider.GetComponent<HumanBehaviour>();
                if (human != null)
                {
                    Debug.DrawRay(pos, direction * hit.distance, Color.red);
                    return human.transform;
                }
                else
                {
                    Debug.DrawRay(pos, direction * hit.distance, Color.yellow);
                }
            }
            else
            {
                Debug.DrawRay(pos, direction * aggroRadius, Color.white);
            }
            direction = stepAngle * direction;
        }

        return null;
    }
}
