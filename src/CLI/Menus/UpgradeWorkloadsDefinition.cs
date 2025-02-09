using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CLIFramework;
using ScaleUnitManagement.WorkloadSetupOrchestrator;

namespace CLI
{
    internal class UpgradeWorkloadsDefinition : DevToolMenu
    {
        public override async Task Show(int input, string selectionHistory)
        {
            List<CLIOption> options = SelectScaleUnitOptions(GetSortedScaleUnits(), Upgrade);
            var screen = new MultiSelectScreen(options, selectionHistory,
                $"Please select the environment(s) you want to upgrade the workload definitions on\n" +
                $"Press enter to upgrade the workloads on all environments.\n",
                "\nWhich environment would you like to upgrade the workloads on?: ");
            await CLIController.ShowScreen(screen);

            Console.WriteLine("Done\n");
        }

        public async Task Upgrade(int input, string selectionHistory)
        {
            var workloadDefinitionManager = new WorkloadDefinitionManager();
            await workloadDefinitionManager.UpgradeWorkloadsDefinition();
        }
    }
}
