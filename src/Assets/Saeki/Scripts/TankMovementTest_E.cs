using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.GridLayoutGroup;

public class TankMovementTest_E : EnemyBaseClass
{
    [SerializeField]
    GameObject TankBody, TankCanon, TankCatapera;
    private int cornersCount = 0;
    private Vector3 directionToNext;
    void BodyRotete()
    {
        Vector3 directionToTarget = Target.transform.position - TankBody.transform.position;
        directionToTarget.y = 0; // �������������Ɍ����ꍇ�AY���̉�]�𖳎�����
        LookSlerp(TankBody, directionToTarget);
    }
    void CataperaRotete()
    {
        var corners = Agent.path.corners;
        if (cornersCount == corners.Length)
        {
            cornersCount = corners.Length;
            directionToNext = corners[1] - corners[0];
            directionToNext.y = 0; // �������������Ɍ����ꍇ�AY���̉�]�𖳎�����
        }
        LookSlerp(TankCatapera, directionToNext);
    }
    void CanonRotete()
    {
        Vector3 directionToTarget = Target.transform.position - TankCanon.transform.position;
        directionToTarget.x = 0;
        LookSlerp(TankCanon,directionToTarget);
    }

    void LookSlerp(GameObject tankPart,Vector3 dir)
    {
        float angle = Vector3.Angle(tankPart.transform.forward, dir);

        // ���ȏ�̊p�x��������΁A�^�[�Q�b�g�̕���������
        if (angle > 0.1f)
        {
            // �^�[�Q�b�g�����Ɍ�������]���v�Z
            Quaternion targetRotation = Quaternion.LookRotation(dir);

            // ���X�Ƀ^�[�Q�b�g�̕����ɉ�]
            tankPart.transform.rotation = Quaternion.Slerp(tankPart.transform.rotation,
                targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
    protected override void StopChase()
    {
        CataperaRotete();

        if (FindCheck())
        {
            Agent.speed = 0f;
            // �^�[�Q�b�g�̕����ւ̉�]
            BodyRotete();
            CanonRotete();

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
