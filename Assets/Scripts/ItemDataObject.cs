using UnityEngine;

//public enum InteractType;
//{
   // Buah,
   // Heal,
   // Trap,
//}

//[CreateAssetMenu(fileName = "New Item Data", menuName = "Game Data/Item Data")]
public class ItemDataObject : ScriptableObject
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("Visual & Info")]

    public string itemName;
    public Sprite icon;

    //[Header("Behavior Logic")]
   // public InteractType type;

   // [Tooltip("Jika Buah = Score point. Jika Heal = Heal point. Jika Trap = Damage point.")]
    //public int effectValue;
}
