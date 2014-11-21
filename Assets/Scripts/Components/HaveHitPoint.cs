using UnityEngine;

/// <summary>
/// Компонент применяющий к себе урон
/// </summary>
[RequireComponent(typeof(IDamageDealer))]
public class HaveHitPoint : MonoBehaviour, IHittable
{
    [SerializeField]
    private int _hp = 100;
    
    /// <summary>
    /// Количество очков жизни
    /// </summary>
    public int HP { get { return _hp; } }
    /// <summary>
    /// Проверка условия смерти
    /// </summary>
    public bool IsDead 
    {
        get { return _hp <= 0; }
    }

    private IDamageDealer _applyingDamage;

    public void Awake()
    {
        _applyingDamage = this.GetComponent<ApplyingDamage>();
    }
    /// <summary>
    /// Нанесения урона цели через IApplyingDamage
    /// </summary>
    /// <param name="dmgValue"></param>
    public void ImpactDamage(int dmgValue)
	{
        if (IsDead) return;
        _hp = _applyingDamage.ImpactDamage(_hp, dmgValue);
        if (IsDead)
        {
            SendMessage("HaveHitPointIsDead", SendMessageOptions.DontRequireReceiver);
            //отметим объект для юнити на удаление
            Destroy(gameObject);
        }
        else
            SendMessage("HaveHitPointIsDamaged", SendMessageOptions.DontRequireReceiver);
	}

}

