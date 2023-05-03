using System.Collections.Generic;
using Core.AI;
using Core.AI.Workers;
using Core.Utils;
using Setups.Interactions;
using Setups.Recipes;

namespace Core.Interaction
{
    public class CutTransformerInteraction : BaseInteraction<TransformerInteractionSetup>
    {

        public override bool CanInteract(Worker worker)
        {
           
            Dictionary<ResourceType, int> recipe = MechanicsController.Combine(setup.recipes.recipes, worker.Inventory.Items);
            if (recipe == null) return false;

            return base.CanInteract(worker);
        }


        public override void Interact(Worker worker)
        {
            base.Interact(worker);
            
            
            Inventory.Add(worker.Inventory.Items);
            worker.Inventory.Clear();
        }

        public override void CompleteInteraction(Worker worker)
        {
            Dictionary<ResourceType, int> recipe = MechanicsController.Combine(setup.recipes.recipes, Inventory.Items);
            Inventory.Clear();

            worker.Inventory.Add(recipe);
            base.CompleteInteraction(worker);
           
        }

        public override void BreakUpInteraction(Worker worker)
        {
            ReturnResourceToWorker(worker);
            base.BreakUpInteraction(worker);
        }

       

        private void ReturnResourceToWorker(Worker worker)
        {
            worker.Inventory.Add(Inventory.Items);
            Inventory.Clear();
        }

    }
}