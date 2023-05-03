using System;
using System.Collections.Generic;
using System.Linq;
using OdinNode.Recipes.Nodes;
using Setups.Recipes;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;
using XNode;

namespace OdinNode.Recipes
{
    [CreateAssetMenu(fileName = "BaseRecipeGraph", menuName = "Recipes/BaseRecipeGraph")]
    public class BaseRecipeGraph : NodeGraph
    {
        public List<Recipe> recipes;

        [Button]
        public void CreateRecipes()
        {
            var recipesNodes = nodes.FindAll(x => x is BaseRecipeNode).Cast<BaseRecipeNode>().ToList();
            for (int i = 0; i < recipesNodes.Count; i++)
                recipes.Add(recipesNodes[i].recipe);
            
        }
        //
        //
        // [Button]
        // public void OnUpdateView()
        // {
        //     var recipesNode = nodes.FindAll(x => x is RecipeNode).Cast<RecipeNode>().ToList();
        //     var resourceTypeNodes = nodes.FindAll(x => x is ResourceTypeNode).Cast<ResourceTypeNode>().ToList();
        //
        //
        //     foreach (var recipeNode in recipesNode)
        //     {
        //         foreach (var resourceType in recipeNode.recipe.recipe)
        //         {
        //             var resourceTypeNode =
        //                 resourceTypeNodes.FirstOrDefault(x => x.resourceType == resourceType.resourceType);
        //             if (resourceTypeNode != null)
        //             {
        //                 resourceTypeNode.GetPort("type").Connect(recipeNode.GetPort("resourceType"));
        //             }
        //         }
        //     }
        // }
        //
        //
        // [Button]
        // public void OnCreateResourceTypes()
        // {
        //     List<ResourceType> allRecipes = new List<ResourceType>();
        //     string[] guids = AssetDatabase.FindAssets("t:Object", new[] {"Assets/Setups/ResourceTypes/Sandwich/"});
        //
        //     Vector2 position = Vector2.zero;
        //
        //     foreach (string guid in guids)
        //     {
        //         string myObjectPath = AssetDatabase.GUIDToAssetPath(guid);
        //         var recipes = AssetDatabase.LoadAllAssetsAtPath(myObjectPath).Cast<ResourceType>().ToList();
        //
        //
        //         foreach (var recipe in recipes)
        //         {
        //             if (!allRecipes.Contains(recipe))
        //             {
        //                 allRecipes.Add(recipe);
        //                 var node = NodeGraphEditor.GetEditor(this, NodeEditorWindow.current)
        //                     .CreateNode(typeof(ResourceTypeNode), Vector2.zero) as ResourceTypeNode;
        //
        //
        //                 node.resourceType = recipe;
        //                 node.position = position;
        //                 position += new Vector2(0, 100);
        //             }
        //         }
        //     }
        //}
    }
}