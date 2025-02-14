using System;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class HungerThirstAT : ActionTask {

		public BBParameter<bool> sleeping;

		public BBParameter<float> thirst;
		public BBParameter<float> hunger;

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			if (sleeping.value) EndAction();
			
			thirst.value -= 1 * Time.deltaTime;
			hunger.value -= 1 * Time.deltaTime;
		}

		
	}
}