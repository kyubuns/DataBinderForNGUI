using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class BinderTools
{
  public static void ApplyModel(IEnumerable<ReferenceModel> views, DataBinderForNGUI.Model model)
  {
    foreach(var view in views) view.Model = model;
  }

  public static float GetFloatValue(object obj)
  {
    float v;
    var type = obj.GetType();
    if(type == typeof(float))       v = (float)obj;
    else if(type == typeof(double)) v = (float)((double)obj);
    else if(type == typeof(int))    v = (float)((int)obj);
    else throw new System.InvalidCastException(string.Format("invalid type: {0}", obj.GetType()));
    return v;
  }
}
