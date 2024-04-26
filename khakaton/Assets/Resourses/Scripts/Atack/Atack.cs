using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private Animation _attackAnim;
    [SerializeField] private Animation _DeathTreeAnim;    
    [SerializeField] private Inputs _inputs;
    [SerializeField] private Tree _tree;
    [SerializeField] private Collider _player;
    private int _beatCounter = 0;


    private void Awake()
    {
        _inputs.shootEvent.AddListener(OnAtack);
    }

    private void Update()
    {
        OnAtack();
    }


    public void OnAtack()
    {
        _attackAnim.Play();
        if (_player  )
        {

        }

    }

    public void OnFelling()
    {

    }

}
