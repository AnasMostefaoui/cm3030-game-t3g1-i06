using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpiritBar : MonoBehaviour
{
    private Slider spiritBar;

    void Start()
    {
        // Get the slide and set is max value
        spiritBar = GetComponent<Slider>();
        spiritBar.maxValue = GameManager.Instance.spiritManager.maxSpiritHealth;
    }

    // Update is called once per frame
    void Update()
    {
        // Ensure slider up to date with health
        spiritBar.value = GameManager.Instance.spiritManager.spiritHealth;
    }
}
