using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHUD : UnitHUD
{
    public EnemyBase EnemyBase => _unit as EnemyBase;
}
