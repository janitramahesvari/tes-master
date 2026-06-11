using UnityEngine;

[CreateAssetMenu (fileName = "Game Data/Items/Hazard")]

public class HazardData : ItemDataObject
{
    [Header("Hazard Spesific Data")]

    public int damage;
    public float hazardKnockbackForce;
}