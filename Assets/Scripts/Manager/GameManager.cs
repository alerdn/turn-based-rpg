using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Static<GameManager>
{
    public Player Player => _player;

    [SerializeField] private Player _player;
    [SerializeField] private GameObject _enemiesParent;
    [SerializeField] private List<EnemyBase> _enemies;

    private void Start()
    {
        _enemies = _enemiesParent.GetComponentsInChildren<EnemyBase>().ToList();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.UnloadSceneAsync(1);
        }
    }

    public void StartBattle()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
    }

    public EnemyBase GetRandomEnemy()
    {
        return _enemies[Random.Range(0, _enemies.Count)];
    }
}
