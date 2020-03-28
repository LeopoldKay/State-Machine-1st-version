using Assets.Scripts.System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystemLogic : MonoBehaviour
{
    public int HealthPoint = 100;

	public bool DealDamage(int damage)
	{
		bool result = false;
		//post DealDamage Event
		HealthPoint -= damage;

		if (HealthPoint <= 0)
		{
			HealthPoint = 0;
			result = true;
		}

		PostHealthChangeEvent(HealthPoint);
		return result;
	}

	private void PostHealthChangeEvent(int healthPoint)
	{
		EventAggregator.Post<HealthPointChangeEvent>(this, new HealthPointChangeEvent() { HealthPoint = healthPoint });
	}
}
