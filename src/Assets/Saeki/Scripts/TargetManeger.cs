using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TargetManeger : MonoBehaviour
{
    private static List<EnemyBaseClass> Enemy = new List<EnemyBaseClass>();
    private static GameObject playerObject;
    private static float TimeCount = 0;

    [SerializeField] private static float Interval = 3f;
    [SerializeField] private static float watchDistancs = 15f;

    /// <summary>
    /// static�Ő錾���ꂽGet���]�b�g
    /// </summary>
    /// <returns>�v���C���[�̃I�u�W�F�N�g</returns>
    public static GameObject getPlayerObj() { return playerObject; }

    /// <summary>
    /// static�Ő錾���ꂽGet���]�b�g
    /// </summary>
    /// <returns>�c���Slow��Ԃ�(����)0~1(���)�܂łɕϊ������p�����[�^</returns>
    public static float GetSlowValue()
    {
        float value = TimeCount / Interval;
        if (value < 0f) value = 0f;
        else if (value > 1f) value = 1f;
        return value; 
    }
    
    void Start()
    {
        playerObject = GameObject.FindWithTag("Player");
        GameObject[] onFieldEnemy = GameObject.FindGameObjectsWithTag("Enemy");
        TimeCount = 0;
        foreach (GameObject g in onFieldEnemy)
            AddEnemyBaseClass(g);
    }

    private void Update()
    {
        TimeScaleManagement();
    }

    private void TimeScaleManagement()
    {
        if (Time.timeScale == 1f || Time.timeScale == 0f)
            return;

        TimeCount += Time.unscaledDeltaTime;

        if (TimeCount > Interval)
            Time.timeScale = 1f;
    }

    /// <summary>
    /// ���ڂ�̓��𓊂����ԂɈꎞ�I��timeScale��߂�
    /// </summary>
    public static void StartHeadChange()
    {
        TimeCount = 0;
        Time.timeScale = 1f;
    }

    /// <summary>
    /// �G�ΑΏۂ̈����̊m��
    /// </summary>
    public static void AddEnemyBaseClass(GameObject enemy)
    {
        Enemy.Add(enemy.GetComponentInParent<EnemyBaseClass>());
    }
    /// <summary>
    /// �G�΂���Ώۂ�ύX����
    /// </summary>
    public static void SetTarget(GameObject player)
    {
        playerObject = player;
        TimeCount = 0;
        Time.timeScale = 0.2f;
        ChangeTarget();
    }
   
    private static void ChangeTarget()
    {
        foreach (EnemyBaseClass baseClass in Enemy)
        {
            baseClass.ChangeTarget(playerObject);
        }
    }

    /// <summary>
    /// ���̋����ɂ���Enemy�̃^�[�Q�b�g����������
    /// </summary>
    public static void WatchTarget()
    {
        foreach (EnemyBaseClass baseClass in Enemy)
        {
            if (distance_Square(baseClass.transform.position) < watchDistancs)    
                baseClass.Watch();
        }
    }

    private static float distance_Square(Vector3 enemy) 
    { 
        return (playerObject.transform.position - enemy).sqrMagnitude; 
    }
}