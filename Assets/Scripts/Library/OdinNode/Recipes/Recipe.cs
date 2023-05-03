using System;
using System.Collections.Generic;
using System.Linq;
using Setups.Recipes;
using Sirenix.OdinInspector;
using UnityEngine;

namespace OdinNode.Recipes
{
    [Serializable]
    public class Recipe
    {
        [PreviewField(50)] public Sprite iconRecipe;
        [ListDrawerSettings(Expanded = true)] public List<RecipeInfo> recipe = new List<RecipeInfo>();

        public bool CheckContainsResourceType(ResourceType resourceType) =>
            recipe.FirstOrDefault(x => x.resourceType == resourceType) != null;

        public double ProfitRecipe => (recipe.Sum(x => x.resourceType.ResourcePrice));
    }

    [Serializable]
    public class RecipeInfo
    {
        public ResourceType resourceType;
        public int count;
    }
}