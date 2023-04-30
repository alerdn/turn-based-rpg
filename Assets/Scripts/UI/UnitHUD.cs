using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UnitHUD : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private TMP_Text _hpText;

    protected UnitBase _unit;
    protected UnitBase _target;

    public virtual void Init(UnitBase unit, UnitBase target)
    {
        _unit = unit;
        _target = target;

        _unit.OnHPChanged += UpdateHUD;
        UpdateHUD();
    }

    private void UpdateHUD()
    {
        _hpText.text = $"{_unit.CurrentHP}/{_unit.MaxHP}";
    }
}
