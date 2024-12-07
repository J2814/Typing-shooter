using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MySlider : Slider
{
    public Action MySliderUp;

    
    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        MySliderUp?.Invoke();
    }


    


    //protected override void Start()
    //{
    //    VolumeSlider = GetComponent<MySlider>();
    //}
    //private void ChangeVolume()
    //{
    //    if (prevSliderVal != VolumeSlider.value)
    //    {
    //        AudioManager.instance.SetSfxVolume(VolumeSlider.value);
    //    }
    //    prevSliderVal = VolumeSlider.value;
    //}
}
