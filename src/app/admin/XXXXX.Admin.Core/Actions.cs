using System.Collections.Generic;

using XXXXX.Admin.Core.Models;

namespace XXXXX.Admin.Core
{
    public static class Actions
    {
        private static readonly ActionDefinition[] ACTIONS = new ActionDefinition[]
        {
            // TODO
            // new ActionDefinition()
            // {
            //     Authorizations = Enumerable.Empty<string>(),
            //     LabelCode = "ui.devices.add-connected",
            //     LabelDefault = "Add connected device",
            //     Icon = "mdi-wifi",
            //     RouteTemplate = "/devices",
            //     ActionType = ActionType.OpenDrawer,
            //     ComputePath = (_, _) => Task.FromResult("/connect/devices/drawer")
            // },
        };

        public static IEnumerable<ActionDefinition> GetActions()
        {
            return ACTIONS;
        }
    }
}