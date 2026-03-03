using System;
using System.Collections.Generic;
using Events;
using GUI;
using Managers;
using PlayerScripts;
using Saving;
using UnityEngine;

public class DataLoader : MonoBehaviour
{
    private SaveDataManager saveDataManager;

    private void Awake()
    {
        // Create the save data manager
        saveDataManager = new SaveDataManager();
    }

    private void Start()
    {
        // Load all the data
        var data = saveDataManager.LoadGame();
        
        // Load specific data
        // Create items
        LoadItems(data.itemIds);
        // Load room counter
        RoomManager.Instance.LoadData(data);
        // Load player attributes
        PlayerInfo.Instance.LoadData(data);
        // Update the UI
        var guiElements = GameObject.FindGameObjectWithTag("UI").GetComponentsInChildren<DisplayAttribute>();
        foreach (var guiElement in guiElements)
        {
            guiElement.DisplayValues();
        }
    }

    private void LoadItems(List<int> itemIds)
    {
        itemIds.ForEach(i =>
        {
            var item = Instantiate(GameEventManager.Instance.itemEvents.GetItemById(i), transform.position,
                transform.rotation);
            item.SetActive(true);
        });
    }
}
