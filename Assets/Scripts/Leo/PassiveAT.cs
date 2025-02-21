using NodeCanvas.Framework;
using ParadoxNotion.Design;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class PassiveAT : ActionTask {

		public float timer;
		public float timeLimit;
		public Transform wanderSpot;
		public BBParameter<NavMeshAgent> navMeshAgent;
		public float wanderRadius;
		public BBParameter<bool> dead;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			wanderSpotPick();
            navMeshAgent.value.stoppingDistance = 0.2f;
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			if (!dead.value)
			{


				timer += 1 * Time.deltaTime;

				if (timer > timeLimit && navMeshAgent.value.remainingDistance < 0.2)
				{
					wanderSpotPick();
					timer = 0;
				}
			}
		}

		void wanderSpotPick()
		{
            Vector3 randomPoint = Random.insideUnitSphere * wanderRadius + agent.transform.position;
            NavMeshHit navMeshHit;

			if (!NavMesh.SamplePosition(randomPoint, out navMeshHit, wanderRadius, NavMesh.AllAreas)){
				return;
			}

			navMeshAgent.value.SetDestination(navMeshHit.position);
        }
    }
}