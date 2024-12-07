using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public MySlider VolumeSlider;

    public enum SliderType { Sfx, Music, Master}

    


    [Serializable]
    public class Slider
    {
        public MySlider MySlider;
        public SliderType Type;


    }

    public List<Slider> SliderList;
    private float prevSliderVal = -100;
    private void ChangeVolume()
    {
        if (prevSliderVal != VolumeSlider.value)
        {
            AudioManager.instance.SetSfxVolume(VolumeSlider.value);
        }
        prevSliderVal = VolumeSlider.value;
    }
}
