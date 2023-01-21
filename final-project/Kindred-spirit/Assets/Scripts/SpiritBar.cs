using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritBar : MonoBehaviour
{
    private TMPro.TextMeshProUGUI textMeshPro;

    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        textMeshPro.text = GameManager.Instance.levelTimer.ToString("0");
    }
}
