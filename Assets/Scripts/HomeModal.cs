using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeModal : MonoBehaviour
{
    public GameObject ModalPanel;
    
	public void openHome()
	{
		if (ModalPanel != null)
		{
			ModalPanel.SetActive(true);
		}
	}
}
