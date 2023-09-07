//-------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;

namespace Full_GRASP_And_SOLID.Library
{
    public class Recipe
    {
        private ArrayList steps = new ArrayList();

        public Product FinalProduct { get; set; }

        public void AddStep(Step step)
        {
            this.steps.Add(step);
        }

        public void RemoveStep(Step step)
        {
            this.steps.Remove(step);
        }

        public double GetProductionCost()
        {
            double totalCostOfIngredients = 0;
            double totalCostOfEquipment = 0;

            foreach (Step step in this.steps)
            {
                totalCostOfIngredients += step.Quantity * step.Input.UnitCost;
                totalCostOfEquipment += (step.Time / 60.0) * step.Equipment.HourlyCost; // Convertir minutos a horas
            }
            double totalProductionCost = totalCostOfIngredients + totalCostOfEquipment;
            return totalProductionCost;
        }

        public void PrintRecipe()
        {
            Console.WriteLine($"Receta de {this.FinalProduct.Description}:");
            foreach (Step step in this.steps)
            {
                Console.WriteLine($"{step.Quantity} de '{step.Input.Description}' " +
                    $"usando '{step.Equipment.Description}' durante {step.Time} minutos");
            }

            double totalProductionCost = GetProductionCost();
            Console.WriteLine($"Costo total de producción: ${totalProductionCost}");
        }
    }
}