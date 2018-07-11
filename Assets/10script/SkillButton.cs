using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class SkillButton : MonoBehaviour {

	[SerializeField]
	private Button m_btnUse;
	private bool m_bUse;

	public int index;

	public UnityEventInt OnClick = new UnityEventInt();

	void Awake()
	{
		m_btnUse.onClick.AddListener(() =>
		{
		});
	}

	void Start()
	{
		m_bUse = false;
		HideUseButton();
	}

	public void ShowUseButton()
	{
		m_btnUse.gameObject.SetActive(true);
	}

	public void HideUseButton()
	{
		m_btnUse.gameObject.SetActive(false);

		if(m_bUse)
		{
			Debug.Log("use this button");
			OnClick.Invoke(index);
		}
		m_bUse = false;

	}

	public void UseStandby()
	{
		m_bUse = true;
	}
	public void UseCancel()
	{
		m_bUse = false;
	}



}
