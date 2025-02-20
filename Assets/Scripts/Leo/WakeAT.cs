using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine.AI;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class WakeAT : ActionTask {

        public BBParameter<Transform> morningSpot;
        public BBParameter<NavMeshAgent> navMeshAgent;
        public BBParameter<bool> interrupted;

        protected override void OnExecute()
        {
            if (interrupted.value)
            {
                interrupted.value = false;
                navMeshAgent.value.ResetPath();
                EndAction(true);
            }
            else
            {
                navMeshAgent = agent.GetComponent<NavMeshAgent>();
                navMeshAgent.value.destination = morningSpot.value.position;
                navMeshAgent.value.stoppingDistance = 0.2f;
            }
        }

        //Called once per frame while the action is active.
        protected override void OnUpdate()
        {
            if (navMeshAgent.value.remainingDistance <= navMeshAgent.value.stoppingDistance && !navMeshAgent.value.pathPending)
            {
                EndAction(true);
            }

        }
    }
}