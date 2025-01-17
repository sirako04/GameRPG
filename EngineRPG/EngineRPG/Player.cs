﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.ComponentModel;
namespace EngineRPG

{

    public class Player : LivingCreature
    {
        public event EventHandler<MessageEventArgs> OnMessage;
        private Location _currentLocation;
        private Monster _currentMonster;
        private int _gold;
        private int _experiencePoints;
        private int _level;
        public int Gold 
        {
            get { return _gold; }
            set 
            { 
              _gold = value;
              OnPropertyChanged("Gold");
            }

        }
        public int ExperiencePoints 
        {
            get { return _experiencePoints;} 
            
            private set
            { _experiencePoints = value;
             Level = (_experiencePoints / 65) + 1;
                OnPropertyChanged("ExperiencePoints");              
            } 
        }
        public List<Weapon> Weapons 
        {
            get { return Inventory.Where(x => x.Details is Weapon).Select(x => x.Details as Weapon).ToList(); }    
        }
        public List<HealingPotion> Potions 
        {
            get { return Inventory.Where(x=> x.Details is HealingPotion).Select(x => x.Details as HealingPotion).ToList(); }
        }

        public int Level 
        { 
            get { return _level; }
            set
            {
                if (_level != value)
                {
                    _level = value;
                    RaiseMessage("");
                    RaiseMessage("LEVEL UP!!! ");
                    RaiseMessage($"Congratulations! You are now Level {Level}.", true);
                    RaiseMessage(" +10HP gained! ", true);
                    OnPropertyChanged(nameof(Level));

                }
            }
        }    
        public Location CurrentLocation
        {
            get { return _currentLocation; }
            set
            {
                _currentLocation = value;
                OnPropertyChanged(nameof(CurrentLocation));
            }
        }
        public BindingList<InventoryItem> Inventory { get; set; }
        public BindingList<PlayerQuest> Quests { get; set; }
        private Monster CurrentMonster { get; set; }

        public Weapon CurrentWeapon { get; set; }
        private Player(int currentHitPoints, int maximumHitPoints, int gold, int experiencePoints) : base(currentHitPoints, maximumHitPoints)
        {
            Gold = gold;
            ExperiencePoints = experiencePoints;          
            Inventory = new BindingList<InventoryItem>();
            Quests = new BindingList<PlayerQuest>();
        }
        public static Player CreateDefaultPlayer()
        {
            Player player = new Player(10,10,20,0);
            player.Inventory.Add(new InventoryItem(World.ItemByID(World.ITEM_ID_RUSTY_SWORD), 1));
            player.CurrentLocation = World.LocationByID(World.LOCATION_ID_HOME);
            return player;
        }
        public void AddExperiencePoints(int experiencePointsToAdd)
        {
            ExperiencePoints += experiencePointsToAdd;
            MaximumHitPoints = (Level*10);
        }
        private void RaiseInventoryChangedEvent(Item item) 
        {
            if(item is Weapon) 
            {
                OnPropertyChanged(nameof(Weapons));
            }
            if (item is HealingPotion)
            {
                OnPropertyChanged(nameof(Potions));
            }
        }
        public void RemoveItemFromInventory(Item ItemtoRemove, int quantity = 1) 
        {
           InventoryItem item = Inventory.SingleOrDefault(ii => ii.Details.ID ==ItemtoRemove.ID );
            if (item == null) 
            {
                // error 
                
            }
            else
            {
                item.Quantity -= quantity;
                if (item.Quantity < 0)
                {
                    item.Quantity = 0;
                }
                if (item.Quantity == 0)
                {
                    Inventory.Remove(item);
                }

                RaiseInventoryChangedEvent(ItemtoRemove);
            }


        }          
        public static Player CreatePlayerFromXmlString(string xmlPlayerData)
        {
            try
            {
                XmlDocument playerData = new XmlDocument();
                playerData.LoadXml(xmlPlayerData);
                int currentHitPoints = Convert.ToInt32(playerData.SelectSingleNode("/Player/Stats/CurrentHitPoints").InnerText);
                int maximumHitPoints = Convert.ToInt32(playerData.SelectSingleNode("/Player/Stats/MaximumHitPoints").InnerText);
                int gold = Convert.ToInt32(playerData.SelectSingleNode("/Player/Stats/Gold").InnerText);
                int experiencePoints = Convert.ToInt32(playerData.SelectSingleNode("/Player/Stats/ExperiencePoints").InnerText);
                int level = Convert.ToInt32(playerData.SelectSingleNode("/Player/Stats/Level").InnerText);

                Player player = new Player(currentHitPoints, maximumHitPoints, gold, experiencePoints);
                int currentLocationID = Convert.ToInt32(playerData.SelectSingleNode("/Player/Stats/CurrentLocation").InnerText);
                player.CurrentLocation = World.LocationByID(currentLocationID);

                if (playerData.SelectSingleNode("/Player/Stats/CurrentWeapon") != null)
                {
                    int currentWeaponID = Convert.ToInt32(playerData.SelectSingleNode("/Player/Stats/CurrentWeapon").InnerText);
                    player.CurrentWeapon = (Weapon)World.ItemByID(currentWeaponID);
                }

                foreach (XmlNode node in playerData.SelectNodes("/Player/InventoryItems/InventoryItem"))
                {
                    int id = Convert.ToInt32(node.Attributes["ID"].Value);
                    int quantity = Convert.ToInt32(node.Attributes["Quantity"].Value);
                    for (int i = 0; i < quantity; i++)
                    {
                        player.AddItemToInventory(World.ItemByID(id));
                    }
                }
                foreach (XmlNode node in playerData.SelectNodes("/Player/PlayerQuests/PlayerQuest"))
                {
                    int id = Convert.ToInt32(node.Attributes["ID"].Value);
                    bool isCompleted = Convert.ToBoolean(node.Attributes["IsCompleted"].Value);
                    PlayerQuest playerQuest = new PlayerQuest(World.QuestByID(id));
                    playerQuest.IsCompleted = isCompleted;
                    player.Quests.Add(playerQuest);
                }
                return player;
            }
            catch  
            {
                // If there was an error with the XML data, return a default player object

                return Player.CreateDefaultPlayer();
            }
        }
        public bool HasRequiredItemToEnterThisLocation(Location location)
        {
            if (location.ItemRequiredToEnter == null)
            {
                // There is no required item for this location, so return "true"
                return true;
            }

            // See if the player has the required item in their inventory
            return Inventory.Any(ii => ii.Details.ID == location.ItemRequiredToEnter.ID);

            // We didn't find the required item in their inventory, so return "false"
            
        }
        private void SetTheCurrentMonsterForTheCurrentLocation(Location location)
        {
            // Populate the current monster with this location's monster (or null, if there is no monster here)
            CurrentMonster = location.NewInstanceOfMonsterLivingHere();

            if (CurrentMonster != null)
            {
                RaiseMessage("You see a " + location.MonsterLivingHere.Name);
            }
        }

        public bool PlayerHasThisQuest(Quest quest)
        {
           return Quests.Any(pq => pq.Details.ID == quest.ID);
        }

        public bool CompletedThisQuest(Quest quest)
        {
            foreach (PlayerQuest playerQuest in Quests)
            {
                if (playerQuest.Details.ID == quest.ID)
                {
                    return playerQuest.IsCompleted;
                }
            }

            return false;
        }

        public bool HasAllQuestCompletionItems(Quest quest)
        {
            // See if the player has all the items needed to complete the quest here
            foreach (QuestCompletionItem qci in quest.QuestCompletionItems)
            {
                // Check each item in the player's inventory, to see if they have it, and enough of it
                if (!Inventory.Any(ii => ii.Details.ID == qci.Details.ID && ii.Quantity >= qci.Quantity))
                {
                    return false;
                }
            }
            // If we got here, then the player must have all the required items, and enough of them, to complete the quest.
            return true;

        }
        public void RemoveQuestCompletionItems(Quest quest)
        {
            foreach (QuestCompletionItem qci in quest.QuestCompletionItems)
            {
                InventoryItem item = Inventory.SingleOrDefault(ii => ii.Details.ID == qci.Details.ID);
                if (item != null)
                {
                    // Subtract the quantity from the player's inventory that was needed to complete the quest
                    RemoveItemFromInventory(item.Details,qci.Quantity);
                }
            }
            
        }

        public void AddItemToInventory(Item itemToAdd ,int quantity = 1 )
        {
            InventoryItem existingItemInInventory = Inventory.SingleOrDefault(ii => ii.Details.ID == itemToAdd.ID);
            if (existingItemInInventory == null)
            {
                // They didn't have the item, so add it to their inventory, with a quantity of 1
                Inventory.Add(new InventoryItem(itemToAdd, 1));
            }
            else
            {
                // They have the item in their inventory, so increase the quantity by one
                existingItemInInventory.Quantity += quantity;
            }
            RaiseInventoryChangedEvent(itemToAdd);
        }

        public void MarkQuestCompleted(Quest quest)
        {
            // Find the quest in the player's quest list

            PlayerQuest playerQuest = Quests.SingleOrDefault(pq => pq.Details.ID == quest.ID);
            if (playerQuest != null)
            {
                playerQuest.IsCompleted = true;
            }
        }
        public void RaiseMessage(string message, bool addExtraNewLine = false)
        {
            OnMessage?.Invoke(this, new MessageEventArgs(message, addExtraNewLine));
        }
        public void MoveTo(Location newLocation)
        {
            //Does the location have any required items
            if (!HasRequiredItemToEnterThisLocation(newLocation))
            {
                RaiseMessage("You must have a " + newLocation.ItemRequiredToEnter.Name + " to enter this location.");
                return;
            }

            // Update the player's current location
            CurrentLocation = newLocation;

            // Completely heal the player
            CurrentHitPoints = MaximumHitPoints;

            if (newLocation.HasAQuest)
            {
                         
                if (PlayerHasThisQuest(newLocation.QuestAvailableHere))
                {
                   
                    if (!CompletedThisQuest(newLocation.QuestAvailableHere))
                    {
                        // See if the player has all the items needed to complete the quest
                        bool playerHasAllItemsToCompleteQuest = HasAllQuestCompletionItems(newLocation.QuestAvailableHere);

                        // The player has all items required to complete the quest
                        if (playerHasAllItemsToCompleteQuest)
                        {
                            // Display message
                            GivePlayerQuestRewards(newLocation);
                        }
                    }
                }
                else
                {
                    // The player does not already have the quest

                    // Display the messages
                    RaiseMessage("You receive the " + newLocation.QuestAvailableHere.Name + " quest.");
                    RaiseMessage(newLocation.QuestAvailableHere.Description);
                    RaiseMessage("To complete it, return with:");
                    foreach (QuestCompletionItem qci in newLocation.QuestAvailableHere.QuestCompletionItems)
                    {
                        if (qci.Quantity == 1)
                        {
                            RaiseMessage(qci.Quantity + " " + qci.Details.Name);
                        }
                        else
                        {
                            RaiseMessage(qci.Quantity + " " + qci.Details.NamePlural);
                        }
                    }
                    RaiseMessage("");

                    // Add the quest to the player's quest list
                    Quests.Add(new PlayerQuest(newLocation.QuestAvailableHere));
                }
            }

            // Does the location have a monster?
            if (CurrentLocation.HasAMonster)
            {
                RaiseMessage("You see a " + CurrentMonster.Name);

                // Make a new monster, using the values from the standard monster in the World.Monster list
                Monster standardMonster = World.MonsterByID(CurrentMonster.ID);

                _currentMonster = new Monster(standardMonster.ID, standardMonster.Name, standardMonster.MaximumDamage,
                    standardMonster.RewardExperiencePoints, standardMonster.RewardGold, standardMonster.CurrentHitPoints, standardMonster.MaximumHitPoints);

                foreach (LootItem lootItem in standardMonster.LootTable)
                {
                    CurrentMonster.LootTable.Add(lootItem);
                }
            }
            else
            {
                _currentMonster = null;
            }
        }

        private void GivePlayerQuestRewards(Location newLocation)
        {
            RaiseMessage("");
            RaiseMessage("You completed the '" + newLocation.QuestAvailableHere.Name + "' quest.");
            RaiseMessage("You receive: ");
            RaiseMessage(newLocation.QuestAvailableHere.RewardExperiencePoints + " experience points");
            RaiseMessage(newLocation.QuestAvailableHere.RewardGold + " gold");
            RaiseMessage(newLocation.QuestAvailableHere.RewardItem.Name, true);


            AddExperiencePoints(newLocation.QuestAvailableHere.RewardExperiencePoints);
            Gold += newLocation.QuestAvailableHere.RewardGold;
      
            RemoveQuestCompletionItems(newLocation.QuestAvailableHere);
            AddItemToInventory(newLocation.QuestAvailableHere.RewardItem);
           
            MarkQuestCompleted(newLocation.QuestAvailableHere);
        }

        public void UseWeapon(Weapon weapon)
        {
            // Determine the amount of damage to do to the monster
            int damageToMonster = RandomNumberGenerator.NumberBetween(weapon.MinimumDamage, weapon.MaximumDamage);

            // Apply the damage to the monster's CurrentHitPoints
            CurrentMonster.CurrentHitPoints -= damageToMonster;

            // Display message
            RaiseMessage("You hit the " + CurrentMonster.Name + " for " + damageToMonster + " points.");

            // Check if the monster is dead
            if (CurrentMonster.CurrentHitPoints <= 0)
            {
                // Monster is dead
                RaiseMessage("");
                RaiseMessage("You defeated the " + CurrentMonster.Name);
        
                AddExperiencePoints(CurrentMonster.RewardExperiencePoints);
                RaiseMessage("You receive " + CurrentMonster.RewardExperiencePoints + " experience points");
               
                Gold += CurrentMonster.RewardGold;
                RaiseMessage("You receive " + CurrentMonster.RewardGold + " gold");
               

                // Get random loot items from the monster
                List<InventoryItem> lootedItems = new List<InventoryItem>();

                // Add items to the lootedItems list, comparing a random number to the drop percentage
                foreach (LootItem lootItem in CurrentMonster.LootTable)
                {
                    if (RandomNumberGenerator.NumberBetween(1, 100) <= lootItem.DropPercentage)
                    {
                        lootedItems.Add(new InventoryItem(lootItem.Details, 1));
                    }
                }

                // If no items were randomly selected, then add the default loot item(s).
                if (lootedItems.Count == 0)
                {
                    foreach (LootItem lootItem in CurrentMonster.LootTable)
                    {
                        if (lootItem.IsDefaultItem)
                        {
                            lootedItems.Add(new InventoryItem(lootItem.Details, 1));
                        }
                    }
                }

                // Add the looted items to the player's inventory
                foreach (InventoryItem inventoryItem in lootedItems)
                {
                    AddItemToInventory(inventoryItem.Details);

                    if (inventoryItem.Quantity == 1)
                    {
                        RaiseMessage("You loot " + inventoryItem.Quantity + " " + inventoryItem.Details.Name);
                    }
                    else
                    {
                        RaiseMessage("You loot " + inventoryItem.Quantity + " " + inventoryItem.Details.NamePlural);
                    }
                }

                // Add a blank line to the messages box, just for appearance.
                RaiseMessage("");

                // Move player to current location (to heal player and create a new monster to fight)
                MoveTo(CurrentLocation);
            }
            else
            {
                // Monster is still alive

                // Determine the amount of damage the monster does to the player
                int damageToPlayer = RandomNumberGenerator.NumberBetween(0, CurrentMonster.MaximumDamage);

                // Display message
                RaiseMessage("The " + CurrentMonster.Name + " did " + damageToPlayer + " points of damage.");

                // Subtract damage from player
                CurrentHitPoints -= damageToPlayer;

                if (CurrentHitPoints <= 0)
                {
                    // Display message
                    RaiseMessage("The " + CurrentMonster.Name + " killed you.");

                    // Move player to "Home"
                     MoveHome();
                }
            }
        }

        public void UsePotion(HealingPotion potion)
        {
            // Add healing amount to the player's current hit points
            CurrentHitPoints += potion.AmountToHeal;

            // CurrentHitPoints cannot exceed player's MaximumHitPoints
            if (CurrentHitPoints > MaximumHitPoints)
            {
                CurrentHitPoints = MaximumHitPoints;
            }

            // Remove the potion from the player's inventory
            RemoveItemFromInventory(potion, 1);

            // Display message
            RaiseMessage("You drink a " + potion.Name);

            // Monster gets their turn to attack

            // Determine the amount of damage the monster does to the player
            int damageToPlayer = RandomNumberGenerator.NumberBetween(0, CurrentMonster.MaximumDamage);

            // Display message
            RaiseMessage("The " + CurrentMonster.Name + " did " + damageToPlayer + " points of damage.");

            // Subtract damage from player
            CurrentHitPoints -= damageToPlayer;

            if (CurrentHitPoints <= 0)
            {
                // Display message
                RaiseMessage("The " + CurrentMonster.Name + " killed you.");

                // Move player to "Home"
                MoveHome();
            }
        }
        private void MoveHome() 
        {
            MoveTo(World.LocationByID(World.LOCATION_ID_HOME));
        }
        public void MoveNorth()
        {
            if (CurrentLocation.LocationToNorth != null)
            {
                MoveTo(CurrentLocation.LocationToNorth);
            }
        }

        public void MoveEast()
        {
            if (CurrentLocation.LocationToEast != null)
            {
                MoveTo(CurrentLocation.LocationToEast);
            }
        }

        public void MoveSouth()
        {
            if (CurrentLocation.LocationToSouth != null)
            {
                MoveTo(CurrentLocation.LocationToSouth);
            }
        }

        public void MoveWest()
        {
            if (CurrentLocation.LocationToWest != null)
            {
                MoveTo(CurrentLocation.LocationToWest);
            }
        }
        public string ToXmlString()
        {
            XmlDocument playerData = new XmlDocument();
            // Create the top-level XML node
            XmlNode player = playerData.CreateElement("Player");
            playerData.AppendChild(player);

            XmlNode stats = CreatePlayerStatsNodeToXml(playerData, player);

            if (CurrentWeapon != null)
            {
                XmlNode currentWeapon = playerData.CreateElement("CurrentWeapon");
                currentWeapon.AppendChild(playerData.CreateTextNode(this.CurrentWeapon.ID.ToString()));
                stats.AppendChild(currentWeapon);
            }
            CreateInventoryItemNodeToXml(playerData, player);
            CreateQuestNodeToXml(playerData, player);
            return playerData.InnerXml; // The XML document, as a string, so we can save the data to disk
        }

        private XmlNode CreatePlayerStatsNodeToXml(XmlDocument playerData, XmlNode player)
        {
            // Create the "Stats" child node to hold the other player statistics nodes
            XmlNode stats = playerData.CreateElement("Stats");
            player.AppendChild(stats);
            // Create the child nodes for the "Stats" node
            XmlNode currentHitPoints = playerData.CreateElement("CurrentHitPoints");
            currentHitPoints.AppendChild(playerData.CreateTextNode(this.CurrentHitPoints.ToString()));
            stats.AppendChild(currentHitPoints);
            XmlNode maximumHitPoints = playerData.CreateElement("MaximumHitPoints");
            maximumHitPoints.AppendChild(playerData.CreateTextNode(this.MaximumHitPoints.ToString()));
            stats.AppendChild(maximumHitPoints);
            XmlNode gold = playerData.CreateElement("Gold");
            gold.AppendChild(playerData.CreateTextNode(this.Gold.ToString()));
            stats.AppendChild(gold);
            XmlNode experiencePoints = playerData.CreateElement("ExperiencePoints");
            experiencePoints.AppendChild(playerData.CreateTextNode(this.ExperiencePoints.ToString()));
            stats.AppendChild(experiencePoints);
            XmlNode level = playerData.CreateElement("Level");
            level.AppendChild(playerData.CreateTextNode(this.Level.ToString()));
            stats.AppendChild(level);
            XmlNode currentLocation = playerData.CreateElement("CurrentLocation");
            currentLocation.AppendChild(playerData.CreateTextNode(this.CurrentLocation.ID.ToString()));
            stats.AppendChild(currentLocation);
            return stats;
        }

        private void CreateInventoryItemNodeToXml(XmlDocument playerData, XmlNode player)
        {
            // Create the "InventoryItems" child node to hold each InventoryItem node
            XmlNode inventoryItems = playerData.CreateElement("InventoryItems");
            player.AppendChild(inventoryItems);
            // Create an "InventoryItem" node for each item in the player's inventory
            foreach (InventoryItem item in this.Inventory)
            {
                XmlNode inventoryItem = playerData.CreateElement("InventoryItem");
                XmlAttribute idAttribute = playerData.CreateAttribute("ID");
                idAttribute.Value = item.Details.ID.ToString();
                inventoryItem.Attributes.Append(idAttribute);
                XmlAttribute quantityAttribute = playerData.CreateAttribute("Quantity");
                quantityAttribute.Value = item.Quantity.ToString();
                inventoryItem.Attributes.Append(quantityAttribute);
                inventoryItems.AppendChild(inventoryItem);
            }
        }

        private void CreateQuestNodeToXml(XmlDocument playerData, XmlNode player)
        {
            // Create the "PlayerQuests" child node to hold each PlayerQuest node
            XmlNode playerQuests = playerData.CreateElement("PlayerQuests");
            player.AppendChild(playerQuests);
            // Create a "PlayerQuest" node for each quest the player has acquired
            foreach (PlayerQuest quest in this.Quests)
            {
                XmlNode playerQuest = playerData.CreateElement("PlayerQuest");
                XmlAttribute idAttribute = playerData.CreateAttribute("ID");
                idAttribute.Value = quest.Details.ID.ToString();
                playerQuest.Attributes.Append(idAttribute);
                XmlAttribute isCompletedAttribute = playerData.CreateAttribute("IsCompleted");
                isCompletedAttribute.Value = quest.IsCompleted.ToString();
                playerQuest.Attributes.Append(isCompletedAttribute);
                playerQuests.AppendChild(playerQuest);
            }
        }

        public static Player CreatePlayerFromDataBase(int currentHitPoints,int maximumHitPoints,int gold, int experiencePoints, int currentLocationID) 
        {
            Player player = new Player(currentHitPoints,maximumHitPoints,gold,experiencePoints);
            player.MoveTo(World.LocationByID(currentLocationID));
            return player;
        }

      
    }
       

        
}


