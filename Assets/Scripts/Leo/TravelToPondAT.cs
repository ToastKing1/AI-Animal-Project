using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class TravelToPondAT : ActionTask {

		public BBParameter<Transform> pondSpot;
		public NavMeshAgent navMeshAgent;


		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
            navMeshAgent = agent.GetComponent<NavMeshAgent>();
            navMeshAgent.destination = pondSpot.value.position;
			navMeshAgent.stoppingDistance = 0.2f;
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
            if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance && !navMeshAgent.pathPending) 
			{
				EndAction(true);
			}

		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}