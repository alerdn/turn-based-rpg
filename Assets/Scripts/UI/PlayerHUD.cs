using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : UnitHUD
{
    public Player Player => _unit as Player;

    [Header("Action")]
    [SerializeField] private Transform _actionContainer;
    [SerializeField] private Button _actionButton;

    [Header("Ability")]
    [SerializeField] private Transform _abilitiesContainer;
    [SerializeField] private Button _abilityButtonPrefab;

    public override void Init(UnitBase unit, UnitBase target)
    {
        base.Init(unit, target);
        _actionButton.onClick.AddListener(SwitchActions);

        foreach (AbilityBase ability in Player.Abilities)
        {
            // O player inicializa as habilidades aqui enquanto o inimigo inicializa na sua classe Base
            ability.Init(Player, _target, Player.OnAction);

            Button abilityButton = Instantiate(_abilityButtonPrefab, _abilitiesContainer);
            abilityButton.onClick.AddListener(() => UseAbility(ability));
            abilityButton.GetComponentInChildren<TMP_Text>().text = ability.name;
        }
    }

    public void HideUI()
    {
        _actionContainer.gameObject.SetActive(false);
    }

    public void ShowUI()
    {
        _actionButton.gameObject.SetActive(true);

        _abilitiesContainer.gameObject.SetActive(false);
        _actionContainer.gameObject.SetActive(true);
    }

    private IEnumerator DelayedAbility(Action callback, float delay)
    {
        yield return new WaitForSeconds(delay);
        callback();
    }

    private void SwitchActions()
    {
        _actionButton.gameObject.SetActive(false);
        _abilitiesContainer.gameObject.SetActive(true);
    }

    private void UseAbility(AbilityBase ability)
    {
        HideUI();
        StartCoroutine(DelayedAbility(() => ability.Use(), 2f));
    }
}
