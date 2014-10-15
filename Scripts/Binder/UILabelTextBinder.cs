using UnityEngine;
using System.Collections;

namespace DataBinderForNGUI
{

[RequireComponent(typeof(UILabel))]
class UILabelTextBinder : UIPropertyBinder
{
  [SerializeField] private string format;
  private UILabel target;

  private static readonly string defaultFormat = "{0}";

  protected override void Awake()
  {
    target = GetComponent<UILabel>();
    if(!target)
    {
      Debug.LogWarning("target not found");
      Destroy(this);
      return;
    }

    format = !string.IsNullOrEmpty(format) ? format : defaultFormat;
    base.Awake();
  }

  protected override void OnChange()
  {
    target.text = string.Format(format, PropertyValue);
  }
}

}
