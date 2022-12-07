using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [SerializeField] public float health = 100;
    [SerializeField] int scoreValue = 100;

    [Header("Shots")]
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] AudioClip shootSound;
    [SerializeField] [Range(0, 1)] float shootSoundVolume = 0.25f;

    [Header("Projectile")]
    [SerializeField] GameObject projectile;
    [SerializeField] float projectileSpeed = 10f;

    [Header("Death")]
    [SerializeField] GameObject deathExplosion;
    [SerializeField] AudioClip deathSound;
    [SerializeField] [Range(0, 1)] float deathSoundVolume = 0.75f;
    [SerializeField] GameObject animator_death;


    private void Start()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    private void Update()
    {
        CountDownAndShoot();
    }

    private void CountDownAndShoot()
    { //time between shots
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f)
        {
            Fire();
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void Fire()
    {
        GameObject laser = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);                       //why minus??
        AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();

        ProcessHit(damageDealer);
    }

    public Action OnSetDamage;

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
       // OnSetDamage?.Invoke();                 "?" §ï§ä§à §á§â§à§Ó§Ö§â§Ü§Ñ §â§Ñ§Ó§Ö§ß §Ý§Ú §à§ß §ß§å§Ý§ð(if (OnSetDamage != null) {}
        damageDealer.Hit();
        if (!damageDealer) { return; }
        if (health <= 0)
        {
            Die();

        }


    }

    private void Die()
    {
        FindObjectOfType<GameSession>().AddToScore(scoreValue);
        Destroy(gameObject);
        // GameObject explosion = Instantiate(deathExplosion, transform.position, transform.rotation);    //where is explosion in unity?
        //Destroy(explosion, 1f);

        GameObject anim_explosion = Instantiate(animator_death, transform.position, transform.rotation);
        Destroy(anim_explosion, 1f);
        //Animator animation_death = animator_death.GetComponent<Animator>();


        AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathSoundVolume);

    }
}


/*
public delegate int Pppp(float x, bool a);

public class Tttt
{
    void Fff(Pppp p)
    {
        p(10,false);
    }

    int qqq(float x, bool a)
    {
        return 1;
    }

    void Ccc()
    {
        Fff(qqq); //1
        Fff(ooo); //2
        int a = qqq(10,false); //1
    }

    int ooo(float x, bool a)
    {
        return 2;
    }

    
}
*/
