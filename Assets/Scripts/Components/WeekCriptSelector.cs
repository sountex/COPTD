using System.Linq;
using UnityEngine;

/// <summary>
/// Компонент реализующий логику выбора самого слабого врага их доступных
/// </summary>
[DisallowMultipleComponent]
[AddComponentMenu("TDCore/TargetSelector/WeekCriptSelector")]
public class WeekCriptSelector : TargetSelector
{
    public override IHittable SelectTarger()
    {
        if (allEnemy.Count <= 0) return null;
        return allEnemy.OrderBy(enemy => enemy.HP).ToList()[0];
    }
}

