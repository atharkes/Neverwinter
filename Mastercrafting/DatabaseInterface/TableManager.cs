﻿using DatabaseInterface.Structure;
using DatabaseInterface.Structure.Tables;
using System.Collections.Generic;

namespace DatabaseInterface {
    /// <summary> Manages the table objects in the database </summary>
    static class TableManager {
        /// <summary> Enum for getting to the tables in the dictionary </summary>
        public enum Tables {
            Profession,
            Recipe,
            RecipeCost,
            RecipeResult,
            Resource,
            ResourcePrice,
            Upgrade
        }

        /// <summary> The tables currently being managed </summary>
        public readonly static Dictionary<Tables, Table> Table = new Dictionary<Tables, Table>();

        /// <summary> Creates the table objects </summary>
        public static void InitializeTableStructure() {
            Table.Add(Tables.Profession, new ProfessionTable());
            Table.Add(Tables.Recipe, new RecipeTable());
            Table.Add(Tables.Resource, new ResourceTable());
            Table.Add(Tables.RecipeCost, new RecipeCostTable());
            Table.Add(Tables.RecipeResult, new RecipeResultTable());
            Table.Add(Tables.ResourcePrice, new ResourcePriceTable());
            Table.Add(Tables.Upgrade, new UpgradeTable());
        }

        /// <summary> Adds the tables to the database that currently don't exist </summary>
        public static void AddTablesToDatabase() {
            foreach (Table table in Table.Values) {
                if (!table.Exists) {
                    table.Create();
                }
            }
        }

        internal static ProfessionTable Profession => Table[Tables.Profession] as ProfessionTable;
        internal static RecipeTable Recipe => Table[Tables.Recipe] as RecipeTable;
        internal static RecipeCostTable RecipeCost => Table[Tables.RecipeCost] as RecipeCostTable;
        internal static RecipeResultTable RecipeResult => Table[Tables.RecipeResult] as RecipeResultTable;
        internal static ResourceTable Resource => Table[Tables.Resource] as ResourceTable;
        internal static ResourcePriceTable ResourcePrice => Table[Tables.Resource] as ResourcePriceTable;
        internal static UpgradeTable Upgrade => Table[Tables.Upgrade] as UpgradeTable;
    }
}
