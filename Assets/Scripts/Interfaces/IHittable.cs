public interface IHittable 
{
	int HP { get; }

	bool IsDead { get; }

	void ImpactDamage(int dmgValue);

}

