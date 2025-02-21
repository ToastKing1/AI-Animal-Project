using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class AttackAT : ActionTask {

        public BBParameter<AudioSource> source;
		public BBParameter<AudioClip> clip;

        public BBParameter<GameObject> rabbit;
		public Transform rabbitTransform;
        public BBParameter<NavMeshAgent> navMeshAgent;

		bool roar;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

        //This is called once each time the task is enabled.
        //Call EndAction() to mark the action as finished, either in success or failure.
        //EndAction can be called from anywhere.
		protected override void OnExecute() {
			roar = false;
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
            if (navMeshAgent.value.remainingDistance <= navMeshAgent.value.stoppingDistance && !navMeshAgent.value.pathPending)
            {
				if (!roar)
				{
					source.value.PlayOneShot(clip.value);
					roar = true;
				}
				Blackboard rabbitBlackboard = rabbit.value.GetComponent<Blackboard>();
				rabbitBlackboard.SetVariableValue("dead", true);
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