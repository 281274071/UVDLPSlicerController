﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UV_DLP_3D_Printer.Drivers
{
    public class GenericDriver : DeviceDriver
    {
        public GenericDriver() 
        {
            m_drivertype = eDriverType.eGENERIC;
        }
        public override bool Connect() 
        {
            m_serialport.Open();
            if (m_serialport.IsOpen) 
            {
                m_connected = true;
                RaiseDeviceStatus(this, eDeviceStatus.eConnect);
                return true;
            }
            return false;
        }
        public override bool Disconnect() 
        {
            m_serialport.Close();
            m_connected = false;
            RaiseDeviceStatus(this, eDeviceStatus.eDisconnect);
            return true;
        }
        public override int Write(byte[] data, int len) 
        {
            m_serialport.Write(data, 0, len);
            return len;
        }
        public override int Write(String line) 
        {
            m_serialport.Write(line);
            return line.Length; 
        }
    }
}
