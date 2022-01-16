using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Health : MonoBehaviour
{   
    [SerializeField] float startingHealth;
    [SerializeField] public AudioSource playerDamagedSound;

    public float currentHealth { get; set; }
    UnityEngine.Object playerParticles; ///////
    bool particlesSpawned = false; ///////

    void Start() 
    {
    playerParticles = Resources.Load("PlayerDestroy"); ///////
    }

    void Awake()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(float _damage) 
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        playerDamagedSound.Play();

        if (currentHealth > 0)
        {
            //LIVE
        }
        else
        {
            Death();
        }
    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }



    public void Death() ///////
    {
        gameObject.SetActive(false);
        Instantiate(playerParticles, transform.position, Quaternion.identity);
        particlesSpawned = true;
        Invoke("RestartScene", 2);
    }

    public void RestartScene() ///////
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}