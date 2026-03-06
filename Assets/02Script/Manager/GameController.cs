using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public bool isDataReaded { get; private set; }
    private EnumPlayer player;

    private int _stage;
    private byte[] _items;
    public int _maxPlayerLife { get; private set; }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
        player = EnumPlayer.Square;
        _maxPlayerLife = 5;
        _items = new byte[4];
    }

    public void ItemSelect(int slot, int jam)
    {
        _items[slot] = (byte)jam;
    }

    public  void StageSelect(int stageNum)
    {
        _stage = stageNum;
    }

    public void DataReadedInvoke()
    {
        isDataReaded = true;
    }

    public void SetPlayerCharacter(EnumPlayer p)
    {
        player = p;
    }

    /*
    public PlayerStateSO GetPlayerCharacter()
    {
        return 
    }
    */
}