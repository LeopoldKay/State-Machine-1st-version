using Assets.Scripts.System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayBehaviour : MonoBehaviour
{
    [SerializeField] private HumanBehaviour _humanPrefab;
   // [SerializeField] private Camera _helpCamera;

    private HumanBehaviour _humanBehaviour;


    void Start()
    {
        EventAggregator.Subscribe<GameStartEvent>(OnGameStartHandler);
        EventAggregator.Subscribe<SpawnButtonClickEvent>(OnSpawnPlayerButtonClickHandler);
    }

    private void OnGameStartHandler(object sender, GameStartEvent gameStartEvent)
    {
      //  _helpCamera.gameObject.SetActive(false);
        SpawnPlayer();
    }

    private void OnSpawnPlayerButtonClickHandler(object sender, SpawnButtonClickEvent spawnButtonClickEvent)
    {
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        if (_humanBehaviour == null)
        {
            _humanBehaviour = Instantiate(_humanPrefab);
        }

        var spawnPoint = MainGameDataHolder.HumanSpawnPoints.GetFreeSpawnPoint();
        _humanBehaviour.transform.position = spawnPoint.transform.position;
        _humanBehaviour.transform.rotation = spawnPoint.transform.rotation;
    }
}
