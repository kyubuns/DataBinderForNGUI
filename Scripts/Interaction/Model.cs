using UnityEngine;
using System;
using System.Collections;

namespace DataBinderForNGUI
{

public class Model
{
  public Action<string> OnChange;
  protected void Changed(string propertyName)
  {
    if(OnChange != null) OnChange(propertyName);
  }
}

}
