using UnityEngine;
using System;
using System.Collections;
using System.Reflection;
using System.Linq;

namespace DataBinderForNGUI
{

public abstract class UIMethodBinder : UIBinder
{
  [SerializeField] protected string methodName;

  // === cache ===
  private MethodInfo cachedMethodInfo = null;
  protected MethodInfo CachedMethodInfo
  {
    get
    {
      if(cachedMethodInfo == null) { cachedMethodInfo = CachedModelType.GetMethod(methodName); }
      return cachedMethodInfo;
    }
  }
}

}
