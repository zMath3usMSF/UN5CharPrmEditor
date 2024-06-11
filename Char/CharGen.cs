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
    public class CharGen
    {
        public static List<CharGen> CharGenPrm = new List<CharGen>();
        public static List<CharGen> CharGenPrmBkp = new List<CharGen>();
        #region GeneralParameters

        public float Width, Height;

        public float Speed, Slide,
            Weight, Gravity, SpeedAir,
            FirstJumpHeight, SecondJumpHeight,
            DashSpeed, DashDistance,
            BackDashHeight, BackDashWeight, BackDashDistance,
            BackDashHeight2,
            Strength, Defense, DamageKnockback, AttackKnockback,
            StatusDuration, QuantityProjectiles, HealingMultiplier,
            ChakraSpeed;

        public int ID, cUnk1, cUnk2, AtkCount, AnmCount, AnmNameCount,
            FirstJumpDelay, DashDelay, DashDuration;

        public byte[] NameOffset, CCSOffset, CLTOffset, TEXOffset, MDLOffset,
                      HolOBJOffset, PrgOffset, AtkListOffset, AnmListOffset, AnmNameListOffset;

        public byte[] Unk, Unk1, Unk2, Unk3, Unk4, Unk5, Unk6;

        #endregion
        internal static CharGen ReadCharGenPrm(byte[] Input) => new CharGen
        {
            ID = (int)Input.ReadUInt(0x0, 32),
            NameOffset = Input.ReadBytes(0x4, 4),
            CCSOffset = Input.ReadBytes(0x8, 4),
            CLTOffset = Input.ReadBytes(0xC, 4),
            TEXOffset = Input.ReadBytes(0x10, 4),
            MDLOffset = Input.ReadBytes(0x14, 4),
            HolOBJOffset = Input.ReadBytes(0x18, 4),
            PrgOffset = Input.ReadBytes(0x1C, 4),
            cUnk1 = (int)Input.ReadUInt(0x20, 32),
            cUnk2 = (int)Input.ReadUInt(0x24, 32),
            AtkCount = (int)Input.ReadUInt(0x28, 32),
            AtkListOffset = Input.ReadBytes(0x2C, 4),
            AnmCount = (int)Input.ReadUInt(0x38, 32),
            AnmListOffset = Input.ReadBytes(0x3C, 4),
            AnmNameCount = (int)Input.ReadUInt(0x44, 32),
            AnmNameListOffset = Input.ReadBytes(0x48, 4),

            Height = Input.ReadSingle(0x58),
            Width = Input.ReadSingle(0x5c),
            Speed = Input.ReadSingle(0x60),
            Unk = Input.ReadBytes(0x64, 4),
            Slide = Input.ReadSingle(0x68),
            Weight = Input.ReadSingle(0x6c),
            Gravity = Input.ReadSingle(0x70),
            SpeedAir = Input.ReadSingle(0x74),
            Unk1 = Input.ReadBytes(0x78, 4),
            Unk2 = Input.ReadBytes(0x7c, 4),
            FirstJumpDelay = (int)Input.ReadUInt(0x80, 32),
            FirstJumpHeight = Input.ReadSingle(0x84),
            SecondJumpHeight = Input.ReadSingle(0x88),
            DashDelay = (int)Input.ReadUInt(0x8c, 32),
            DashDuration = (int)Input.ReadUInt(0x90, 32),
            DashSpeed = Input.ReadSingle(0x94),
            DashDistance = Input.ReadSingle(0x98),
            BackDashHeight = Input.ReadSingle(0x9c),
            BackDashWeight = Input.ReadSingle(0xa0),
            BackDashDistance = Input.ReadSingle(0xa4),
            BackDashHeight2 = Input.ReadSingle(0xa8),

            Unk3 = Input.ReadBytes(0xac, 4),
            Unk4 = Input.ReadBytes(0xb0, 4),
            Unk5 = Input.ReadBytes(0xb4, 4),
            Unk6 = Input.ReadBytes(0xb8, 4),

            Strength = Input.ReadSingle(0xbc),
            Defense = Input.ReadSingle(0xc0),
            DamageKnockback = Input.ReadSingle(0xc4),
            AttackKnockback = Input.ReadSingle(0xc8),
            StatusDuration = Input.ReadSingle(0xcc),
            QuantityProjectiles = Input.ReadSingle(0xd0),
            HealingMultiplier = Input.ReadSingle(0xd4),
            ChakraSpeed = Input.ReadSingle(0xd8)
        };
        public object Clone()
        {
            return this.MemberwiseClone();
        }
        public static void UpdateP1GenPrm(byte[] resultBytes)
        {
            IntPtr processHandle = Main.OpenProcess(Main.PROCESS_ALL_ACCESS, false, Main.currentProcessID);
            if (processHandle != IntPtr.Zero)
            {
                int charCurrentP1CharTbl = Main.isUN6 == true ? 0x20C5FB44 : 0x208ED410;

                byte[] buffer = new byte[4];

                Main.ReadProcessMemory(processHandle, (IntPtr)charCurrentP1CharTbl, buffer, buffer.Length, out var none);
                buffer[3] = 0x20;

                int P1Offset = BitConverter.ToInt32(buffer, 0) + 140;

                IntPtr NewP1Offset = (IntPtr)P1Offset;

                IntPtr NewOffsetPlus58 = IntPtr.Add(NewP1Offset, 0x58);

                Main.WriteProcessMemory(processHandle, NewOffsetPlus58, resultBytes, (uint)resultBytes.Length, out var none1);

                Main.CloseHandle(processHandle);
            }
        }
        public static void WriteELFCharPrm(byte[] resultBytes, int charID)
        {
            if (!File.Exists(Main.caminhoELF))
            {
                MessageBox.Show("Unable to save, check if the file has been deleted or moved.", string.Empty, MessageBoxButtons.OK);
            }
            else
            {
                using (FileStream fs = new FileStream(Main.caminhoELF, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    int skipChars = charID * 0x8 + 0x4;
                    fs.Seek(0x317E80 + skipChars, SeekOrigin.Begin);

                    byte[] charMainPointer = new byte[4];
                    fs.Read(charMainPointer, 0, charMainPointer.Length);
                    int charMainOffset = BitConverter.ToInt32(charMainPointer, 0);
                    charMainOffset = charMainOffset - 0xFFE80 + 0x58;

                    fs.Seek(charMainOffset, SeekOrigin.Begin);
                    fs.Write(resultBytes, 0, resultBytes.Length);

                    MessageBox.Show("The changes were saved successfully!", string.Empty, MessageBoxButtons.OK);
                }
            }
        }
        public static byte[] UpdateCharGenPrm(GeneralParameters genForm, int charID)
        {
            List<byte> resultBytesList = new List<byte>();

            resultBytesList.AddRange(BitConverter.GetBytes(Convert.ToSingle(genForm.txtCharHeight.Text)));
            CharGenPrm[charID].Height = Convert.ToSingle(genForm.txtCharHeight.Text);
            resultBytesList.AddRange(BitConverter.GetBytes(Convert.ToSingle(genForm.txtCharWidth.Text)));
            CharGenPrm[charID].Width = Convert.ToSingle(genForm.txtCharWidth.Text);
            resultBytesList.AddRange(BitConverter.GetBytes(Convert.ToSingle(genForm.txtCharSpeed.Text)));
            CharGenPrm[charID].Speed = Convert.ToSingle(genForm.txtCharSpeed.Text);
            resultBytesList.AddRange(CharGen.CharGenPrm[charID].Unk);
            resultBytesList.AddRange(BitConverter.GetBytes(Convert.ToSingle(genForm.txtCharSlide.Text)));
            CharGenPrm[charID].Slide = Convert.ToSingle(genForm.txtCharSlide.Text);
            resultBytesList.AddRange(BitConverter.GetBytes(Convert.ToSingle(genForm.txtCharWeight.Text)));
            CharGenPrm[charID].Weight = Convert.ToSingle(genForm.txtCharWeight.Text);
            resultBytesList.AddRange(BitConverter.GetBytes(Convert.ToSingle(genForm.txtCharGravity.Text)));
            CharGenPrm[charID].Gravity = Convert.ToSingle(genForm.txtCharGravity.Text);
            resultBytesList.AddRange(BitConverter.GetBytes(Convert.ToSingle(genForm.txtCharSpeedAir.Text)));
            CharGenPrm[charID].SpeedAir = Convert.ToSingle(genForm.txtCharSpeedAir.Text);
            resultBytesList.AddRange(CharGen.CharGenPrm[charID].Unk1);
            resultBytesList.AddRange(CharGen.CharGenPrm[charID].Unk2);
            resultBytesList.AddRange(BitConverter.GetBytes(Convert.ToInt32(genForm.txtCharFirstJumpDelay.Text)));
            CharGenPrm[charID].FirstJumpDelay = Convert.ToInt32(genForm.txtCharFirstJumpDelay.Text);
            resultBytesList.AddRange(BitConverter.GetBytes(Convert.ToSingle(genForm.txtCharFirstJumpHeight.Text)));
            CharGenPrm[charID].FirstJumpHeight = Convert.ToSingle(genForm.txtCharFirstJumpHeight.Text);
            resultBytesList.AddRange(BitConverter.GetBytes(Convert.ToSingle(genForm.txtCharSecondJumpHeight.Text)));
            CharGenPrm[charID].SecondJumpHeight = Convert.ToSingle(genForm.txtCharSecondJumpHeight.Text);
            resultBytesList.AddRange(BitConverter.GetBytes(Convert.ToInt32(genForm.txtCharDashDelay.Text)));
            CharGenPrm[charID].DashDelay = Convert.ToInt32(genForm.txtCharDashDelay.Text);
            resultBytesList.AddRange(BitConverter.GetBytes(Convert.ToInt32(genForm.txtCharDashDuration.Text)));
            CharGenPrm[charID].DashDuration = Convert.ToInt32(genForm.txtCharDashDuration.Text);
            resultBytesList.AddRange(BitConverter.GetBytes(Convert.ToSingle(genForm.txtCharDashSpeed.Text)));
            CharGenPrm[charID].DashSpeed = Convert.ToSingle(genForm.txtCharDashSpeed.Text);
            resultBytesList.AddRange(BitConverter.GetBytes(Convert.ToSingle(genForm.txtCharDashDistance.Text)));
            CharGenPrm[charID].DashDistance = Convert.ToSingle(genForm.txtCharDashDistance.Text);
            resultBytesList.AddRange(BitConverter.GetBytes(Convert.ToSingle(genForm.txtCharBackDashHeight.Text)));
            CharGenPrm[charID].BackDashHeight = Convert.ToSingle(genForm.txtCharBackDashHeight.Text);
            resultBytesList.AddRange(BitConverter.GetBytes(Convert.ToSingle(genForm.txtCharBackDashWeight.Text)));
            CharGenPrm[charID].BackDashWeight = Convert.ToSingle(genForm.txtCharBackDashWeight.Text);
            resultBytesList.AddRange(BitConverter.GetBytes(Convert.ToSingle(genForm.txtCharBackDashDistance.Text)));
            CharGenPrm[charID].BackDashDistance = Convert.ToSingle(genForm.txtCharBackDashDistance.Text);
            resultBytesList.AddRange(BitConverter.GetBytes(Convert.ToSingle(genForm.txtCharBackDashHeight2.Text)));
            CharGenPrm[charID].BackDashHeight2 = Convert.ToSingle(genForm.txtCharBackDashHeight2.Text);
            resultBytesList.AddRange(CharGen.CharGenPrm[charID].Unk3);
            resultBytesList.AddRange(CharGen.CharGenPrm[charID].Unk4);
            resultBytesList.AddRange(CharGen.CharGenPrm[charID].Unk5);
            resultBytesList.AddRange(CharGen.CharGenPrm[charID].Unk6);
            resultBytesList.AddRange(BitConverter.GetBytes(Convert.ToSingle(genForm.txtCharStrength.Text)));
            CharGenPrm[charID].Strength = Convert.ToSingle(genForm.txtCharStrength.Text);
            resultBytesList.AddRange(BitConverter.GetBytes(Convert.ToSingle(genForm.txtCharDefense.Text)));
            CharGenPrm[charID].Defense = Convert.ToSingle(genForm.txtCharDefense.Text);
            resultBytesList.AddRange(BitConverter.GetBytes(Convert.ToSingle(genForm.txtCharDamageKnockback.Text)));
            CharGenPrm[charID].DamageKnockback = Convert.ToSingle(genForm.txtCharDamageKnockback.Text);
            resultBytesList.AddRange(BitConverter.GetBytes(Convert.ToSingle(genForm.txtCharAttackKnockback.Text)));
            CharGenPrm[charID].AttackKnockback = Convert.ToSingle(genForm.txtCharAttackKnockback.Text);
            resultBytesList.AddRange(BitConverter.GetBytes(Convert.ToSingle(genForm.txtCharStatus.Text)));
            CharGenPrm[charID].StatusDuration = Convert.ToSingle(genForm.txtCharStatus.Text);
            resultBytesList.AddRange(BitConverter.GetBytes(Convert.ToSingle(genForm.txtCharQuantityProjectiles.Text)));
            CharGenPrm[charID].QuantityProjectiles = Convert.ToSingle(genForm.txtCharQuantityProjectiles.Text);
            resultBytesList.AddRange(BitConverter.GetBytes(Convert.ToSingle(genForm.txtCharHealingMultiplier.Text)));
            CharGenPrm[charID].HealingMultiplier = Convert.ToSingle(genForm.txtCharHealingMultiplier.Text);
            resultBytesList.AddRange(BitConverter.GetBytes(Convert.ToSingle(genForm.txtCharChakraRecoverySpeed.Text)));
            CharGenPrm[charID].ChakraSpeed = Convert.ToSingle(genForm.txtCharChakraRecoverySpeed.Text);

            byte [] resultBytes = resultBytesList.ToArray();
            return resultBytes;
        }
        public static void SendTextToGenForm(GeneralParameters genForm, int charID)
        {
            genForm.txtCharHeight.Text = ($"{CharGenPrm[charID].Height}");
            genForm.txtCharWidth.Text = ($"{CharGenPrm[charID].Width}");
            genForm.txtCharSpeed.Text = ($"{CharGenPrm[charID].Speed}");
            genForm.txtCharSlide.Text = ($"{CharGenPrm[charID].Slide}");
            genForm.txtCharWeight.Text = ($"{CharGenPrm[charID].Weight}");
            genForm.txtCharGravity.Text = ($"{CharGenPrm[charID].Gravity}");
            genForm.txtCharSpeedAir.Text = ($"{CharGenPrm[charID].SpeedAir}");
            genForm.txtCharFirstJumpDelay.Text = ($"{CharGenPrm[charID].FirstJumpDelay}");
            genForm.txtCharFirstJumpHeight.Text = ($"{CharGenPrm[charID].FirstJumpHeight}");
            genForm.txtCharSecondJumpHeight.Text = ($"{CharGenPrm[charID].SecondJumpHeight}");
            genForm.txtCharDashDelay.Text = ($"{CharGenPrm[charID].DashDelay}");
            genForm.txtCharDashDuration.Text = ($"{CharGenPrm[charID].DashDuration}");
            genForm.txtCharDashSpeed.Text = ($"{CharGenPrm[charID].DashSpeed}"); ;
            genForm.txtCharDashDistance.Text = ($"{CharGenPrm[charID].DashDistance}");
            genForm.txtCharBackDashHeight.Text = ($"{CharGenPrm[charID].BackDashHeight}");
            genForm.txtCharBackDashWeight.Text = ($"{CharGenPrm[charID].BackDashWeight}");
            genForm.txtCharBackDashDistance.Text = ($"{CharGenPrm[charID].BackDashDistance}");
            genForm.txtCharBackDashHeight2.Text = ($"{CharGenPrm[charID].BackDashHeight2}");
            genForm.txtCharStrength.Text = ($"{CharGenPrm[charID].Strength}");
            genForm.txtCharDefense.Text = ($"{CharGenPrm[charID].Defense}");
            genForm.txtCharDamageKnockback.Text = ($"{CharGenPrm[charID].DamageKnockback}");
            genForm.txtCharAttackKnockback.Text = ($"{CharGenPrm[charID].AttackKnockback}");
            genForm.txtCharStatus.Text = ($"{CharGenPrm[charID].StatusDuration}");
            genForm.txtCharQuantityProjectiles.Text = ($"{CharGenPrm[charID].QuantityProjectiles}");
            genForm.txtCharHealingMultiplier.Text = ($"{CharGenPrm[charID].HealingMultiplier}");
            genForm.txtCharChakraRecoverySpeed.Text = ($"{CharGenPrm[charID].ChakraSpeed}");
            genForm.grpGeneralConfig.Visible = true;
            genForm.grpMovementConfig.Visible = true;
            genForm.grpMovementAirConfig.Visible = true;
        }
    }
}