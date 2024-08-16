using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppeaaranceChangeScript : MonoBehaviour
{
    // �G�̃f�[�^�Ń}�e���A����ݒ肷�邩���A�䂭�䂭�̓A�j���[�V����������Ă���
    [SerializeField] Material possessableMaterial;
    [SerializeField] Material deadMaterial;
    
    public void ChangeMaterialToPossessable(GameObject gameObject)
    {
        gameObject.GetComponent<MeshRenderer>().material = possessableMaterial;
    }
    public void ChangeMaterialToDead(GameObject gameObject)
    {
        gameObject.GetComponent<MeshRenderer>().material = deadMaterial;
    }
}
