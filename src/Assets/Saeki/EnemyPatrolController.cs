using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrolController : MonoBehaviour
{
    public int remainingBullets;
    [SerializeField] private NavMeshAgent Agent;
    [SerializeField] private float moveSpeed = 3.5f;
    [SerializeField] private GameObject Target;
    [SerializeField] private float targetDistance = 12f;
    [SerializeField] private float nextPosDistance = 12f;
    [SerializeField] private float rotationSpeed = 0.1f;
    [SerializeField] private float fireIntarval = 3f;
    [SerializeField] private Transform[] wayPoints;
    [SerializeField] private bool isRoop = true;
    private float timeCount = 0;
    private int nextPoint = -1;
    // Start is called before the first frame update
    void Start()
    {
        Agent.speed = moveSpeed;
        GoNextPoint();
    }

    void TargetChase()
    {
        if (Agent.enabled)
        {
            if (Agent.pathStatus == NavMeshPathStatus.PathInvalid)
                Destroy(this.gameObject);
            else
            {
                if(Agent.remainingDistance < nextPosDistance)
                GoNextPoint();
            }
           
        }
    }
    void StopChase()
    {
        float isDistanse = Vector3.Distance(Target.transform.position, transform.position);
        if (isDistanse < targetDistance)
        {
            Agent.speed = 0f;
            // �^�[�Q�b�g�̕����ւ̉�]
            Vector3 direction = Target.transform.position - transform.position;
            direction.y = 0.0f;
            Quaternion lookRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, rotationSpeed);

            timeCount += Time.deltaTime;
        }
        else
        {
            timeCount = 0f;
            Agent.speed = moveSpeed;
        }
    }

    void OnFire()
    {
        remainingBullets--;
        timeCount = 0f;
        Debug.Log("FIRE!!");
        //GameObject.Instantiate(Bullet, Muzzle.transform.position, Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {
        TargetChase();
        //float roteBefore = transform.rotation.y;
        StopChase();
        //float roteValue = transform.rotation.y - roteBefore;

        if (timeCount > fireIntarval && remainingBullets > 0)
            OnFire();
    }

    void GoNextPoint()
    {
        // �n�_���Ȃɂ��ݒ肳��Ă��Ȃ��Ƃ��ɕԂ�
        if (wayPoints.Length == 0)
            return;

        else if (wayPoints.Length == 1)
        {
            Agent.destination = wayPoints[0].position; 
            return;
        }

        // �z����̎��̈ʒu��ڕW�n�_�ɐݒ�
        nextPoint++;

        // �ꏄ������ŏ��̒n�_�Ɉړ�
        if (isRoop && nextPoint == wayPoints.Length)
        {
            nextPoint = 0;
        }

        // �G�[�W�F���g�����ݐݒ肳�ꂽ�ڕW�n�_�ɍs���悤�ɐݒ�
        Agent.destination = wayPoints[nextPoint].position;
    }
}
