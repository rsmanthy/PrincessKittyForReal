using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModalWindow : MonoBehaviour
{
	public GameObject ModalPanel;
    
	public void openModal()
	{
		if (ModalPanel != null)
		{
			ModalPanel.SetActive(true);
		}
	}
		
}
