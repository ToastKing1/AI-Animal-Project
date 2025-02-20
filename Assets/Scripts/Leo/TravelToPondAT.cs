using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class TravelToPondAT : ActionTask {

		public BBParameter<Transform> pondSpot;
		public BBParameter<NavMeshAgent> navMeshAgent;

		protected override void OnExecute() {
            navMeshAgent = agent.GetComponent<NavMeshAgent>();
            navMeshAgent.value.destination = pondSpot.value.position;
			navMeshAgent.value.stoppingDistance = 0.2f;
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
            if (navMeshAgent.value.remainingDistance <= navMeshAgent.value.stoppingDistance && !navMeshAgent.value.pathPending) 
			{
				EndAction(true);
			}

		}


	}
}