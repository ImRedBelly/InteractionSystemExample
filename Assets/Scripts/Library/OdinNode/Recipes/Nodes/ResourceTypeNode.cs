using XNode;
using Setups.Recipes;
using OdinNode.Scripts;

namespace OdinNode.Recipes.Nodes
{
    public class ResourceTypeNode : Node
    {
        [Output(ShowBackingValue.Always)] public ResourceType resourceType;
        public override object GetValue(NodePort port) => resourceType;
        
        // private void OnValidate()
        // {
        //     name = resourceType.name;
        // }

    }
}