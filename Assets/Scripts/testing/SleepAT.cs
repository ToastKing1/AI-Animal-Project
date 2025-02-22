using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class SleepAT : ActionTask {

		public BBParameter<GameObject> sleepySprite;
        public BBParameter<GameObject> sun;

		protected override void OnExecute() {
			if (sun.value.GetComponent<DayNightCycle>().night)
			{
                sleepySprite.value.SetActive(true);
            }
			
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			if (!sun.value.GetComponent<DayNightCycle>().night)
			{
                sleepySprite.value.SetActive(false);
                EndAction(true);
			}
		}

	}
}