using UnityEngine;

public class RPGBattleStateModel : DataBinderForNGUI.Model
{
  public RPGBattleStateModel(RPGStatusModel player, RPGStatusModel enemy)
  {
    this.Player = player;
    this.Enemy = enemy;
  }

  private RPGStatusModel player;
  public RPGStatusModel Player
  {
    get { return player; }
    set { player = value; Changed("Player"); }
  }

  private RPGStatusModel enemy;
  public RPGStatusModel Enemy
  {
    get { return enemy; }
    set { enemy = value; Changed("enemy"); }
  }
}
