using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpiritBar : MonoBehaviour
{
    private Slider spiritBar;

    // Start is called before the first frame update
    void Start()
    {
        spiritBar = GetComponent<Slider>();
        spiritBar.maxValue = GameManager.Instance.spiritHealth;
    }

    // Update is called once per frame
    void Update()
    {
        spiritBar.value = GameManager.Instance.spiritHealth;
    }
}
