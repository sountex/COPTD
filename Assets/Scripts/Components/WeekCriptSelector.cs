using System.Linq;
/// <summary>
/// Компонент реализующий логику выбора самого слабого врага их доступных
/// </summary>
public class WeekCriptSelector : TargetSelector
{
    public override IHittable SelectTarger()
    {
        if (allEnemy.Count <= 0) return null;
        return allEnemy.OrderBy(enemy => enemy.HP).ToList()[0];
    }
}

