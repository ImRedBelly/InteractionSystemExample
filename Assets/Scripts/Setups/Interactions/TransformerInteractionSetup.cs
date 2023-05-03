using UnityEngine;
using OdinNode.Recipes;

namespace Setups.Interactions
{
    [CreateAssetMenu(fileName = "Transformer Interaction", menuName = "Setups/Interactions/Transformer")]
    public class TransformerInteractionSetup : BaseInteractionSetup
    {
        public TransformRecipeGraph recipes;
    }
}