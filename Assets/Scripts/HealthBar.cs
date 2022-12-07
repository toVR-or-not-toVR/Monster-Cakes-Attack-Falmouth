using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{

    [SerializeField] private Enemy enemy;
    [SerializeField] private GameObject barSprite;
    private float enemyHealth;
    private float enemyHealthMax;

    private void Start()
    {
        enemyHealth = enemy.health;
        enemyHealthMax = enemyHealth;
        enemy.OnSetDamage = () => { UpdateBar(); }; // §Ó () §á§Ú§ê§å§ä§ã§ñ §Ñ§â§å§Ô§å§Þ§Ö§ß§ä§í. §Ý§ñ§Þ§Ò§Õ§Ñ §ï§ä§à §á§â§Ú§ã§Ó§Ñ§Ú§Ó§Ñ§ß§Ú§Ö, §ã§Ü§Ý§Ñ§Õ§í§Ó§Ñ§Ö§ä §Þ§Ö§ä§à§Õ§í. §ã §Ö§Ô§à §á§à§Þ§à§ë§î§ð §ã§Ó§ñ§Ù§í§Ó§Ñ§Ö§ä 2 §ã§Ü§â§Ú§á§ä§Ñ
    }

    private void UpdateBar()
    {
        enemyHealth = enemy.health;
        barSprite.transform.localScale = new Vector3(1,enemyHealth / enemyHealthMax,1);
    }
}
