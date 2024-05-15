using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _toolAnm;

    public void UpdateAnmByVelocity(Vector3 _velocity)
    {
        _toolAnm.SetFloat("velocity", _velocity.magnitude);
    }
}
