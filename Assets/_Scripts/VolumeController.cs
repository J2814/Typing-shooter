using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeController : MonoBehaviour
{
    public enum SliderType { Sfx, Music, Master}

    [Serializable]
    public class Slider
    {
        public MySlider MySlider;
        public SliderType Type;
    }

    public List<Slider> SliderList;
    private float prevMasterSliderVal = -100;
    private float prevMusicSliderVal = -100;
    private float prevSfxSliderVal = -100;
    
    void Update()
    {
        ChangeVolume();
    }
    private void ChangeVolume()
    {
        foreach (Slider s in SliderList)
        {
            if (s.Type == SliderType.Sfx)
            {
                if (prevSfxSliderVal != s.MySlider.value)
                {
                    AudioManager.instance.SetSfxVolume(s.MySlider.value);
                }
            }

            if (s.Type == SliderType.Music)
            {
                if (prevMusicSliderVal != s.MySlider.value)
                {
                    AudioManager.instance.SetMusicVolume(s.MySlider.value);
                }
            }

            if (s.Type == SliderType.Master)
            {
                if (prevMasterSliderVal != s.MySlider.value)
                {
                    AudioManager.instance.SetMasterVolume(s.MySlider.value);
                }
            }
        }
    }
}
