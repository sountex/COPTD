﻿using UnityEngine;
/// <summary>
/// Компонент применяющий урон
/// </summary>
public class ApplyingDamage : MonoBehaviour, IApplyingDamage
{
    /// <summary>
    /// Простая логика применения урона
    /// </summary>
    /// <param name="currentHP">Текущее значение HP</param>
    /// <param name="value">Количество урона</param>
    /// <returns></returns>
	public int ImpactDamage(int currentHP, int value)
	{
	   var result = currentHP - value;
	   return result;
	}

}
