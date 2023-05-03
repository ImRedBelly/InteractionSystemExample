using UnityEngine;
using OdinNode.Recipes;
using System.Collections.Generic;

namespace Setups
{
    [CreateAssetMenu(menuName = "Game Balance")]
    public class GameBalance : ScriptableObject
    {
        public List<BaseRecipeGraph> baseRecipes;
    }
}