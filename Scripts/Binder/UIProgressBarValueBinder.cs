using UnityEngine;
using System.Collections;

namespace DataBinderForNGUI
{

[RequireComponent(typeof(UIProgressBar))]
class UIProgressBarValueBinder : UIPropertyBinder
{
  private UISlider target;

  protected override void Awake()
  {
    target = GetComponent<UISlider>();
    EventDelegate.Add(target.onChange, OnSliderChange);
    base.Awake();
  }

  protected override void OnDestroy()
  {
    EventDelegate.Remove(target.onChange, OnSliderChange);
    base.OnDestroy();
  }

  private void OnSliderChange()
  {
    SetPropertyValue<float>(target.value);
  }

  protected override void OnChange()
  {
    target.value = BinderTools.GetFloatValue(PropertyValue);
  }
}

}
