using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Threading;
using SafeControl.Base;
using System.Net.NetworkInformation;
using System.Net;

namespace SafeControl.Dictionary
{
    /// <summary>
    /// Thư viện thao tác MNetworkInterface
    /// </summary>
    [Serializable]
    public class MNetworkInterface : MBase
    {
        public MNetworkInterface()
        {

        }
        #region Lấy địa chỉ MacClient
        // *********************************************************************
        /// <summary>
        /// 
        /// </summary>
        private const int PING_TIMEOUT = 1000;
        private static bool IsHostAccessible(string hostNameOrAddress)
        {
            Ping ping = new Ping();
            PingReply reply = ping.Send(hostNameOrAddress, PING_TIMEOUT);
            return reply.Status == IPStatus.Success;
        }
        

        public string GetMacAddress()
        {
            string macAddress = string.Empty;
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            NetworkInterface adapter = nics[0];
            PhysicalAddress address = adapter.GetPhysicalAddress();
            byte[] bytes = address.GetAddressBytes();
            for (int i = 0; i < bytes.Length; i++)
            {
                // Display the physical address in hexadecimal.
                macAddress += string.Format("{0}", bytes[i].ToString("X2"));
                // Insert a hyphen after each byte, unless we are at the end of the 
                // address.
                if (i != bytes.Length - 1)
                {
                    macAddress += "-";
                }
            }
            
            return macAddress;
        }
        public static List<string> GetMacAddress1()
        {
            List<string> list_MAC = new List<string>();
            
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            NetworkInterface adapter;
            for (int j = 0; j < nics.Length; j++)
            {
                string macAddress = string.Empty;
                adapter = nics[j];
                PhysicalAddress address = adapter.GetPhysicalAddress();
                byte[] bytes = address.GetAddressBytes();
                for (int i = 0; i < bytes.Length; i++)
                {
                    // Display the physical address in hexadecimal.
                    macAddress += string.Format("{0}", bytes[i].ToString("X2"));
                    // Insert a hyphen after each byte, unless we are at the end of the 
                    // address.
                    if (i != bytes.Length - 1)
                    {
                        macAddress += "-";
                    }
                }
                list_MAC.Add(macAddress);
            }

            return list_MAC;
        }
        public static void ShowNetworkInterfaces()
        {
            IPGlobalProperties computerProperties = IPGlobalProperties.GetIPGlobalProperties();
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            Console.WriteLine("Interface information for {0}.{1}     ",
                    computerProperties.HostName, computerProperties.DomainName);
            if (nics == null || nics.Length < 1)
            {
                Console.WriteLine("  No network interfaces found.");
                return;
            }

            Console.WriteLine("  Number of interfaces .................... : {0}", nics.Length);
            foreach (NetworkInterface adapter in nics)
            {
                IPInterfaceProperties properties = adapter.GetIPProperties(); //  .GetIPInterfaceProperties();
                Console.WriteLine();
                Console.WriteLine(adapter.Description);
                Console.WriteLine(String.Empty.PadLeft(adapter.Description.Length, '='));
                Console.WriteLine("  Interface type .......................... : {0}", adapter.NetworkInterfaceType);
                Console.Write("  Physical address ........................ : ");
                PhysicalAddress address = adapter.GetPhysicalAddress();
                byte[] bytes = address.GetAddressBytes();
                for (int i = 0; i < bytes.Length; i++)
                {
                    // Display the physical address in hexadecimal.
                    Console.Write("{0}", bytes[i].ToString("X2"));
                    // Insert a hyphen after each byte, unless we are at the end of the 
                    // address.
                    if (i != bytes.Length - 1)
                    {
                        Console.Write("-");
                    }
                }
                Console.WriteLine();
            }
        }
        #endregion
        #region Lấy địa chỉ IPClient
        public IPAddress GetIpAddressV4Client()
        {
            IPAddress[] serverIP = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress var in serverIP)
                if (var.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    return var;
            return null;
        }
        public IPAddress GetIpAddressV4Client(IPAddress[] serverIP)
        {
            foreach (IPAddress var in serverIP)
                if (var.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork && var.ToString() != "::1")
                    return var;
            return null;
        }
        #endregion
    }
}
