using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCBeahaviour : MonoBehaviour
{

    private NavMeshAgent m_Agent;
    public Transform[] wayPoints;
    [SerializeField] int curruntPos;

    private Animator animator;

    private void Start()
    {
        m_Agent = GetComponent<NavMeshAgent>();
        animator=GetComponent<Animator>();
        Transform wp = wayPoints[curruntPos];
    }

    private void Update()
    {
        float distanceBetweenPoints = Vector3.Distance(transform.position, wayPoints[curruntPos].position);

        if (distanceBetweenPoints <= 1f)
        {
            if (curruntPos==3)
            {
                Debug.Log("reached destination");
                m_Agent.speed = 0f;
                animator.SetFloat("Locomotion", 0);
            }
            else
            {
                curruntPos = (curruntPos + 1) % wayPoints.Length;
                animator.SetFloat("Locomotion",1);
            }
        }
        else
        {
            m_Agent.destination = wayPoints[curruntPos].position;
        }
    }





}
