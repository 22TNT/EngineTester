using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineTester
{
    abstract class Engine
    {
        double _inertia { get; set; } // I - moment of intertia (kg*m^2)
        double _tempEnvinroment { get; set; } //Tenvironment - environment temperature (C)
        double _tempEngine { get; set; } // Tengine - engine temperature (C)
        double _tempOverheat { get; set; } // Toverheat - overheating temperature (C)
        double _ratioCooling { get; set; } // C - ratio of cooling effectiveness based on engine temp and environment temp

        public Engine(double inertia, double tempOverheat, double coolingRatio, double tempEnvinroment)
        {
            _inertia = inertia;
            _tempOverheat = tempOverheat;
            _ratioCooling = coolingRatio;
            _tempEnvinroment = tempEnvinroment;
            _tempEngine = _tempEnvinroment;
        }

        public abstract void EngineHeatUp();
        public abstract void EngineCooling();
        public abstract double Acceleration(); 
    }
}
