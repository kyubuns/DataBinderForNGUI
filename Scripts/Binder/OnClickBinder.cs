using UnityEngine;
using System;
using System.Collections;
using System.Reflection;

namespace DataBinderForNGUI
{

[RequireComponent(typeof(UIButton))]
class OnClickBinder : UIMethodBinder
{
  public void OnClick()
  {
    CachedMethodInfo.Invoke(referenceModel.Model, null);
  }
}

}
