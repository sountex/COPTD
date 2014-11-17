using System.Linq;
/// <summary>
/// Компонент реализующий логику выбора самого слабого врага их доступных
/// </summary>
public class WeekCriptSelector : TargetSelector
{
    public override IHaveHitPoint SelectTarger()
    {
        if (allEnemy.Count > 0) 
            return allEnemy.OrderBy(enemy => enemy.HP).ToList()[allEnemy.Count];

        return null;
    }
}

