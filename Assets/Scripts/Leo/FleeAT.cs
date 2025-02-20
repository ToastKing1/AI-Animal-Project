using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class FleeAT : ActionTask {

        public BBParameter<GameObject> sun;
		public BBParameter<Transform> sleepingSpot;
        public BBParameter<NavMeshAgent> navMeshAgent;

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
            navMeshAgent = agent.GetComponent<NavMeshAgent>();
            navMeshAgent.value.destination = sleepingSpot.value.position;
            navMeshAgent.value.stoppingDistance = 0.2f;
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
            if (sun.value.GetComponent<DayNightCycle>().night)
			{
                EndAction(true);
            }
            else if (navMeshAgent.value.remainingDistance <= navMeshAgent.value.stoppingDistance && !navMeshAgent.value.pathPending)
            {
                EndAction(true);
            }

        }
	}
}