using UnityEngine;
using System;
using System.Collections;
using System.Reflection;
using System.Linq;

namespace DataBinderForNGUI
{

public abstract class UIPropertyBinder : UIBinder
{
  [SerializeField] protected string propertyName;
  protected object PropertyValue { get { return cachedPropertyValue; } }
  private object cachedPropertyValue;
  private bool changed = false;
  private bool firstChange = true;

  protected override void Awake()
  {
    base.Awake();
    if(referenceModel == null) return;

    propertyName = !string.IsNullOrEmpty(propertyName) ? propertyName : gameObject.name;
    referenceModel.OnModelChange += ModelChange;
    ModelChange(null);
  }

  protected void Update()
  {
    if(!changed) return;
    changed = false;

    var currentPropertyValue = GetPropertyValue<object>();
    if(currentPropertyValue == null) return;
    if(Equals(currentPropertyValue, cachedPropertyValue)) return;

    cachedPropertyValue = currentPropertyValue;
    OnChange();
  }

  protected virtual void OnDestroy()
  {
    if(referenceModel != null) referenceModel.OnModelChange -= ModelChange;
  }

  protected abstract void OnChange();
  void ModelChange(string changedPropertyName)
  {
    if(changed) return;
    if(referenceModel == null || referenceModel.Model == null) return;
    if(changedPropertyName != null && propertyName != changedPropertyName) return;
    changed = true;

    if(firstChange)
    {
      firstChange = false;
      Update();
    }
  }


  private T GetPropertyValue<T>()
  {
    var property = CachedPropertyInfo;
    if (property is PropertyInfo)
    {
      return (T)((PropertyInfo)property).GetValue(referenceModel.Model, null);
    }
    else
    {
      return default(T);
    }
  }


  // === cache ===
  private PropertyInfo cachedPropertyInfo = null;
  protected PropertyInfo CachedPropertyInfo
  {
    get
    {
      if(cachedPropertyInfo == null) { cachedPropertyInfo = CachedModelType.GetProperty(propertyName); }
      return cachedPropertyInfo;
    }
  }
}

}
