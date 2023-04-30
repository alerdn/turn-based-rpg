using System;

public interface IAbility
{
    void Use(UnitBase actor, IDamageable target, Action callback);
}
