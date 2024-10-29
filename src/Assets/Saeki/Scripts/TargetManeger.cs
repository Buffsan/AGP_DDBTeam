using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManeger : MonoBehaviour
{
    private static List<EnemyBaseClass> Enemy = new List<EnemyBaseClass>();
    private static GameObject playerObject;
    /// <summary>
    /// static�Ő錾���ꂽGet���]�b�g
    /// </summary>
    /// <returns>�v���C���[�̃I�u�W�F�N�g</returns>
    public static GameObject getPlayerObj() { return playerObject; }
    void Start()
    {
        playerObject = GameObject.FindWithTag("Player");
        GameObject[] onFieldEnemy = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject g in onFieldEnemy)
            AddEnemyBaseClass(g);
    }

    /// <summary>
    /// �G�΂���Ώۂ�ύX����
    /// </summary>
    public static void SetTarget(GameObject player)
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
    public static void AddEnemyBaseClass(GameObject enemy)
    {
        Enemy.Add(enemy.GetComponentInParent<EnemyBaseClass>());
    }
}
