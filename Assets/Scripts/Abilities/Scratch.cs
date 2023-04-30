using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Scratch")]
public class Scratch : AbilityBase
{
    public override void Use()
    {
        _target.Damage(_actor.Power + Power);
        _onFinishAbility?.Invoke();
    }
}
