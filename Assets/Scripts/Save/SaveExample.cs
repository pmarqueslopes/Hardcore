using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
namespace DefaultNamespace
{
    public class SaveExample : MonoBehaviour
    {
        [Header("CACHE")]
        public SaveSystem.SaveData data;
        
        [Header("REFERENCES")]
        //public InventorySO inventory;

        public Transform player;
        
        //public ItemSO[] items;
        //public ItemParameterSO[] itemsParametersSO;

        public static SaveExample Instance { get; private set; }
    

      
        public void Save()    
        {
            Debug.Log("testeSave");
            #region Aplicar valores
            List<SaveSystem.ItemStack> stacks = new();
            
            //foreach (var item in inventory.inventoryItems)
            //{
            //    List<SaveSystem.ItemStackParameter> lista = new List<SaveSystem.ItemStackParameter>();
            //    foreach (var parameter in item.itemState)
            //    {
            //        lista.Add(new SaveSystem.ItemStackParameter()
            //        {
            //                id = Array.IndexOf(this.itemsParametersSO, parameter.itemParameter),
            //            value = parameter.value
            //        });
            //    }

            //    stacks.Add(new SaveSystem.ItemStack()
            //    {
            //        id = Array.IndexOf(this.items, item.item),
            //        amount = item.quantity,
            //        parameters = lista.ToArray()
            //    });
            //}
            
            data.scene = SceneManager.GetActiveScene().name;
            data.damage = PlayerStats.instance.damage;
            data.currentHp = PlayerStats.instance.currentHp;
            data.maxHp = PlayerStats.instance.maxHp;
            data.armor = PlayerStats.instance.armor;
            data.level = PlayerStats.instance.level;
            data.fury = PlayerStats.instance.fury;
            data.singleCost = PlayerStats.instance.singleCost;
            data.multipleCost = PlayerStats.instance.multipleCost;
            data.powerSingleCost = PlayerStats.instance.powerSingleCost;
            data.ultimateCost = PlayerStats.instance.ultimateCost;
            data.inimigosAzul = CombatTransition.instance.InimigosAzul;
            data.inimigosVermelho = CombatTransition.instance.InimigosVermelho;
            data.inimigosVerde= CombatTransition.instance.InimigosVerde;
            data.battleWin= CombatTransition.instance.BattleWin;
            data.xpValue= CombatTransition.instance.xpValue;
            data.currentLVL = XPmanager.Instance.currentLVL;
            data.currentXP = XPmanager.Instance.currentXP;
            data.maxXP = XPmanager.Instance.maxXP;
            data.currentenemy=CombatTransition.instance.currentenemy;
            data.pickaxeGems = PlayerStats.instance.pickaxeGems;
            data.pickaxeGemsTier = PlayerStats.instance.pickaxeGemsTier;
            data.armorGems = PlayerStats.instance.armorGems;
            data.armorGemsTier = PlayerStats.instance.armorGemsTier;
            data.playerPos = player.position;
            data.playerRot = player.eulerAngles;
            data.itemStacks = stacks.ToArray();
          
            //Save em si
            SaveSystem.Save(data, 0);
         
        }
        
        public void Load ()
        
        {
            Debug.Log("testeLoad");
            //Load em si
            data = SaveSystem.Load(0);
            
        
            #region Ler valores
            SceneManager.LoadScene(data.scene);
            PlayerStats.instance.damage = data.damage;
            PlayerStats.instance.currentHp = data.currentHp;
            PlayerStats.instance.maxHp = data.maxHp;
            PlayerStats.instance.armor = data.armor;
            PlayerStats.instance.level = data.level;
            PlayerStats.instance.fury = data.fury;
            PlayerStats.instance.singleCost = data.singleCost;
            PlayerStats.instance.multipleCost = data.multipleCost;
            PlayerStats.instance.powerSingleCost = data.powerSingleCost;
            PlayerStats.instance.ultimateCost = data.ultimateCost;
            CombatTransition.instance.InimigosAzul = data.inimigosAzul;
            CombatTransition.instance.InimigosVermelho = data.inimigosVermelho;
            CombatTransition.instance.InimigosVerde=data.inimigosVerde;
            CombatTransition.instance.BattleWin=data.battleWin;
            CombatTransition.instance.xpValue=data.xpValue;
            CombatTransition.instance.currentenemy=data.currentenemy;
            XPmanager.Instance.currentLVL=data.currentLVL;
            XPmanager.Instance.currentXP=data.currentXP;
            XPmanager.Instance.maxXP=data.maxXP;
            PlayerStats.instance.pickaxeGems = data.pickaxeGems;
            PlayerStats.instance.pickaxeGemsTier = data.pickaxeGemsTier;
            PlayerStats.instance.armorGems = data.armorGems;
            PlayerStats.instance.armorGemsTier = data.armorGemsTier;
            player.position = data.playerPos;
            Debug.LogError(data.playerPos);
            player.eulerAngles = data.playerRot;
             
            //inventory.inventoryItems.Clear();
         
            #endregion
       
            //foreach (var item in data.itemStacks)
            //{
            //    InventoryItem i = new InventoryItem();
            //    i.quantity = item.amount;
            //    i.itemState = new List<ItemParameter>();
            //    if(item.id>=0) i.item = this.items[item.id];
            //    inventory.inventoryItems.Add(i);
            //    foreach (var VAr in item.parameters)
            //    {
            //        i.itemState.Add(new ItemParameter()
            //        {
            //            itemParameter = itemsParametersSO[VAr.id],
            //            value = VAr.value
            //        });
            //    }
            //}
            
            //Carregado
            #endregion
        }
        
    }
}