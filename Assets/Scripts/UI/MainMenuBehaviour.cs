using Assets.Scripts.System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuBehaviour : MonoBehaviour
{
    [SerializeField] private Button _startGameButton;
    [SerializeField] private Button _spawnPlayerButton;
    //[SerializeField] private Image _crosshair;
    [SerializeField] private GameObject[] _needActivateOnStart;
    [SerializeField] private GameObject[] _needDeaactivateOnStart;


    // Start is called before the first frame update
    void Start()
    {
        _spawnPlayerButton.gameObject.SetActive(false);
        _spawnPlayerButton.onClick.AddListener(OnSpawnButtonClickHandler);
        _startGameButton.onClick.AddListener(OnStartButtonClickHandler);

        EventAggregator.Subscribe<WeaponAddedEvent>(OnWeaponAddedHandler);

    }

    private void OnSpawnButtonClickHandler()
    {
        EventAggregator.Post(this, new SpawnButtonClickEvent());
    }

    private void OnStartButtonClickHandler()
    {
        OnGameStart();
        EventAggregator.Post(this, new GameStartEvent());
    }

    private void OnGameStart()
    {
        DeactivateOnStart();
        ActivateOnStart();

        _startGameButton.gameObject.SetActive(false);
        _spawnPlayerButton.gameObject.SetActive(true);
    }

    private void DeactivateOnStart()
    {
        foreach (var item in _needDeaactivateOnStart)
        {
            item.SetActive(false);
        }
    }

    private void ActivateOnStart()
    {
        foreach (var item in _needActivateOnStart)
        {
            item.SetActive(true);
        }
    }

    private void OnWeaponAddedHandler(object sender, WeaponAddedEvent WeaponAddedEvent)
    {
        if (WeaponAddedEvent.Owner.Human.HumanType == ControllingType.AI)
            return;
        var crossHairData = MainGameDataHolder.GetWeaponCrosshairData(WeaponAddedEvent.Weapon.WeaponType);
        //_crosshair.sprite = crossHairData.Crosshair;
       // _crosshair.gameObject.SetActive(true);
    }
}
