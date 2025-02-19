using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class FleeCT : ConditionTask {

		public BBParameter<GameObject> sun;


		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {
			return sun.value.GetComponent<DayNightCycle>().night;
		}
	}
}