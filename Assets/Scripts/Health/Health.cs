using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float startingHealth;

    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;

    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;  // Removido el carácter inválido
    [SerializeField] private int numberOfFlashes;    // Removido el carácter inválido
    private SpriteRenderer spriteRend;

    [Header("Components")]
    [SerializeField] private Behaviour[] components;
    private bool invulnerable;

    [Header("Sounds")]
    [SerializeField] private AudioClip dieSound;
    
    [SerializeField] private AudioClip hurtSound;

    private void Awake()
    {
        currentHealth = startingHealth;  // Initialize current health
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();

    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
            StartCoroutine(Invulnerability());
            SoundManager.instance.PlaySound(hurtSound);
        }
        else
        {
            if (!dead) 
            {
                //Deactivate all attached component classes
                foreach (Behaviour component in components)
                    component.enabled = false;

                anim.SetBool("grounded", true);
                anim.SetTrigger("die");
                dead = true;
                SoundManager.instance.PlaySound(dieSound);
                

                //Player
                if(GetComponent<PlayerController>() != null)
                    GetComponent<PlayerController>().enabled = false;

                //Enemy
                if (GetComponentInParent<EnemyPatrol>() != null)
                    GetComponentInParent<EnemyPatrol>().enabled = false;

                if (GetComponent<MeleeEnemy>() != null)
                    GetComponent<MeleeEnemy>().enabled = false;



                
            }
         

        }
    }
    public void AddHealth(float _value)
    {
        
        currentHealth = Mathf.Clamp(currentHealth +_value, 0, startingHealth);


    }

    public void Respawn()
    {
        dead = false;
        AddHealth(startingHealth);
        anim.ResetTrigger("die");
        anim.Play("Idle");
        StartCoroutine(Invulnerability());

        //Activate all attached component classes
        foreach (Behaviour component in components)
            component.enabled = true;
        // Reactivar el PlayerController si está presente
        if (GetComponent<PlayerController>() != null)
            GetComponent<PlayerController>().enabled = true;
    }

    private IEnumerator Invulnerability() 
    
    {
        Physics2D.IgnoreLayerCollision(7, 8, true);
        for (int i =0; i < numberOfFlashes; i++) 
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration/(numberOfFlashes*2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));


        }
        Physics2D.IgnoreLayerCollision(7, 8, false);


    }

}
