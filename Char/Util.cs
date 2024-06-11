using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace UN5CharPrmEditor
{
    internal class Util
    {
        public static string ReadStringWithOffset(int basePointer)
        {
            IntPtr processHandle = Main.OpenProcess(Main.PROCESS_VM_READ, false, Main.currentProcessID);

            IntPtr baseOffset = (IntPtr)basePointer;

            List<byte> stringBytes = new List<byte>();

            while (true)
            {
                byte[] charBytes = new byte[1];
                if (Main.ReadProcessMemory(processHandle, baseOffset, charBytes, 1, out var bytesRead))
                {
                    if (charBytes[0] == 0) // Se encontrar o terminador de string '\0', termina a leitura
                        break;
                    stringBytes.Add(charBytes[0]);
                    baseOffset += 1; // Avança para o próximo byte
                }
                else
                {
                    MessageBox.Show("Error reading string.");
                    break;
                }
            }

            string decodedString = Encoding.GetEncoding("iso-8859-1").GetString(stringBytes.ToArray());
            return decodedString;
        }
        public static void VerifyCurrentPlayersIDs()
        {
            IntPtr processHandle = Main.OpenProcess(Main.PROCESS_VM_READ, false, Main.currentProcessID);
            if (processHandle != IntPtr.Zero)
            {
                int charCurrentP1CharTbl = 0x20BD8844 + Main.memoryDif;

                byte[] buffer = new byte[4];
                Main.ReadProcessMemory(processHandle, (IntPtr)charCurrentP1CharTbl, buffer, buffer.Length, out var bytesRead);
                buffer[3] = 0x20;

                int P1Offset = BitConverter.ToInt32(buffer, 0) + 0x8C;
                IntPtr NewP1Offset = (IntPtr)P1Offset;

                Main.ReadProcessMemory(processHandle, NewP1Offset, buffer, buffer.Length, out var bytesRead2);

                Main.P1ID = BitConverter.ToInt32(buffer, 0);
            }
        }
        public static byte FormarByte(int[] bits)
        {
            byte resultado = 0;
            for (int i = 0; i < 8; i++)
            {
                // Definindo o bit na posição i de acordo com o valor na posição i do array bits
                resultado |= (byte)(bits[i] << i);
            }
            return resultado;
        }
    }
}
