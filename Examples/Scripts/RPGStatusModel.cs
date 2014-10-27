using UnityEngine;

namespace DataBinderForNGUI.Example
{

public class RPGStatusModel : DataBinderForNGUI.Model
{
  public RPGStatusModel(string name, int hp, int mp, int attack)
  {
    this.Name = name;
    this.HP = hp;
    this.MP = mp;
    this.Attack = attack;
  }

  private string name;
  public string Name { get { return name; } set { name = value; Changed("Name"); } }

  private int hp;
  public int HP { get { return hp; } set { hp = Mathf.Max(0, value); Changed("HP"); } }

  private int mp;
  public int MP { get { return mp; } set { mp = Mathf.Max(0, value); Changed("MP"); } }

  private int attack;
  public int Attack { get { return attack; } set { attack = value; Changed("Attack"); } }

  public void Damage()
  {
    HP--;
    HP--; // 2回値をいじっても、Updateは1フレームに1回しか呼ばれない
    Debug.Log(string.Format("Damage HP:{0}", HP));
  }
}

}
