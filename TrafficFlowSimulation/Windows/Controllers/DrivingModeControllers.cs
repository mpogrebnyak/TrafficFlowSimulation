﻿using Localization.Localization;
using Settings;
using System;
using System.Linq;
using System.Windows.Forms;
using TrafficFlowSimulation.Сonstants;

namespace TrafficFlowSimulation.Windows.Controllers
{
    public static class DrivingModeControllers
    {
        public static void Initialize(ToolStripDropDownButton modesButton)
        {
            modesButton.DropDownItems.Clear();
            var availableModes = SettingsHelper.Get<Properties.Settings>().AvailableDrivingModes.ToList();

            foreach (DrivingMode mode in Enum.GetValues(typeof(DrivingMode)))
            {
                if (availableModes.Contains(mode))
                {
                    var menuItem = new ToolStripMenuItem
                    {
                        Name = mode.ToString(),
                        Text = mode.GetDescription(),
                        Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)))
                    };

                    menuItem.Click += new System.EventHandler(MenuItem_Click);
                    modesButton.DropDownItems.Add(menuItem);
                }
            }

            modesButton.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));

            modesButton.Text = modesButton.DropDownItems.Count > 0
                ? modesButton.DropDownItems[0].Text
                : "Нет доступных режимов";
        }

        private static void MenuItem_Click(object sender, EventArgs e)
        {
            var selectedModeItem = sender as ToolStripMenuItem;
            var owner = (selectedModeItem.Owner as ToolStripDropDownMenu).OwnerItem;
            owner.Text = selectedModeItem.Text;
        }
    }
}