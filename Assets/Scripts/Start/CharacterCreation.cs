using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCreation : MonoBehaviour
{

    public UIInput nameInput;
    public GameObject[] charaterPrefabs;
    private GameObject[] charaterGameObjects;
    private int selectedIndex = 0;
    private int length;
    // Use this for initialization
    void Start()
    {
        length = charaterPrefabs.Length;
        charaterGameObjects = new GameObject[length];
        for (int i = 0; i < length; ++i)
        {
            charaterGameObjects[i] = (GameObject)GameObject.Instantiate(charaterPrefabs[i], transform.position, transform.rotation);
        }
        UpdateCharaterShow();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void UpdateCharaterShow()
    {
        for (int i = 0; i < length; ++i)
        {
            if (i != selectedIndex)
            {
                charaterGameObjects[i].SetActive(false);
            }
            else
            {
                charaterGameObjects[i].SetActive(true);
            }
        }
    }
    public void OnNextButtonClick()
    {
        selectedIndex++;
        selectedIndex %= length;
        UpdateCharaterShow();
    }
    public void OnPrevButtonClick()
    {
        selectedIndex--;
        if (selectedIndex == -1)
        {
            selectedIndex = length - 1;
        }
        UpdateCharaterShow();
    }
    public void OnOkButtonClick()
    {
        PlayerPrefs.SetInt("SelectedCharaterIndex", selectedIndex);
        PlayerPrefs.SetString("name", nameInput.value);
    }
}
