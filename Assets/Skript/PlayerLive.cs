using System.Collections;
using UnityEngine;


public class PlayerLive : MonoBehaviour
{
    private int MaxHealth = 100;
    private int CurrentHealth;
    private bool isHealing = false;
    public bool isDead = false; //используется в методе EndCanvas

    [SerializeField] private HealthBar healthBar;
    [SerializeField] private CapsuleCollider cap;
    [SerializeField] private GameObject panel;
    [SerializeField] private Animator camShake;
    [SerializeField] private AudioSource audio;

    private void Start()
    {
        CurrentHealth = MaxHealth;
        healthBar.SetMaxHealth(MaxHealth);
    }
    private void Update()
    {
        if (CurrentHealth < MaxHealth && !isHealing)
        {
            StartCoroutine(Health());
        }
    }
    private void OnCollisionEnter(Collision collision)
    {        

        if (collision.gameObject.CompareTag("Walls"))
        {
                TakeHealth(MaxHealth);
                    Death();
                    
                            
        }
        else if (collision.gameObject.CompareTag("Trees"))
        {            
            if (CurrentHealth > 0)
            {
                StartCoroutine(CountOfDamage());
                if (CurrentHealth <= 0)
                {
                    Death();
                    
                }
            }                        
        }
    }
      
    IEnumerator CountOfDamage()
    {
        camShake.SetTrigger("shake");
        TakeHealth(PlayerPrefs.GetInt("currentSpeed"));
        cap.enabled = false;
        cap.GetComponentInChildren<Collider>().enabled = false;
        yield return new WaitForSeconds(.5f);
        cap.enabled = true;
        cap.GetComponentInChildren<Collider>().enabled = true;
        
    }
    IEnumerator Health()
    {
        isHealing = true;
        yield return new WaitForSeconds(5);
        if (CurrentHealth < MaxHealth)
        {
            do
            {
                CurrentHealth += 1;
                healthBar.SetHealth(CurrentHealth);
                yield return new WaitForSeconds(.1f);
            }
            while (CurrentHealth != MaxHealth);                       
                isHealing = false;             
        }
    }
    void Death()
    {
        Cursor.visible = true;
        Time.timeScale = 0f;
        panel.SetActive(true);
        isDead = true;
        audio.volume = 0f;
    }
    void TakeHealth(int damage)
    {
        CurrentHealth -= damage;
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth); // Ограничиваем здоровье в пределах [0, MaxHealth]
        healthBar.SetHealth(CurrentHealth);
    }

}
