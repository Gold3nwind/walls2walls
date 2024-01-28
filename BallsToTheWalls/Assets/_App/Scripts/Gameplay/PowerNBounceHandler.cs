using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class PowerNBounceHandler : MonoBehaviour
{
    [SerializeField] SphereCollider SphereCollider;
    [SerializeField] Slider BounceSlider;
    [SerializeField] XRGrabInteractable Interactable;
    [SerializeField] Slider PowerSlider;
    private void Start()
    {
        BounceSlider.value = SphereCollider.material.bounciness;
        PowerSlider.value = Interactable.throwVelocityScale;
    }
    public void BouncinessChange()
    {
        if (SphereCollider != null)
        {
            //assign the slider value to bounciness
            SphereCollider.material.bounciness = BounceSlider.value;
            Debug.Log("Called");
            SphereCollider.enabled = false;
            SphereCollider.enabled = true;
        }
        else
        {
            Debug.Log("SphereCollider is null");
        }
    }

    public void ThrowPowerChange()
    {
        try
        {
            Interactable.throwVelocityScale = PowerSlider.value;
            Debug.Log($"Throw power changed to {PowerSlider.value}");
        }
        catch (NullReferenceException ex)
        {
            Debug.Log($"Interactable is null: {ex.Message}");
        }
    }
}

