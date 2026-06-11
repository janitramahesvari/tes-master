using UnityEngine;

[CreateAssetMenu (fileName = "Game Data/Items/Harvest")]

public class HarvestData : ItemDataObject
{
    [Header("Harvest Spesific Data")]

    public int Score;
    public AudioClip AudioClipDiambil;
}