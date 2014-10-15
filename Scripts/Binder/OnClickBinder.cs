using UnityEngine;
using System;
using System.Collections;
using System.Reflection;

namespace DataBinderForNGUI
{

class OnClickBinder : UIMethodBinder
{
  public void OnClick()
  {
    CachedMethodInfo.Invoke(referenceModel.Model, null);
  }
}

}
