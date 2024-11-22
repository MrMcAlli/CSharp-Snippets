using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerClickToMove : MonoBehaviour
{
    private NavMeshAgent _agent; 
    public GameObject MoveBoxPrefab; //LOL-style move visuals, optional

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    public void MoveToMouse(RaycastHit hit) //called by InputController
    {
        Debug.Log(hit + "Hit Object");
        if (hit.collider.gameObject != null)
        {
            GameObject hitObj = hit.collider.gameObject;
            if (hitObj.tag == "Ground")
            {
                _agent.SetDestination(hit.point);
                GameObject g = GameObject.Instantiate(MoveBoxPrefab, hit.point, Quaternion.identity); //Visuals
                Destroy(g, 1f); // Destroy visuals
            }
            else
            {
                Debug.Log("Invalid Mouse Position for MoveClick");
            }
        }
    }
}
