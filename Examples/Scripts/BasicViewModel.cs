using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace DataBinderForNGUI.Example
{

public class BasicViewModel : MonoBehaviour
{
  [SerializeField] List<ReferenceModel> views;
  RPGStatusModel model;

  void Awake()
  {
    model = new RPGStatusModel("kyubuns", 10, 20, 5);
    BinderTools.ApplyModel(views, model);
  }
}

}
