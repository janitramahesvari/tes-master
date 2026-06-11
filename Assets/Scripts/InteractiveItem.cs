using UnityEngine;
using UnityEngine.UIElements;

public class InteractiveItem : MonoBehaviour
{
    // --- AREA SCRIPTABLE OBJECT ---
    [Header("Scriptable Object Data")]
    [SerializeField] private ItemDataObject itemData;
    public SpriteRenderer spriteRenderer;
   

    private void Awake()
    {
            spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        //spriteRenderer = GetComponent<SpriteRenderer>();
        
       // if (itemData != null && spriteRenderer != null)
        //{
          //  spriteRenderer.sprite = itemData.icon;
        //}
    }

//public void configure(ItemDataObject newData)
    //{
  //      itemData = newData;

        // Otomatis ganti gambar sesuai data yang diberikan spawner
    //    if (spriteRenderer == null) spriteRenderer = GetComponent<SpriteRenderer>();
      //  if (itemData != null && spriteRenderer != null)
        //{
          //  spriteRenderer.sprite = itemData.icon;
        //}
    //}
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ApplyEffect();
        }
    }

    void ApplyEffect()
    {
        //New Method Using Scriptable Object
        if (itemData == null)
        {
            Debug.LogWarning("ItemDataObject is not assigned!");
            return;
        }
           
        if (itemData is HarvestData harvest)
        {
            Debug.Log($"Buah diambil dan mendapatkan skor:{harvest.Score} points");
            //AudioSource.PlayClipAtPoint(harvest.AudioClipDiambil);
             Destroy(gameObject);

        } else if (itemData is HazardData hazard)
        {
            Debug.Log($"Menabrak {hazard.itemName}! terkena damage sebanyak: {hazard.damage}");
         } else
         {
                Debug.Log("Objek tidak dikenali");
        }
    }

       // public void Configure(ItemDataObject data)
        public void Configure(ItemDataObject newData)
{
    itemData = newData;

    if (spriteRenderer == null)
        spriteRenderer = GetComponent<SpriteRenderer>();

    if (itemData != null && spriteRenderer != null)
    {
        spriteRenderer.sprite = itemData.icon;
    }
} //ini buat method di interactive gara2 error di script brokenspawner configure
//{


//}
  
       // switch (itemData.type)
       // {
           // case InteractType.Buah:
              //  Debug.Log($"<color=yellow>Harvested {itemData.itemName}!</color> Score +{itemData.effectValue}");
               // Destroy(gameObject);
               // break;

           // case InteractType.Heal:
               // Debug.Log($"<color=green>Used {itemData.itemName}!</color> Healed +{itemData.effectValue}");
              //  Destroy(gameObject);
               // break;
            
           // case InteractType.Trap:
              //  Debug.Log($"<color=red>Hit by {itemData.itemName}!</color> Damage -{itemData.effectValue}");
            //   break;
       // }
   
}
