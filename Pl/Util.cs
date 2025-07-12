using System;
using System.Collections.Generic;
using System.Text;
using WindowsFormsApp1;

namespace UN5CharPrmEditor
{
    public static class Util
    {
        public static byte[] ReadProcessMemoryBytes(int address, int length)
        {
            byte[] buffer = new byte[length];
            IntPtr processHandle = Main.OpenProcess(Main.PROCESS_VM_READ, false, Main.currentProcessID);

            Main.ReadProcessMemory(processHandle, ToPointer(address), buffer, buffer.Length, out var none);
            return buffer;
        }
        public static int ReadProcessMemoryInt8(int address)
        {
            byte[] buffer = new byte[1];
            IntPtr processHandle = Main.OpenProcess(Main.PROCESS_ALL_ACCESS, false, Main.currentProcessID);

            Main.ReadProcessMemory(processHandle, ToPointer(address), buffer, buffer.Length, out var none);
            return buffer[0];
        }
        public static int ReadProcessMemoryInt16(int address)
        {
            byte[] buffer = new byte[2];
            IntPtr processHandle = Main.OpenProcess(Main.PROCESS_VM_READ, false, Main.currentProcessID);

            Main.ReadProcessMemory(processHandle, ToPointer(address), buffer, 2, out var none);
            return BitConverter.ToInt16(buffer, 0);
        }
        public static int ReadProcessMemoryInt32(int address)
        {
            byte[] buffer = new byte[4];
            IntPtr processHandle = Main.OpenProcess(Main.PROCESS_VM_READ, false, Main.currentProcessID);

            Main.ReadProcessMemory(processHandle, ToPointer(address), buffer, 4, out var none);
            return BitConverter.ToInt32(buffer, 0);
        }
        public static void WriteProcessMemoryInt32(int address, int value)
        {
            byte[] buffer = BitConverter.GetBytes(Convert.ToInt32(value));
            IntPtr processHandle = Main.OpenProcess(Main.PROCESS_VM_WRITE, false, Main.currentProcessID);

            Main.WriteProcessMemory(processHandle, ToPointer(address), buffer, 4, out var none);
        }
        public static void WriteProcessMemoryBytes(int address, byte[] value)
        {
            IntPtr processHandle = Main.OpenProcess(Main.PROCESS_ALL_ACCESS, false, Main.currentProcessID);

            Main.WriteProcessMemory(processHandle, ToPointer(address), value, (uint)value.Length, out var none);
        }
        public static IntPtr ToPointer(int value)
        {
            return (IntPtr)(Main.eeAddress + (ulong)value);
        }
        public static string ReadStringWithOffset(int basePointer, bool encShift)
        {
            List<byte> stringBytes = new List<byte>();

            while (true)
            {
                int currentByte = ReadProcessMemoryInt8(basePointer);
                if (currentByte == 0) break;
                stringBytes.Add((byte)currentByte);
                basePointer += 1;
            }
            string decodedString = "";
            if(encShift == true)
            {
                decodedString = Encoding.GetEncoding("shift-jis").GetString(stringBytes.ToArray());
            }
            else
            {
                decodedString = Encoding.GetEncoding("iso-8859-1").GetString(stringBytes.ToArray());
            }
            return decodedString;
        }
        public static void VerifyCurrentPlayersIDs()
        {
            IntPtr processHandle = Main.OpenProcess(Main.PROCESS_VM_READ, false, Main.currentProcessID);
            if (processHandle != IntPtr.Zero)
            {
                int charCurrentP1CharTbl = 0xBD8844 + Main.memoryDif;

                int P1Offset = ReadProcessMemoryInt32(charCurrentP1CharTbl) + 0x8C;
                Main.P1ID = ReadProcessMemoryInt32(P1Offset);
            }
        }
        public static byte FormarByte(int[] bits)
        {
            byte resultado = 0;
            for (int i = 0; i < 8; i++)
            {
                //Definindo o bit na posição i de acordo com o valor na posição i do array bits
                resultado |= (byte)(bits[i] << i);
            }
            return resultado;
        }
    }
}
