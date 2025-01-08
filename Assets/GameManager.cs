using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using TMPro;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<GameObject> adanaROADS = new List<GameObject>();
    [SerializeField] List<GameObject> enemyCars = new List<GameObject>();
    [SerializeField] List<Transform> spawnPoints = new List<Transform>();
    [SerializeField] float chaseModeRate = 25f;
    [SerializeField] private GameObject roadCamera;
    [SerializeField] private GameObject carParent;
    [SerializeField] private GameObject chaseCamera;
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject callingUIPrefab;
    [SerializeField] float roadLength = 84.0f;
    [SerializeField] float gameSpeed = 5.0f;
    [SerializeField] float enemySpawnRate = 10.0f;
    [SerializeField] private GameObject heart1;
    [SerializeField] private GameObject heart2;
    [SerializeField] private GameObject heart3;
    [SerializeField] private GameObject heart4;
    PoliceSpawner spawner;
    private float spawnSpeed;
    public bool isSpawningEnemy;
    private bool chaseMode;
    public bool dialogEnded = true;
    float seconds = 20f;

    public int health = 4;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateHealth();
        HideCursor();
        Invoke("SpawnRoads",roadLength/gameSpeed-0.1f);
        spawner= FindObjectOfType<PoliceSpawner>();
        isSpawningEnemy = true;
        StartCoroutine(SpawnEnemyCars());
        StartCoroutine(GamePlanner());

    }

    private IEnumerator SpawnEnemyCars()
    {
        while (isSpawningEnemy)
        {
            SpawnEnemyCar();
            yield return new WaitForSeconds(enemySpawnRate);
        }
    }

    private void UpdateHealth()
    {
        switch (health)
        {
            case 1:
                heart1.SetActive(true);
                heart2.SetActive(false);
                heart3.SetActive(false);
                heart4.SetActive(false);
                break;
            case 2:
                heart1.SetActive(true);
                heart2.SetActive(true);
                heart3.SetActive(false);
                heart4.SetActive(false);
                break;
            case 3:
                heart1.SetActive(true);
                heart2.SetActive(true);
                heart3.SetActive(true);
                heart4.SetActive(false);
                break;
            case 4:
                heart1.SetActive(true);
                heart2.SetActive(true);
                heart3.SetActive(true);
                heart4.SetActive(true);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            seconds = 1f;
        }


        if (Input.GetKeyDown(KeyCode.M) && !chaseMode)
        {
            SpawnEnemyCar();
        }
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private IEnumerator GamePlanner()
    {
             yield return new WaitForSeconds(5f);
             yield return SpawnCallingUI("BIR POLIS VURMAK MI ?! KAFAYI MI YEDIN SEN ?  BUNUN SONU NE OLUR HIC MI DUSUNMEDIN ? SANA BEKLE DEMISTIM AMA ILLA GIDIP BENSIZ BIR SEYLER CEVIRECEKTIN DEGIL MI ? TUM EMNIYET PESINE DUSTU","ONU BEN VURMADIM !","BEN DEGILDIM !","Oyle olsa bile artik tum emniyet senin pesinde. Simdi Riza Amir'in yanina gidiyorum bakalim o ne diyecek","Oyle olsa bile artik tum emniyet senin pesinde. Simdi Riza Amir'in yanina gidiyorum bakalim o ne diyecek");
             yield return new WaitForSeconds(seconds); 
             StartChaseMode();
             yield return new WaitForSeconds(seconds);
             StartChaseMode();
             yield return new WaitForSeconds(seconds);
             StartChaseMode();
             yield return new WaitForSeconds(seconds);
             StartChaseMode();
             yield return new WaitForSeconds(seconds);
             StartChaseMode();
             yield return new WaitForSeconds(seconds);
             yield return new WaitForSeconds(seconds);
             yield return SpawnCallingUI("SIMDI RIZA AMIRIN ODASINDAN CIKTIM. OLAY SADECE VURULMA DEGIL. CASEY DAVASINDA ARASTIRDIGIMIZ TUM POLISLER OLU BULUNMUS. SENIN YAPTIGINI DUSUNUYORLAR","Ben kimseyi vurmadim","DEMEK TUM SUCU BANA ATIP ISIN ICINDEN CIKACAKLAR HA ?","HMMM.. SANIRIM BIRILERI DAVAYI SENIN USTUNE YIKIP TEK TASLA IKI KUS VURMAYA CALISIYOR. SIMDI VURULAN POLISLERIN EVINE GIDIYORUM IPUCU BULURSAM ARARIM","TAM DA OYLE OLUYOR GIBI GOZUKUYOR. SIMDI VURULAN POLISLERIN EVINE GIDIYORUM IPUCU BULURSAM ARARIM.");
             yield return new WaitForSeconds(seconds);
             StartChaseMode();
             yield return new WaitForSeconds(seconds);
             StartChaseMode();
             yield return new WaitForSeconds(seconds);
             StartChaseMode();
             yield return new WaitForSeconds(seconds);
             yield return SpawnCallingUI("HER BIR EVI DIDIK DIDIK ARADIM TARADIM AMA HEPSI TERTEMIZDI. HATTA GEREKSIZ TEMIZDI. SANKI BIRISI HER MEKANI TEMIZLEMIS GIBI. SADECE USTUNDE GARIP BIR LOGO OLAN BURUSUK BIR KAGIT BULABILDIM.","KEMALE GOTUR O BU ISLERDE UZMANDIR","SENCE LOGONUN ANLAMI NE OLABILIR ?","EVET YOLA CIKTIM BILE KEMALIN YANINA VARINCA ARARIM BAKALIM KEMALDEN BIR SEY CIKACAK MI ?","BILMIYORUM AMA HAPISHANE DOVMELERINE BENZIYOR BELKI ISLENEN SUCLAR ICIN BIR TUR IMZA BIRAKMAK ISTEDILER. LOGOYU KEMALE GOTURUYORUM BAKALIM O NE DIYECEK.");
             StartChaseMode();
             yield return new WaitForSeconds(seconds);
             StartChaseMode();
             yield return new WaitForSeconds(seconds);
             StartChaseMode();
             yield return new WaitForSeconds(seconds);
             yield return SpawnCallingUI("SIMDI KEMALIN YANINDAN CIKTIM. ILK DEFA KEMAL'IN BILE BILMEDIGI BIR SEY ILE KARSI KARSIYAYIZ AMA BUNUN GIBI BIR SIMGEYI DAHA ONCE HALEY CLUBDA GORDUGUNU SOYLEDI. AMIRIN SUREKLI TAKILDIGI MEKAN... GITTIKCE DERINLESIYOR HA ?","SENCE ISIN ICINDE AMIR DE OLABILIR MI ?","SANIRIM EN IYI SANSIMIZ O CLUB.","SANMAM AMIR O KADAR DA CESUR BIR INSAN DEGILDIR AMA KIMSEYE DE GUVENMEMEMIZ GEREK. YOLA CIKIYORUM VARINCA ARARIM","O CLUB HAKKINDA HIC IYI SEYLER DUYMADIGIM KESIN. BAZILARI LANETLI OLDUGUNU BILE SOYLER. ORAYA GIDINCE HABER EDERIM");
             yield return new WaitForSeconds(seconds);
             StartChaseMode();
             yield return new WaitForSeconds(seconds);
             StartChaseMode();
             yield return new WaitForSeconds(seconds);
             StartChaseMode();
             yield return new WaitForSeconds(seconds);
             StartChaseMode();
             yield return new WaitForSeconds(seconds);
             yield return SpawnCallingUI("TAMAM CLUB'UN ONUNE GELDIM SIMDI. GUVENLIKTEN GECMEYE CALISACAGIM ONDAN SONRASINA BAKARIZ.","DIKKATLI OL","SANA GUVENIYORUM","6 SENEDIR BERABER GOREVLERE CIKIYORUZ HALA BANA DIKKATLI OL DIYORSUN. AAHHH HIC DEGISMIYORSUN DEGIL MI ? BIR SEYLER BULDUGUMDA ARAYACAGIM","HAHAHAHA SEN KIMSIN VE ESKI SEMIH'E NE YAPTIN ? BIR SEYLER BULDUGUMDA ARAYACAGIM");
             yield return new WaitForSeconds(seconds);
             StartChaseMode();
             yield return new WaitForSeconds(seconds);
             StartChaseMode();
             yield return new WaitForSeconds(seconds);
             StartChaseMode();
             yield return new WaitForSeconds(seconds);
             StartChaseMode();
             yield return new WaitForSeconds(seconds);
             yield return SpawnCallingUI("CLUBA GIRMEYI BASARDIM SIMDI BILGI TOPLAMAK ICIN ICERIYI ARASTIRIYORUM","TAMAM BEKLIYORUM.","BELKI DE MEKANIN SAHIBINE SORMALISIN ?","BARMENE SORMAYA GIDIYORUM BAKALIM O NELER BILIYORMUS.","AYNEN GIDIP ADAMIN ODASINI BASAYIM SONRA DA HEY MERHABALAR BANA TUM BILDIKLERINI ANLAT YOKSA SENI VURURUM DIYEYIM. GERCEKTEN COK MANTIKLI OLUR DI MI ?. BARMENDEN BALSIYORUM.");   
             yield return new WaitForSeconds(seconds);
             StartChaseMode();
             yield return new WaitForSeconds(seconds);
             StartChaseMode();
             yield return new WaitForSeconds(seconds);
             StartChaseMode();
             yield return new WaitForSeconds(seconds);
             yield return SpawnCallingUI("BARMENDEN BIR SEY CIKMADI... AMA IKI SOL MASADAKI ADAMIN TEKI SUREKLI BURAYA BAKIYOR. BIR SEYLER BILIYOR SANKI. BIRAZDAN ONA SORACAGIM","SUPHELENMIS OLABILIRLER. CIK ORADAN","MEKANIN SAHIBINE GERI DONELIM MI ?","BASKA BIR IPUCUMUZ KALMADI ORAYA GIDIYORUM.","O PLANI KAFANDAN AT. ORAYA GIDIYORUM"); 
             yield return new WaitForSeconds(seconds);
             StartChaseMode();
             yield return new WaitForSeconds(seconds);
             StartChaseMode();
             yield return new WaitForSeconds(seconds);
             StartChaseMode();
             yield return new WaitForSeconds(seconds);
             yield return SpawnCallingUI("ADAMIN MASASINA OTURDUM. TAM BIR DENYO AMA BANA LOGONUN ANLAMINI ANLATTI. BU LOGO CASEY DAVASINDA ARASTIRDIGIMIZ FALIA KARTELININ TETIKCILERININ SIMGESIYMIS SANIRIM BIR YERLERE VARIYORUZ. SIMDI CLUBTAN CIKIYORUM BURADA BULUSALIM.","TAMAM GELIYORUM.","BIRAZDAN ORADAYIM.","CIKISTA BEKLIYOR OLACAGIM","TAMAM CIKISA GECIYORUM."); 
             yield return new WaitForSeconds(seconds);
             StartChaseMode();
             yield return new WaitForSeconds(seconds);
             StartChaseMode();
             yield return new WaitForSeconds(seconds);
             yield return SpawnCallingUI("SEMIH ! SAKIN BURAYA GELM....... GELM.EEE..... BENI TANIDI....LAR.... SU AN KACIYORUM.... GEL.... *AAAHHH* ","NOLDU !!?!?!","IYI MISIN CEVAP VER !","................",".............."); 
             yield return new WaitForSeconds(5f);
             SceneManager.LoadScene("EndGame");
    }

    public IEnumerator SpawnCallingUI(string dialog,string firstoption,string secondoption,string firstanswer,string secondanswer)
    {
        dialogEnded = false;
        isSpawningEnemy = false;
        foreach (Transform child in carParent.transform)
        {
            // Child objeyi yok et
            Destroy(child.gameObject);
        }
        ShowCursor();
        UIController dialogMenu = Instantiate(callingUIPrefab, Vector3.zero,transform.rotation,canvas.transform).GetComponent<UIController>();
        dialogMenu.GetComponent<RectTransform>().anchoredPosition = new Vector3(-84, 638.24f, 0); 
        dialogMenu.dialogT = dialog;
        dialogMenu.optionsFirstT = firstoption;
        dialogMenu.optionsSecondT = secondoption;
        dialogMenu.answerFirst = firstanswer;
        dialogMenu.answerSecond = secondanswer;
        while (true)
        {
            if (dialogEnded)
            {
                print("BREAK THE POINT");
                break;
                
            }

            yield return new WaitForSeconds(2f);
        }
        StartCoroutine(SpawnEnemyCars());
    }

    private void StartChaseMode()
    {
        chaseMode = true;
        isSpawningEnemy = false;
        StartChasing();
        spawner.Spawn();
        foreach (Transform child in carParent.transform)
        {
            // Child objeyi yok et
            Destroy(child.gameObject);
        }
        
        
    }

    void SpawnRoads()
    {
        
        Instantiate(adanaROADS[Random.Range(0,adanaROADS.Count)], transform.position, Quaternion.identity).transform.GetChild(0).GetComponent<RoadScript>().movementSpeed = gameSpeed;
        Invoke("SpawnRoads",roadLength/gameSpeed-0.1f);
        
    }


    public void SpawnEnemyCar()
    {
        Instantiate(enemyCars[Random.Range(0,enemyCars.Count)], spawnPoints[Random.Range(0,spawnPoints.Count)].position, Quaternion.Euler(0, 180, 0)).transform.SetParent(carParent.transform);
    }

    public void ChangeHealth(int amount)
    {
        if (health + amount > 0)
        {
            health += amount;
            UpdateHealth();
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void ChangeCameraLook(bool status)
    {
        chaseCamera.SetActive(status);
        roadCamera.SetActive(!status);
    }

    public void StopChasing()
    {
        ChangeCameraLook(false);
        HideCursor();
        chaseMode = false;
        isSpawningEnemy = true;
        StartCoroutine(SpawnEnemyCars());
    }

    public void StartChasing()
    {
        ChangeCameraLook(true);
        ShowCursor();
    }
    
    public void HideCursor()
    {
        Cursor.visible = false;       // İmleci görünmez yapar
        Cursor.lockState = CursorLockMode.Locked; // İmleci ekrana kilitler
    }

    // Cursor'u gösteren bir fonksiyon
    public void ShowCursor()
    {
        Cursor.visible = true;        // İmleci görünür yapar
        Cursor.lockState = CursorLockMode.None;  // İmleci serbest bırakır
    }

}
