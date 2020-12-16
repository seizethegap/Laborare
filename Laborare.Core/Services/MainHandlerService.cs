namespace Laborare.Core.Services
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Threading;
    using System.Windows;

    using Laborare.Core.Commands.CommandProcessor;
    using Laborare.Core.Configuration;
    using Laborare.Core.Models;


    public static class MainHandlerService
    {
        /* This static class is our handler will hold the instances of our motors,
         * third-party peripherals, etc. Our whole application should be able to 
         * access things in this Handler service.
         */

        // Holds value for whether motor position will be in millimeter or inches
        public static string _Metric_Setting = ConfigurationManager.AppSettings["metric_setting"];

        public static int _NumOfTrays = Convert.ToInt32(ConfigurationManager.AppSettings["number_of_trays"]);

        // Holds value for interval of reading input signals from io board.
        public static string Read_Io_Interval_Setting
        {
            get
            {
                return ConfigurationManager.AppSettings["read_io_interval"];
            }
            set
            {
                Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                configuration.AppSettings.Settings["read_io_interval"].Value = value;
                configuration.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
        }

        /// <summary>
        /// This Dictionary will hold the initialized objects from the InitializedDevices
        /// function for the remainder of the application being open.
        /// </summary>
        public static Dictionary<string, IAxisMotor> AxisMotors = new Dictionary<string, IAxisMotor>();

        /// <summary>
        /// This Dictionary will hold the name of the function for IO boards as well as their location
        /// and description (for the I/O check screen and more)
        /// i.e 
        /// key = "VAC_GENERATOR_SENSOR" value = ["RP0003QJ", "s0", "Vacuum Generator's Sensor"]
        /// </summary>
        public static Dictionary<string, string[]> IoDevices = new Dictionary<string, string[]>();

        /// <summary>
        /// This Dictionary will hold the initialized io boards detected from our USBIOBoardService
        /// </summary>
        public static Dictionary<string, IIOBoard> ActiveIOBoards = new Dictionary<string, IIOBoard>();

        /// <summary>
        /// This Dictionary will hold the initialized trays detected.
        /// </summary>
        public static Dictionary<string, Tray> ActiveTrays = new Dictionary<string, Tray>();

        // TODO: what to do with peripherals that aren't motors?
        public static void InitializeTcpDevices()
        {
            // Get the custom Configuration Section using its name
            var TcpConfig = (TCPConnectionConfig)ConfigurationManager.GetSection("TCPConnection");

            // Loop through each instance in the TCPConnectionInstanceCollection
            foreach (TCPConnectionInstanceElement instance in TcpConfig.TCPConnectionInstances)
            {
                // Check to see if device is a motor 
                if (instance.Name.Contains("motor"))
                {
                    // yes it is, now check which motor it is
                    if (instance.Name.Contains("x")) 
                    {
                        // okay, so it is an x motor, now what type of motor is it? (e.g cm1? cm2?)
                        if (instance.Type.Contains("cm1"))
                        {
                            // so it is a tcp cm1 x motor, use the CM1 command processor
                            AxisMotors.Add(instance.Name, new XMotor(instance.Name, instance.Device_Id, instance.Resolution, new TCPConnectionService(instance.Ip_Address, instance.Port), new CM1CommandProcessor()));
                        }
                        else if (instance.Type.Contains("cm2"))
                        {
                            // so it is a tcp cm2 x motor, use the CM2 command processor
                            AxisMotors.Add(instance.Name, new XMotor(instance.Name, instance.Device_Id, instance.Resolution, new TCPConnectionService(instance.Ip_Address, instance.Port), new CM2CommandProcessor()));
                        }
                        else
                        {
                            // if we are here, that means I haven't yet implemented a commandprocessor for this motor type.
                            //MessageBox.Show("X Motor is an unknown motor type that still needs implementation. Contact Andrew.");
                            break;
                        }
                    }
                    else if (instance.Name.Contains("y"))
                    {
                        // okay, so it is a y motor, now what type of motor is it? (e.g cm1? cm2?)
                        if (instance.Type.Contains("cm1"))
                        {
                            // so it is a tcp cm1 y motor, use the CM1 command processor
                            AxisMotors.Add(instance.Name, new YMotor(instance.Name, instance.Device_Id, instance.Resolution, new TCPConnectionService(instance.Ip_Address, instance.Port), new CM1CommandProcessor()));
                        }
                        else if (instance.Type.Contains("cm2"))
                        {
                            // so it is a tcp cm2 y motor, use the CM2 command processor
                            AxisMotors.Add(instance.Name, new YMotor(instance.Name, instance.Device_Id, instance.Resolution, new TCPConnectionService(instance.Ip_Address, instance.Port), new CM2CommandProcessor()));
                        }
                        else
                        {
                            // if we are here, that means I haven't yet implemented a commandprocessor for this motor type.
                            //MessageBox.Show("Y Motor is an unknown motor type that still needs implementation. Contact Andrew.");
                            break;
                        }
                    }
                    else if (instance.Name.Contains("z"))
                    {
                        // okay, so it is a z motor, now what type of motor is it? (e.g cm1? cm2?)
                        if (instance.Type.Contains("cm1"))
                        {
                            // so it is a tcp cm1 z motor, use the CM1 command processor
                            AxisMotors.Add(instance.Name, new ZMotor(instance.Name, instance.Device_Id, instance.Resolution, new TCPConnectionService(instance.Ip_Address, instance.Port), new CM1CommandProcessor()));
                        }
                        else if (instance.Type.Contains("cm2"))
                        {
                            // so it is a tcp cm2 z motor, use the CM2 command processor
                            AxisMotors.Add(instance.Name, new ZMotor(instance.Name, instance.Device_Id, instance.Resolution, new TCPConnectionService(instance.Ip_Address, instance.Port), new CM2CommandProcessor()));
                        }
                        else
                        {
                            // if we are here, that means I haven't yet implemented a commandprocessor for this motor type.
                            //MessageBox.Show("Z Motor is an unknown motor type that still needs implementation. Contact Andrew.");
                            break;
                        }
                    }
                    else if (instance.Name.Contains("r"))
                    {
                        // okay, so it is a r motor, now what type of motor is it? (e.g cm1? cm2?)
                        if (instance.Type.Contains("cm1"))
                        {
                            // so it is a tcp cm1 r motor, use the CM1 command processor
                            AxisMotors.Add(instance.Name, new RMotor(instance.Name, instance.Device_Id, instance.Resolution, new TCPConnectionService(instance.Ip_Address, instance.Port), new CM1CommandProcessor()));
                        }
                        else if (instance.Type.Contains("cm2"))
                        {
                            // so it is a tcp cm2 r motor, use the CM2 command processor
                            AxisMotors.Add(instance.Name, new RMotor(instance.Name, instance.Device_Id, instance.Resolution, new TCPConnectionService(instance.Ip_Address, instance.Port), new CM2CommandProcessor()));
                        }
                        else if (instance.Type.Contains("uirobot"))
                        {
                            // so it is a tcp uirobot r motor, use the uirobot command processor
                            AxisMotors.Add(instance.Name, new RMotor(instance.Name, instance.Device_Id, instance.Resolution, new TCPConnectionService(instance.Ip_Address, instance.Port), new UIRobotCommandProcessor()));
                        }
                        else
                        {
                            // if we are here, that means I haven't yet implemented a commandprocessor for this motor type.
                            //MessageBox.Show("R Motor is an unknown motor type that still needs implementation. Contact Andrew.");
                            break;
                        }
                    }
                }
                else
                {
                    // TODO: these devices are not motors, they could be cameras, tester, etc. Need to implement this.
                }
            }
        }

        public static void InitializeRs232Devices()
        {
            // Get the custom Configuration Section using its name
            var Rs232Config = (RS232ConnectionConfig)ConfigurationManager.GetSection("RS232Connection");

            // Loop through each instance in the TCPConnectionInstanceCollection
            foreach (RS232ConnectionInstanceElement instance in Rs232Config.RS232ConnectionInstances)
            {
                // Check to see if device is a motor 
                if (instance.Name.Contains("motor"))
                {
                    // yes it is, now check which motor it is
                    if (instance.Name.Contains("x"))
                    {
                        // okay, so it is an x motor, now what type of motor is it? (e.g cm1? cm2?)
                        if (instance.Type.Contains("cm1"))
                        {
                            // so it is a rs232 cm1 x motor, use the CM1 command processor
                            AxisMotors.Add(instance.Name, new XMotor(instance.Name, instance.Device_Id, instance.Resolution, new RS232ConnectionService(instance.Port_Name, 
                                instance.Baud_Rate, instance.Databits, instance.Read_Timeout, instance.Write_Timeout, instance.Device_Id), new CM1CommandProcessor()));
                        }
                        else if (instance.Type.Contains("cm2"))
                        {
                            // so it is a rs232 cm2 x motor, use the CM2 command processor
                            AxisMotors.Add(instance.Name, new XMotor(instance.Name, instance.Device_Id, instance.Resolution, new RS232ConnectionService(instance.Port_Name,
                                instance.Baud_Rate, instance.Databits, instance.Read_Timeout, instance.Write_Timeout, instance.Device_Id), new CM2CommandProcessor()));
                        }
                        else
                        {
                            // if we are here, that means I haven't yet implemented a commandprocessor for this motor type.
                            //MessageBox.Show("X Motor is an unknown motor type that still needs implementation. Contact Andrew.");
                            break;
                        }
                    }
                    else if (instance.Name.Contains("y"))
                    {
                        // okay, so it is a y motor, now what type of motor is it? (e.g cm1? cm2?)
                        if (instance.Type.Contains("cm1"))
                        {
                            // so it is a rs232 y motor, use the CM1 command processor
                            AxisMotors.Add(instance.Name, new YMotor(instance.Name, instance.Device_Id, instance.Resolution, new RS232ConnectionService(instance.Port_Name,
                                instance.Baud_Rate, instance.Databits, instance.Read_Timeout, instance.Write_Timeout, instance.Device_Id), new CM1CommandProcessor()));
                        }
                        else if (instance.Type.Contains("cm2"))
                        {
                            // so it is a rs232 y motor, use the CM2 command processor
                            AxisMotors.Add(instance.Name, new YMotor(instance.Name, instance.Device_Id, instance.Resolution, new RS232ConnectionService(instance.Port_Name,
                                instance.Baud_Rate, instance.Databits, instance.Read_Timeout, instance.Write_Timeout, instance.Device_Id), new CM2CommandProcessor()));
                        }
                        else
                        {
                            // if we are here, that means I haven't yet implemented a commandprocessor for this motor type.
                            //MessageBox.Show("Y Motor is an unknown motor type that still needs implementation. Contact Andrew.");
                            break;
                        }
                    }
                    else if (instance.Name.Contains("z"))
                    {
                        // okay, so it is a z motor, now what type of motor is it? (e.g cm1? cm2?)
                        if (instance.Type.Contains("cm1"))
                        {
                            // so it is a rs232 cm1 z motor, use the CM1 command processor
                            AxisMotors.Add(instance.Name, new ZMotor(instance.Name, instance.Device_Id, instance.Resolution, new RS232ConnectionService(instance.Port_Name,
                                instance.Baud_Rate, instance.Databits, instance.Read_Timeout, instance.Write_Timeout, instance.Device_Id), new CM1CommandProcessor()));
                        }
                        else if (instance.Type.Contains("cm2"))
                        {
                            // so it is a rs232 cm2 z motor, use the CM2 command processor
                            AxisMotors.Add(instance.Name, new ZMotor(instance.Name, instance.Device_Id, instance.Resolution, new RS232ConnectionService(instance.Port_Name,
                                instance.Baud_Rate, instance.Databits, instance.Read_Timeout, instance.Write_Timeout, instance.Device_Id), new CM1CommandProcessor()));
                        }
                        else
                        {
                            // if we are here, that means I haven't yet implemented a commandprocessor for this motor type.
                            //MessageBox.Show("Z Motor is an unknown motor type that still needs implementation. Contact Andrew.");
                            break;
                        }
                    }
                    else if (instance.Name.Contains("r"))
                    {
                        // okay, so it is a r motor, now what type of motor is it? (e.g cm1? cm2?)
                        if (instance.Type.Contains("cm1"))
                        {
                            // so it is a rs232 cm1 r motor, use the CM1 command processor
                            AxisMotors.Add(instance.Name, new RMotor(instance.Name, instance.Device_Id, instance.Resolution, new RS232ConnectionService(instance.Port_Name,
                                instance.Baud_Rate, instance.Databits, instance.Read_Timeout, instance.Write_Timeout, instance.Device_Id), new CM1CommandProcessor()));
                        }
                        else if (instance.Type.Contains("cm2"))
                        {
                            // so it is a rs232 cm2 r motor, use the CM2 command processor
                            AxisMotors.Add(instance.Name, new RMotor(instance.Name, instance.Device_Id, instance.Resolution, new RS232ConnectionService(instance.Port_Name,
                                instance.Baud_Rate, instance.Databits, instance.Read_Timeout, instance.Write_Timeout, instance.Device_Id), new CM1CommandProcessor()));
                        }
                        else if (instance.Type.Contains("uirobot"))
                        {
                            // so it is a rs232 uirobot r motor, use the UIRobot command processor
                            AxisMotors.Add(instance.Name, new RMotor(instance.Name, instance.Device_Id, instance.Resolution, new RS232ConnectionService(instance.Port_Name,
                                instance.Baud_Rate, instance.Databits, instance.Read_Timeout, instance.Write_Timeout, instance.Device_Id), new UIRobotCommandProcessor()));
                        }
                        else
                        {
                            // if we are here, that means I haven't yet implemented a commandprocessor for this motor type.
                            //MessageBox.Show("R Motor is an unknown motor type that still needs implementation. Contact Andrew.");
                            break;
                        }
                    }
                }
                else
                {
                    // TODO: these devices are not motors, they could be cameras, tester, etc. Need to implement this.
                }
            }
        }

        public static void InitializeIoDeviceLocations()
        {
            var IoLegendConfig = (IOLegendConfig)ConfigurationManager.GetSection("IOLegend");

            foreach (IOLegendSignalElement entry in IoLegendConfig.IOLegendSignals)
            {
                // check whether the entry is an input or output signal
                if (entry.Signal.Contains("sol") || entry.Signal.Contains("s"))
                {
                    // lets split the key at the . because of our
                    // format of RPxxxxxx.sol 
                    // splitSignal[0] should be the board name
                    // splitSignal[1] should be the signal name
                    // value format = { board serial number, signal name, signal description }
                    string[] splitSignal = entry.Signal.Split('.');
                    IoDevices.Add(entry.Function, new string[] { splitSignal[0], splitSignal[1], entry.Description });
                }
                else
                {
                    //MessageBox.Show("There is an invalid entry in the IOLegend section of App.config.");
                }
            }
        }

        public static void InitializeTrays()
        {
            for (int i = 1; i <= _NumOfTrays; i++)
            {
                ActiveTrays.Add("Tray " + i.ToString(), new Tray());
            }
        }
    }
}
