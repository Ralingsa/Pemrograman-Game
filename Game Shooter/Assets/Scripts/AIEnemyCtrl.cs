using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]

public class AIEnemyCtrl : MonoBehaviour
{
    public float speed;
    public int enemyHealth = 30;
    public static int enemyDamage = 1;
    public static bool giveDamage = false;
    Animator anim;
    GameObject target;
    public UnityEngine.AI.NavMeshAgent agent { get; private set; }

    public AudioSource enemyAudio;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponentInChildren<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("player");
        agent.speed = speed;
        agent.updateRotation = true;
        agent.updatePosition = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            agent.SetDestination(target.transform.position);
            anim.SetBool("isWalk", true);
        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Destroy"))
        {
            Destroy(gameObject);
        }
    }

    void takeDamage(int damage)
    {
        enemyHealth -= damage;
        if (enemyHealth <= 0)
        {
            anim.SetBool("isDie", true);
            UImanager.score += 10;
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            anim.SetBool("isAttack", true);
            anim.SetBool("isWalk", false);
            giveDamage = true;
            enemyAudio.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        anim.SetBool("isAttack", false);
        anim.SetBool("isWalk", true);
        giveDamage = false;
    }
}
