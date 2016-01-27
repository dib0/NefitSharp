﻿using System;
using System.Threading;

namespace NefitSharp.Entities
{
    public struct Status
    {
        public string UserMode { get; }

        public string ClockProgram { get; }

        public string InHouseStatus { get; }

        public double InHouseTemperature { get; }

        public string BoilerIndicator { get; }

        public string Control { get; }

        public double TempOverrideDuration { get; }

        public double CurrentSwitchpoint { get; }

        public bool PowerSaveMode { get; }

        public bool FireplaceMode { get; }

        public bool TempOverride { get; }

        public bool HolidayMode { get; }

        public bool BoilerBlock { get; }

        public bool BoilerLock { get; }

        public bool BoilerMaintenance { get; }

        public double TemperatureSetpoint { get; }

        public double TemperatureOverrideSetpoint { get; }

        public double TemparatureManualSetpoint { get; }

        public bool HedEnabled { get; }

        public bool HedDeviceAtHome { get; }

        public double OutdoorTemperature { get; }

        public string OutdoorTemperatureSource { get; }

        internal Status(NefitStatus stat,double outdoorTemp)
        {
            UserMode = stat.UMD;
            ClockProgram = stat.CPM;
            InHouseStatus = stat.IHS;
            InHouseTemperature = Convert.ToDouble(stat.IHT.Replace(".", Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator));
            BoilerIndicator = stat.BAI;
            Control = stat.CTR;
            TempOverrideDuration = Convert.ToDouble(stat.TOD.Replace(".", Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator));
            CurrentSwitchpoint = Convert.ToDouble(stat.CSP.Replace(".", Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator));
            PowerSaveMode = stat.ESI=="on";
            FireplaceMode = stat.FPA == "on";
            TempOverride = stat.TOR == "on";
            HolidayMode = stat.HMD == "on";
            BoilerBlock = stat.BBE == "on";
            BoilerLock = stat.BLE == "on";
            BoilerMaintenance = stat.BMR == "on";
            TemperatureSetpoint = Convert.ToDouble(stat.TSP.Replace(".", Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator));
            TemperatureOverrideSetpoint = Convert.ToDouble(stat.TOT.Replace(".", Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator));
            TemparatureManualSetpoint = Convert.ToDouble(stat.MMT.Replace(".", Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator));
            HedEnabled = stat.HED_EN == "on";
            HedDeviceAtHome = stat.HED_DEV == "on";
            OutdoorTemperature =outdoorTemp;
            OutdoorTemperatureSource = "unknown";
        }


    }
}