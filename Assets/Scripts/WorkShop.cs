using JetBrains.Annotations;
using UnityEngine;

public class WorkShop : MonoBehaviour
{
    public bool riceSet;
    public bool laverSet;
    public bool materialSet;
    public bool oilSet;
    public bool slice;
    public bool sesameSet;
    public Player player;
    void Start()
    {

    }

    void Update()
    {
        
    }

    public void MakeStart()
    {
        riceSet = false;
        laverSet = false;
        materialSet = false;
        oilSet = false;
        slice = false;
        sesameSet = false;
        player.endurance = 100f;
        player.ReduceEndurance();
    }
}
