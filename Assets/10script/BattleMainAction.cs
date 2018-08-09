using HutongGames.PlayMaker;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace BattleMainAction
{
	public class BattleMainActionBase : FsmStateAction
	{
		protected BattleMain battleMain;
		public override void OnEnter()
		{
			base.OnEnter();
			battleMain = Owner.GetComponent<BattleMain>();
		}
	}

	[ActionCategory("BattleMainAction")]
	[HutongGames.PlayMaker.Tooltip("BattleMainAction")]
	public class SkillCommanda : BattleMainActionBase
	{
		public FsmInt selected_skill_index;
		public FsmGameObject obj_skill_command;

		private SkillCommand skillCommand;
		public override void OnEnter()
		{
			base.OnEnter();

			obj_skill_command.Value.gameObject.SetActive (true);

			skillCommand = obj_skill_command.Value.GetComponent<SkillCommand>();

			skillCommand.OnCancel.AddListener(HandleCancel);
			skillCommand.OnSelectedSkillIndex.AddListener(HandleSelectedSkillIndex);
		}

		private void HandleSelectedSkillIndex(int arg0)
		{
			selected_skill_index.Value = arg0;
			Fsm.Event("select");
		}

		private void HandleCancel()
		{
			Fsm.Event("cancel");
		}

		public override void OnExit ()
		{
			base.OnExit ();
			obj_skill_command.Value.gameObject.SetActive (false);
		}
	}
}






