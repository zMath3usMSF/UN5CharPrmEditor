using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace UN5CharPrmEditor
{
    internal class CharAnm
    {
        public static List<List<string>> charAnmNameList = new List<List<string>>();
        public static List<List<CharAnm>> CharAnmPrm = new List<List<CharAnm>>();
        public static List<List<CharAnm>> CharAnmPrmBkp = new List<List<CharAnm>>();

        #region Anm Attributes

        public float AnmCharXDistance, AnmCharYDistance, AnmHitBoxScale, AnmHitBoxXPosition, AnmHitBoxYPosition, AnmHitBoxScale2, AnmHitBoxXPosition2, AnmHitBoxYPosition2;

        public float AnmUnk5, AnmUnk6;

        public int AnmUnk, AnmUnk1, AnmUnk4, AnmUnk7, AnmUnk8;

        public uint AnmUnk2, AnmUnk3;

        public uint AnmSpeed, AtkFlagGroup2, AtkDefenseFlag, AtkFlagGroup4, AtkPos, AtkDpadFlag, AtkButtonFlag, AtkDamageEffect;

        public short AnmID, AnmStartHitFrame, AnmEndHitFrame, AnmStartHitFrame2, AnmEndHitFrame2;

        public byte[] AnmObjAtk, AnmObjAtk2;

        #endregion

        internal static CharAnm ReadCharAnmPrm(byte[] Input) => new CharAnm
        {
            AnmID = (short)Input.ReadUInt(0x0, 16),

            AnmUnk = (short)Input.ReadUInt(0x2, 16),
            AnmUnk1 = (short)Input.ReadUInt(0x4, 16),

            AnmSpeed = Input.ReadUInt(0x6, 16),

            AnmUnk2 = Input.ReadUInt(0x8, 8),
            AnmUnk3 = Input.ReadUInt(0x9, 8),
            AnmUnk4 = (short)Input.ReadUInt(0xA, 16),

            AnmCharXDistance = Input.ReadSingle(0xC),
            AnmCharYDistance = Input.ReadSingle(0x10),

            AnmUnk5 = Input.ReadSingle(0x14),
            AnmUnk6 = Input.ReadSingle(0x18),
            AnmUnk7 = (Int32)Input.ReadUInt(0x1C, 32),

            AnmStartHitFrame = (short)Input.ReadUInt(0x20, 16),
            AnmEndHitFrame = (short)Input.ReadUInt(0x22, 16),

            AnmHitBoxScale = Input.ReadSingle(0x24),
            AnmObjAtk = Input.ReadBytes(0x28, 4),
            AnmHitBoxXPosition = Input.ReadSingle(0x2C),
            AnmHitBoxYPosition = Input.ReadSingle(0x30),

            AnmUnk8 = (Int32)Input.ReadUInt(0x34, 32),
            AnmStartHitFrame2 = (short)Input.ReadUInt(0x38, 16),
            AnmEndHitFrame2 = (short)Input.ReadUInt(0x3A, 16),
            AnmHitBoxScale2 = Input.ReadSingle(0x3C),
            AnmObjAtk2 = Input.ReadBytes(0x40, 4),
            AnmHitBoxXPosition2 = Input.ReadSingle(0x44),
            AnmHitBoxYPosition2 = Input.ReadSingle(0x48),
        };

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public Dictionary<string, byte[]> cCommonBonnesList = new Dictionary<string, byte[]>()
        {
        {"OBJ_2cmn00t0 l foot", new byte[]{ 0x20, 0xC3, 0x41, 0x00 }},
        {"OBJ_2cmn00t0 l clavicle", new byte[]{ 0x60, 0xC3, 0x41, 0x00 }},
        {"OBJ_2cmn00t0 r finger0", new byte[]{ 0x80, 0xC3, 0x41, 0x00 }},
        {"OBJ_2cmn00t0 pelvis", new byte[]{ 0xA0, 0xC3, 0x41, 0x00 }},
        {"OBJ_2cmn00t0 spine", new byte[]{ 0xC0, 0xC3, 0x41, 0x00 }},
        {"OBJ_2cmn00t0 l finger0", new byte[]{ 0x80, 0xC4, 0x41, 0x00 }},
        {"OBJ_2cmn00t0 r foot", new byte[]{ 0xA0, 0xC4, 0x41, 0x00 }},
        {"OBJ_2cmn00t0 l calf", new byte[]{ 0x00, 0xC5, 0x41, 0x00 }},
        {"OBJ_2cmn00t0 r clavicle", new byte[]{ 0xC0, 0x6F, 0x42, 0x00 }},
        {"OBJ_2cmn00t0 r calf", new byte[]{ 0xE0, 0x6F, 0x42, 0x00 }},
        {"OBJ_2cmn00t0 head", new byte[]{ 0x20, 0xB9, 0x42, 0x00 }},
        {"OBJ_2cmn00t0 body", new byte[]{ 0x40, 0xB9, 0x42, 0x00 }},
        {"OBJ_2cmn00t0 r hand", new byte[]{ 0x90, 0x90, 0x46, 0x00 }},
        {"OBJ_2cmn00t0 l hand", new byte[]{ 0xB0, 0x90, 0x46, 0x00 }},
        {"OBJ_2cmn00t0 l thigh", new byte[]{ 0xA0, 0xF6, 0x46, 0x00 }},
        {"OBJ_2cmn00t0 neck", new byte[]{ 0x40, 0x88, 0x49, 0x00 }},
        {"OBJ_2cmn00t0 r thigh", new byte[]{ 0x60, 0x88, 0x49, 0x00 }},
        {"OBJ_2cmn00t0 tail2", new byte[]{ 0x80, 0x1B, 0x4B, 0x00 }},
        {"OBJ_2cmn00t0 tail", new byte[]{ 0x80, 0x26, 0x4C, 0x00 }},
        {"OBJ_2cmn00t0 r upperarm", new byte[]{ 0xC0, 0x26, 0x4C, 0x00 }},
        {"OBJ_2cmn00t0 tail1", new byte[]{ 0xE0, 0x26, 0x4C, 0x00 }},
        {"OBJ_2cmn00t0 spine1", new byte[]{ 0x70, 0xB9, 0x4C, 0x00 }},
        {"OBJ_2cmn00t0 l forearm", new byte[]{ 0x40, 0xC3, 0x41, 0x00 }}
        };

        public Dictionary<string, byte[]> CommonBonnesList = new Dictionary<string, byte[]>()
        {
        {"OBJ_2cmn00t0 pelvis", new byte[]{ 0xA0, 0xC3, 0x41, 0x00 }},
        {"OBJ_2cmn00t0 spine", new byte[]{ 0xC0, 0xC3, 0x41, 0x00 }},
        {"OBJ_2cmn00t0 l thigh", new byte[]{ 0xA0, 0xF6, 0x46, 0x00 }},
        {"OBJ_2cmn00t0 l calf", new byte[]{ 0x00, 0xC5, 0x41, 0x00 }},
        {"OBJ_2cmn00t0 l foot", new byte[]{ 0x20, 0xC3, 0x41, 0x00 }},
        {"OBJ_2cmn00t0 r thigh", new byte[]{ 0x60, 0x88, 0x49, 0x00 }},
        {"OBJ_2cmn00t0 r calf", new byte[]{ 0xE0, 0x6F, 0x42, 0x00 }},
        {"OBJ_2cmn00t0 r foot", new byte[]{ 0xA0, 0xC4, 0x41, 0x00 }},
        {"OBJ_2cmn00t0 spine1", new byte[]{ 0x70, 0xB9, 0x4C, 0x00 }},
        {"OBJ_2cmn00t0 neck", new byte[]{ 0x40, 0x88, 0x49, 0x00 }},
        {"OBJ_2cmn00t0 head", new byte[]{ 0x20, 0xB9, 0x42, 0x00 }},
        {"OBJ_2cmn00t0 l clavicle", new byte[]{ 0x60, 0xC3, 0x41, 0x00 }},
        {"OBJ_2cmn00t0 l forearm", new byte[]{ 0x40, 0xC3, 0x41, 0x00 }},
        {"OBJ_2cmn00t0 l hand", new byte[]{ 0xB0, 0x90, 0x46, 0x00 }},
        {"OBJ_2cmn00t0 l finger0", new byte[]{ 0x80, 0xC4, 0x41, 0x00 }},
        {"OBJ_2cmn00t0 r clavicle", new byte[]{ 0xC0, 0x6F, 0x42, 0x00 }},
        {"OBJ_2cmn00t0 r upperarm", new byte[]{ 0xC0, 0x26, 0x4C, 0x00 }},
        {"OBJ_2cmn00t0 r hand", new byte[]{ 0x90, 0x90, 0x46, 0x00 }},
        {"OBJ_2cmn00t0 r finger0", new byte[]{ 0x80, 0xC3, 0x41, 0x00 }},
        {"OBJ_2cmn00t0 tail", new byte[]{ 0x80, 0x26, 0x4C, 0x00 }},
        {"OBJ_2cmn00t0 tail1", new byte[]{ 0xE0, 0x26, 0x4C, 0x00 }},
        {"OBJ_2cmn00t0 tail2", new byte[]{ 0x80, 0x1B, 0x4B, 0x00 }},
        {"OBJ_2cmn00t0 body", new byte[]{ 0x40, 0xB9, 0x42, 0x00 }},
        };

        public static CharAnm GetCharAnm(int currentCharID, int selectedIndex)
        {
            int anmCount = CharGen.CharGenPrm[currentCharID].AnmCount;

            while (CharAnmPrm.Count <= 93)
            {
                CharAnmPrm.Add(new List<CharAnm>());
                CharAnmPrmBkp.Add(new List<CharAnm>());
            }
            if (CharAnmPrm[currentCharID].Count == 0)
            {
                IntPtr processHandle = Main.OpenProcess(Main.PROCESS_VM_READ, false, Main.currentProcessID);

                byte[] anmListOffsetBytes = CharGen.CharGenPrm[currentCharID].AnmListOffset;
                anmListOffsetBytes[3] = 0x20;
                int anmListPointer = BitConverter.ToInt32(anmListOffsetBytes, 0);

                List<CharAnm> ninjaCharsAnm = new List<CharAnm>();
                List<CharAnm> ninjaCharsAnmBkp = new List<CharAnm>();

                for (int i = 0; i != anmCount; i++)
                {
                    byte[] currentAnmBlock = new byte[0x4C];
                    int skipsAnmBlocks = i * 0x4C;
                    int currentAnmListPointer = anmListPointer + skipsAnmBlocks;

                    IntPtr currentAnmListOffset = (IntPtr)currentAnmListPointer;

                    if (Main.ReadProcessMemory(processHandle, currentAnmListOffset, currentAnmBlock, currentAnmBlock.Length, out var bytesRead))
                    {
                        var ninja = CharAnm.ReadCharAnmPrm(currentAnmBlock);
                        var clone = (CharAnm)ninja.Clone();
                        ninjaCharsAnm.Add(ninja);
                        ninjaCharsAnmBkp.Add(clone);
                    }
                }
                CharAnmPrm[currentCharID] = ninjaCharsAnm;
                CharAnmPrmBkp[currentCharID] = ninjaCharsAnmBkp;
            }

            return CharAnmPrm[currentCharID][selectedIndex];
        }

        public static string GetCharAnmName(int CharIndex, int AnmIndex)
        {
            while (charAnmNameList.Count <= 93)
            {
                charAnmNameList.Add(new List<string>());
            }
            if (charAnmNameList[CharIndex].Count == 0)
            {
                IntPtr processHandle = Main.OpenProcess(Main.PROCESS_VM_READ, false, Main.currentProcessID);

                int anmNameCount = CharGen.CharGenPrm[CharIndex].AnmNameCount;

                byte[] anmNameAreaPointerBytes = CharGen.CharGenPrm[CharIndex].AnmNameListOffset;
                anmNameAreaPointerBytes[3] = 0x20;
                int anmNameAreaPointer = BitConverter.ToInt32(anmNameAreaPointerBytes, 0);

                IntPtr anmNameAreaOffset = (IntPtr)anmNameAreaPointer;

                byte[] anmNameAreaBuffer = new byte[anmNameCount * 0x4];
                Main.ReadProcessMemory(processHandle, anmNameAreaOffset, anmNameAreaBuffer, anmNameAreaBuffer.Length, out var none2);

                List<string> anmNameList = new List<string>();

                for (int i = 0; i < anmNameCount; i++)
                {
                    byte[] anmNamePointerBytes = new byte[4];
                    Array.Copy(anmNameAreaBuffer, i * 0x4, anmNamePointerBytes, 0, 4);

                    anmNamePointerBytes[3] = 0x20;
                    int anmNamePointer = BitConverter.ToInt32(anmNamePointerBytes, 0);

                    string docodedAnmName = Util.ReadStringWithOffset(anmNamePointer);

                    anmNameList.Add(docodedAnmName);
                }

                charAnmNameList[CharIndex] = anmNameList;
            }

            return charAnmNameList[CharIndex][AnmIndex];
        }

        public static void UpdateP1Anm(byte[] resultBytes, int selectedAnm)
        {
            IntPtr processHandle = Main.OpenProcess(Main.PROCESS_ALL_ACCESS, false, Main.currentProcessID);
            if (processHandle != IntPtr.Zero)
            {
                int charCurrentP1CharTbl = Main.isUN6 == true ? 0x20C5FB44 : 0x208ED410;

                byte[] buffer = new byte[4];
                Main.ReadProcessMemory(processHandle, (IntPtr)charCurrentP1CharTbl, buffer, buffer.Length, out var none);
                buffer[3] = 0x20;

                int P1Offset = BitConverter.ToInt32(buffer, 0) + 204;

                IntPtr NewP1Offset = (IntPtr)P1Offset;

                Main.ReadProcessMemory(processHandle, NewP1Offset, buffer, buffer.Length, out var none1);

                buffer[3] = 0x20;

                int skipAnms = selectedAnm * 0x4C;

                int P1AnmPointer = BitConverter.ToInt32(buffer, 0) + skipAnms;

                IntPtr P1AnmOffset = (IntPtr)P1AnmPointer;

                Main.WriteProcessMemory(processHandle, P1AnmOffset, resultBytes, (uint)resultBytes.Length, out var none2);

                Main.CloseHandle(processHandle);
            }
        }

        public static void SendTextAnm(MovesetParameters movForm, CharAnm charAnm)
        {
            int currentCharID = int.Parse(movForm.lblCharID2.Text);

            movForm.cmbPlayAnmID.Items.AddRange(movForm.cmbPlayAnmID.Items.Count == 0 ? charAnmNameList[currentCharID].ToArray() : new object[0]);
            movForm.cmbPlayAnmID.SelectedIndex = charAnm.AnmID;
            movForm.numAnmUnk1.Value = charAnm.AnmUnk1;
            float anmSpeed = Convert.ToSingle(charAnm.AnmSpeed) / 256;
            movForm.txtAnmSpeed.Text = Convert.ToString(anmSpeed);
            movForm.numAnmUnk2.Value = charAnm.AnmUnk2;
            movForm.numAnmUnk3.Value = charAnm.AnmUnk3;
            movForm.numAnmUnk4.Value = charAnm.AnmUnk4;
            movForm.txtCharXDistance.Text = Convert.ToString(charAnm.AnmCharXDistance);
            movForm.txtCharYDistance.Text = Convert.ToString(charAnm.AnmCharYDistance);
            movForm.txtAnmUnk5.Text = Convert.ToString(charAnm.AnmUnk5);
            movForm.txtAnmUnk6.Text = Convert.ToString(charAnm.AnmUnk6);

            movForm.numAnmUnk7.Value = charAnm.AnmUnk7;
            movForm.numAnmStartHitFrame.Value = charAnm.AnmStartHitFrame;
            movForm.numAnmEndHitFrame.Value = charAnm.AnmEndHitFrame;
            movForm.txtHitBoxScale.Text = Convert.ToString(charAnm.AnmHitBoxScale);
            byte[] anmObjectAtk = new byte[4];
            Array.Copy(charAnm.AnmObjAtk, 0x0, anmObjectAtk, 0, 4);
            anmObjectAtk[3] = 0x20;
            int anmObjectAtkPointer = BitConverter.ToInt32(anmObjectAtk, 0);
            string anmObjectAtkString = Util.ReadStringWithOffset(anmObjectAtkPointer);
            var commonBonnesList = charAnm.CommonBonnesList;
            movForm.cmbAnmObjectAtk.Items.Clear();
            if (commonBonnesList.ContainsKey(anmObjectAtkString))
            {
                movForm.cmbAnmObjectAtk.Items.AddRange(commonBonnesList.Keys.ToArray());
                for (int i = 0; i < movForm.cmbAnmObjectAtk.Items.Count; i++)
                {
                    if (movForm.cmbAnmObjectAtk.Items[i].ToString() == anmObjectAtkString)
                    {
                        movForm.cmbAnmObjectAtk.SelectedIndex = i;
                        break;
                    }
                }
            }
            else
            {
                movForm.cmbAnmObjectAtk.Items.AddRange(commonBonnesList.Keys.ToArray());
                movForm.cmbAnmObjectAtk.Items.Add(anmObjectAtkString == "" ? "(None)" : anmObjectAtkString);
                movForm.cmbAnmObjectAtk.SelectedIndex = movForm.cmbAnmObjectAtk.Items.Count - 1;
            }
            movForm.txtHitBoxXPos.Text = Convert.ToString(charAnm.AnmHitBoxXPosition);
            movForm.txtHitBoxYPos.Text = Convert.ToString(charAnm.AnmHitBoxYPosition);

            movForm.numAnmUnk8.Value = charAnm.AnmUnk8;
            movForm.numAnmStartHitFrame2.Value = charAnm.AnmStartHitFrame2;
            movForm.numAnmEndHitFrame2.Value = charAnm.AnmEndHitFrame2;
            movForm.txtAnmHitBoxScale2.Text = Convert.ToString(charAnm.AnmHitBoxScale2);
            byte[] anmObjectAtk2 = new byte[4];
            Array.Copy(charAnm.AnmObjAtk2, 0x0, anmObjectAtk2, 0, 4);
            anmObjectAtk2[3] = 0x20;
            int anmObjectAtkPointer2 = BitConverter.ToInt32(anmObjectAtk2, 0);
            string anmObjectAtkString2 = Util.ReadStringWithOffset(anmObjectAtkPointer2);
            movForm.txtAnmHitBoxXPos2.Text = Convert.ToString(charAnm.AnmHitBoxXPosition2);
            movForm.txtAnmHitBoxYPos2.Text = Convert.ToString(charAnm.AnmHitBoxYPosition2);

            movForm.cmbAnmObjectAtk2.Items.Clear();
            if (commonBonnesList.ContainsKey(anmObjectAtkString2))
            {
                movForm.cmbAnmObjectAtk2.Items.AddRange(commonBonnesList.Keys.ToArray());
                for (int i = 0; i < movForm.cmbAnmObjectAtk2.Items.Count; i++)
                {
                    if (movForm.cmbAnmObjectAtk2.Items[i].ToString() == anmObjectAtkString2)
                    {
                        movForm.cmbAnmObjectAtk2.SelectedIndex = i;
                        break;
                    }
                }
            }
            else
            {
                movForm.cmbAnmObjectAtk2.Items.AddRange(commonBonnesList.Keys.ToArray());
                movForm.cmbAnmObjectAtk2.Items.Add(anmObjectAtkString2 == "" ? "(None)" : anmObjectAtkString2);
                movForm.cmbAnmObjectAtk2.SelectedIndex = movForm.cmbAnmObjectAtk2.Items.Count - 1;
            }
        }

        public static byte[] UpdateCharAnmPrm(MovesetParameters movForm, int charID)
        {
            int anmBlockID = int.Parse(movForm.listBox1.SelectedItem.ToString().Split(':')[0]);

            var ninjaCharsAnm = CharAnmPrm[charID][anmBlockID];

            List<byte> anmBlockBytes = new List<byte>();

            int anmID = movForm.cmbPlayAnmID.SelectedIndex;
            anmBlockBytes.AddRange(BitConverter.GetBytes(Convert.ToInt16(anmID)));
            ninjaCharsAnm.AnmID = Convert.ToInt16(anmID);
            anmBlockBytes.AddRange(BitConverter.GetBytes(Convert.ToInt16(ninjaCharsAnm.AnmUnk)));
            anmBlockBytes.AddRange(BitConverter.GetBytes(Convert.ToInt16((short)movForm.numAnmUnk1.Value)));
            ninjaCharsAnm.AnmUnk1 = (short)movForm.numAnmUnk1.Value;
            float anmSpeed = Convert.ToSingle(movForm.txtAnmSpeed.Text.Replace(",", ".")) * 256;
            anmBlockBytes.AddRange(BitConverter.GetBytes(Convert.ToUInt16((ushort)anmSpeed)));
            ninjaCharsAnm.AnmSpeed = Convert.ToUInt16((ushort)anmSpeed);
            anmBlockBytes.Add((byte)movForm.numAnmUnk2.Value);
            ninjaCharsAnm.AnmUnk2 = (byte)movForm.numAnmUnk2.Value;
            anmBlockBytes.Add((byte)movForm.numAnmUnk3.Value);
            ninjaCharsAnm.AnmUnk3 = (byte)movForm.numAnmUnk3.Value;
            anmBlockBytes.AddRange(BitConverter.GetBytes(Convert.ToInt16((short)movForm.numAnmUnk4.Value)));
            ninjaCharsAnm.AnmUnk4 = (short)movForm.numAnmUnk4.Value;
            anmBlockBytes.AddRange(BitConverter.GetBytes(Convert.ToSingle(movForm.txtCharXDistance.Text)));
            ninjaCharsAnm.AnmCharXDistance = Convert.ToSingle(movForm.txtCharXDistance.Text);
            anmBlockBytes.AddRange(BitConverter.GetBytes(Convert.ToSingle(movForm.txtCharYDistance.Text)));
            ninjaCharsAnm.AnmCharYDistance = Convert.ToSingle(movForm.txtCharYDistance.Text);
            anmBlockBytes.AddRange(BitConverter.GetBytes(Convert.ToSingle(movForm.txtAnmUnk5.Text)));
            ninjaCharsAnm.AnmUnk5 = Convert.ToSingle(movForm.txtAnmUnk5.Text);
            anmBlockBytes.AddRange(BitConverter.GetBytes(Convert.ToSingle(movForm.txtAnmUnk6.Text)));
            ninjaCharsAnm.AnmUnk6 = Convert.ToSingle(movForm.txtAnmUnk6.Text);
            anmBlockBytes.AddRange(BitConverter.GetBytes(Convert.ToInt32(movForm.numAnmUnk7.Value)));
            ninjaCharsAnm.AnmUnk7 = Convert.ToInt32(movForm.numAnmUnk7.Value);
            anmBlockBytes.AddRange(BitConverter.GetBytes(Convert.ToInt16(movForm.numAnmStartHitFrame.Value)));
            ninjaCharsAnm.AnmStartHitFrame = Convert.ToInt16(movForm.numAnmStartHitFrame.Value);
            anmBlockBytes.AddRange(BitConverter.GetBytes(Convert.ToInt16(movForm.numAnmEndHitFrame.Value)));
            ninjaCharsAnm.AnmEndHitFrame = Convert.ToInt16(movForm.numAnmEndHitFrame.Value);
            anmBlockBytes.AddRange(BitConverter.GetBytes(Convert.ToSingle(movForm.txtHitBoxScale.Text)));
            ninjaCharsAnm.AnmHitBoxScale = Convert.ToSingle(movForm.txtHitBoxScale.Text);
            int selectedIndexcmbAnmObjectAtk = movForm.cmbAnmObjectAtk.SelectedIndex;
            if (ninjaCharsAnm.CommonBonnesList.TryGetValue(movForm.cmbAnmObjectAtk.Items[selectedIndexcmbAnmObjectAtk].ToString(), out byte[] anmObjAtkPointerBytes))
            {
                anmBlockBytes.AddRange(anmObjAtkPointerBytes);
                ninjaCharsAnm.AnmObjAtk = anmObjAtkPointerBytes;
            }
            else
            {
                anmBlockBytes.AddRange(ninjaCharsAnm.AnmObjAtk);
            }
            anmBlockBytes.AddRange(BitConverter.GetBytes(Convert.ToSingle(movForm.txtHitBoxXPos.Text)));
            ninjaCharsAnm.AnmHitBoxXPosition = Convert.ToSingle(movForm.txtHitBoxXPos.Text);
            anmBlockBytes.AddRange(BitConverter.GetBytes(Convert.ToSingle(movForm.txtHitBoxYPos.Text)));
            ninjaCharsAnm.AnmHitBoxYPosition = Convert.ToSingle(movForm.txtHitBoxYPos.Text);
            anmBlockBytes.AddRange(BitConverter.GetBytes(Convert.ToInt32(movForm.numAnmUnk8.Value)));
            ninjaCharsAnm.AnmUnk8 = Convert.ToInt32(movForm.numAnmUnk8.Value);
            anmBlockBytes.AddRange(BitConverter.GetBytes(Convert.ToInt16(movForm.numAnmStartHitFrame2.Value)));
            ninjaCharsAnm.AnmStartHitFrame2 = Convert.ToInt16(movForm.numAnmStartHitFrame2.Value);
            anmBlockBytes.AddRange(BitConverter.GetBytes(Convert.ToInt16(movForm.numAnmEndHitFrame2.Value)));
            ninjaCharsAnm.AnmEndHitFrame2 = Convert.ToInt16(movForm.numAnmEndHitFrame2.Value);
            anmBlockBytes.AddRange(BitConverter.GetBytes(Convert.ToSingle(movForm.txtAnmHitBoxScale2.Text)));
            ninjaCharsAnm.AnmHitBoxScale2 = Convert.ToSingle(movForm.txtAnmHitBoxScale2.Text);
            int selectedIndexCmbAnmObjectAtk2 = movForm.cmbAnmObjectAtk2.SelectedIndex;
            if (ninjaCharsAnm.CommonBonnesList.TryGetValue(movForm.cmbAnmObjectAtk2.Items[selectedIndexCmbAnmObjectAtk2].ToString(), out byte[] anmObjAtkPointerBytes2))
            {
                anmBlockBytes.AddRange(anmObjAtkPointerBytes2);
                ninjaCharsAnm.AnmObjAtk2 = anmObjAtkPointerBytes2;
            }
            else
            {
                anmBlockBytes.AddRange(ninjaCharsAnm.AnmObjAtk2);
            }
            anmBlockBytes.AddRange(BitConverter.GetBytes(Convert.ToSingle(movForm.txtAnmHitBoxXPos2.Text)));
            ninjaCharsAnm.AnmHitBoxXPosition2 = Convert.ToSingle(movForm.txtAnmHitBoxXPos2.Text);
            anmBlockBytes.AddRange(BitConverter.GetBytes(Convert.ToSingle(movForm.txtAnmHitBoxYPos2.Text)));
            ninjaCharsAnm.AnmHitBoxYPosition2 = Convert.ToSingle(movForm.txtAnmHitBoxYPos2.Text);

            byte[] resultBytes = anmBlockBytes.ToArray();
            return resultBytes;
        }

        public static byte[] UpdateAllCharAnmPrm(MovesetParameters movForm, int charID)
        {
            List<byte> anmBlockBytes = new List<byte>();

            for(int i = 0; i < CharGen.CharGenPrm[charID].AnmCount; i++)
            {
                var ninjaCharsAnm = CharAnmPrm[charID][i];

                anmBlockBytes.AddRange(BitConverter.GetBytes(Convert.ToInt16(ninjaCharsAnm.AnmID)));
                anmBlockBytes.AddRange(BitConverter.GetBytes(Convert.ToInt16(ninjaCharsAnm.AnmUnk)));
                anmBlockBytes.AddRange(BitConverter.GetBytes(Convert.ToInt16((short)ninjaCharsAnm.AnmUnk1)));
                anmBlockBytes.AddRange(BitConverter.GetBytes(Convert.ToUInt16((ushort)ninjaCharsAnm.AnmSpeed)));
                anmBlockBytes.Add((byte)ninjaCharsAnm.AnmUnk2);
                anmBlockBytes.Add((byte)ninjaCharsAnm.AnmUnk3);
                anmBlockBytes.AddRange(BitConverter.GetBytes(Convert.ToInt16((short)ninjaCharsAnm.AnmUnk4)));
                anmBlockBytes.AddRange(BitConverter.GetBytes(Convert.ToSingle(ninjaCharsAnm.AnmCharXDistance)));
                anmBlockBytes.AddRange(BitConverter.GetBytes(Convert.ToSingle(ninjaCharsAnm.AnmCharYDistance)));
                anmBlockBytes.AddRange(BitConverter.GetBytes(Convert.ToSingle(ninjaCharsAnm.AnmUnk5)));
                anmBlockBytes.AddRange(BitConverter.GetBytes(Convert.ToSingle(ninjaCharsAnm.AnmUnk6)));
                anmBlockBytes.AddRange(BitConverter.GetBytes(Convert.ToInt32(ninjaCharsAnm.AnmUnk7)));
                anmBlockBytes.AddRange(BitConverter.GetBytes(Convert.ToInt16(ninjaCharsAnm.AnmStartHitFrame)));
                anmBlockBytes.AddRange(BitConverter.GetBytes(Convert.ToInt16(ninjaCharsAnm.AnmEndHitFrame)));
                anmBlockBytes.AddRange(BitConverter.GetBytes(Convert.ToSingle(ninjaCharsAnm.AnmHitBoxScale)));
                anmBlockBytes.AddRange(ninjaCharsAnm.AnmObjAtk);
                anmBlockBytes.AddRange(BitConverter.GetBytes(Convert.ToSingle(ninjaCharsAnm.AnmHitBoxXPosition)));
                anmBlockBytes.AddRange(BitConverter.GetBytes(Convert.ToSingle(ninjaCharsAnm.AnmHitBoxYPosition)));
                anmBlockBytes.AddRange(BitConverter.GetBytes(Convert.ToInt32(ninjaCharsAnm.AnmUnk8)));
                anmBlockBytes.AddRange(BitConverter.GetBytes(Convert.ToInt16(ninjaCharsAnm.AnmStartHitFrame2)));
                anmBlockBytes.AddRange(BitConverter.GetBytes(Convert.ToInt16(ninjaCharsAnm.AnmEndHitFrame2)));
                anmBlockBytes.AddRange(BitConverter.GetBytes(Convert.ToSingle(ninjaCharsAnm.AnmHitBoxScale2)));
                anmBlockBytes.AddRange(ninjaCharsAnm.AnmObjAtk2);
                anmBlockBytes.AddRange(BitConverter.GetBytes(Convert.ToSingle(ninjaCharsAnm.AnmHitBoxXPosition2)));
                anmBlockBytes.AddRange(BitConverter.GetBytes(Convert.ToSingle(ninjaCharsAnm.AnmHitBoxYPosition2)));
            }
            byte[] resultBytes = anmBlockBytes.ToArray();
            return resultBytes;
        }
        public static void WriteELFCharAnm(byte[] resultBytes, int charID)
        {
            if (!File.Exists(Main.caminhoELF))
            {
                MessageBox.Show("Unable to save, check if the file has been deleted or moved.", string.Empty, MessageBoxButtons.OK);
            }
            else
            {
                using (FileStream fs = new FileStream(Main.caminhoELF, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    byte[] charAnmAreaOffsetBytes = CharGen.CharGenPrm[charID].AnmListOffset;
                    charAnmAreaOffsetBytes[3] = 0x0;
                    int charAnmAreaOffset = BitConverter.ToInt32(charAnmAreaOffsetBytes, 0) - 0xFFE80;

                    fs.Seek(charAnmAreaOffset, SeekOrigin.Begin);

                    fs.Write(resultBytes, 0, resultBytes.Length);

                    MessageBox.Show("The changes were saved successfully!", string.Empty, MessageBoxButtons.OK);
                }
            }
        }
    }
}
