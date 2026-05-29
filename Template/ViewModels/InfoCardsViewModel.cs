using BusinessLayer;
using Production_Analysis.DbServices;
using Production_Analysis.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Production_Analysis.ViewModels
{
    public class InfoCardsViewModel : BaseViewModel
    {       
        public decimal ProductionTotal { get; set; }
        public decimal TotalPatient { get; set; }
        public decimal TotalVaccines { get; set; }
        public decimal ProductionDefectsPercent { get; set; }
        public decimal EnergyConsumption { get; set; }
        public decimal Emissions { get; set; }

        public PatientCollection AllPatients { get; set; }
        public VaccineCollection AllVaccines { get; set; }

        /*

        public InfoCardsViewModel(TimePeriod period)
        {
            IEnumerable<ProductionKPI> productionIndicators = LoadDbData.GetProductionIndicators(period);

            ProductionTotal = (productionIndicators.Select(p => p.ProductionOutput).Sum());
            ProductionDefectsPercent = (productionIndicators.Select(p => p.ProductionDefect).Sum()) / ProductionTotal;
            EnergyConsumption = (productionIndicators.Select(p => p.EnergyConsumption).Sum()) / ProductionTotal;
            Emissions = (productionIndicators.Select(p => p.Emissions).Sum()) / ProductionTotal;
        }

        */

        // teste so para rodar o codigo:
        public InfoCardsViewModel(TimePeriod period)
        {
            IEnumerable<ProductionKPI> productionIndicators = LoadDbData.GetProductionIndicators(period);

            var totalProduction = productionIndicators.Sum(p => p.ProductionOutput);
            var totalDefects = productionIndicators.Sum(p => p.ProductionDefect);
            var totalEnergy = productionIndicators.Sum(p => p.EnergyConsumption);
            var totalEmissions = productionIndicators.Sum(p => p.Emissions);

            ProductionTotal = totalProduction + 1;

            if (this.AllVaccines == null)
            {
                this.AllVaccines = Vaccine.GetListVaccines();
            }

            this.TotalVaccines = this.AllVaccines.GetTotal();

            System.Diagnostics.Debug.WriteLine($"Total Vaccines: {this.TotalVaccines}");

            ProductionDefectsPercent = totalProduction == 0
                ? 0
                : totalDefects / totalProduction;

            EnergyConsumption = totalProduction == 0
                ? 0
                : totalEnergy / totalProduction;

            Emissions = totalProduction == 0
                ? 0
                : totalEmissions / totalProduction;
        }
    }
}
