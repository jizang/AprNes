﻿namespace AprNes
{
    unsafe public partial class NesCore
    {
        //Color Dreams https://wiki.nesdev.com/w/index.php/Color_Dreams ok 
        static void mapper011write_ROM(ushort address, byte value)
        {
            PRG_Bankselect = value & 3; //Select 32 KB PRG ROM bank for CPU $8000-$FFFF
            CHR_Bankselect = (value & 0xf0) >> 4;//Select 8 KB CHR ROM bank for PPU $0000-$1FFF
        }

        static byte mapper011read_RPG(ushort address)
        {
            return PRG_ROM[(address - 0x8000) + (PRG_Bankselect << 15)];
        }

        static byte mapper011read_CHR(int address)
        {
            return CHR_ROM[address + (CHR_Bankselect << 13)];
        }
    }
}
