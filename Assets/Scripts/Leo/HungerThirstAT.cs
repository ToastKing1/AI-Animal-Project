using System;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class HungerThirstAT : ActionTask {

		public BBParameter<bool> sleeping;

		public BBParameter<float> thirst;
		public BBParameter<float> hunger;

		public BBParameter<float> survivalRate;

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			if (sleeping.value) EndAction();
			
			thirst.value -= survivalRate.value * Time.deltaTime;
			hunger.value -= survivalRate.value * Time.deltaTime;
		}

		
	}
}