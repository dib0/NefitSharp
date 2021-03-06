using System;
using NefitSharp.Entities.Internal;

namespace NefitSharp.Entities
{
    public class UIStatus
    {
        public ClockProgram ClockProgram { get; }
        public InHouseStatus InHouseStatus { get; }
        public double InHouseTemperature { get; }
        public BoilerIndicator BoilerIndicator { get; }
        public ControlMode Control { get; }
        public double TempOverrideDuration { get; }
        public int CurrentProgramSwitch { get; }
        public bool PowerSaveMode { get; }
        public bool FireplaceMode { get; }
        public bool HotWaterAvailable { get; }
        public bool TempOverride { get; }
        public bool HolidayMode { get; }
        public bool BoilerBlock { get; }
        public bool DayAsSunday { get; }
        public bool BoilerLock { get; }
        public bool BoilerMaintenance { get; }
        public double TemperatureSetpoint { get; }
        public double TemperatureOverrideSetpoint { get; }
        public double TemparatureManualSetpoint { get; }
        public bool HedEnabled { get; }
        string HedDeviceName { get; }
        public bool HedDeviceAtHome { get; }
        public UserModes UserMode { get; }
        internal UIStatus(NefitStatus stat)
        {
            switch (stat.UMD.ToLower())
            {
                case "clock":
                    UserMode = UserModes.Clock;
                    break;

                case "manual":
                    UserMode = UserModes.Manual;
                    break;
                default:
                    UserMode = UserModes.Unknown;
                    break;
            }
            switch (stat.CPM.ToLower())
            {
                case "selflearning":
                    ClockProgram = ClockProgram.SelfLearning;
                    break;
                case "auto":
                    ClockProgram = ClockProgram.Auto;
                    break;
                default:
                    ClockProgram = ClockProgram.Unknown;
                    break;
            }
            switch (stat.IHS.ToLower())
            {
                case "ok":
                    InHouseStatus = InHouseStatus.Ok;
                    break;

                default:
                    InHouseStatus = InHouseStatus.Unknown;
                    break;
            }
            switch (stat.CTR.ToLower())
            {
                case "room":
                    Control = ControlMode.Room;
                    break;

                default:
                    Control = ControlMode.Unknown;
                    break;
            }
            switch (stat.BAI.ToLower())
            {
                case "no":
                    BoilerIndicator = BoilerIndicator.Off;
                    break;

                case "ch":
                    BoilerIndicator = BoilerIndicator.CentralHeating;
                    break;
                case "hw":
                    BoilerIndicator = BoilerIndicator.HotWater;
                    break;


                default:
                    BoilerIndicator = BoilerIndicator.Unknown;
                    break;
            }
            InHouseTemperature = Utils.StringToDouble(stat.IHT);
            TempOverrideDuration = Utils.StringToDouble(stat.TOD);
            CurrentProgramSwitch =Convert.ToInt32(stat.CSP);
            PowerSaveMode = stat.ESI == "on";
            FireplaceMode = stat.FPA == "on";
            TempOverride = stat.TOR == "on";
            HolidayMode = stat.HMD == "on";
            BoilerBlock = stat.BBE == "true";
            DayAsSunday = stat.DAS == "on";
            BoilerLock = stat.BLE == "on";
            BoilerMaintenance = stat.BMR == "true";
            TemperatureSetpoint = Utils.StringToDouble(stat.TSP);
            TemperatureOverrideSetpoint = Utils.StringToDouble(stat.TOT);
            TemparatureManualSetpoint = Utils.StringToDouble(stat.MMT);
            HedEnabled = stat.HED_EN == "true";
            HedDeviceAtHome = stat.HED_DEV == "true";
            HotWaterAvailable = stat.DHW == "on";
            HedDeviceName = stat.HED_DB;
        }
    }
}