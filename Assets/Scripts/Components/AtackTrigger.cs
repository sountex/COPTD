﻿using UnityEngine;
/// <summary>
/// Компонент реагирующий на OnTriggerEnter2D/OnTriggerExit2D для инициализации выбора врага для атаки
/// </summary>
[RequireComponent(typeof(Rigidbody2D), typeof(IInflictDamage), typeof(ITargetSelector))]
public class AtackTrigger : MonoBehaviour
{
    private IInflictDamage _damager;
    private ITargetSelector _targetSelector;

    public void Awake()
    {
        _damager = this.GetComponent<IInflictDamage>();
        _targetSelector = this.GetComponent<ITargetSelector>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        var enemy = other.GetComponent<IHaveHitPoint>();
        if (enemy == null) return;
        SendMessage("AddCript", enemy);
        TrySelectTarget();
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        var enemy = other.GetComponent<IHaveHitPoint>();
        if (enemy == null) return;
        SendMessage("RemoveCript", enemy);
        _damager.EndDPS();
    }

    /// <summary>
    /// Выбираем и атакуем врага, если можно выбрать врага.
    /// <remarks>Выбора врага через ITargetSelector</remarks> 
    /// </summary>
    private void TrySelectTarget()
    {
        var enemy = _targetSelector.SelectTarger();
        if (enemy == null) return;
        _damager.BeginDPS(enemy);
    }
    /// <summary>
    /// Обработка события когда нужна новая цель для атаки
    /// </summary>
    public void CurrentTargetLose(IHaveHitPoint _target)
    {
        SendMessage("RemoveCript", _target);
        TrySelectTarget();
    }
}
