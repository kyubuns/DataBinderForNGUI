using UnityEngine;
using System;
using System.Collections;
using System.Reflection;
using System.Linq;

namespace DataBinderForNGUI
{

public abstract class UIBinder : MonoBehaviour
{
  [SerializeField] protected ReferenceModel referenceModel;

  protected virtual void Awake()
  {
    referenceModel = referenceModel ?? NGUITools.FindInParents<ReferenceModel>(transform.parent);
  }

  // === cache ===
  private Type cachedModelType = null;
  protected Type CachedModelType
  {
    get
    {
      if(cachedModelType == null) { cachedModelType = referenceModel.Model.GetType(); }
      return cachedModelType;
    }
  }
}

}
