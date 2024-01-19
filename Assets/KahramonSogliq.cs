using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KahramonSogliq : MonoBehaviour
{
    public Slider healthSlider;
    private float maxHealth = 100f;
    private float currentHealth;
    private float interactionTime = 30f; // Etkileşim süresi (saniye)
    private float remainingInteractionTime; // Kalan etkileşim süresi
    private bool interactionInProgress = false; // Etkileşim devam ediyor mu?

    void Start()
    {
        currentHealth = maxHealth;
        remainingInteractionTime = interactionTime;
    }

    void Update()
    {
        // Eğer etkileşim süresi devam ediyorsa, süreyi güncelle
        if (interactionInProgress)
        {
            remainingInteractionTime -= Time.deltaTime;
            // Sağlık çubuğunda kalan süreyi göster
            UpdateHealthBar();
        }

        // Eğer etkileşim süresi bitmişse ve sağlık 0'dan büyükse sağlığı azalt
        if (!interactionInProgress && currentHealth > 0)
            // Eğer etkileşim bittiğinde
            GetComponent<Saglik>().SetInteractionInProgress(false);
        {
            currentHealth -= Time.deltaTime;
            UpdateHealthBar();

            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BuzEtkilesim"))
        {
            // Eğer etkileşim başlamamışsa ve sağlık 0'dan büyükse
            if (!interactionInProgress && currentHealth > 0)
                // Eğer etkileşim başladıysa
                GetComponent<Saglik>().SetInteractionInProgress(true);
            {
                // Etkileşim süresini başlat
                interactionInProgress = true;
                remainingInteractionTime = interactionTime;

                // Sağlığı yenile
                currentHealth = maxHealth;

                // Etkileşim nesnesini yok et
                Destroy(other.gameObject);
            }
        }
    }

    void UpdateHealthBar()
    {
        healthSlider.value = currentHealth / maxHealth;
    }

    void Die()
    {
        // Karakterin ölme durumu
        Debug.Log("Kahramon öldü");
    }
}


