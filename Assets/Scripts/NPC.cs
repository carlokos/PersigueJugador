using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agente;
    [SerializeField] private float speed = 3.5f;
    [SerializeField] private GameManager gm;
    private GameObject target;
    void Start()
    {
        target = GameObject.Find("Player");
        agente.enabled = true;
        agente.speed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        var lookPos = target.transform.position - transform.position;
        lookPos.y = 0;

        agente.SetDestination(target.transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gm.GameOver();
        }
    }
}
