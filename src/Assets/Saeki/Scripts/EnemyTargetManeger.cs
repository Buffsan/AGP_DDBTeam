using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTargetManeger : MonoBehaviour
{
    private List<EnemyBaseClass> Enemy = new List<EnemyBaseClass>();
    private GameObject playerObject;
    void Start()
    {
        playerObject = GameObject.FindWithTag("Player");
        GameObject[] onFieldEnemy = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject g in onFieldEnemy)       
            Enemy.Add(g.GetComponentInParent<EnemyBaseClass>());
        
    }

    /// <summary>
    /// �G�΂���Ώۂ�ύX����
    /// </summary>
    public void SetTarget(GameObject player)
    {
        playerObject = player;
        foreach (EnemyBaseClass baseClass in Enemy)
        {
            baseClass.ChengeTarget(playerObject);
        }         
    }
    /// <summary>
    /// �G�ΑΏۂ̈����̊m��
    /// </summary>
    public void AddEnemyBaseClass(GameObject enemy)
    {
        Enemy.Add(enemy.GetComponentInParent<EnemyBaseClass>());
    }
}
