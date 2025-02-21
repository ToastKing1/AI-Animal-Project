using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class RabbitSpawnAT : ActionTask {

        public BBParameter<NavMeshAgent> navMeshAgent;

		protected override void OnExecute() {
            Vector3 randomPoint = Random.insideUnitSphere;
            NavMeshHit navMeshHit;

            if (!NavMesh.SamplePosition(randomPoint, out navMeshHit, 30, NavMesh.AllAreas))
            {
                return;
            }

			navMeshAgent.value.Warp(navMeshHit.position);
			EndAction(true);
        }

	}
}