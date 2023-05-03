using System;
using XNode;
using Setups.Recipes;
using OdinNode.Scripts;

namespace OdinNode.Recipes.Nodes
{
    public class BaseRecipeNode : Node
    {
        [Input(ShowBackingValue.Never)] public ResourceType inputResourceType;
        [Output] public Recipe outputRecipe;
        public Recipe recipe;

        // private void OnValidate()
        // {
        //     name = recipe.iconRecipe.name;
        // }

        public override object GetValue(NodePort port)
        {
            if (port.fieldName == nameof(outputRecipe))
                return recipe;
            return null;
        }

        public override void OnCreateConnection(NodePort from, NodePort to)
        {
            base.OnCreateConnection(from, to);


            var value = from.ValueType;
            var node = to.node as BaseRecipeNode;

            if (value == typeof(ResourceType))
            {
                var values = from.GetOutputValue() as ResourceType;
                recipe.recipe.Add(new RecipeInfo() {resourceType = values, count = 1});
            }

            else if (this == from.node && value == typeof(Recipe))
            {
                var values = from.GetOutputValue() as Recipe;

                for (int i = 0; i < values.recipe.Count; i++)
                {
                    node.recipe.recipe.Add(new RecipeInfo() {resourceType = values.recipe[i].resourceType, count = 1});
                }
            }
        }
    }
}