using UnityEngine;
using UnityEngine.UI;

class CheckWin//Проверка только на 1 линию
{
    public int[] index = { 2, 5, 20 };
    //public FillSlot fillSlot_script;

    public float CheckWinLine(int amount,Transform main)
    {
        float sum = 0;
        string[,] names = new string[3, 5];

        for (int i = 0; i < names.GetLength(0); i++)
            for (int j = 0; j < names.GetLength(1); j++)
                names[i, j] = main.GetChild(i).transform.GetChild(j).GetComponent<Image>().sprite.name;

        int indexWin = 1;

        //for (int i = 0; i < names.GetLength(0) - 1; i++)
            for (int j = 0; j < names.GetLength(1) - j; j++)
                if (names[0, j] == names[0, j+1])
                    indexWin++;
                else break;

        if (indexWin >= 3)
            sum += amount * index[indexWin] / 20;

        return sum;
    }
}
