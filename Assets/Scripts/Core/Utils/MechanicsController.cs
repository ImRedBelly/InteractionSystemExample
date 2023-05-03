using System.Collections.Generic;
using System.Linq;
using OdinNode.Recipes;
using Setups.Recipes;
using Storage;

namespace Core.Utils
{
    public static class MechanicsController
    {
        public static bool CanPlayerTakeResource(List<Recipe> recipes, Inventory playerInventory, ResourceType resource)
        {
            if (playerInventory.Items.Count == 0) return true;

            var items = playerInventory.ItemsCopy;
            items.Ensure(resource);
            items[resource] += 1;

            return DoesRecipeExistWithIngredients(recipes, items);
        }

        public static bool DoesRecipeExistWithIngredients(List<Recipe> recipes,
            IReadOnlyDictionary<ResourceType, int> ingredients)
        {
            if (recipes.Count == 0) return false;

            foreach (var recipe in recipes)
                if (CheckCompleteRecipe(recipe, ingredients))
                    return true;

            return false;
        }

        public static bool DoesRecipeExistWithIngredientsForWaiter(List<Recipe> recipes,
            IReadOnlyDictionary<ResourceType, int> ingredients)
        {
            if (recipes.Count == 0) return false;

            foreach (var recipe in recipes)
                if (CheckCompleteRecipeForWaiter(recipe, ingredients))
                    return true;

            return false;
        }

        public static Dictionary<ResourceType, int> Combine(List<Recipe> recipes,
            IReadOnlyDictionary<ResourceType, int> ingredients)
        {
            foreach (var r in recipes)
            {
                if (r.recipe.Count != ingredients.Count) continue;

                if (CheckResource(r, ingredients))
                    return ingredients
                        .ToDictionary(x => x.Key, x => x.Value);
            }

            return ingredients.ToDictionary(x => x.Key, x => x.Value);
            ;
        }

        public static Dictionary<ResourceType, int> Combine(List<TransformerRecipe> recipes,
            IReadOnlyDictionary<ResourceType, int> ingredients)
        {
            foreach (var r in recipes)
            {
                if (r.recipe.Count != ingredients.Count) continue;

                if (CheckResource(r, ingredients))
                    return r.resultRecipe
                        .ToDictionary(x => x.resourceType, x => x.count);
            }

            return null;
        }

        private static bool CheckCompleteRecipe(Recipe baseRecipe, IReadOnlyDictionary<ResourceType, int> resourceTypes)
        {
            foreach (var kv in resourceTypes)
                if (!baseRecipe.CheckContainsResourceType(kv.Key))
                    return false;

            foreach (var kv in baseRecipe.recipe)
            {
                var countResource = 0;

                if (resourceTypes.ContainsKey(kv.resourceType))
                    countResource += resourceTypes[kv.resourceType];

                if (countResource != kv.count && countResource != 0)
                    return false;
            }

            return true;
        }

        private static bool CheckCompleteRecipeForWaiter(Recipe baseRecipe,
            IReadOnlyDictionary<ResourceType, int> resourceTypes)
        {
            foreach (var kv in resourceTypes)
                if (!baseRecipe.CheckContainsResourceType(kv.Key))
                    return false;

            foreach (var kv in baseRecipe.recipe)
            {
                var countResource = 0;

                if (resourceTypes.ContainsKey(kv.resourceType))
                    countResource += resourceTypes[kv.resourceType];

                if (countResource != kv.count)
                    return false;
            }

            return true;
        }

        public static bool CheckResource(Recipe recipe, IReadOnlyDictionary<ResourceType, int> resource)
        {
            bool theSame = true;

            foreach (var kv in resource)
                if (theSame)
                    theSame = recipe.CheckContainsResourceType(kv.Key);

            return theSame;
        }

        public static bool CheckResource(Recipe recipe, List<List<RecipeInfo>> recipes)
        {
            var theSame = true;
            foreach (var listInfo in recipes)
            {
                foreach (var recipeInfo in listInfo)
                {
                    if (theSame)
                        theSame = recipe.CheckContainsResourceType(recipeInfo.resourceType);
                    else
                        break;
                }

                if (theSame)
                    return true;
            }

            return false;
        }
    }
}