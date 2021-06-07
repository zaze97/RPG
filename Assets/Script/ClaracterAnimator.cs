using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
/// <summary>
/// player移动事件，暂无模型动画
/// </summary>
public class ClaracterAnimator : MonoBehaviour
{
    private const float locomationAnimationSmoothTime = .1f;
    private NavMeshAgent _agent;
    private Animator _animator;
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponentInChildren<Animator>();
    }
    
    void Update()
    {
        float speedPercent = _agent.velocity.magnitude / _agent.speed;
        _animator.SetFloat("speedPercent",speedPercent,.1f,Time.deltaTime);
    }
}
