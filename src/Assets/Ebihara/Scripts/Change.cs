using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Change : MonoBehaviour
{
    //GameObject changeObj;

    PlayerMove playerMove;
    CharacterStatus characterStatus;


    [SerializeField] GameObject camera;
    PlayerRay playerRay;

    // Start is called before the first frame update
    void Start()
    {
        playerRay = camera.GetComponent<PlayerRay>();
        playerMove = this.GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(this.transform.localEulerAngles.ToString());
    }

    public void ChangeEnemy(GameObject changeObj)
    {
        //��
        //changeObj = playerRay.GetObj();
        characterStatus = changeObj.GetComponent<CharacterStatus>();

        //���ڂ菈��
        if (characterStatus.IsDead == true)
        {
            //Debug.Log("���ڂ�G:" + changeObj.name);

            Debug.Log("Change");

            //�e��Enemy��
            transform.parent.gameObject.tag = "Enemy";

            //�e�̕t���ւ�
            this.gameObject.transform.parent = changeObj.transform;
            playerMove.SetplayerParent(this.transform.parent.gameObject);

            //�e��Player��
            this.transform.parent.gameObject.tag = "Player";

            //�e�̕ύX
            playerMove.SetGunObject();

            //Player�̈ʒu����
            this.transform.position = changeObj.transform.position;
            Vector3 correction = new Vector3(0f, 1.5f, 0f);
            this.transform.position += correction;

            Vector3 angles = this.transform.localEulerAngles;
            angles.y = 0f;
            this.transform.localEulerAngles = angles;
            Debug.Log(this.transform.localEulerAngles.ToString());

            changeObj = null;
        }
    }
}
