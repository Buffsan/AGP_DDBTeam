using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ClearFlag : MonoBehaviour
{
    private List<EnemyBaseClass> Enemys = new List<EnemyBaseClass>();
    private bool clearCheck;
    [SerializeField] private PlayableDirector playableDirector;
    public bool IsClearFlag => clearCheck;
    // Start is called before the first frame update
    void Start()
    {
        Enemys = TargetManeger.EnemyList;
        clearCheck = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //後から追加には未対応
        if(!clearCheck && Check(TargetManeger.EnemyList))
            PlayTimeline();
    }
    bool Check(List<EnemyBaseClass> enemys)
    {
        List<EnemyBaseClass> Dead = new List<EnemyBaseClass>();
        foreach (EnemyBaseClass enemy in enemys)
        {
            if (enemy.IsDead)
            {
                Dead.Add(enemy);
            }
        }

        for (int i = 0;i < Dead.Count; i++)
        {
            Enemys.Remove(Dead[i]);
        }

        //Debug.Log(Enemys.Count);
        return Enemys.Count == 0;
    }

    void PlayTimeline()
    {
        playableDirector.Play();
        clearCheck = true;
    }
}
