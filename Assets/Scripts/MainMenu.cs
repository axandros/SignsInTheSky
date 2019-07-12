using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public enum Zodiac { Aquarius, Aries, Cancer, Capricorn, Gemini, Leo, Libra, Picese, Sagittarius, Scorpio, Taurus, Virgo }

    [SerializeField]
    private Text WinTextBox = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel(Zodiac level)
    {
        switch (level)
        {
            case Zodiac.Aquarius: SceneManager.LoadScene("Aquarius"); break;
            case Zodiac.Aries: SceneManager.LoadScene("Aries"); break;
            case Zodiac.Cancer: SceneManager.LoadScene("Cancer"); break;
            case Zodiac.Capricorn: SceneManager.LoadScene("Capricorn"); break;
            case Zodiac.Gemini: SceneManager.LoadScene("Gemini"); break;
            case Zodiac.Leo: SceneManager.LoadScene("Leo"); break;
            case Zodiac.Libra: SceneManager.LoadScene("Libra"); break;
            case Zodiac.Picese: SceneManager.LoadScene("Picese"); break;
            case Zodiac.Sagittarius: SceneManager.LoadScene("Sagittarius"); break;
            case Zodiac.Scorpio: SceneManager.LoadScene("Scorpio"); break;
            case Zodiac.Taurus: SceneManager.LoadScene("Taurus"); break;
            case Zodiac.Virgo: SceneManager.LoadScene("Virgo"); break;
        }
        
    }

    public void LoadAquarius()
    { LoadLevel(Zodiac.Aquarius); }
    public void LoadAries()
    { LoadLevel(Zodiac.Aries); }
    public void LoadCancer()
    { LoadLevel(Zodiac.Cancer); }
    public void LoadCapricorn()
    { LoadLevel(Zodiac.Capricorn); }
    public void LoadGemini()
    { LoadLevel(Zodiac.Gemini); }
    public void LoadLeo()
    { LoadLevel(Zodiac.Leo); }
    public void LoadLibra()
    { LoadLevel(Zodiac.Libra); }
    public void LoadPicese()
    { LoadLevel(Zodiac.Picese); }
    public void LoadSagittarius()
    { LoadLevel(Zodiac.Sagittarius); }
    public void LoadScorpio()
    { LoadLevel(Zodiac.Scorpio); }
    public void LoadTaurus()
    { LoadLevel(Zodiac.Taurus); }
    public void LoadVirgo()
    { LoadLevel(Zodiac.Virgo); }

    public void ReturnToMain()
    {
        Debug.Log("Called Return to Main");
        SceneManager.LoadScene("Menu");
    }

    public void Win(string Constellation)
    {
        
        if(WinTextBox != null)
        {
            string display = Constellation + " Completed";
            Debug.Log(display);
            WinTextBox.text = display;
            //WinTextBox.
        }
        else { Debug.Log("Wind Text Box is null"); }
    }
}
