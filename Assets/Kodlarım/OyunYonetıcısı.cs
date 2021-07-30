using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OyunYonetıcısı : MonoBehaviour
{
    GameObject donenCember;
    GameObject AnaCember;
    public Animator animator;
    public Text DonenCemberLevel;
    public Text bir;
    public Text iki;
    public Text uc;
    public int KacTaneKucukCemberOlsun;
    bool kontrol = true;

    void Start()

    {
        PlayerPrefs.SetInt("kayit",int.Parse(SceneManager.GetActiveScene().name));
        
       
        donenCember = GameObject.FindGameObjectWithTag("donencembertag");
        AnaCember = GameObject.FindGameObjectWithTag("anacembertag");
        DonenCemberLevel.text = SceneManager.GetActiveScene().name;

        if (KacTaneKucukCemberOlsun < 2)
        {
            bir.text = KacTaneKucukCemberOlsun + "";
        }
        else if (KacTaneKucukCemberOlsun < 3)
        {
            bir.text = KacTaneKucukCemberOlsun + "";
            iki.text = (KacTaneKucukCemberOlsun - 1) + "";
        }
        else
        {
            bir.text = KacTaneKucukCemberOlsun + "";
            iki.text = (KacTaneKucukCemberOlsun - 1) + "";
            uc.text = (KacTaneKucukCemberOlsun - 2) + "";
        }
        


    }
    
    public void KucukCemberlerdeTextGosterme()
    {
        KacTaneKucukCemberOlsun--;
        if (KacTaneKucukCemberOlsun < 2)

        {
            bir.text = KacTaneKucukCemberOlsun + "";
            iki.text = "";
            uc.text = "";
        }
        else if (KacTaneKucukCemberOlsun < 3)
        {
            bir.text = KacTaneKucukCemberOlsun + "";
            iki.text = (KacTaneKucukCemberOlsun - 1) + "";
            uc.text = "";
        }
        else
        {
            bir.text = KacTaneKucukCemberOlsun + "";
            iki.text = (KacTaneKucukCemberOlsun - 1) + "";
            uc.text = (KacTaneKucukCemberOlsun - 2) + "";
        }
        if (KacTaneKucukCemberOlsun == 0)
        {
            StartCoroutine(yeniLevel());

        }

    }
    IEnumerator yeniLevel()
    {

        donenCember.GetComponent<Dondurme>().enabled = false;
        AnaCember.GetComponent<AnaCember>().enabled = false;
        yield return new WaitForSeconds(0.5f);
        if (kontrol)
        {
            animator.SetTrigger("yenilevel");
            yield return new WaitForSeconds(1.5f);

            SceneManager.LoadScene(int.Parse(SceneManager.GetActiveScene().name) + 1);
        }


    }

    
   

    public void OyunBitti()
    {
        StartCoroutine(CagrılanMetot());
    }


    IEnumerator CagrılanMetot()
    {
        donenCember.GetComponent<Dondurme>().enabled = false;
        AnaCember.GetComponent<AnaCember>().enabled = false;
        animator.SetTrigger("oyunbitti");
        kontrol = false;

        yield return new WaitForSeconds(1); // 1 saniye bekletiyoruz
        

        
        SceneManager.LoadScene("AnaMenu");


    }
}
