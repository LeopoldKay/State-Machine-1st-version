using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public bool IsEmpty { get; private set; }

    void Start()
    {
        IsEmpty = true;
    }

    private void OnTriggerStay(Collider other)
    {
        IsEmpty = false;
    }

    private void OnTriggerExit(Collider other)
    {
        IsEmpty = true;
    }
}
