using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

class FillSlot : MonoBehaviour
{
	public List<Slot> slotsInfo;
	public GameObject prefabSlot;
	public GameObject prefabLine;
	public Transform lineParent;
	public Transform tableInfo;

	[HideInInspector]
	public Vector3[] linesStartPos;

	int X = -800;
	
	private void Start()
	{
		Fill(0,5700);
	}

	public void Fill(int idSlot,int Y)
	{
		linesStartPos = new Vector3[5];
		for (int i = 0; i < 5; i++)
		{
			var line = Instantiate(prefabLine,lineParent);
			line.transform.localPosition = new Vector3(X, Y, 0);
			
			for (int j = 0; j < 20; j++)
			{
				int randCube = Random.Range(0, slotsInfo[idSlot].slot_sprites.Length);
				var prefab = Instantiate(prefabSlot,line.transform);
				prefab.name = $"Slot{j}";
				prefab.GetComponent<Image>().sprite = slotsInfo[idSlot].slot_sprites[randCube];
			}

			linesStartPos[i] = line.transform.position;
			X += 250;
		}

		X = -800;

		for (int i = 0; i < tableInfo.childCount; i++)
			tableInfo.GetChild(i).GetComponent<Image>().sprite = slotsInfo[idSlot].slot_sprites[i];
	}

	public void RefreshPosition()
	{
		for (int i = 0; i < lineParent.childCount; i++)
			lineParent.GetChild(i).position = linesStartPos[i];
	}
}