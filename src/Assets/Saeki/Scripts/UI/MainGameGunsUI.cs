using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainGameGunsUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI remainBulletText;
    [SerializeField] PlayerMove player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        remainBulletText.SetText("{0}", player.Gun.RemainBullets);
        remainBulletText.color = SetUITextColor(player.Gun.RemainBullets);
    }

    Color SetUITextColor(int Bullets)
    {
        if (Bullets == 0)// �c�e��0�̂Ƃ�
        {
            return Color.red;
        }
        else //if (remainBulletText.color == Color.red)// �c�e��0����񕜂����Ƃ��i����؂�ւ�������ڂ莞�j
        {
            return Color.white;
        }
    }
}
