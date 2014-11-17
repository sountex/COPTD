public interface IInflictDamage  
{
	int DamageValue { get; }

    float Cooldown { get; }

    void BeginDPS(IHittable target);

	void EndDPS();

}

