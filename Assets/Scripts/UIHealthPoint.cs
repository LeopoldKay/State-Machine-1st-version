using Assets.Scripts.System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIHealthPoint : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _healthPointText;

	public void EventHandler(int healthPoint)
	{
		throw new System.NotImplementedException();
	}

	void Start()
	{
		EventAggregator.Subscribe<HealthPointChangeEvent>(HealthpointChangedHandler);
	}

	private void HealthpointChangedHandler(object arg1, HealthPointChangeEvent arg2)
	{
		_healthPointText.SetText(arg2.HealthPoint.ToString());
	}

	private void OnDestroy()
	{
		EventAggregator.Unsubscribe<HealthPointChangeEvent>(HealthpointChangedHandler);
	}
}
