using Core.AI;
using Core.AI.Workers;
using Core.Storage;
using Core.Utils;
using Storage;
using Setups.Interactions;
using UnityEngine;


namespace Core.Interaction
{
    public class CookTransformerInteraction : BaseInteraction<TransformerInteractionSetup>
    {
        [SerializeField] private InventoryView inventoryView;
        readonly Inventory _returnInventory = new Inventory();

        protected override void OnEnable()
        {
            base.OnEnable();
            Inventory.OnChangeResource += inventoryView.UpdateView;
        }


        public override bool CanInteract(Worker worker)
        {
            var recipe = MechanicsController.Combine(setup.recipes.recipes, Inventory.Items);
            if (recipe == null) return false;
           
            _returnInventory.Add(worker.Inventory.Items);
            worker.Inventory.Clear();
            
            return base.CanInteract(worker);
        }

        public override void CompleteInteraction(Worker worker)
        {
            var recipe = MechanicsController.Combine(setup.recipes.recipes, Inventory.Items);

            if (recipe != null)
            {
                Inventory.Clear();
                worker.Inventory.Add(recipe);
            }

            base.CompleteInteraction(worker);
        }

        public override void BreakUpInteraction(Worker worker)
        {
            ReturnResourceToworker(worker);
            base.BreakUpInteraction(worker);
        }

        private void ReturnResourceToworker(Worker worker)
        {
            worker.Inventory.Add(_returnInventory.Items);
            _returnInventory.Clear();
        }
    }
}