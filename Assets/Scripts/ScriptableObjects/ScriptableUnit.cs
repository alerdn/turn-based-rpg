using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Unit", menuName = "Units/New Unit")]
public class ScriptableUnit : ScriptableObject
{
    public float MaxHP;
    public int BasePower;
    public List<AbilityBase> Abilities;
}
