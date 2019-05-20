using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinTracker : MonoBehaviour
{
    public float totalCoins;
    public Slider coinSlider;

    public void Update()
    {
        coinSlider.value = totalCoins;
        print(totalCoins);
    }
}
