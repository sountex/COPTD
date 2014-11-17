public interface IInflictDamage 
{
	int DamageValue { get; }

    float Cooldown { get; }

	void BeginDPS(IHaveHitPoint Target);

	void EndDPS();

}

