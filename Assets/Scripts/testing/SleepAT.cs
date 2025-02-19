using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class SleepAT : ActionTask {

		public BBParameter<GameObject> sleepySprite;
        public BBParameter<GameObject> sun;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			sleepySprite.value.SetActive(!sleepySprite.value.activeInHierarchy);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			if (sun.value.GetComponent<DayNightCycle>().night)
			{
                sleepySprite.value.SetActive(!sleepySprite.value.activeInHierarchy);
                EndAction(true);
			}
		}

	}
}