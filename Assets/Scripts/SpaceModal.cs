using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceModal : MonoBehaviour
{
    public GameObject ModalPanel;
    
	public void openSpace()
	{
		if (ModalPanel != null)
		{
			ModalPanel.SetActive(true);
		}
	}
}
