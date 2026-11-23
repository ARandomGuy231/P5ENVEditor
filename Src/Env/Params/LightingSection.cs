using Amicitia.IO.Binary;

namespace P5ENVEditor.Env.Params
{
    public struct LightingSection
    {
        public byte enableGraphicalOutput;
        public byte enableToneMap;
        public byte enableStarGlare;
        public byte enableAdaptedLumAuto;
        public float middleGray; //0-10 bloom threshold is more accurate, called medium brightness in beta, two decimal places.
        public float bloomScale; //bloom strength 0-4, two decimal places.
        public float adaptedLum; //star stength 0-4, two decimal places.
        public float elapsedTime; //0-1, after bloomScale in the beta, but it's called adaptive brightness, lower value means stronger bloom, two decimal places.
        public float starGlareScale; //no idea if this is correct, can't find it in the beta editor

        public float starGlareLength; //0.10-2, two decimal places.
        public float starGlareChromaticAberration; //0-5, two decimal places.
        public float starGlareSI; //glare rotation/tilt 0-360, two decimal places.
        public uint starGlareLines; //2, 3 or 4.

        //Royal Params
        public byte field1CC;
        public byte field1CD;
        public byte field1CE;
        public byte field1CF;
        public uint field1D0;
        public float bloomAmount;
        public float bloomDetail;
        public float bloomWhiteLevel;
        public float bloomDarkLevel;
        public float glareSensitivity; //renamed starGlareScale?
        public float sceneWhiteLevels;
        public float sceneDarkLevels;
        public float field1F0;
        public float field1F4;
        public float field1F8;
        public uint field1FC;
        public float field200;
        public float field204;
        public uint field208;
        public uint field20C;
        public float field210;
        public float field214;
        public float redColorBoost;
        public float greenColorBoost;
        public float blueColorBoost;
        public float field224;
        public float field228;
        public float field22C;
        public float field230;
        public float field234;
        public float field238;
        public float field23C;

        /*0x1105090 only (only here in case I decide to add support later on)
        public uint field1CD_uint;
        public ushort field1D1;
        public float field1E7;
        public float field1EB;
        public float field1EF;
        public float field1F3;
        public float field1F7;
        public uint field1FB;
        public uint field1FF;
        public uint field203;
        public float field207;
        public float field20B;
        public float field20F;
        public float field213;
        public float field217;
        public float field21B;
        public float field21F;
        public float field223;
        public float field227;
        public float field22B;
        public float field22F;
        public float field233;*/

        public LightingSection(BinaryObjectReader reader)
        {
            enableGraphicalOutput = reader.ReadByte();
            enableToneMap = reader.ReadByte();
            enableStarGlare = reader.ReadByte();

            if (EnvFunctions.envVersionCheck >= 0x1105100)
            {
                field1CC = reader.ReadByte();
                field1CD = reader.ReadByte();
                field1CE = reader.ReadByte();
                field1CF = reader.ReadByte();
                field1D0 = reader.ReadUInt32();
                bloomAmount = reader.ReadSingle();
                bloomDetail = reader.ReadSingle();
                bloomWhiteLevel = reader.ReadSingle();
                bloomDarkLevel = reader.ReadSingle();
                glareSensitivity = reader.ReadSingle();
                sceneWhiteLevels = reader.ReadSingle();
                sceneDarkLevels = reader.ReadSingle();
                field1F0 = reader.ReadSingle();
                field1F4 = reader.ReadSingle();
                field1F8 = reader.ReadSingle();
                field1FC = reader.ReadUInt32();
                field200 = reader.ReadSingle();
                field204 = reader.ReadSingle();
                field208 = reader.ReadUInt32();
                field20C = reader.ReadUInt32();
                field210 = reader.ReadSingle();
                field214 = reader.ReadSingle();
                redColorBoost = reader.ReadSingle();
                greenColorBoost = reader.ReadSingle();
                blueColorBoost = reader.ReadSingle();
                field224 = reader.ReadSingle();
                field228 = reader.ReadSingle();
                field22C = reader.ReadSingle();
                field230 = reader.ReadSingle();
                field234 = reader.ReadSingle();
                field238 = reader.ReadSingle();
                field23C = reader.ReadSingle();
            }
            else
            {
                enableAdaptedLumAuto = reader.ReadByte();
                middleGray = reader.ReadSingle();
                bloomScale = reader.ReadSingle();
                adaptedLum = reader.ReadSingle();
                elapsedTime = reader.ReadSingle();
                starGlareScale = reader.ReadSingle();
            }

            starGlareLength = reader.ReadSingle();
            starGlareChromaticAberration = reader.ReadSingle();
            starGlareSI = reader.ReadSingle();
            starGlareLines = reader.ReadUInt32();
        }

        public void Write(BinaryObjectWriter writer)
        {
            writer.WriteByte(enableGraphicalOutput);
            writer.WriteByte(enableToneMap);
            writer.WriteByte(enableStarGlare);

            if (EnvFunctions.loadedENVHeader.gfsVersion >= 0x1105100)
            {
                writer.WriteByte(field1CC);
                writer.WriteByte(field1CD);
                writer.WriteByte(field1CE);
                writer.WriteByte(field1CF);
                writer.WriteUInt32(field1D0);
                writer.WriteSingle(bloomAmount);
                writer.WriteSingle(bloomDetail);
                writer.WriteSingle(bloomWhiteLevel);
                writer.WriteSingle(bloomDarkLevel);
                writer.WriteSingle(glareSensitivity);
                writer.WriteSingle(sceneWhiteLevels);
                writer.WriteSingle(sceneDarkLevels);
                writer.WriteSingle(field1F0);
                writer.WriteSingle(field1F4);
                writer.WriteSingle(field1F8);
                writer.WriteUInt32(field1FC);
                writer.WriteSingle(field200);
                writer.WriteSingle(field204);
                writer.WriteUInt32(field208);
                writer.WriteUInt32(field20C);
                writer.WriteSingle(field210);
                writer.WriteSingle(field214);
                writer.WriteSingle(redColorBoost);
                writer.WriteSingle(greenColorBoost);
                writer.WriteSingle(blueColorBoost);
                writer.WriteSingle(field224);
                writer.WriteSingle(field228);
                writer.WriteSingle(field22C);
                writer.WriteSingle(field230);
                writer.WriteSingle(field234);
                writer.WriteSingle(field238);
                writer.WriteSingle(field23C);
            }
            else
            {
                writer.WriteByte(enableAdaptedLumAuto);
                writer.WriteSingle(middleGray);
                writer.WriteSingle(bloomScale);
                writer.WriteSingle(adaptedLum);
                writer.WriteSingle(elapsedTime);
                writer.WriteSingle(starGlareScale);
            }

            writer.WriteSingle(starGlareLength);
            writer.WriteSingle(starGlareChromaticAberration);
            writer.WriteSingle(starGlareSI);
            writer.WriteUInt32(starGlareLines);
        }
    }
}
