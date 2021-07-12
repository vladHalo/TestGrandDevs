class Player
{
    public string _name;
    public float _money;

    public void SetPlayer(string name, string money)
    {
        _name = name;
        _money = float.Parse(money);
    }
}
