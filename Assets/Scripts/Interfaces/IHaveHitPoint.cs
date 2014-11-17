public interface IHaveHitPoint
{
	int HP { get; }

	bool IsDead { get; }

	void ImpactDamage(int dmgValue);

}

