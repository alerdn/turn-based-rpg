using System;
using UnityEngine;

public class AbilityBase : ScriptableObject
{
    public int Power;

    protected UnitBase _actor, _target;
    protected Action _onFinishAbility;

    public virtual void Init(UnitBase actor, UnitBase target, Action OnFinishAbility)
    {
        _actor = actor;
        _target = target;
        _onFinishAbility = OnFinishAbility;
    }

    public virtual void Use() { }
}
