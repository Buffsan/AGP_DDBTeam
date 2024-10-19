using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovementTest_E : EnemyBaseClass
{
    [SerializeField]
    GameObject TankBody, TankCanon, TankCatapera;
    void CataperaRotete()
    {
        Vector3 directionToTarget = Target.transform.position - transform.position;
        directionToTarget.y = 0; // �������������Ɍ����ꍇ�AY���̉�]�𖳎�����

        // ���݂̑O�����ƃ^�[�Q�b�g�̕����̊p�x���v�Z
        float angle = Vector3.Angle(transform.forward, directionToTarget);

        // ���ȏ�̊p�x��������΁A�^�[�Q�b�g�̕���������
        if (angle > 0.1f)
        {
            // �^�[�Q�b�g�����Ɍ�������]���v�Z
            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);

            // ���X�Ƀ^�[�Q�b�g�̕����ɉ�]
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    protected override void StopChase()
    {
        if (FindCheck())
        {
            Agent.speed = 0f;
            // �^�[�Q�b�g�̕����ւ̉�]
            Vector3 direction = Target.transform.position - transform.position;
            direction.y = 0.0f;
            Quaternion lookRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);

            remainingCount += Time.deltaTime;

            if (lockonCount < lockonIntarval)
            {
                lockonCount += Time.deltaTime;
                lockonCheck = true;
            }
            else
            {
                lockonCheck = false;
            }
        }
        else
        {
            remainingCheck = false;
            remainingCount = 0f;
            lockonCount = 0f;
            Agent.speed = moveSpeed;
        }
    }
}
