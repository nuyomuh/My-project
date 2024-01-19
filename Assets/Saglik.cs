using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Saglik : MonoBehaviour
{
    public Slider healthSlider; // Canvas içindeki Slider bileşeni
    private bool interactionInProgress = false; // Etkileşim durumu kontrol değişkeni

    void Start()
    {
        // Sağlık çubuğunu devre dışı bırak
        healthSlider.gameObject.SetActive(false);
    }

    void Update()
    {
        // Eğer etkileşim devam ediyorsa ve sağlık çubuğu kapalıysa
        if (interactionInProgress && !healthSlider.gameObject.activeSelf)
        {
            // Sağlık çubuğunu aktive et
            healthSlider.gameObject.SetActive(true);
        }
    }

    // Etkileşim durumu set etmek için bir metod
    public void SetInteractionInProgress(bool value)
    {
        interactionInProgress = value;
    }
}



