using UnityEngine;
using UnityEngine.UI;

class SpinLogic : MonoBehaviour
{
    [Header("Button Active")]
    public GameObject btnSpin;
    public GameObject btnAmount;

    [Header("Text Info")]
    public Text amount_Text;
    public Text win;
    public Text infoPlayer;
    
    [Header("Move Lines")]
    public float step;
    int index = 0;
    int sum = 1;
    float progress;
    bool spinStatus = false;
    Vector3[] startPos;
    Transform child;

    [Header("Take player info")]
    public MainApp mainApp_script;
    
    int[] indexAmount = { 1, 2, 5, 10, 25, 50 };
    
    void Start()
    {
        child = transform.GetChild(0).transform;
    }

    void FixedUpdate()
    {
        if (spinStatus)
        {
            int count = child.childCount;
            if(count==15)
                count=10;
            for (int i = 0; i < count; i++)
                child.GetChild(i).localPosition = Vector3.Lerp(startPos[i], new Vector3(startPos[i].x, startPos[i].y - 4000, 0), progress);
            progress += step;
        }

        if (child.GetChild(0).localPosition.y == -2300)
        {
            spinStatus = false;
            
            for (int j = 0; j < 5; j++)
                Destroy(child.GetChild(j).gameObject);
            
            CheckWin checkWin = new CheckWin();
            var result = checkWin.CheckWinLine(sum, child);
            win.text= $"Win:{result}";
            
            var name = mainApp_script.player_script._name;
            var money = mainApp_script.player_script._money += result;
            infoPlayer.text = $"{name} {money}$";

            btnSpin.SetActive(true);
            btnAmount.SetActive(true);
        }
    }

    public void Spin()
    {
        btnSpin.SetActive(false);
        btnAmount.SetActive(false);

        transform.GetComponent<FillSlot>().Fill(MainApp.idSlot,5700);
        spinStatus = true;
        progress = 0;

        child = transform.GetChild(0).transform;
        startPos = new Vector3[child.childCount];

        for (int i = 0; i < child.childCount; i++)
            startPos[i] = child.GetChild(i).localPosition;
    }

    public void AddAmount()
    {
        if (index == indexAmount.Length - 1)
            return;
        index++;
        SetAmount();
    }

    public void MinAmount()
    {
        if (index == 0)
            return;
        index--;
        SetAmount();
    }

    void SetAmount()
    {
        sum = indexAmount[index];
        amount_Text.text = $"{sum}$";
    }
}