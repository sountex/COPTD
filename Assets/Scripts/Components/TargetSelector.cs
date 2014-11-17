using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Базовый компонент выбора врага для атаки, с дефолтной реализацией
/// </summary>
public class TargetSelector : MonoBehaviour, ITargetSelector
{
    protected List<IHittable> allEnemy;
    
    public void Awake()
    {
        allEnemy = new List<IHittable>();
    }

    /// <summary>
    /// Обработка события добавления врага в список возможных целей
    /// </summary>
    /// <param name="enemy"></param>
    public virtual void AddCript(IHittable enemy)
    {
        var go = enemy as HaveHitPoint;
        if (go.gameObject.tag != "Enemy") return;
        allEnemy.Add(enemy);
    }

    /// <summary>
    /// Обработка события удаления врага из списока возможных целей
    /// </summary>
    /// <param name="enemy"></param>
    public virtual void RemoveCript(IHittable enemy)
    {
        allEnemy.Remove(enemy);
    }

    /// <summary>
    /// Логика выбор цели для атаки. 
    /// <remarks>Подефолту - первая цель в списке</remarks>
    /// </summary>
    /// <returns>null, если не найдена подходящая цель</returns>
    public virtual IHittable SelectTarger()
    {
        return allEnemy.Count > 0 ? allEnemy[0] : null;
    }
}

