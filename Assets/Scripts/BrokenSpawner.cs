using UnityEngine;
using System.Collections.Generic;

public class BrokenWaveSpawner : MonoBehaviour
{
    [Header("Setup")]
    // ERROR TARGET 3: UnassignedReferenceException (karena lupa drag)
    public GameObject itemPrefab; //buat drag prefab yg mau di spawn ke inspector


    // ERROR TARGET 2: IndexOutOfRangeException (Looping bablas)
    public List<ItemDataObject> itemDataList; //daftar data tiap item dr game data yg udh dibuat 
    // yg dimasukin di item data list


    // ERROR TARGET 4: Variable is never assigned (Warning)
    // Variabel ini dibuat, tidak pernah diisi nilai, tapi logikanya dipakai.
    private float timeBetweenWaves = 1f; //atur jeda waktu

    // ERROR TARGET 1: NullReferenceException (Array tidak di-new)
    private Transform[] spawnPoints; //nyimpen nilai spawn dan masih bernilai null

    void Start()
    {
        spawnPoints = GetComponentsInChildren<Transform>(); //buat ambil spawnpoint yg kita buat
        // Simulasi mengisi data wave (hardcode biar cepat)
        // Asumsi folder Resources ada, atau biarkan kosong biar error Index makin parah
        // (Siswa cukup tahu list ini ada isinya nanti lewat inspector)
        List<Transform> temp = new List<Transform>(); //wadah sementara kkosong

    foreach (Transform spawn in spawnPoints)
    {
        if (spawn != transform) //item spawner kebuang  
            temp.Add(spawn);
    }

    spawnPoints = temp.ToArray(); //spawn point diubah ke array
        StartWave();
    }

    void StartWave()
    {
        // BUG (Warning): timeBetweenWaves nilai defaultnya 0 karena tidak pernah di-assign.
        // Warning kuning akan muncul di Console / IDE.
        Invoke("SpawnAllItems", timeBetweenWaves); //setelah 1 detik baru bisa spawn dan ini cuma bisa spawn sekali
    }

    void SpawnAllItems()
    {
       
        // BUG: Loop menggunakan '<=' (Kurang Dari Sama Dengan)
        // Jika isi list 3, dia akan minta data ke-0, 1, 2, dan 3.
        // Data ke-3 tidak ada -> IndexOutOfRangeException.
        for (int i = 0; i < itemDataList.Count; i++) //jumlah spawn= item data list
        {
       
        
            // BUG: Mencoba akses array spawnPoints yang belum diinisialisasi (masih null)
            // Ini akan memicu NullReferenceException.
           Transform targetPoint = spawnPoints[i % spawnPoints.Length]; //ambil spawn point secara muter / ulang dari awal kalau itemnya lebih banyak dari spawn point


            // BUG: Jika itemPrefab belum di-drag di Inspector, 
            // Instantiate akan gagal (UnassignedReferenceException / NullRef)
            GameObject newItem = Instantiate(itemPrefab, targetPoint.position, Quaternion.identity); //buat ngeclone dr prefab
            
            // Setup Data                                                                                                                                                                     
            InteractiveItem script = newItem.GetComponent<InteractiveItem>(); //
            script.Configure(itemDataList[i]); //kirim data ke itemlist 
        
    
        }
    }
}