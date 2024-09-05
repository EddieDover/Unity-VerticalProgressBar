using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class VerticalProgressBar : VisualElement
{
    public new class UxmlFactory : UxmlFactory<VerticalProgressBar, UxmlTraits> { }

    private VisualElement _progressBar;
    private VisualElement _progressBarFill;
    private float _originalValue;
    public float Value
    {
        get => _originalValue;
        set
        {
            _originalValue = value;
            _progressBarFill.style.height = Length.Percent(GetInterpolatedValue(value));
        }
    }

    public float MaxValue { get; set; } = 100;

    public float MinValue { get; set; } = 0;
    public VerticalProgressBar()
    {
        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/UI Toolkit/CustomComponents/VerticalProgressBar.uxml");
        visualTree.CloneTree(this);

        _progressBar = this.Q<VisualElement>("progress-bar");
        _progressBarFill = this.Q<VisualElement>("progress-bar-fill");
    }


    public new class UxmlTraits : VisualElement.UxmlTraits
    {
        UxmlFloatAttributeDescription m_Value =
            new UxmlFloatAttributeDescription
            {
                name = "value",
                defaultValue = 25
            };

        UxmlFloatAttributeDescription m_MaxValue =
            new UxmlFloatAttributeDescription
            {
                name = "max-value",
                defaultValue = 100
            };

        UxmlFloatAttributeDescription m_MinValue =
        new UxmlFloatAttributeDescription
        {
            name = "min-value",
            defaultValue = 0
        };

        UxmlColorAttributeDescription m_BackgroundColor =
            new UxmlColorAttributeDescription
            {
                name = "background-color",
                defaultValue = new Color(0.1f, 0.1f, 0.1f, 1)
            };

        public override IEnumerable<UxmlChildElementDescription> uxmlChildElementsDescription
        {
            get { yield break; }
        }

        public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
        {
            base.Init(ve, bag, cc);
            var ate = ve as VerticalProgressBar;
            ate._progressBar = ve.Q<VisualElement>("progress-bar");
            ate._progressBarFill = ve.Q<VisualElement>("progress-bar-fill");
            ate._progressBarFill.style.backgroundColor = m_BackgroundColor.GetValueFromBag(bag, cc);
            ate.MinValue = m_MinValue.GetValueFromBag(bag, cc);
            ate.MaxValue = m_MaxValue.GetValueFromBag(bag, cc);
            ate.Value = m_Value.GetValueFromBag(bag, cc);
        }
    }

    public float GetInterpolatedValue(float value)
    {
        float clampedValue = Mathf.Clamp(value, MinValue, MaxValue);
        float finalValue = Mathf.InverseLerp(MinValue, MaxValue, clampedValue) * 100;
        return finalValue;
    }

    public Color BackgroundColor
    {
        get => _progressBarFill.style.backgroundColor.value;
        set
        {
            _progressBarFill.style.backgroundColor = value;
        }
    }
}