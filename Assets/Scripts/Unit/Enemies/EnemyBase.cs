using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : UnitBase
{
    public void HandleAction(UnitBase player)
    {
        Debug.Log($"{name} is choosing its action...");
        StartCoroutine(DelayedAction(callback: () =>
         {
             AbilityBase ability = Abilities[UnityEngine.Random.Range(0, Abilities.Count)];
             Debug.Log(ability);

             // Os inimigos inicianm suas habilidades aqui enquanto o player inicializa no seu HUD
             ability.Init(this, player, OnAction);
             ability.Use();
         }, delay: 2f));
    }

    private IEnumerator DelayedAction(Action callback, float delay)
    {
        yield return new WaitForSeconds(delay);
        callback();
    }
}
