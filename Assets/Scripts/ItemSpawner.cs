using UnityEngine;
using System.Collections.Generic; // WAJIB UNTUK PAKAI LIST<>

public class itemSpawer : MonoBehaviour
{
    public GameObject itemPrefab;
    public List<ItemDataObject> dataToSpawn; // harus sama nama ny kaya script yg ItemDataObjeck nama isi list<> nya
    public int totalItemsToSpawn = 10;
    public Vector2 spawnAreaSize = new Vector2(10,5); // Ukuran area spawn (lebar)

    void Start()
    {
        SpawnAllItems();
    }

    void SpawnAllItems()
    {
        // Validasi : Jangan spawn kalau prefab atau data kososng
        if (itemPrefab == null || dataToSpawn.Count == 0) return;

        for (int i = 0; i < totalItemsToSpawn; i++)
        {
            SpawnSingleItems();
        }
    }

    void SpawnSingleItems()
    {
        // 1. Tentukan Posisi Acak
        Vector2 randomPos = new Vector2(
            Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
            Random.Range(-spawnAreaSize.y / 2, spawnAreaSize.y / 2)
        );

        // Tambahkan offset posisi spawner (SUPAYA AREA IKUT GESER KALAU )
        Vector2 finalPos = (Vector2)transform.position + randomPos;

        // 2. Instantiate (Lahirkan) perfab kosong
        GameObject newItem = Instantiate(itemPrefab, finalPos, Quaternion.identity);

        // 3. Ambil script dan suntikkan data (Dependency Injection sederhana)
        InteractiveItem script = newItem.GetComponent<InteractiveItem>();

        // Pilih data acak dari List
        ItemDataObject randomData = dataToSpawn[Random.Range(0, dataToSpawn.Count)];

        // Konfigurasi Item
        script.Configure(randomData);

        // Opsional : Masukkan ke dalam folder perent biar Hearachy rapi
        newItem.transform.SetParent(this.transform);
    }

    // Fitur Debug : Menggambar kotak area spawn di scene View
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, new Vector3(spawnAreaSize.x, spawnAreaSize.y, 0));
    }
}