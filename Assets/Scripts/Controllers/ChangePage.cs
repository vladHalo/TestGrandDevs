using UnityEngine;

class ChangePage : MonoBehaviour
{
    public GameObject[] tables;

    public void NextMenu(int i)
    {
        if(i > transform.childCount - 1)
            return;

        var child = transform.GetChild(i).gameObject;
        if (child.activeSelf == true)
        {
            child.SetActive(false);
            return;
        }

        for(int j=0;j<transform.childCount;j++)
            transform.GetChild(j).gameObject.SetActive(false);
        child.gameObject.SetActive(true);
    }

    public void BackMainMenu()
    {
        tables[0].SetActive(false);
        tables[1].SetActive(false);
        transform.GetChild(transform.childCount-1).gameObject.SetActive(false);
        transform.GetChild(0).gameObject.SetActive(true);
    }
}
