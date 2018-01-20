using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using RootMotion.FinalIK;
public class Lemming_AI : MonoBehaviour {

	public GameObject target;

	public NavMeshAgent agent;

	private Animator animator;

	public Transform root;
	public bool enableRagDoll;
	private RagdollUtility ragdoll;

	// Use this for initialization
	void Start () {
		agent  = GetComponent<NavMeshAgent>();
		animator = GetComponent<Animator>();
		ragdoll = GetComponent<RagdollUtility>();
		//agent.destination = target.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(enableRagDoll){
			ragdoll.EnableRagdoll();
			animator.SetBool("Walk",false);
			animator.SetBool("Ragdoll",true);
		}
		else{
			
			ragdoll.DisableRagdoll();
					//agent.Move();
			if(Vector3.Distance(transform.position,target.transform.position) < 1){
			animator.SetBool("Walk",false);
			agent.isStopped = true;
			
			}
			else{
				if(animator.GetBool("Ragdoll") == false){
					animator.SetBool("Walk",true);
				}
				agent.isStopped = false;
			}
			agent.destination = target.transform.position;
		}
		

	}

	public void Standup () {
		print("animation event");
		animator.SetBool("Walk",true);
    	animator.SetBool("Ragdoll",false);
	}

	void OnTriggerEnter(Collider collision){
		if(collision.transform.tag == "PhysicsObject"){
			print("HERE?");
			StartCoroutine(Example());
		}
	}

	    IEnumerator Example()
    {
		enableRagDoll = true;
        yield return new WaitForSeconds(5);
        enableRagDoll = false;
		// Vector3 rPos = root.position;
		gameObject.transform.position = root.position;
		root.position = Vector3.zero;
    }
}
