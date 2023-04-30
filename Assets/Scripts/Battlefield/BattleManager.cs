using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : Static<BattleManager>
{
    public PlayerHUD PlayerHUD => _playerHUD;
    public EnemyHUD EnemyHUD => _enemyHUD;

    public Player Player => _player;
    public EnemyBase Enemy => _enemy;

    [Header("HUD")]
    [SerializeField] private PlayerHUD _playerHUD;
    [SerializeField] private EnemyHUD _enemyHUD;

    private int _stateIndex;
    private List<IBattleState> _states;

    private Player _player;
    private EnemyBase _enemy;

    private void Start()
    {
        _player = GameManager.Instance.Player;
        _enemy = GameManager.Instance.GetRandomEnemy();

        _player.Action += OnUnitAct;
        _enemy.Action += OnUnitAct;

        PlayerHUD.Init(_player, _enemy);
        EnemyHUD.Init(_enemy, _player);

        _stateIndex = 0;
        _states = new()
        {
            new PlayerState(),
            new EnemyState()
        };

        Initialize(_stateIndex);
    }

    private void OnDestroy()
    {
        _player.Action -= OnUnitAct;
        _enemy.Action -= OnUnitAct;
    }

    private void Initialize(int index)
    {
        _stateIndex = index;
        _states[_stateIndex].Enter();
    }

    private void ChangeState(int index)
    {
        _states[_stateIndex].Exit();
        Initialize(index);
    }

    private void OnUnitAct()
    {
        int nextIntex = _stateIndex + 1;

        if (nextIntex >= _states.Count)
        {
            nextIntex = 0;
        }

        ChangeState(nextIntex);
    }
}