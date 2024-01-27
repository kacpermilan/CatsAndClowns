using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCatAnimation : MonoBehaviour
{
    private Animator _animator;

    private LaserCat _laserCat;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _laserCat = GetComponentInParent<LaserCat>();
    }

    private void Update()
    {
        _animator.SetBool("IsResting", _laserCat.OnCooldown);
    }


}
