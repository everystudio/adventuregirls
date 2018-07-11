using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SkillCommand : MonoBehaviour {

	[SerializeField]
	private GameObject m_goSkillButtonRoot;

	private SkillButton[] skillButtonArr;

	[SerializeField]
	private Button btnClose;

	public UnityEventInt OnSelectedSkillIndex = new UnityEventInt();
	public UnityEvent OnCancel = new UnityEvent();

	void Awake()
	{
		skillButtonArr = m_goSkillButtonRoot.GetComponentsInChildren<SkillButton>();

		int iIndex = 0;
		foreach( SkillButton btn in skillButtonArr)
		{
			btn.index = iIndex;
			btn.OnClick.AddListener((int _iIndex) =>
			{
				OnSelectedSkillIndex.Invoke(_iIndex);
			});
			iIndex += 1;
		}

		btnClose.onClick.AddListener(() =>
		{
			OnCancel.Invoke();
		});

	}






}
