using System.Collections.Generic;
using System.Linq;
using OdinNode.Recipes.Nodes;
using Sirenix.OdinInspector;
using UnityEngine;
using XNode;

namespace OdinNode.Recipes
{
    [CreateAssetMenu(fileName = "TransformRecipeGraph", menuName = "Recipes/TransformRecipeGraph")]
    public class TransformRecipeGraph : NodeGraph
    {
        public List<TransformerRecipe> recipes;


        [Button]
        public void CreateRecipes()
        {
            var recipesNodes = nodes.FindAll(x => x is TransformRecipeNode).Cast<TransformRecipeNode>().ToList();
            for (int i = 0; i < recipesNodes.Count; i++)
                recipes.Add(new TransformerRecipe()
                    {recipe = recipesNodes[i].inputResourceType, resultRecipe = recipesNodes[i].outputResourceType});
        }
    }
}