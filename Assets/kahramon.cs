using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Eklediğimiz UI isim alanını kullanabilmek için

public class Kahramon : MonoBehaviour
{
    private Rigidbody2D _rgb;
    private Vector3 velocity;
    public Animator animator;
    public Slider healthSlider; // Unity UI elemanı

    private float speedAmount = 10f;
    private float jumpAmount = 15f;
    private int jumpsRemaining = 2;
    private bool canJump;

    // Sağlık kontrolü için değişkenler
    public float maxHealth = 100f;
    public float currentHealth;
    public float decreaseRate = 1f;
    public float healAmount = 20f;

    void Start()
    {
        _rgb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Sağlık kontrolünü güncelle
        DecreaseHealth();

        velocity = new Vector3(Input.GetAxis("Horizontal"), 0f);
        transform.position += velocity * speedAmount * Time.deltaTime;
        animator.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));

        if (Input.GetButtonDown("Jump") && (canJump || jumpsRemaining > 0))
        {
            _rgb.velocity = new Vector2(_rgb.velocity.x, 0f);
            _rgb.AddForce(Vector3.up * jumpAmount, ForceMode2D.Impulse);
            jumpsRemaining--;
            canJump = false;
            animator.SetBool("IsJumping", true);
        }

        if (animator.GetBool("IsJumping") && (canJump || jumpsRemaining > 0))
        {
            animator.SetBool("IsJumping", false);
        }

        // Vurma animasyonunu kontrol et
        if (Input.GetButtonDown("Fire1"))
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Hitting"))
            {
                animator.SetTrigger("IsHitting");
            }
        }

        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else if (Input.GetAxisRaw("Horizontal") == 1)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;
            jumpsRemaining = 2;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = false;
        }
    }

    void FixedUpdate()
    {
        // Artan bir yerçekimi uygula (bu değeri ihtiyaca göre ayarlayabilirsiniz)
        _rgb.AddForce(Vector2.down * 5f);
    }

    // Sağlık kontrol fonksiyonu
    void DecreaseHealth()
    {
        if (currentHealth > 0)
        {
            currentHealth -= decreaseRate;

            if (currentHealth <= 0)
            {
                Die();
            }

            UpdateHealthBar();
        }
    }

    void Die()
    {
        Debug.Log("Character has died!");
        // Ölme durumuyla ilgili diğer işlemleri burada gerçekleştirebilirsiniz.
    }

    // Sağlık çubuğunu güncelleme fonksiyonu
    void UpdateHealthBar()
    {
        healthSlider.value = currentHealth / maxHealth;
    }
}