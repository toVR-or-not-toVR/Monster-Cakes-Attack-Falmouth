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
        enemy.OnSetDamage = () => { UpdateBar(); }; // �� () ��ڧ����� �ѧ��ԧ�ާ֧ߧ��. �ݧ�ާҧէ� ���� ���ڧ�ӧѧڧӧѧߧڧ�, ��ܧݧѧէ�ӧѧ֧� �ާ֧��է�. �� �֧ԧ� ���ާ���� ��ӧ�٧�ӧѧ֧� 2 ��ܧ�ڧ���
    }

    private void UpdateBar()
    {
        enemyHealth = enemy.health;
        barSprite.transform.localScale = new Vector3(1,enemyHealth / enemyHealthMax,1);
    }
}
