using UnityEngine;
using System;
using System.Collections;

public class ReferenceModel : DataBinderForNGUI.UIPropertyBinder
{
  private DataBinderForNGUI.Model model;
  public DataBinderForNGUI.Model Model
  {
    get { return model; }
    set
    {
      if(model != null) model.OnChange -= OnModelChanged;
      model = value;
      model.OnChange += OnModelChanged;
      OnModelChanged(null);
    }
  }

  protected override void Awake()
  {
    base.Awake();
  }

  protected override void OnChange()
  {
    if(model == null)
    {
      var property = PropertyValue as DataBinderForNGUI.Model;
      if(property == null) return;
      if(model != null) model.OnChange -= OnModelChanged;
      model = property;
      model.OnChange += OnModelChanged;
    }
    OnModelChanged(null);
  }

  protected override void OnDestroy()
  {
    base.OnDestroy();
    if(model != null) model.OnChange -= OnModelChanged;
  }

  void OnModelChanged(string propertyName)
  {
    if(model != null && OnModelChange != null) OnModelChange(propertyName);
  }

  public Action<string> OnModelChange;
}
