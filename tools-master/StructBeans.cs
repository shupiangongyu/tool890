using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Tools
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct Poke_basestats
    {
        public byte base_hp;
        public byte base_atk;
        public byte base_def;
        public byte base_spd;
        public byte base_spatk;
        public byte base_spdef;
        public byte type1;
        public byte type2;
        public byte catch_rate;

        public byte exp_yield;

        /*
        short evs_hp : 2;
        short evs_atk : 2;
        short evs_def : 2;
        short evs_spd : 2;
        short evs_spatk : 2;
        short evs_spdef : 2;
        short unused : 4;
        */
        public ushort evs;
        public ushort item1;
        public ushort item2;
        public byte gender_ratio;
        public byte hatching;
        public byte friendship;
        public byte exp_curve;
        public byte egg_group1;
        public byte egg_group2;
        public byte ability1;
        public byte ability2;
        public byte safari_flee_rate;
        public byte dex_colour;
        public byte pad1;
        public byte pad2;
    };

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct Wild_Poke
    {
        public byte minLvl;
        public byte maxLvl;
        public ushort spieces;
    }

    public class IniName : Attribute
    {
        public string Name { private set; get; }

        public IniName(string name)
        {
            Name = name;
        }
    }

    public class INI_init
    {
        [IniName("起始空位")] public int start_offset;
        [IniName("特性名")] public int abilities;
        [IniName("特性总量")] public int ablitynum;
        [IniName("精灵总量")] public int pokenum;
        [IniName("基础值")] public int pokebasestats;
        [IniName("精灵名字")] public int pokenames;
        [IniName("道具")] public int items;
        [IniName("道具总量")] public int itemnum;
        [IniName("道具图片")] public int itemimages;
        [IniName("TM学习面")] public int tmhmcompabilities;
        [IniName("TM总量")] public int tmhmnum;
        [IniName("TOUTOR总量")] public int toutornum;

        [IniName("TOUTOR总量")] public int toutorsize;
        [IniName("TM总量")] public int tmhmsize;
        [IniName("TMLIST")] public int tmhmlist;
        [IniName("TOUTOR学习面")] public int toutorcompabilities;
        [IniName("TOUTORLIST")] public int toutorlist;
        [IniName("技能总量")] public int movenum;
        [IniName("技能名")] public int moves;
        [IniName("正面图")] public int frontspritetable;
        [IniName("背面图")] public int backspritetable;
        [IniName("普通色板")] public int frontpalettetable;
        [IniName("闪光色板")] public int shinypalettetable;
        [IniName("升级技能")] public int learnset;
        [IniName("技能描述")] public int movedesc;
        [IniName("技能表")] public int moveinfo;
        [IniName("训练师图片")] public int trainerimg;
        [IniName("训练师调色板")] public int trainerpal;
        [IniName("图片数量")] public int trainernum;
        [IniName("训练师数量")] public int trainertatal;
        [IniName("训练师地址")] public int traineroffset;
        [IniName("全国图鉴")] public int national_dex;
        [IniName("图标色板标号")] public int icoinindextable;
        [IniName("图标色板")] public int icoinpallete;
        [IniName("图标")] public int icointable;


        public void Settmhmnum(int tmhmnum)
        {
            this.tmhmnum = GetSize(tmhmnum);
        }

        public void Settoutornum(int toutornum)
        {
            this.toutornum = GetSize(toutornum);
        }

        private static byte GetSize(int total)
        {
            byte size = 4;
            if (total > 32 && total <= 64)
                size = 8;
            else if (total <= 96)
                size = 12;
            else if (total <= 128)
                size = 16;
            return size;
        }

        public override string ToString()
        {
            return
                $"{nameof(start_offset)}= {start_offset}, {nameof(abilities)}= {abilities}, {nameof(ablitynum)}= {ablitynum}, {nameof(pokenum)}= {pokenum}, {nameof(pokebasestats)}= {pokebasestats}, {nameof(pokenames)}= {pokenames}, {nameof(items)}= {items}, {nameof(itemnum)}= {itemnum}, {nameof(itemimages)}= {itemimages}, {nameof(tmhmcompabilities)}= {tmhmcompabilities}, {nameof(tmhmnum)}= {tmhmnum}, {nameof(toutornum)}= {toutornum}, {nameof(toutorsize)}= {toutorsize}, {nameof(tmhmsize)}= {tmhmsize}, {nameof(tmhmlist)}= {tmhmlist}, {nameof(toutorcompabilities)}= {toutorcompabilities}, {nameof(toutorlist)}= {toutorlist}, {nameof(movenum)}= {movenum}, {nameof(moves)}= {moves}, {nameof(frontspritetable)}= {frontspritetable}, {nameof(backspritetable)}= {backspritetable}, {nameof(frontpalettetable)}= {frontpalettetable}, {nameof(shinypalettetable)}= {shinypalettetable}, {nameof(learnset)}= {learnset}, {nameof(movedesc)}= {movedesc}, {nameof(moveinfo)}= {moveinfo}, {nameof(trainerimg)}= {trainerimg}, {nameof(trainerpal)}= {trainerpal}, {nameof(trainernum)}= {trainernum}, {nameof(trainertatal)}= {trainertatal}, {nameof(traineroffset)}= {traineroffset}, {nameof(national_dex)}= {national_dex}, {nameof(icoinindextable)}= {icoinindextable}, {nameof(icoinpallete)}= {icoinpallete}, {nameof(icointable)}= {icointable}";
        }

        public static INI_init DefaultValue()
        {
            return new INI_init
            {
                start_offset = 19202048, 
                abilities = 1372372, 
                ablitynum = 78, 
                pokenum = 412, 
                pokebasestats = 444,
                pokenames = 324, 
                items = 881808, 
                itemnum = 377, 
                itemimages = 1769524, 
                tmhmcompabilities = 450736,
                tmhmnum = 58, 
                toutornum = 30, 
                toutorsize = 12, 
                tmhmsize = 8, 
                tmhmlist = 1797392,
                toutorcompabilities = 1778576, 
                toutorlist = 1289988, 
                movenum = 355, 
                moves = 328,
                frontspritetable = 214540, 
                backspritetable = 214716, 
                frontpalettetable = 452440,
                shinypalettetable = 452496, 
                learnset = 431008, 
                movedesc = 1851132, 
                moveinfo = 460, 
                trainerimg = 384888,
                trainerpal = 374660, 
                trainernum = 92, 
                trainertatal = 855, 
                traineroffset = 399816, 
                national_dex = 447676,
                icoinindextable = 836324, 
                icoinpallete = 14541304, 
                icointable = 864328
            };
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct Item
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 14)]
        public byte[] name;

        public ushort index;
        public ushort price;
        public byte held_effect;
        public byte held_effect_quality;
        public uint desc_pointer;
        public ushort mystery_value;
        public byte pocket_no;
        public byte type_of_item;
        public uint field_usage_code;
        public uint battle_usage;
        public uint battle_usage_code;
        public uint extra_param;
    };

    public struct Move_Info
    {
        public byte script_id;
        public byte base_power;
        public byte type;
        public byte accuracy;
        public byte pp;
        public byte effect_chance;
        public byte target;
        public sbyte priority;
        public byte move_flags;
        public byte arg1;
        public byte split;
        public byte arg2;
    };

    public struct Battle_Frontier
    {
        public short poke;
        public short move1;
        public short move2;
        public short move3;
        public short move4;
        public byte item;
        public byte ev;
        public byte nature;
        public byte pad1;
        public short pad2;
    }

    //trainer_classname 0x30FCD4
    //奖金的指针在 0x4E6A8
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct Trainer_Data
    {
        //u8 custom_moves : 1;
        //u8 custom_item : 1;
        public byte moves_item; //1:1

        public byte trainer_class;

        //u8 music : 7;
        //u8 gender : 1;
        public byte music_gender; //7:1
        public byte sprite;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public byte[] name;

        public byte field_E;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public short[] items;

        public byte double_battle;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] padd1;

        public int ai_scripts; //32位
        public byte poke_number;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] padd2;

        public int poke_data;
    };

    public struct TrainerPokeData
    {
        public byte evs_id;
        public byte filler;
        public byte level;
        public byte filler2;
        public short poke_id;
        public short item_id;
    };

    public struct Dex_Info
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
        public byte[] name;

        public ushort height;
        public ushort weight;
        public int text_pointer;
        public short filler1;
        public short poke_scale;
        public short poke_pos;
        public short role_scale;
        public short role_pos;
        public short filler2;
    }


    public struct npc_type
    {
        public short tiles_tag;
        public short pal_tag;
        public short pal_tag2;
        public short field_6;
        public short width;
        public short height;
        public byte field_C;
        public byte field_D;
        public byte field_E;
        public byte field_F;
        public int oam;
        public int formation;
        public int image_anims;
        public int gfx_table; //(size = x*y/2, pointer)
        public int rotscale_anims;
    }

    public struct Evo
    {
        public byte method;
        public byte padd0;
        public ushort parameter;
        public short poke;
        public short padd1;
    }

    public class EvoMethods
    {
        public int method;
        public string desc;

        public int Method
        {
            get { return method; }
        }

        public string Desc
        {
            get { return desc; }
        }
    }

    public struct mapheader
    {
        public int map_footer;
        public int events; //2026698
        public int scripts;
        public int connections;
        public short music_id;
        public short footer_id;
        public byte name; //0x5a1480
        public byte light;
        public byte weather;
        public byte maptype;
        public byte field_18;
        public byte can_dig;
        public byte show_name;
        public byte battletype;
    };


    struct blockset
    {
        public byte compressed;
        public byte pal_mode_flag;
        public byte field2;
        public byte field3;
        public int tileset;
        public int pals;
        public int blockset_data; //每个2字节，一共8个16字节，后0x3ff blockid，前12位调色板id
        public int bg_bytes;
        public int anim_routine;
    };


    public struct footer
    {
        public int width_blocks;
        public int height_blocks;
        public int border_data;
        public int blocksID_movement; //后10位blockid 前6位行为字节
        public int primary_blockset;
        public int secondary_blockset;
    };

    public struct events
    {
        public byte npc_num;
        public byte entry_num;
        public byte script_num;
        public byte sign_num;
        public int rom_npc; //人物
        public int entry_scripts; //出入口
        public int script_scripts; //脚本
        public int sign_scripts; //标志
    }

    public struct entry_scripts
    {
    }

    public struct script_scripts
    {
    }

    public struct sign_scripts
    {
    }

    public struct rom_npc
    {
        public byte localID; //0
        public byte spriteID; //1
        public short field2; //2
        public short x_pos; //4
        public short y_pos; //6
        public byte height; //8
        public byte behaviour; //9
        public short behaviour_property; // xA
        public byte is_trainer; //xC
        public byte fieldD; //xD
        public short radius_plantID; //xE
        public int script; //x10
        public short flag; //x14
        public short field16; //x16
    }

    /// <summary>
    /// 用于结构体和字节数组的互换
    /// </summary>
    public static unsafe class StructsUtil
    {
        /// <summary>
        /// 字节数组转结构体
        /// </summary>
        /// <param name="bytes">字节数组</param>
        /// <param name="type">所需要转换的结构体的类型</param>
        /// <returns>object</returns>
        public static object ByteToStruct(byte[] bytes, Type type)
        {
            int size = Marshal.SizeOf(type);
            if (size > bytes.Length)
            {
                return null;
            }

            fixed (byte* b = bytes)
            {
                return Marshal.PtrToStructure(new IntPtr(b), type);
            }
        }

        /// <summary>
        /// 结构体转字节数组
        /// </summary>
        /// <param name="structure">需要转换的结构体</param>
        /// <returns>字节数组</returns>
        public static byte[] StructToByte(ValueType structure)
        {
            int size = Marshal.SizeOf(structure);
            byte[] bytes = new byte[size];
            fixed (byte* b = bytes)
            {
                IntPtr ptr = new IntPtr(b);
                Marshal.StructureToPtr(structure, ptr, false);
                return bytes;
            }
        }
    }
}