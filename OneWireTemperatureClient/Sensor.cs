using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DalSemi.OneWire;
using DalSemi.OneWire.Adapter;
using DalSemi.OneWire.Container;

namespace OneWireTemperatureClient
{
    class Sensor
    {
        PortAdapter adapter;

        public Sensor(string adapterName, string portName)
        {
            adapter = AccessProvider.GetAdapter(adapterName, portName);
        }

        public double? GetTemperature()
        {
            double? temperature = null;

            // Connects to the onewire adapter                        
            DeviceContainerList owSensors = adapter.GetDeviceContainers();

            if (owSensors.Count > 0)
            {
                OneWireContainer owc = owSensors[0];
                string owcType = owc.GetType().ToString();
                if (owcType.CompareTo("DalSemi.OneWire.Container.OneWireContainer10") == 0) // Read DS1820 and DS18S20
                {
                    OneWireContainer10 owc10 = (OneWireContainer10)owc;
                    byte[] state = owc10.ReadDevice();
                    owc10.DoTemperatureConvert(state);

                    //Changes the resultion that that will be read
                    owc10.SetTemperatureResolution(OneWireContainer10.RESOLUTION_MAXIMUM, state);

                    //Reads the temperature
                    temperature = owc10.GetTemperature(state);
                }
            }
            return temperature;
        }
    }
}
