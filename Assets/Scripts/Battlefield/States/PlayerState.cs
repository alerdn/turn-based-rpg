public class PlayerState : IBattleState
{
    public void Enter()
    {
        BattleManager.Instance.PlayerHUD.ShowUI();
    }

    public void Exit()
    {
    }
}