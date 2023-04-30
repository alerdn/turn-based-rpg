using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBase : MonoBehaviour, IDamageable, IUnit
{
    public event Action OnHPChanged;
    public event Action Action;

    public float MaxHP => _unitData.MaxHP;
    public float CurrentHP { get => _currentHP; private set => _currentHP = value; }
    public float Power => _unitData.BasePower;
    public List<AbilityBase> Abilities => _unitData.Abilities;

    [SerializeField] private ScriptableUnit _unitData;

    private float _currentHP;

    private void Awake()
    {
        _currentHP = MaxHP;
    }

    public void OnAction()
    {
        Action?.Invoke();
    }

    public virtual void Attack(IDamageable target)
    {
        target.Damage(Power);
        Debug.Log($"Striked the {target} with {Power} power!");
    }

    public virtual void Damage(float damage)
    {
        CurrentHP -= damage;
        OnHPChanged?.Invoke();
    }

    public virtual void Heal(float Heal)
    {
        CurrentHP += Heal;
        if (CurrentHP > MaxHP) CurrentHP = MaxHP;
        OnHPChanged?.Invoke();
    }
}
