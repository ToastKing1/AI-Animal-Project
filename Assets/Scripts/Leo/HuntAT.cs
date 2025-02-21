using NodeCanvas.Framework;
using ParadoxNotion.Design;
using ParadoxNotion.Serialization.FullSerializer;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class HuntAT : ActionTask {


		public float huntRadius;
		public BBParameter<GameObject> rabbit;
		public LayerMask rabbitLayerMask;
        public Transform wanderSpot;
        public BBParameter<NavMeshAgent> navMeshAgent;
        public float wanderRadius;

		protected override void OnExecute() {
            navMeshAgent.value.stoppingDistance = 1f;
            rabbit.value = null;
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
            if (rabbit.value == null)
            {
                Collider[] detectedColliders = Physics.OverlapSphere(agent.transform.position, huntRadius, rabbitLayerMask);
                if (detectedColliders.Length > 0)
                {

                    rabbit.value = detectedColliders[0].gameObject;
                    
                }
                else
                {
                    if (navMeshAgent.value.remainingDistance < 0.2)
                    {
                        wanderSpotPick();
                    }

                }
            }
            else
            {
                Debug.Log(navMeshAgent.value.remainingDistance);
                navMeshAgent.value.destination = rabbit.value.transform.position;
                if (navMeshAgent.value.remainingDistance < 1.25)
                {
                    rabbit.value.GetComponent<NavMeshAgent>().isStopped = true;
                    EndAction(true);
                }
                
            }
        }

        void wanderSpotPick()
        {
            Vector3 randomPoint = Random.insideUnitSphere * wanderRadius + agent.transform.position;
            NavMeshHit navMeshHit;

            if (!NavMesh.SamplePosition(randomPoint, out navMeshHit, wanderRadius, NavMesh.AllAreas))
            {
                return;
            }

            navMeshAgent.value.SetDestination(navMeshHit.position);
        }
    }
}