using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AmmunitionSpawnBehaviour : MonoBehaviour
{
    [SerializeField] private List<AmmunitionPack> _ammunitionPackListPrefab;
    [SerializeField] private MinMaxFloat _timeAppearDelay;
    private Tween _delayTween;
    private float _delayTimeCounter = 0f;

    void Start()
    {
        CheckForSpawnPoint();
    }

    private void CheckForSpawnPoint()
    {
        Debug.Log("[CheckForSpawnPoint] OK");

        if (_delayTween != null)
            _delayTween.onComplete -= CheckForSpawnPoint;

        var spawnPoint = MainGameDataHolder.AmminitionSpawnPoints.GetFreeSpawnPoint();
        if (spawnPoint == null)
        {
            StartDelay();
            return;
        }

        AddAmmunition(spawnPoint);
    }
    private void StartDelay()
    {
        _delayTimeCounter = 0f;
        var duration = _timeAppearDelay.GetRandom();
        _delayTween = DOTween.To(() => _delayTimeCounter, newValue => _delayTimeCounter = newValue, duration, duration);
        _delayTween.onComplete += CheckForSpawnPoint;
    }

    private void AddAmmunition(SpawnPoint spawnPoint)
    {

        var index = UnityEngine.Random.Range(0, _ammunitionPackListPrefab.Count);
        var prefab = _ammunitionPackListPrefab[index];

        var ammunition = Instantiate(prefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
        ammunition.transform.SetParent(transform, true);
        StartDelay();
    }
}



[Serializable]
public class MinMaxInt
{
    public int Min;
    public int Max;

    public int GetRandom()
    {
        return UnityEngine.Random.Range(Min, Max);
    }
}

[Serializable]
public class MinMaxFloat
{
    public float Min;
    public float Max;

    public float GetRandom()
    {
        return UnityEngine.Random.Range(Min, Max);
    }
}
