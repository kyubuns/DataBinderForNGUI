using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BasicViewModel : MonoBehaviour
{
  [SerializeField] List<ReferenceModel> views;
  RPGBattleStateModel model;

  void Awake()
  {
    var playerModel = new RPGStatusModel("kyubuns", 10, 20, 5);
    var enemyModel  = new RPGStatusModel("Teki",    15, 25, 100);
    model = new RPGBattleStateModel(playerModel, enemyModel);
    BinderTools.ApplyModel(views, model);
  }
}
