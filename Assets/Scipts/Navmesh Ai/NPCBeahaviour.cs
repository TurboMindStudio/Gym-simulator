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
    public Animator DoorAnimator;

    public bool doWorkout;
    public Transform workoutPosition;

    private void Start()
    {
        m_Agent = GetComponent<NavMeshAgent>();
        animator=GetComponent<Animator>();
        Transform wp = wayPoints[curruntPos];
        doWorkout = true;
    }

    private void Update()
    {
        float distanceBetweenPoints = Vector3.Distance(transform.position, wayPoints[curruntPos].position);

        if (distanceBetweenPoints <= 1f)
        {
            if (curruntPos==3)
            {
                //Debug.Log("reached destination");
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

        if (UserManager.instance.MemberJoined == true && doWorkout == true)
        {
            m_Agent.speed = 2.5f;
            animator.SetFloat("Locomotion", 1);
            m_Agent.destination=GameObject.FindGameObjectWithTag("equipment").GetComponent<Transform>().position;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Door"))
        {
            Debug.Log("Open Door");
            DoorAnimator.SetBool("DoorOpen", true);
        }
        if (other.CompareTag("MemberShipTrigger"))
        {
            
            UserManager.instance.UserButton.onClick.AddListener(UserManager.instance.UpdateMemberData);
            UserManager.instance.RandomMemberName = Random.Range(0, UserManager.instance.GymMembers.Length);
            UserManager.instance.MemberNameText.text = UserManager.instance.GymMembers[UserManager.instance.RandomMemberName].Name.ToString();
            Debug.Log(UserManager.instance.GymMembers[UserManager.instance.RandomMemberName].Name);

            UserManager.instance.warningTxt.SetActive(false);
            UserManager.instance.gymMemberPanel.SetActive(false);
        }

        if (other.CompareTag("Workout"))
        {
            doWorkout = false;
            Debug.Log("start Exercise");
            m_Agent.speed = 0;
            animator.SetTrigger("jogg");
            animator.SetFloat("Locomotion", 0);
            this.transform.position = workoutPosition.position;
            transform.rotation = Quaternion.identity;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Door"))
        {
            Debug.Log("Close Door");
            DoorAnimator.SetBool("DoorOpen", false);
        }

        
    }

}
