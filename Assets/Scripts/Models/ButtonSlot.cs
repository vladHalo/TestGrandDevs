using UnityEngine;
using UnityEngine.UI;

class ButtonSlot
{
	int _id;
	public ButtonSlot(GameObject btn, int id, Sprite mainImg, ChangePage changePage_script,FillSlot fillslot_script,Music music_script)
	{
		_id = id;
		btn.name = $"Slot{id}";
		btn.GetComponent<Image>().sprite = mainImg;
		btn.GetComponent<Button>().onClick.AddListener(()=>music_script.PlaySound());
		btn.GetComponent<Button>().onClick.AddListener(()=>changePage_script.NextMenu(2));
		btn.GetComponent<Button>().onClick.AddListener(()=>fillslot_script.Fill(id,1700));
		btn.GetComponent<Button>().onClick.AddListener(GetId);
		btn.GetComponent<RectTransform>().rect.Set(0, 0, 300, 300);
	}

	void GetId() => MainApp.idSlot = _id;
}