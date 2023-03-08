using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineTester
{
    /// <summary>
    /// Abstract class for an Engine.
    /// </summary>
    abstract class Engine
    {
        public double _inertia { get; set; } // I - moment of intertia (kg*m^2)
        public double _tempEnvinroment { get; set; } //Tenvironment - environment temperature (C)
        public double _tempEngine { get; set; } // Tengine - engine temperature (C)
        public double _tempOverheat { get; set; } // Toverheat - overheating temperature (C)
        public double _ratioCooling { get; set; } // C - ratio of cooling effectiveness based on engine temp and environment temp

        public double _torque { get; set; } // m - current torque
        public double _velocity { get; set; } // v - current velocity

        public Engine(double inertia, double tempOverheat, double coolingRatio, double tempEnvinroment)
        {
            _inertia = inertia;
            _tempOverheat = tempOverheat;
            _ratioCooling = coolingRatio;
            _tempEnvinroment = tempEnvinroment;
            _tempEngine = _tempEnvinroment;
            _velocity = 0;
        }

        public abstract double GetTemperatureHeatUp();
        public abstract double GetTemperatureCooldown();
        public abstract double Acceleration();
        public abstract void EngineChangeTemperature();

        public abstract void SimulateSecond();
    }
}
