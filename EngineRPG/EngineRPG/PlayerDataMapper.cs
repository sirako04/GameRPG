﻿using System;
using System.Data;
using System.Data.SqlClient;
namespace EngineRPG
{
    public static class PlayerDataMapper
    {
        public static readonly string _connectionString =
"Data Source=(local);Initial Catalog=SuperAdventure;Integrated Security=True";

        public static Player CreateFromDatabase()
        {
            try
            {
                // This is our connection to the database
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    Player player;
                    using (SqlCommand savedGameCommand = connection.CreateCommand())
                    {
                       
                        savedGameCommand.CommandType = CommandType.Text;
                        savedGameCommand.CommandText = "SELECT TOP 1 * FROM SavedGame";

                        // Use ExecuteReader when you expect the query to return a row, or rows
                        SqlDataReader reader = savedGameCommand.ExecuteReader();

                        if (!reader.HasRows)
                        {
                            // no data rows 
                            return null;
                        }
                        // get the row from the data reader
                        reader.Read();

                        // NOW get the column values for the row
                        int currentHitPoints = (int)reader["CurrentHitPoints"];
                        int maximumHitPoints = (int)reader["MaximumHitPoints"];
                        int gold = (int)reader["Gold"];
                        int experiencePoints = (int)reader["ExperiencePoints"];
                        int currentLocationID = (int)reader["CurrentLocationID"];

                        player = Player.CreatePlayerFromDataBase(currentHitPoints, maximumHitPoints, gold, experiencePoints, currentLocationID);
                    }
                    
                    AddQuestsDataToPlayer(connection, player);
                    AddInventoryDataToPlayer(connection, player);

                    // player is built from DB return it now
                    return player;
                }
            }
            catch (Exception)
            {

            }
            return null;
        }
        private static void AddQuestsDataToPlayer(SqlConnection connection, Player player)
        {
            using (SqlCommand questCommand = connection.CreateCommand())
            {
                questCommand.CommandType = CommandType.Text;
                questCommand.CommandText = "SELECT * FROM Quest";
                SqlDataReader reader = questCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int questID = (int)reader["QuestID"];
                        bool isCompleted = (bool)reader["IsCompleted"];

                        PlayerQuest playerQuest = new PlayerQuest(World.QuestByID(questID));
                        playerQuest.IsCompleted = isCompleted;
                        // Add the PlayerQuest to the player's property
                        player.Quests.Add(playerQuest);
                    }
                }
            }
        }
        private static void AddInventoryDataToPlayer(SqlConnection connection, Player player)
        {
            using (SqlCommand inventoryCommand = connection.CreateCommand())
            {
                inventoryCommand.CommandType = CommandType.Text;
                inventoryCommand.CommandText = "SELECT * FROM Inventory";
                SqlDataReader reader = inventoryCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int inventoryItemID = (int)reader["InventoryItemID"];
                        int quantity = (int)reader["Quantity"];

                        player.AddItemToInventory
                        (World.ItemByID(inventoryItemID), quantity);

                    }
                }
            }
        }
        public static void SavetoDataBase(Player player)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    // Insert/Update data in SavedGame table
                    using (SqlCommand existingRowCountCommand = connection.CreateCommand())
                    {
                        existingRowCountCommand.CommandType = CommandType.Text;
                        existingRowCountCommand.CommandText = "SELECT count(*) FROM SavedGame";

                        int existingPlayerRowCount = (int)existingRowCountCommand.ExecuteScalar();
                        if (existingPlayerRowCount == 0)
                        {
                            InsertPlayerStatsData(player, connection);
                        }
                        else
                        {
                            UpdatePlayerStatsData(player, connection);
                        }
                    }
                    
                    UpdatingPlayerQuestData(player, connection);

                    
                    UpdatingInventoryData(player, connection);
                }


            }
            catch (Exception)
            {
                // ignoring for now
            }
        }

        private static void InsertPlayerStatsData(Player player, SqlConnection connection)
        {
            using (SqlCommand insertSavedGame = connection.CreateCommand())
            {
                insertSavedGame.CommandType = CommandType.Text;
                insertSavedGame.CommandText = "INSERT INTO SavedGame "
                + "(CurrentHitPoints, MaximumHitPoints, Gold, ExperiencePoints, CurrentLocationID) "
                + "VALUES "
                + "(@CurrentHitPoints,@MaximumHitPoints,@Gold,@ExperiencePoints,@CurrentLocationID)";
                // Pass the values from the player object, to the SQL query, using parameters
                insertSavedGame.Parameters.Add("@CurrentHitPoints", SqlDbType.Int);
                insertSavedGame.Parameters["@CurrentHitPoints"].Value = player.CurrentHitPoints;

                insertSavedGame.Parameters.Add("@MaximumHitPoints", SqlDbType.Int);
                insertSavedGame.Parameters["@MaximumHitPoints"].Value = player.MaximumHitPoints;

                insertSavedGame.Parameters.Add("@Gold", SqlDbType.Int);
                insertSavedGame.Parameters["@Gold"].Value = player.Gold;

                insertSavedGame.Parameters.Add("@ExperiencePoints", SqlDbType.Int);
                insertSavedGame.Parameters["@ExperiencePoints"].Value = player.ExperiencePoints;

                insertSavedGame.Parameters.Add("@CurrentLocationID", SqlDbType.Int);
                insertSavedGame.Parameters["@CurrentLocationID"].Value = player.CurrentLocation.ID;
                // Perform the SQL command.
                // ExecuteNonQuery, because this query does not return any results.
                insertSavedGame.ExecuteNonQuery();
            }
        }

        private static void UpdatePlayerStatsData(Player player, SqlConnection connection)
        {
            using (SqlCommand updateSavedGame = connection.CreateCommand())
            {
                updateSavedGame.CommandType = CommandType.Text;
                updateSavedGame.CommandText = "UPDATE SavedGame "
                + "SET CurrentHitPoints = @CurrentHitPoints, " + "MaximumHitPoints = @MaximumHitPoints, " + "Gold = @Gold, " + "ExperiencePoints = @ExperiencePoints, "
                + "CurrentLocationID = @CurrentLocationID";

                updateSavedGame.Parameters.Add("@CurrentHitPoints", SqlDbType.Int);
                updateSavedGame.Parameters["@CurrentHitPoints"].Value = player.CurrentHitPoints;

                updateSavedGame.Parameters.Add("@MaximumHitPoints", SqlDbType.Int);
                updateSavedGame.Parameters["@MaximumHitPoints"].Value = player.MaximumHitPoints;

                updateSavedGame.Parameters.Add("@Gold", SqlDbType.Int);
                updateSavedGame.Parameters["@Gold"].Value = player.Gold;

                updateSavedGame.Parameters.Add("@ExperiencePoints", SqlDbType.Int);
                updateSavedGame.Parameters["@ExperiencePoints"].Value = player.ExperiencePoints;

                updateSavedGame.Parameters.Add("@CurrentLocationID", SqlDbType.Int);
                updateSavedGame.Parameters["@CurrentLocationID"].Value = player.CurrentLocation.ID;

                updateSavedGame.ExecuteNonQuery();

            }
        }

        private static void UpdatingPlayerQuestData(Player player, SqlConnection connection)
        {
            using (SqlCommand deleteQuestsCommand = connection.CreateCommand())
            {
                deleteQuestsCommand.CommandType = CommandType.Text;
                deleteQuestsCommand.CommandText = "DELETE  FROM Quest";
                deleteQuestsCommand.ExecuteNonQuery();
            }
            foreach (PlayerQuest playerQuest in player.Quests)
            {
                using (SqlCommand insertQuestCommand = connection.CreateCommand())
                {
                    insertQuestCommand.CommandType = CommandType.Text;
                    insertQuestCommand.CommandText =
                   "INSERT INTO Quest (QuestID, IsCompleted) VALUES (@QuestID, @IsCompleted)";

                    insertQuestCommand.Parameters.Add("@QuestID", SqlDbType.Int);
                    insertQuestCommand.Parameters["@QuestID"].Value = playerQuest.Details.ID;
                    insertQuestCommand.Parameters.Add("@IsCompleted", SqlDbType.Bit);
                    insertQuestCommand.Parameters["@IsCompleted"].Value = playerQuest.IsCompleted;

                    insertQuestCommand.ExecuteNonQuery();
                }
            }
        }

        private static void UpdatingInventoryData(Player player, SqlConnection connection)
        {
            using (SqlCommand deleteInventoryCommand = connection.CreateCommand())
            {
                deleteInventoryCommand.CommandType = CommandType.Text;
                deleteInventoryCommand.CommandText = "DELETE FROM Inventory";
                deleteInventoryCommand.ExecuteNonQuery();
            }
            foreach (InventoryItem Inventoryitem in player.Inventory)
            {
                using (SqlCommand insertInventoryCommand = connection.CreateCommand())
                {
                    insertInventoryCommand.CommandType = CommandType.Text;
                    insertInventoryCommand.CommandText =
                   "INSERT INTO Inventory (InventoryItemID, Quantity) VALUES (@InventoryItemID, @Quantity)";

                    insertInventoryCommand.Parameters.Add("@InventoryItemID", SqlDbType.Int);
                    insertInventoryCommand.Parameters["@InventoryItemID"].Value = Inventoryitem.ItemID;
                    insertInventoryCommand.Parameters.Add("@Quantity", SqlDbType.Int);
                    insertInventoryCommand.Parameters["@Quantity"].Value = Inventoryitem.Quantity;

                    insertInventoryCommand.ExecuteNonQuery();
                }
            }
        }
    }
}
