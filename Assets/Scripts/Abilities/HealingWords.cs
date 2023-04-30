using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Healing Words")]
public class HealingWords : AbilityBase
{
    public override void Use()
    {
        _actor.Heal(Power);
        _onFinishAbility?.Invoke();
    }
}
