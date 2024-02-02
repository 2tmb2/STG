using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreBuy : MonoBehaviour
{
    public GameObject Gun1L;
    public GameObject Gun1R;
    public GameObject Sword1L;
    public GameObject Sword1R;
    public GameObject RPG1L;
    public GameObject RPG1R;
    public GameObject Gun2L;
    public GameObject Gun2R;
    public GameObject ItemToBuyL;
    public GameObject ItemToBuyR;
    public GameObject CurrentItemL;
    public GameObject CurrentItemR;
    public bool triggered;
    public int itemPrice;
    public GameControllerEndless GC;
    public Text TextPrice;
    // Start is called before the first frame update
    void Start()
    {
        TextPrice.text = itemPrice.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Gun1L.activeInHierarchy == true)
        {
            CurrentItemL = Gun1L;
            CurrentItemR = Gun1R;
        }
        else if (Sword1L.activeInHierarchy == true)
        {
            CurrentItemL = Sword1L;
            CurrentItemR = Sword1R;
        }
        else if (RPG1L.activeInHierarchy == true)
        {
            CurrentItemL = RPG1L;
            CurrentItemR = RPG1R;
        }
        else if (Gun2L.activeInHierarchy == true)
        {
            CurrentItemL = Gun2L;
            CurrentItemR = Gun2R;

        }
        if (triggered == true)
        {
            if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) > 0.5 || OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > 0.5 || Input.GetKeyDown(KeyCode.U))
            {
                if (GC.CheckGold() >= itemPrice)
                {
                    GC.RemoveGold(itemPrice);
                    itemPrice = 0;
                    CurrentItemL.SetActive(false);
                    CurrentItemR.SetActive(false);
                    ItemToBuyL.SetActive(true);
                    ItemToBuyR.SetActive(true);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        triggered = true;
    }
    private void OnTriggerExit(Collider other)
    {
        triggered = false;
    }

}
