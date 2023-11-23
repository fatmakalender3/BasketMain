using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class Skor : MonoBehaviour
{
    public int skor = 0;
    public TextMeshPro scoreText;
    public TextMeshProUGUI scoreUI;
    public int timer = 60;
    public int hedefSayi = 10;
    public TextMeshProUGUI timerText;
    public GameObject endPanel;
    public GameObject winPanel;
    public GameObject losePanel;
    public Transform pota;


    /*
    public float potaHareketHizi = 2.0f; /
    public float hareketMiktariniCarpan = 2.0f; 

    private Vector3 potaBaslangicPozisyonu; 
    */
    
    void Start()
    {
        StartCoroutine(Timer());
        
        /*
        if (sahneAdi == "Level2")
        {
            potaBaslangicPozisyonu = pota.position; 
        }*/
        
    }

    /*
    void Update()
    {
        HareketEttirPota();
    }*/

    IEnumerator Timer()
    {
        string sahneAdi = SceneManager.GetActiveScene().name;

        yield return new WaitForSeconds(1);
        if (timer > 0)
        {
            timer--;
            StartCoroutine(Timer());
            timerText.text = timer.ToString();
        }
        else if (timer == 0)
        {
            //skoru kontrol et ve oyunu bitir
            if (skor >= hedefSayi)
            {
                //kazandın
                yield return new WaitForSeconds(1);
                winPanel.SetActive(true);
            }
            else if (skor < hedefSayi)
            {
                //kaybettin
                yield return new WaitForSeconds(1);
                losePanel.SetActive(true);
            }

            else if (sahneAdi == "Level2")
            {
                if (skor >= hedefSayi)
                {
                    //kazandın
                    yield return new WaitForSeconds(1);
                    endPanel.SetActive(true);
                    //Time.timeScale = 0;
                }
                else if (skor < hedefSayi)
                {
                    //kaybettin
                    yield return new WaitForSeconds(1);
                    losePanel.SetActive(true);
                    //Time.timeScale = 0;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Basketball")
        {
            if (other.GetComponent<BasketCheck>().alt == true &&
                other.GetComponent<BasketCheck>().ust == true)
            {
                skor++;
                scoreText.text = skor.ToString();
                scoreUI.text = "Amazing!!";
                scoreText.color = Color.green;
                Invoke(nameof(BakctoBlack), 1);
                //pota.position = new Vector3(Random.Range(-6.0f,-4.0f),0,Random.Range(-8.0f,-7.0f));
            }
        }
    }

    /*
    private void HareketEttirPota()
    {
        float hareketMiktari = Mathf.Sin(Time.time * potaHareketHizi) * hareketMiktariniCarpan; // Hareket miktarını belirle
        pota.position = potaBaslangicPozisyonu + new Vector3(hareketMiktari, 0, 0); // Yeni pozisyonu belirle
    }*/

    private void BakctoBlack()
    {
        scoreText.color = Color.black;
        scoreUI.text = "";
    }
}
