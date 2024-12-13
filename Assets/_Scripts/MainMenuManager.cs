
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{

    public Button PlayButton, SettingsButton, ExitButton, BackButton, ContinueButton,
        Dchil, DEasy, DMed, Dhard, Dhell;
    
    public MySlider MV, AV, SFXV;
    public Text MVT, AVT, TD, SFXVT;
    //Button button;
    public Canvas lp;
    static public int difficulty = 0;


    public void Start()
    {
        offDiff();
        onbuttons();
        SetClick();
        // button=Instantiate(BackButton, new Vector3(0, 0, 0), Quaternion.identity);
        //button.transform.SetParent(lp.transform, false);
        //newButton = PlayButton;
        //newButton.gameObject.layer = 5;
        //newButton=Instantiate(PlayButton,new Vector3(0,0,0), Quaternion.identity);
        //newButton.transform.SetParent(lp.transform,false);
    }
    public void SetClick()
    {
        PlayButton.onClick.AddListener(Play_click);
        SettingsButton.onClick.AddListener(Settings_click);
        ExitButton.onClick.AddListener(Exit_click);
        BackButton.onClick.AddListener(BackButton_click);
        ContinueButton.onClick.AddListener(Continue_click);
        Dchil.onClick.AddListener(()=>{ difficulty = 0; Debug.Log(difficulty); });
        DEasy.onClick.AddListener(() => { difficulty = 1; Debug.Log(difficulty); });
        DMed.onClick.AddListener(() => { difficulty = 2; Debug.Log(difficulty); });
        Dhard.onClick.AddListener(() => {difficulty = 3; Debug.Log(difficulty); });
        Dhell.onClick.AddListener(() => {difficulty= 4; Debug.Log(difficulty); });

    }
    public void Play_click()
    {
        onDiff();
    }


    public MySlider VolumeSlider;
    private float prevSliderVal = -100;
    private void ChangeVolume()
    {
        if (prevSliderVal != VolumeSlider.value)
        {
            AudioManager.instance.SetSfxVolume(VolumeSlider.value);
        }
        prevSliderVal = VolumeSlider.value;
    }


    public void Continue_click()
    {
        SceneManager.LoadScene("GameLevel");
        AudioManager.instance.PlaySound(AudioManager.instance.SoundBank.Start);
    }
    public void Settings_click()
    {
        Offbuttons();
        BackButton.gameObject.SetActive(true);
        MV.gameObject.SetActive(true);
        AV.gameObject.SetActive(true);
        SFXV.gameObject.SetActive(true);
        MVT.gameObject.SetActive(true);
        AVT.gameObject.SetActive(true);
        SFXVT.gameObject.SetActive(true);
    }
    public void Exit_click()
    {
        Application.Quit();
    }
    public void BackButton_click() {
        onbuttons();
    }
    void onDiff()
    {
        Offbuttons();
        TD.gameObject.SetActive(true);
        Dchil.gameObject.SetActive(true);
        DEasy.gameObject.SetActive(true);
        DMed.gameObject.SetActive(true);
        Dhard.gameObject.SetActive(true);
        Dhell.gameObject.SetActive(true);
        ContinueButton.gameObject.SetActive(true);
    }
    void offDiff() {
        TD.gameObject.SetActive(false);
        Dchil.gameObject.SetActive(false);
        DEasy.gameObject.SetActive(false);
        DMed.gameObject.SetActive(false);
        Dhard.gameObject.SetActive(false);
        Dhell.gameObject.SetActive(false);
        ContinueButton.gameObject.SetActive(false);
    }
    void offSettings() {
        MV.gameObject.SetActive(false);
        AV.gameObject.SetActive(false);
        SFXV.gameObject.SetActive(false);
        MVT.gameObject.SetActive(false);
        AVT.gameObject.SetActive(false);
        SFXVT.gameObject.SetActive(false);
    }
    void Offbuttons()
    {
        PlayButton.gameObject.SetActive(false);
        SettingsButton.gameObject.SetActive(false);
        ExitButton.gameObject.SetActive(false);
       // BackButton.gameObject.SetActive(true);
       // VolumeButton.gameObject.SetActive(true);
        // Instantiate(Canvas);
    }
    void onbuttons()
    {
        PlayButton.gameObject.SetActive(true);
        SettingsButton.gameObject.SetActive(true);
        ExitButton.gameObject.SetActive(true);
        BackButton.gameObject.SetActive(false);
        offSettings();
        // Instantiate(Canvas);
    }

}
