using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineTester
{
    /// <summary>
    /// Class for the simulated engine test stand
    /// </summary>
    internal class TestStand
    {
        public Engine _engine { get; set; } // The engine that is being tested

        /// <summary>
        /// Constructor for the TestStand class
        /// </summary>
        /// <param name="engine">The engine that is being tested</param>
        public TestStand(Engine engine)
        {  
            _engine = engine;
        }

        /// <summary>
        /// Get the amount of seconds until the engine overheats or -1 if it stays at the same temperature for secondsUntilStable seconds
        /// </summary>
        /// <param name="secondsUntilStable">Seconds at the same temperature until the engine is considered stable and won't overheat</param>
        /// <returns>int seconds or -1</returns>
        public int TestForOverheating(int secondsUntilStable)
        {
            int seconds = 0;
            int stable = 0;
            while (_engine._tempEngine < _engine._tempOverheat)
            {
                var prevT = _engine._tempEngine;
                _engine.SimulateSecond();
                if (_engine._tempEngine == prevT)
                {
                    stable++;
                    if (stable >= secondsUntilStable)
                    {
                        return -1;
                    }
                }
                else
                {
                    stable = 0;
                }
                seconds++;
            }
            return seconds;
        }

        /// <summary>
        /// TestForOverheating with output of Tengine, m and v every second
        /// </summary>
        /// <param name="secondsUntilStable"></param>
        /// <returns></returns>
        public int TestForOverheatingVerbose(int secondsUntilStable)
        {
            int seconds = 0;
            int stable = 0;
            while (_engine._tempEngine < _engine._tempOverheat)
            {
                var prevT = _engine._tempEngine;
                Console.WriteLine($"Second {seconds+1}:");
                _engine.SimulateSecond();
                Console.WriteLine($"T = {_engine._tempEngine}, V = {_engine._velocity}, M = {_engine._torque}\n");
                if (_engine._tempEngine == prevT)
                {
                    stable++;
                    if (stable >= secondsUntilStable)
                    {
                        return -1;
                    }
                }
                else
                {
                    stable = 0;
                }
                seconds++;
            }
            return seconds;
        }
    }
}
