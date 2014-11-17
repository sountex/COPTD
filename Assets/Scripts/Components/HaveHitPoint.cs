using UnityEngine;

/// <summary>
/// Компонент применяющий к себе урон
/// </summary>
[RequireComponent(typeof(IDamageDealer))]
public class HaveHitPoint : MonoBehaviour, IHittable
{
    [SerializeField]
    private int _hp;

    private int _maxHP;

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
        _applyingDamage = this.GetComponent<IDamageDealer>();
        _maxHP = _hp;
    }
    /// <summary>
    /// Нанесения урона цели через IApplyingDamage
    /// </summary>
    /// <param name="dmgValue"></param>
    public void ImpactDamage(int dmgValue)
	{
        if (IsDead) return;
        _hp = _applyingDamage.ImpactDamage(_hp, dmgValue);
        VisualizeImpactDamage();
        if (IsDead)
        {
            SendMessage("HaveHitPointIsDead", SendMessageOptions.DontRequireReceiver);
            //Отключим рендер и отметим объект для юнити на удаление
            GetComponent<Renderer>().enabled = false;
            Destroy(gameObject);
        }
	}

    //Пример визуализация получения урона
    private void VisualizeImpactDamage()
    {
        if (_hp < _maxHP/4)//Присмерти
            GetComponent<SpriteRenderer>().color = Color.red;
    }

}

