using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class DrinkAT : ActionTask {

		public BBParameter<float> Thirst;
        public BBParameter<AudioSource> source;
        public BBParameter<AudioClip> clip;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			source.value.PlayOneShot(clip.value);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			Thirst.value += 10 * Time.deltaTime;

			if (Thirst.value > 95)
			{
				source.value.Stop();
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