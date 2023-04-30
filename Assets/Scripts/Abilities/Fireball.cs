using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Fireball")]
public class Fireball : AbilityBase
{
    public override void Use()
    {
        _target.Damage(_actor.Power + Power);
        _onFinishAbility?.Invoke();
    }
}
