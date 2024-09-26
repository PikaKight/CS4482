using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIhandler : MonoBehaviour
{
    VisualElement healthBar;

    public static UIhandler instance { get; private set; }

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        UIDocument uiDocument = GetComponent<UIDocument>();
        healthBar = uiDocument.rootVisualElement.Q<VisualElement>("HealthBar");
        SetHealthValue(1.0f);

    }

    public void SetHealthValue(float health)
    {
        healthBar.style.width = Length.Percent(100 * health);
    }
}
