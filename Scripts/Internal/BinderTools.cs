using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class BinderTools
{
  public static void ApplyModel(IEnumerable<ReferenceModel> views, DataBinderForNGUI.Model model)
  {
    foreach(var view in views) view.Model = model;
  }
}
