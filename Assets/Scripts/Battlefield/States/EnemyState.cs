public class EnemyState : IBattleState
{
    public void Enter()
    {
        BattleManager.Instance.Enemy.HandleAction(BattleManager.Instance.Player);
    }

    public void Exit()
    {
    }
}