﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Diagnostics;

namespace RelentAttachProcess
{
    class Mem
    {
        [DllImport("kernel32.dll")]
        private static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);
        [DllImport("kernel32.dll")]
        private static extern bool ReadProcessMemory(int hProcess, uint lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool WriteProcessMemory(int hProcess, uint lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesWritten);

        const int PROCESS_ALL_ACCESS = 0x1F0FFF;
        const int PROCESS_WM_READ = 0x0010;
        Process proc;
        IntPtr processHandle;
        private uint baseAddress = 0;

        public Mem()
        {
            OpenProcess(PROCESS_ALL_ACCESS);
        }
        public uint getBaseAddress(uint lbaVer)
        {
            string baseString;
            if (0 != baseAddress) return baseAddress;
            uint readAddr;
            if(1 == lbaVer)
            {
                baseString = "Relent";
                readAddr = 0x0A000FC8;//Base address to start scanning from
            }
            else
            {
                baseString = "Run-Time system.";
                readAddr = 0x0A00003D;
            }

            byte[] b = new byte[baseString.Length];

            for (int i = 0; i <= 0xFFFF; readAddr += 0x1000, i++)
            {
                int bytesRead = 0;

                ReadProcessMemory((int)processHandle, readAddr, b, b.Length, ref bytesRead);
                if (baseString == System.Text.Encoding.UTF7.GetString(b).Trim())
                {
                    baseAddress = readAddr;
                    return readAddr;
                }
            }
            return 0;
        }


        private int writeProcess(uint addressToWrite, byte[] buffer, ushort size)
        {
            int bytesWritten = 0;
            WriteProcessMemory((int)processHandle, addressToWrite, buffer, size, ref bytesWritten);
            return bytesWritten;
        }


        public bool writeAddress(uint LBAVer, Item item, byte[] bytes)
        {
            uint addressToWrite = (uint)item.memoryOffset;
            uint baseAddr = getBaseAddress(LBAVer);
            if (0 == baseAddr)
                return false;
            else
                addressToWrite += baseAddr;
            return (!(0 >= writeProcess(addressToWrite, bytes, item.size)));
        }

        private bool readProcess(uint addressToRead, ref byte[] data)
        {
            int bytesRead = 0;
            return ReadProcessMemory((int)processHandle, addressToRead, data, data.Length, ref bytesRead);            
        }
        public int readAddress(uint LBAVer, int offsetToRead, uint size)
        {
            uint addressToRead = 0;
            byte[] bytes = new byte[size];
            uint baseAddr = getBaseAddress(LBAVer);
            if (0 == baseAddr)
                return -1;
            else
                addressToRead = (uint)(offsetToRead + baseAddr);
            if (readProcess(addressToRead, ref bytes))
            {
                if (1 == size)
                    return bytes[0];
                return BitConverter.ToInt16(bytes, 0);
            }
            return 0;
        }

        public int getVal(uint LBAVer, Item itm)
        {
            if (null == itm) return 0;
            return readAddress(LBAVer, itm.memoryOffset, itm.size);
        }

        public bool WriteVal(uint LBAVer, Item itm, string value)
        {
            ushort val;
            if (!ushort.TryParse(value, out val)) return false;
            if (val > itm.maxVal) val = itm.maxVal;
            if (val < itm.minVal) val = itm.minVal;
            WriteVal(LBAVer, itm, val);
            return true;
        }
        public void WriteVal(uint LBAVer, Item itm, ushort val)
        {
            writeAddress(LBAVer, itm, BitConverter.GetBytes(val));
        }

        //Assigns to proc and ProcessHandle
        private void OpenProcess(int access)
        {
            Process[] p;
            p = Process.GetProcessesByName("DOSBox");
            if (1 != p.Length) return;
            proc = p[0]; ;
            processHandle = OpenProcess(PROCESS_ALL_ACCESS, false, proc.Id); ;
        }
    }
}
