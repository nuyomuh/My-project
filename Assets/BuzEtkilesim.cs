using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuzEtkilesim : MonoBehaviour
{
    private Animator animator;
    private bool etkilesimDevrede = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (etkilesimDevrede && Input.GetKeyDown(KeyCode.E))
        {
            // E tuşuna basıldığında yapılacak işlemler
            animator.SetTrigger("BuzEtkilesim"); // Buz animasyonunu oynat
            Invoke("Kaybol", 1.5f); // 1.5 saniye sonra kaybolma işlemini başlat (süreyi ihtiyacınıza göre ayarlayabilirsiniz)
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Kahramon"))
        {
            // Karakter nesnesiyle etkileşime girildiğinde yapılacak işlemler
            etkilesimDevrede = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Kahramon"))
        {
            // Karakter nesnesiyle etkileşim sona erdiğinde yapılacak işlemler
            etkilesimDevrede = false;
        }
    }

    void Kaybol()
    {
        // Buz nesnesini kaybolmasını sağlayan işlemler
        Destroy(gameObject);
    }
}