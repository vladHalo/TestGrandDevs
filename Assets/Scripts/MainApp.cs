using UnityEngine;
using UnityEngine.UI;

class MainApp : MonoBehaviour
{
    public static int idSlot;

    [Header("Music")]
    public Music music_script;

    [Header("Button")]
    public GameObject prefabBtn;
    public Transform parent;
    public Sprite[] spriteBtn;
    public FillSlot fillslot_script;

    [Header("Player")]
    public InputField namePlayer;
    public InputField moneyPlayer;
    public Text infoPlayer;

    [HideInInspector]
    public Player player_script;
    ChangePage changePage_script;

    void Start()
    {
        player_script = new Player();
        changePage_script = transform.GetComponent<ChangePage>();

        CreateButtons();
    }

    void CreateButtons()
    {
        for (int i = 0; i < spriteBtn.Length; i++)//count sprite is count btn
        {
            var btn = Instantiate(prefabBtn, parent);
            new ButtonSlot(btn, i, spriteBtn[i], changePage_script, fillslot_script, music_script);
        }
    }

    public void SetPlayer() => player_script.SetPlayer(namePlayer.text, moneyPlayer.text);

    public void SetInfoPlayer() => infoPlayer.text = $"{player_script._name}  {player_script._money}$";
    public void SetNullInfoPlayer() => infoPlayer.text = "";
}