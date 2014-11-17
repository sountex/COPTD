public class KeepSelector : TargetSelector
{
    /// <summary>
    /// Переопределение логики добавления цели для атаки - проверка, что это Keep
    /// </summary>
    /// <param name="enemy"></param>
    public override void AddCript(IHittable enemy)
    {
        var go = enemy as HaveHitPoint;
        if (go.gameObject.tag != "Keep") return;
        allEnemy.Add(enemy);
    }

    /// <summary>
    /// Keep неподвижен и уйти не может
    /// </summary>
    /// <param name="enemy"></param>
    public override void RemoveCript(IHittable enemy)
    {
       
    }
}

