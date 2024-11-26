using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class PlayerHeadMoveScript : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;

    Change change;
    CinemachineVirtualCamera virtualCamera;

    CinemachineFramingTransposer framingTransposer;
    float headDistance = 5.0f;
    float playerDistance = 0.3f;

    PlayerDamageEffect damageEffect;
    GameObject changeTarget;
    void Start()
    {
        Debug.Log("Start");
        change = GameObject.FindObjectOfType<Change>();
    }

    /// <summary>
    /// ���ڂ�ΏۂɌ������ē��𓮂����A���ڂ�
    /// </summary>
    /// <param name="start">�J�n�n�_</param>
    /// <param name="target">���ڂ�Ώ�</param>
    /// <param name="headOffset">���̍���</param>
    /// <returns></returns>
    public IEnumerator MoveHead(Vector3 start, Transform target, Vector3 headOffset, GameObject changeObj)
    {
        damageEffect = GameObject.FindObjectOfType<PlayerDamageEffect>();
        damageEffect.Reset();

        transform.LookAt(target);
        ChangeCameraTarget(transform, headDistance);

        float totalTime = Vector3.Distance(start, target.position) / moveSpeed;
        float timer = 0f;

        while(timer < totalTime)
        {
            timer += Time.deltaTime;

            Vector3 position = Vector3.Lerp(start, target.position, timer / totalTime);
            transform.position = position + headOffset;
            yield return null;
        }
        changeTarget = changeObj;
        change.ChangeCameraTarget(changeTarget);
        ChangeCameraTarget(change.gameObject.transform, playerDistance);
        Destroy(gameObject);
    }

    public void ReturnCameraTarget()
    {
        if (changeTarget != null)
        {
            change.ChangeCameraTarget(changeTarget);
            ChangeCameraTarget(change.gameObject.transform, playerDistance);
            Destroy(gameObject);
        }
    }

    void ChangeCameraTarget(Transform target,float distance)
    {
        Debug.Log("target:" + target.name);

        virtualCamera = FindObjectOfType<CinemachineVirtualCamera>();

        framingTransposer = virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>();

        virtualCamera.Follow = target;
        virtualCamera.LookAt = target;
        framingTransposer.m_CameraDistance = distance;
    }
}
